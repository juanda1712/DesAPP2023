using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unidad_1
{
    public partial class Form1 : Form
    {
        string Direccion;
    

        public Form1()
        {
            InitializeComponent();


            // Declaraciones de variable
            int numero = 10;
            int codigo = 3652526; 
            int num1, num2, num3;
            long lg;
            double dec;
            decimal dec2;

            string nombre = "Juan David ";
            string apellido;
            string edad = "30";
            bool bl1 = true;
            DateTime fecha;


            /// VAriable implicita 
            /// 
            var objeto = "carro" ;
            objeto = "moto";
            ////
            ///

            Direccion = "cr 12 n 10-35";
            num1 = 2;



            ///conversiones 
            ///

            lg = num1 ;
            num1 = int.Parse(edad);
            edad = num1.ToString();

            num1 = Convert.ToInt32(edad);
            dec = Convert.ToDouble(edad);
            dec2 = Convert.ToDecimal(edad);
            //bl1 = Convert.ToBoolean(edad);
            edad = bl1.ToString();



            // funciones del string 

            //cant de caractres
            var cant_caracteres = nombre.Length;

            // sub string  p1 = inicia (0) , p2 = donde finalizo (3) = 
            var primeros_caracteres = nombre.Substring(0, 3);

            // quita los caracteres en blanco 
            var nombre_sin_espacios = nombre.Trim();

            // concatenar  

            var nombre_dir = string.Concat(nombre, " ", Direccion);

            var nombre_dir_2 = string.Format(" el nombre es: {0} y la direccion es {1} ", nombre, Direccion);

            /// Operadores
            /// 

            num1 = num1 + 1;
            num1++;
            --num1;
            num1 += 20;




        }

        /// <summary>
        /// /metodo sin retorno  --> VOID
        /// </summary>
        private void mostrarMsj(string texto)
        {
            MessageBox.Show(string.Concat("Hola mundo   ", texto));

        }


        /// <summary>
        /// paramatros opcionales
        /// </summary>
        /// <param name="cc"></param>
        /// <param name="tel"></param>
        /// <param name="PT"></param>
        /// <returns></returns>
        private string consultar_nombre(int cc, int tel = 0, string PT = "" )
        {
            string nombre = "Juan";                    
            
            /// condicionales 
            /// Operadores -> ==, dif-> != , AND -> &&  OR -> ||  
            /// 
            if(cc == 1093 && tel == 123 )
            {
                nombre = "Carlos";
            }
            else if(cc == 1093 || tel == 0)
            {
                nombre = "Lina";
            }
          
            else 
            {
                nombre = "David";
            
            }

            return nombre;
        }


        /// <summary>
        /// swiche
        /// </summary>
        /// <param name="num_dia"></param>
        /// <returns></returns>
        private string consultar_dia_texto(int num_dia)
        {
            string dia= "";
            switch(num_dia)
            {
                case 1:
                    dia = "Lunes";
                    break;
                case 2:
                    dia = "Martes";
                    break;
                case 3:
                    dia = "Miercoles";
                    break;
                case 4:
                    dia = "Jueves";
                    break;

                    default:
                    dia = "No aplica";
                    break;
            }
            
            return dia;                
        }

        private int suma(int num1 , int  num2)
        {
            return num1+ num2;
        }


        /// <summary>
        /// Cliclos -->  While , Do While , For
        /// </summary>
        private void ciclos()
        {

            int a = 20;
            while (a >= 10)
            {
                a --;
            }

            do
            {
                a--;
                MessageBox.Show("");
            }
            while (a >=10);



            // For

            for(int b = 0; b<= 30; b++)
            {
                MessageBox.Show("");
                /// Código

            }



        }

        /// <summary>
        /// Vectores y matrices
        /// </summary>
        private void Arrays()
        {
            int[] vectResult;

            vectResult = new int[10]; // cant posiciones 

            vectResult = new int[5] { 1,2,3,4,5}; // set values  for default

            Array.Resize<int>(ref vectResult, 10);  // aumenta el tamaño del array

            vectResult[0] = 1;
            vectResult[1] = 2;
            vectResult[2] = 3;

            int[,] mtResulta;
            mtResulta = new int[3, 3];
            mtResulta = new int[2, 2] { { 1, 3 }, { 4, 5 } };

        }



        private void Listas()
        {
            List<string> meses = new List<string>() { "diciembre", "noviembre"};  /// default

            meses.Add("enero");  // agg items 
            meses.Add("febrero");
            meses.Add("marzo");
            meses.Add("abril");


            string mes = meses[0];

            meses.Remove("enero");  // remove por detalle
            meses.RemoveAt(1);  // remove por indece


            for (int i = 0; i< meses.Count; i++)
            {
                MessageBox.Show(meses[i]);
            }

            foreach( string item  in meses )
            {
                MessageBox.Show(item);
            }





        }

        /// <summary>
        /// dicc tiene key y value 
        /// </summary>
        private void Diccionarios()
        {

            Dictionary<int, string> Students = new Dictionary<int, string>();

            Students.Add(1, "Juan"); // Insert 
            Students.Add(2, "Pablo");
            Students[1] = "Pedro";  /// Update
            Students.Remove(1);   /// Delete
            Students.Clear(); // Clean
                              
            foreach( var item in Students)
            {
                MessageBox.Show(item.Value);
                MessageBox.Show(item.Key.ToString());
            }





        }



        private void Datatable_example ()
        {


            DataTable dt = new DataTable();  // declaro
            dt.Columns.Add("Id", typeof(string)); // Agg Columnas
            dt.Columns.Add("Detaller", typeof(string));
            dt.Columns.Add("Valor", typeof(double));

            dt.Rows.Add( new object[] { "1","Bolsa" , 50 } );  // Agg Rows 
            dt.Rows.Add(new object[] { "2", "Caja" ,200 });


            DataRow item_dt = dt.NewRow();
            item_dt["Id"] = "3";
            item_dt["Detaller"] = "Cartera";
            item_dt["Valor"] = 50000;
            dt.Rows.Add(item_dt);


            string detalle;


            foreach ( DataRow dr in dt.Rows)
            {

                detalle = dr["Detalle"].ToString(); 
            }

            detalle = dt.Rows[1]["Detalle"].ToString();
            
            dt.Rows[1]["Detalle"] = "Carton";





        }




        public void split_sxample()
        {
            string nombre = txtCC.Text;
            char[] tipo = { ',', '-' };
            string[] array_nombres = nombre.Split(tipo);





        }







        /// <summary>
        /// overloding  / Sobrecarga 
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        private double suma(double num1, double num2)
        {
            return num1 + num2;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int cc = 0;

            split_sxample();


            clsPersona objPersonas = new clsPersona();  // instancia de la clase

           

            if (txtCC.Text != "")
            {

                try
                {

                    cc = Convert.ToInt16(txtCC.Text);
                    
                    if(cc == 10 )
                    {
                        throw new FormatException();
                    }
                    //var con_nombre = consultar_nombre(cc, 123); // llamado de una funcion 

                    //// llamado de un metodo
                    //mostrarMsj(con_nombre);

                    string dia = consultar_dia_texto(cc);
                    mostrarMsj(dia);
                }
                catch(OverflowException)
                {
                    MessageBox.Show("Ingrese un numero menor a 1000");
                }
                catch(FormatException fx)
                {
                    MessageBox.Show("Por favor ingrese un valor numerico " + fx.Message);

                }
                catch( Exception ex) 
                {
                    MessageBox.Show("Error al realizar la operación");                
                } 

                finally  // siempre se ejecutan 
                {
                    MessageBox.Show("finally");
                }
            }
           
          

        }
    }
}

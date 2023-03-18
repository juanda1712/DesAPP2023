using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Unidad_1
{
    internal class clsPersona: IFMasterPersona
    {

       public int Id ;
       private string nombre;

        public int cc { get; set; }

        private int _salario = 2000000;

        public int Salario
        {
            get { return _salario; }
            set
            {
                if (_salario < 1000000)
                    throw new ArgumentOutOfRangeException();
                else
                {
                    _salario = value;
                }
            }
        }


        public clsPersona()
        {
            Id = 0;
        }
        public clsPersona(int _id)
        {
            Id = _id;
        }


        public string consultar_nombre()
        {
            return nombre;
        }
        public virtual int Insertar_Persona( string nombre , int cc, string cell )
        {

            Random rd = new Random();
            return rd.Next(0, 100);
       
        }

        public void CrearPersona()
        {
           


        }

        public void GenerarID()
        {
           
        }

        public void GenerarCodigo()
        {
        }
    }
}

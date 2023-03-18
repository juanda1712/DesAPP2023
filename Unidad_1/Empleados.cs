using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidad_1
{
    internal class Empleados : clsPersona, IFMasterPersona
    {



        private void calcular_nomina()
        {
            Id = 10;
            Salario = 2000000;
        }


        public override int Insertar_Persona(string nombre, int cc, string cell)
        {

            Random rd = new Random();
            return rd.Next(0, 100);

        }

        public void CrearPersona()
        {
            throw new NotImplementedException();
        }

        public void GenerarID()
        {
            throw new NotImplementedException();
        }
    }
}

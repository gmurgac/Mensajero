using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensajeroModel.DTO
{
    public class Mensaje
    {
        private string nombre;
        private string detalle;
        private string tipo;

        public override string ToString()
        {
            //return ""+this.nombre+";"+this.detalle+";"+this.tipo;
            return Nombre + ";" + Detalle + ";" + Tipo;
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Detalle
        {
            get
            {
                return detalle;
            }

            set
            {
                detalle = value;
            }
        }

        public string Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }
    }
}

using MensajeroModel.DAL;
using MensajeroModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensajeroApp
{
   public class Program
    {
        static IMensajesDAL dal = MensajesDALFactory.CreateDAL();
        public static void Main(string[] args)
        {
            Mensaje m = new Mensaje()
            {
                Nombre = "Brocacochi",
                Detalle = "asda",
                Tipo = "asdasd"
            };
            dal.Save(m);
        }
    }
}

using MensajeroModel.DAL;
using MensajeroModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensajeroApp
{
    public partial class Program
    {
        static void IngresarMensaje()
        {
            Mensaje mensaje = new Mensaje();
            Console.WriteLine("Ingrese nombre");
            mensaje.Nombre = Console.ReadLine().Trim();
            Console.WriteLine("Ingrese detalle");
            mensaje.Detalle = Console.ReadLine().Trim();
            mensaje.Tipo = "aplicacion";
            lock (dal) { dal.Save(mensaje); }
            
        }

        static void MostrarMensajes()
        {
            List<Mensaje> mensajes = dal.GetAll();
            mensajes.ForEach(m =>
            {
                Console.WriteLine("Nombre:{0} | Detalle: {1} | Tipo: {2}", m.Nombre, m.Detalle, m.Tipo);

            });
        }

        static bool Menu()
        {
            bool continuar = true;
            Console.WriteLine("Seleccione opcion:");
            Console.WriteLine("1. Ingresar Mensaje");
            Console.WriteLine("2. Mostrar Mensajes");
            string opcion = Console.ReadLine().Trim();
            switch (opcion)
            {
                case "1":
                    IngresarMensaje();
                    break;
                case "2":
                    MostrarMensajes();
                    break;
                case "0":
                    continuar = false;
                    break;

            }
            return continuar;
        }

        static IMensajesDAL dal = MensajesDALFactory.CreateDAL();
    }
}

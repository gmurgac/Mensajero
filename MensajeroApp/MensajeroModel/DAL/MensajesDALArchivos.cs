using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MensajeroModel.DTO;
using System.IO;

namespace MensajeroModel.DAL
{
    public class MensajesDALArchivos : IMensajesDAL
    {
        //crear atributo archivo
        private string archivo = Directory.GetCurrentDirectory()
            + Path.DirectorySeparatorChar + "mensajes.txt"; 


        //Patron Singleton
        //1. Constructor privado
        private MensajesDALArchivos()
        {

        }
        //2. Un atributo de tipo estatico privado de la misma instancia
        private static IMensajesDAL instancia;
        //3. Un metodo estatico que permita obtener la unica instancia
        public static IMensajesDAL GetInstance()
        {
            if (instancia == null)
                instancia = new MensajesDALArchivos();
                return instancia;
        }
        public List<Mensaje> GetAll()
        {
            List<Mensaje> lista = new List<Mensaje>();
            try
            {
                using(StreamReader reader = new StreamReader(archivo))
                {
                    string linea = null;
                    do
                    {
                        linea = reader.ReadLine();
                        if(linea != null)
                        {
                            string[] textoArray = linea.Split(';');
                            Mensaje m = new Mensaje()
                            {
                                Nombre = textoArray[0],
                                Detalle = textoArray[1],
                                Tipo = textoArray[2]
                            };
                            lista.Add(m);
                        }

                    } while (linea != null);
                }
            }catch(Exception ex)
            {
                lista = null;
            }
            return lista;
        }

        public void Save(Mensaje m)
        {
            try
            {
                //Instancia que automatiza metodos para cerrar automaticamente
                using (StreamWriter writer = new StreamWriter(archivo, true))
                {
                    writer.WriteLine(m);
                    writer.Flush();
                }
            }catch(Exception ex)
            {

            }
        }
    }
}

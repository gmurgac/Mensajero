using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketsUtils
{
    public class ClienteSocket
    {
        private Socket comCliente;
        private StreamReader reader;
        private StreamWriter writer;

        public ClienteSocket(Socket comCliente)
        {
            this.comCliente = comCliente;
            Stream stream = new NetworkStream(this.comCliente);
            this.writer = new StreamWriter(stream);
            this.reader = new StreamReader(stream);
        }
        //escribir por el socket
        public bool Escribir(string mensaje)
        {
            try
            {
                this.writer.WriteLine(mensaje);
                this.writer.Flush();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //leer por el socket
        public string Leer()
        {
            try
            {
                return this.reader.ReadLine().Trim();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //cerrar conexion
        public void CerrarConexion()
        {
            this.comCliente.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketsUtils
{
    public class ServerSocket
    {
        private int puerto;
        private Socket servidor; //importar system.net.sockets
        
        //constructor que recibe puerto
        public ServerSocket(int puerto)
        {
            this.puerto = puerto;
        }
        //iniciar conexion
        public bool Iniciar()
        {
            try
            {
                //1- Crear el socket
                this.servidor = new Socket(AddressFamily.InterNetwork, SocketType.Stream,ProtocolType.Tcp);
                //2- Tomar control del puerto
                this.servidor.Bind(new IPEndPoint(IPAddress.Any, this.puerto));
                //3- Definir cuantos clientes podre atender "simultaneamente"
                this.servidor.Listen(10);
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }
        //tomar el puerto
        //esperar cliente
        public ClienteSocket ObtenerCliente()        //TODO: Cambiar obtener escribir y leer a un hilo independiente.
        {
            try
            {
                return new ClienteSocket(this.servidor.Accept());
                
                
            }catch(Exception ex)
            {
                return null;
            }
        }
        
    }
}
//TOODO: Una clase library que dependiendo de parametros de constructor construya un servidor o cliente socket
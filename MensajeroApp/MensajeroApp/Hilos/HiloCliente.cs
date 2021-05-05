using MensajeroModel.DAL;
using MensajeroModel.DTO;
using SocketsUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensajeroApp.Hilos
{
    public class HiloCliente
    {
        private ClienteSocket clienteSocket;
        private IMensajesDAL dal = MensajesDALFactory.CreateDAL();
        public HiloCliente(ClienteSocket clienteSocket)
        {
            this.clienteSocket = clienteSocket;
        }

        public void Ejecutar()
        {
            Mensaje mensaje = new Mensaje();
            clienteSocket.Escribir("Ingrese nombre");
            mensaje.Nombre = clienteSocket.Leer().Trim();
            clienteSocket.Escribir("Ingrese detalle");
            mensaje.Detalle = clienteSocket.Leer().Trim();
            mensaje.Tipo = "TCP";
            lock (dal)
            { 
            dal.Save(mensaje);
            }
            clienteSocket.CerrarConexion();
        }
    }
}

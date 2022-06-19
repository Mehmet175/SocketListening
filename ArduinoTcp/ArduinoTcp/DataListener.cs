using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoTcp
{
    // Gelen veri : cihazId&veriId&value1&value2&dateTime
    // c1f8b010-5d9f-4d3f-87c3-480ed3dfe9ea&46e5bf40-5bc7-422d-ba58-9ee7bf200b11&20&30&19.06.2022 14:30
    // Verinin alındığını haber veren cevap : veriId&#ok#

    class DataListener
    {
        // Database Context
        DbContextDataContext context = new DbContextDataContext();

        // Dinleyeceğimiz socket
        private Socket _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        // Gelen verileri dolduracağımız dizi
        private byte[] _buffer = new byte[1024];

        public DataListener()
        {
            SetupServer();
        }

        private void SetupServer()
        {
            Console.WriteLine("Setting up server...");
            // Dinleyecğimiz ip ve port ayarlanıyor.
            _serverSocket.Bind(new IPEndPoint(IPAddress.Any, 1903));
            _serverSocket.Listen(1);
            _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        private void AcceptCallback(IAsyncResult ar)
        {
            try
            {
                Socket socket = _serverSocket.EndAccept(ar);
                Console.WriteLine("Client Connected...");
                socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
                _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
            } catch (Exception ex)
            {
                Console.WriteLine($"AcceptCallback() error : {ex.Message}");
                _serverSocket.Close();
                _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                SetupServer();
            }
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                Socket socket = (Socket)ar.AsyncState;
                int received = socket.EndReceive(ar);
                byte[] dataBuf = new byte[received];
                Array.Copy(_buffer, dataBuf, received);
                Parsed(socket, dataBuf);
            } catch (Exception ex)
            {
                Console.WriteLine($"ReceiveCallback() error : {ex.Message}");
            }
        }

        private void Parsed(Socket socket, byte[] dataBuf)
        {
            string message = Encoding.ASCII.GetString(dataBuf);
            Console.WriteLine(message);

            // Gelen veri : cihazId & veriId & value1 & value2 & dateTime
            var messageParsed = message.Split('&').ToList();
            DataLog dataLog = new DataLog() 
            {
                Value1 = messageParsed[0],
                Value2 = messageParsed[1],
                Value3 = messageParsed[2],
                Value4 = messageParsed[3],
                Value5 = messageParsed[4],
            };
            context.DataLogs.InsertOnSubmit(dataLog);
            context.SubmitChanges();

            SendOk(socket, messageParsed[1]);
            socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
        }

        private void SendOk(Socket socket, string dataId)
        {
            // Verinin alındığını haber veren cevap : veriId&#ok#
            byte[] data = Encoding.ASCII.GetBytes($"{dataId}&#OK#");
            socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                Socket socket = (Socket)ar.AsyncState;
                socket.EndSend(ar);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"SendCallback() error : {ex.Message}");
            }
        }
    }
}

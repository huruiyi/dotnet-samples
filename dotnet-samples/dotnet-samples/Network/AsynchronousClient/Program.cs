using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace AsynchronousClient
{
    public class StateObject
    {
        // Client socket.
        public Socket WorkSocket;

        // Size of receive buffer.
        public const int BufferSize = 256;

        // Receive buffer.
        public byte[] Buffer = new byte[BufferSize];

        // Received data string.
        public StringBuilder Sb = new StringBuilder();
    }

    internal class Program
    {
        private const int Port = 11000;

        // ManualResetEvent instances signal completion.
        private static readonly ManualResetEvent ConnectDone = new ManualResetEvent(false);

        private static readonly ManualResetEvent SendDone = new ManualResetEvent(false);

        private static readonly ManualResetEvent ReceiveDone = new ManualResetEvent(false);

        private static string _response = string.Empty;

        private static void StartClient()
        {
            // Establish the remote endpoint for the socket.
            IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());

            //IPHostEntry ipHostInfo = Dns.Resolve("host.contoso.com");
            //IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEp = new IPEndPoint(hostEntry.AddressList[0], Port);

            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            client.BeginConnect(remoteEp, ConnectCallback, client);
            ConnectDone.WaitOne();

            Send(client, "This is a test<EOF>");
            SendDone.WaitOne();

            Receive(client);
            ReceiveDone.WaitOne();

            Console.WriteLine("Response received : {0}", _response);

            client.Shutdown(SocketShutdown.Both);
            client.Close();
        }

        private static void ConnectCallback(IAsyncResult ar)
        {
            Socket client = (Socket)ar.AsyncState; // Retrieve the socket from the state object.

            client.EndConnect(ar);

            Console.WriteLine("Socket connected to {0}", client.RemoteEndPoint);

            ConnectDone.Set();   // Signal that the connection has been made.
        }

        private static void Receive(Socket client)
        {
            StateObject state = new StateObject
            {
                WorkSocket = client
            };

            client.BeginReceive(state.Buffer, 0, StateObject.BufferSize, 0, ReceiveCallback, state);
        }

        private static void ReceiveCallback(IAsyncResult ar)
        {
            // Retrieve the state object and the client socket
            // from the asynchronous state object.
            StateObject state = (StateObject)ar.AsyncState;
            Socket client = state.WorkSocket;

            int bytesRead = client.EndReceive(ar);

            if (bytesRead > 0)
            {
                // There might be more data, so store the data received so far.
                state.Sb.Append(Encoding.ASCII.GetString(state.Buffer, 0, bytesRead));

                // Get the rest of the data.
                client.BeginReceive(state.Buffer, 0, StateObject.BufferSize, 0, ReceiveCallback, state);
            }
            else
            {
                if (state.Sb.Length > 1)
                {
                    _response = state.Sb.ToString();
                }
                // Signal that all bytes have been received.
                ReceiveDone.Set();
            }
        }

        private static void Send(Socket client, string data)
        {
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            client.BeginSend(byteData, 0, byteData.Length, 0, SendCallback, client);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            // Retrieve the socket from the state object.
            Socket client = (Socket)ar.AsyncState;

            int bytesSent = client.EndSend(ar);
            Console.WriteLine("Sent {0} bytes to server.", bytesSent);

            // Signal that all bytes have been sent.
            SendDone.Set();
        }

        private static void Main()
        {
            StartClient();
            Console.ReadKey();
        }
    }
}
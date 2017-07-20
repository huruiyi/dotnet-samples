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
        public Socket workSocket = null;

        // Size of receive buffer.
        public const int BufferSize = 256;

        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];

        // Received data string.
        public StringBuilder sb = new StringBuilder();
    }

    internal class Program
    {
        private const int port = 11000;

        // ManualResetEvent instances signal completion.
        private static ManualResetEvent connectDone = new ManualResetEvent(false);

        private static ManualResetEvent sendDone = new ManualResetEvent(false);

        private static ManualResetEvent receiveDone = new ManualResetEvent(false);

        private static string response = string.Empty;

        private static void StartClient()
        {
            // Establish the remote endpoint for the socket.
            IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());

            //IPHostEntry ipHostInfo = Dns.Resolve("host.contoso.com");
            //IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEp = new IPEndPoint(hostEntry.AddressList[0], port);

            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            client.BeginConnect(remoteEp, new AsyncCallback(ConnectCallback), client);
            connectDone.WaitOne();

            Send(client, "This is a test<EOF>");
            sendDone.WaitOne();

            Receive(client);
            receiveDone.WaitOne();

            Console.WriteLine("Response received : {0}", response);

            client.Shutdown(SocketShutdown.Both);
            client.Close();
        }

        private static void ConnectCallback(IAsyncResult ar)
        {
            Socket client = (Socket)ar.AsyncState; // Retrieve the socket from the state object.

            client.EndConnect(ar);

            Console.WriteLine("Socket connected to {0}", client.RemoteEndPoint.ToString());

            connectDone.Set();   // Signal that the connection has been made.
        }

        private static void Receive(Socket client)
        {
            StateObject state = new StateObject();
            state.workSocket = client;

            client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
        }

        private static void ReceiveCallback(IAsyncResult ar)
        {
            // Retrieve the state object and the client socket
            // from the asynchronous state object.
            StateObject state = (StateObject)ar.AsyncState;
            Socket client = state.workSocket;

            int bytesRead = client.EndReceive(ar);

            if (bytesRead > 0)
            {
                // There might be more data, so store the data received so far.
                state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));

                // Get the rest of the data.
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
            }
            else
            {
                if (state.sb.Length > 1)
                {
                    response = state.sb.ToString();
                }
                // Signal that all bytes have been received.
                receiveDone.Set();
            }
        }

        private static void Send(Socket client, string data)
        {
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            client.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), client);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            // Retrieve the socket from the state object.
            Socket client = (Socket)ar.AsyncState;

            int bytesSent = client.EndSend(ar);
            Console.WriteLine("Sent {0} bytes to server.", bytesSent);

            // Signal that all bytes have been sent.
            sendDone.Set();
        }

        private static void Main(string[] args)
        {
            StartClient();
            Console.ReadKey();
        }
    }
}
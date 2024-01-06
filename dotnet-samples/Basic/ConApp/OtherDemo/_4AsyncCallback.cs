using System;
using System.Collections;
using System.Collections.Specialized;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ConApp.OtherDemo
{
    internal class _4AsyncCallback
    {
        private static int _requestCounter;
        private static readonly ArrayList HostData = new ArrayList();
        private static readonly StringCollection HostNames = new StringCollection();

        private static void Main04(string[] args)
        {
            IPHostEntry iphostentry = Dns.GetHostEntry("www.google.com");

            System.AsyncCallback callBack = ProcessDnsInformation;
            string host;
            do
            {
                Console.Write(" Enter the name of a host computer or <enter> to finish: ");
                host = Console.ReadLine();
                if (host.Length > 0)
                {
                    Interlocked.Increment(ref _requestCounter);
                    Dns.BeginGetHostEntry(host, callBack, host);
                }
            }

            while (host.Length > 0);
            while (_requestCounter > 0)
            {
                UpdateUserInterface();
            }
            for (int i = 0; i < HostNames.Count; i++)
            {
                object data = HostData[i];
                string message = data as string;
                if (message != null)
                {
                    Console.WriteLine(@"Request for {0} returned message: {1}", HostNames[i], message);
                    continue;
                }
                IPHostEntry h = (IPHostEntry)data;
                string[] aliases = h.Aliases;
                if (aliases.Length > 0)
                {
                    Console.WriteLine(@"Aliases for {0}", HostNames[i]);
                    foreach (string t in aliases)
                    {
                        Console.WriteLine(@"{0}", t);
                    }
                }

                IPAddress[] addresses = h.AddressList;
                if (addresses.Length > 0)
                {
                    Console.WriteLine(@"Addresses for {0}", HostNames[i]);
                    foreach (IPAddress t in addresses)
                    {
                        Console.WriteLine(@"{0}", t);
                    }
                }
            }
        }

        private static void UpdateUserInterface()
        {
            Console.WriteLine(@"{0} requests remaining.", _requestCounter);
        }

        private static void ProcessDnsInformation(IAsyncResult result)
        {
            string hostName = (string)result.AsyncState;
            HostNames.Add(hostName);
            try
            {
                IPHostEntry host = Dns.EndGetHostEntry(result);
                HostData.Add(host);
            }
            catch (SocketException e)
            {
                HostData.Add(e.Message);
            }
            finally
            {
                Interlocked.Decrement(ref _requestCounter);
            }
        }
    }
}
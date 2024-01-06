using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ConApp.OtherDemo
{
    public class _1AsynchronousOperations
    {
        public class HostRequest
        {
            private readonly string hostName;

            public HostRequest(string name)
            {
                hostName = name;
            }

            public string HostName
            {
                get
                {
                    return hostName;
                }
            }

            public SocketException ExceptionObject { get; set; }

            public IPHostEntry HostEntry { get; set; }
        }

        public class UseDelegateAndStateForAsyncCallback
        {
            private static int requestCounter;

            private static ArrayList hostData = new ArrayList();

            private static void UpdateUserInterface()
            {
                Console.WriteLine(@"{0} requests remaining.", requestCounter);
            }

            public static void Main1()
            {
                AsyncCallback callBack = new AsyncCallback(ProcessDnsInformation);
                string host;
                do
                {
                    Console.Write(" Enter the name of a host computer or <enter> to finish: ");
                    host = Console.ReadLine();
                    if (host.Length > 0)
                    {
                        Interlocked.Increment(ref requestCounter);
                        HostRequest request = new HostRequest(host);
                        hostData.Add(request);
                        Dns.BeginGetHostEntry(host, callBack, request);
                    }
                }
                while (host.Length > 0);
                while (requestCounter > 0)
                {
                    UpdateUserInterface();
                }
                foreach (HostRequest r in hostData)
                {
                    if (r.ExceptionObject != null)
                    {
                        Console.WriteLine(@"Request for host {0} returned the following error: {1}.", r.HostName, r.ExceptionObject.Message);
                    }
                    else
                    {
                        IPHostEntry h = r.HostEntry;
                        string[] aliases = h.Aliases;
                        IPAddress[] addresses = h.AddressList;
                        if (aliases.Length > 0)
                        {
                            Console.WriteLine(@"Aliases for {0}", r.HostName);
                            foreach (string t in aliases)
                            {
                                Console.WriteLine(@"{0}", t);
                            }
                        }
                        if (addresses.Length > 0)
                        {
                            Console.WriteLine(@"Addresses for {0}", r.HostName);
                            foreach (IPAddress t in addresses)
                            {
                                Console.WriteLine(@"{0}", t.ToString());
                            }
                        }
                    }
                }
            }

            private static void ProcessDnsInformation(IAsyncResult result)
            {
                HostRequest request = (HostRequest)result.AsyncState;
                try
                {
                    IPHostEntry host = Dns.EndGetHostEntry(result);
                    request.HostEntry = host;
                }
                catch (SocketException e)
                {
                    request.ExceptionObject = e;
                }
                finally
                {
                    Interlocked.Decrement(ref requestCounter);
                }
            }
        }
    }
}
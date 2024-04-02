using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Management;
using System.Reflection;

namespace ConApp.Samples
{
    public class VMIManagement
    {
        public static void ManagementDemo0()
        {
            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_NetworkAdapterConfiguration");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

            ManagementObjectCollection queryCollection = searcher.Get();
            foreach (ManagementObject m in queryCollection)
            {
                Console.WriteLine("Index : {0}", m["Index"]);
                Console.WriteLine("Description : {0}", m["Description"]);
                Console.WriteLine();
            }
        }

        public static void ManagementDemo1()
        {
            string moAddress = " ";
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc2 = mc.GetInstances();
            foreach (ManagementObject mo in moc2)
            {
                ManagementPath mp = mo.ClassPath;
                IContainer ic = mo.Container;
                ObjectGetOptions ogo = mo.Options;
                ManagementPath mpa = mo.Path;
                PropertyDataCollection pdc = mo.Properties;
                foreach (PropertyData item in pdc)
                {
                    Console.WriteLine($"{item.Name} ={mo[item.Name]}");
                }
                Console.WriteLine("************************************************************");
                PropertyDataCollection.PropertyDataEnumerator pde = pdc.GetEnumerator();

                QualifierDataCollection qd = mo.Qualifiers;
                ManagementScope ms = mo.Scope;
                ISite isi = mo.Site;
                PropertyDataCollection pdct = mo.SystemProperties;
                if ((bool)mo["IPEnabled"] == true)
                    moAddress = mo["MacAddress"].ToString();
                mo.Dispose();
            }
        }

        public static void ManagementDemo2()
        {
            ManagementScope scope = new ManagementScope("\\\\hry6464.tcent.cn\\root\\cimv2");
            scope.Connect();

            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

            ManagementObjectCollection queryCollection = searcher.Get();
            foreach (ManagementObject m in queryCollection)
            {
                Type t = m.GetType();
                PropertyInfo[] pis = t.GetProperties();
                // Display the remote computer information
                Console.WriteLine("Computer Name : {0}", m["csname"]);
                Console.WriteLine("Windows Directory : {0}", m["WindowsDirectory"]);
                Console.WriteLine("Operating System: {0}", m["Caption"]);
                Console.WriteLine("Version: {0}", m["Version"]);
                Console.WriteLine("Manufacturer : {0}", m["Manufacturer"]);
            }
        }

        public static void ManagementDemo3()
        {
            List<Dictionary<string, string>> diskInfoDic = new List<Dictionary<string, string>>();
            ManagementClass diskClass = new ManagementClass("Win32_LogicalDisk");
            ManagementObjectCollection disks = diskClass.GetInstances();
            foreach (ManagementObject disk in disks)
            {
                Dictionary<string, string> diskInfo = new Dictionary<string, string>();

                // 磁盘名称
                diskInfo["Name"] = disk["Name"].ToString();
                // 磁盘描述
                diskInfo["Description"] = disk["Description"].ToString();
                // 磁盘总容量，可用空间，已用空间
                if (System.Convert.ToInt64(disk["Size"]) > 0)
                {
                    long totalSpace = System.Convert.ToInt64(disk["Size"]); //MB;
                    long freeSpace = System.Convert.ToInt64(disk["FreeSpace"]); // MB;
                    long usedSpace = totalSpace - freeSpace;
                    diskInfo["totalSpace"] = totalSpace.ToString();
                    diskInfo["usedSpace"] = usedSpace.ToString();
                    diskInfo["freeSpace"] = freeSpace.ToString();
                }
                diskInfoDic.Add(diskInfo);
            }
        }

        public static void ManagementDemo4()
        {
            //ManagementClass mc = new ManagementClass("win32_processor");
            //ManagementObjectCollection moc = mc.GetInstances();
            //foreach (ManagementObject mo in moc)
            //{
            //    strID = mo.Properties["processorid"].Value.ToString();
            //    break;
            //}

            ManagementClass mc = new ManagementClass("Win32_PhysicalMedia");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                PropertyDataCollection colletion = mo.Properties;
                foreach (PropertyData item in colletion)
                {
                    Console.WriteLine($"{item.Name}  {item.Value}");
                }
            }

            mc = new ManagementClass("Win32_logicaldisk");
            moc = mc.GetInstances();
            Console.WriteLine("Win32_logicaldisk..........................................");

            foreach (ManagementObject mo in moc)
            {
                PropertyDataCollection colletion = mo.Properties;
                foreach (PropertyData item in colletion)
                {
                    Console.WriteLine($"{item.Name}  {item.Value}");
                }
            }
        }

        public static void ManagementDemo5()
        {
            ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = 'TRUE'");
            ManagementObjectCollection queryCollection = query.Get();
            foreach (ManagementObject mo in queryCollection)
            {
                string[] addresses = (string[])mo["IPAddress"];
                string[] subnets = (string[])mo["IPSubnet"];
                string[] defaultgateways = (string[])mo["DefaultIPGateway"];
                string macInfo = "网卡: " + mo["Description"];
                string txtBoard = "";
                string macAddress = (string)mo["MACAddress"];
                txtBoard = "网卡地址: \r\n" + macAddress + "\r\n";
                string ipAddress = addresses[0];
                txtBoard += "网络地址: \r\n" + ipAddress + "\r\n";
                string ipSubnet = subnets[0];
                txtBoard += "子网掩码: \r\n" + ipSubnet + "\r\n";
                string defaultGateway = defaultgateways[0];
                txtBoard += "默认网关: \r\n" + defaultGateway + "\r\n";
                string dnsServer1 = ((string[])mo["DNSServerSearchOrder"])[0];
                txtBoard += "主DNS服务:\r\n" + dnsServer1 + "\r\n";
                string dnsServer2 = ((string[])mo["DNSServerSearchOrder"])[1];
                txtBoard += "备DNS服务:\r\n" + dnsServer2;
                break;
            }
        }

        public static void ManagementDem6()
        {
            WqlObjectQuery wqlQuery = new WqlObjectQuery("SELECT * FROM Win32_LogicalDisk");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wqlQuery);

            foreach (ManagementObject disk in searcher.Get())
            {
                Console.WriteLine(disk.ToString());
            }
        }

        public static void ManagementDem7()
        {
            SelectQuery selectQuery = new SelectQuery("Win32_LogicalDisk");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(selectQuery);

            foreach (ManagementObject disk in searcher.Get())
            {
                Console.WriteLine(disk.ToString());
            }
        }

        public static void ManagementDem8()
        {
            /* Microsoft.Management.Infrastructure.dll */
            //ISession session = ISession.Create("localHost");
            //IEnumerable<IInstance> queryInstance = session.QueryInstances(@"root\cimv2", "WQL", "SELECT * FROM Win32_NetworkAdapterConfiguration");

            //foreach (CimInstance cimObj in queryInstance)
            //{
            //    Console.WriteLine(cimObj.CimInstanceProperties["Index"].ToString());
            //    Console.WriteLine(cimObj.CimInstanceProperties["Description"].ToString());
            //    Console.WriteLine();
            //}
        }

        public static void ManagementDem9()
        {
            SelectQuery selectQuery = new SelectQuery("Win32_TSGatewayConnectionAuthorizationPolicy");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(selectQuery);

            foreach (ManagementObject disk in searcher.Get())
            {
                Console.WriteLine(disk.ToString());
            }
        }

        public static void _01_Cooling_Device()
        {
            Console.WriteLine("Win32_Fan..........................................");
            ManagementClass mc = new ManagementClass("Win32_Fan");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                PropertyDataCollection colletion = mo.Properties;
                foreach (PropertyData item in colletion)
                {
                    Console.WriteLine($"{item.Name}  {item.Value}");
                }
            }

            Console.WriteLine("Win32_HeatPipe..........................................");
            mc = new ManagementClass("Win32_HeatPipe");
            moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                PropertyDataCollection colletion = mo.Properties;
                foreach (PropertyData item in colletion)
                {
                    Console.WriteLine($"{item.Name}  {item.Value}");
                }
            }

            Console.WriteLine("Win32_Refrigeration..........................................");
            mc = new ManagementClass("Win32_Refrigeration");
            moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                PropertyDataCollection colletion = mo.Properties;
                foreach (PropertyData item in colletion)
                {
                    Console.WriteLine($"{item.Name}  {item.Value}");
                }
            }

            Console.WriteLine("Win32_TemperatureProbe..........................................");
            mc = new ManagementClass("Win32_TemperatureProbe");
            moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                PropertyDataCollection colletion = mo.Properties;
                foreach (PropertyData item in colletion)
                {
                    Console.WriteLine($"{item.Name}  {item.Value}");
                }
            }
        }

        public static void _02_Input_Device()
        {
            Console.WriteLine("Win32_Keyboard..........................................");
            ManagementClass mc = new ManagementClass("Win32_Keyboard");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                PropertyDataCollection colletion = mo.Properties;
                foreach (PropertyData item in colletion)
                {
                    Console.WriteLine($"{item.Name}  {item.Value}");
                }
            }

            Console.WriteLine("Win32_PointingDevice..........................................");
            mc = new ManagementClass("Win32_PointingDevice");
            moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                PropertyDataCollection colletion = mo.Properties;
                foreach (PropertyData item in colletion)
                {
                    Console.WriteLine($"{item.Name}  {item.Value}");
                }
            }
        }

        public static void _03_Mass_Storage()
        {
            Console.WriteLine("Win32_Printer..........................................");
            ManagementClass mc = new ManagementClass("Win32_Printer");
            mc.Options.UseAmendedQualifiers = true;

            MethodDataCollection methods = mc.Methods;
            foreach (MethodData item in methods)
            {
                Console.WriteLine(item.Name + "-------------------------" + item.InParameters);
            }
            ManagementBaseObject inParams = mc.GetMethodParameters("PrintTestPage");
            inParams = mc.GetMethodParameters("PrintTestPage");

            //PropertyDataCollection paramsInfo = inParams.Properties;
            //foreach (PropertyData item in paramsInfo)
            //{
            //    Console.WriteLine(item.Name + "    " + item.Value);
            //}

            //object obj = Activator.CreateInstance("Win32_Printer", null);
            //mc.InvokeMethod("Win32_Printer", null);

            //ManagementObjectCollection moc = mc.GetInstances();
            //foreach (ManagementObject mo in moc)
            //{
            //    PropertyDataCollection colletion = mo.Properties;
            //    foreach (PropertyData item in colletion)
            //    {
            //        Console.WriteLine($"{item.Name}  {item.Value}");
            //    }
            //}
        }

        public static void Win32_ProcessDemo()
        {
            //ManagementObject o = new ManagementObject();

            //// Specify the WMI path to which
            //// this object should be bound to
            //o.Path = new ManagementPath("Win32_Process.Name='calc.exe'");

            // Get the WMI class
            ManagementClass processClass = new ManagementClass("Win32_Process");
            processClass.Options.UseAmendedQualifiers = true;

            // Get the methods in the class
            MethodDataCollection methods = processClass.Methods;

            // display the method names
            Console.WriteLine("Method Name: ");
            foreach (MethodData method in methods)
            {
                if (method.Name.Equals("Create"))
                {
                    Console.WriteLine(method.Name);
                    Console.WriteLine("Description: " + method.Qualifiers["Description"].Value);
                    Console.WriteLine();

                    Console.WriteLine("In-parameters: ");
                    foreach (PropertyData i in method.InParameters.Properties)
                    {
                        Console.WriteLine(i.Name);
                    }
                    Console.WriteLine();

                    Console.WriteLine("Out-parameters: ");
                    foreach (PropertyData o in method.OutParameters.Properties)
                    {
                        Console.WriteLine(o.Name);
                    }
                    Console.WriteLine();

                    Console.WriteLine("Qualifiers: ");
                    foreach (QualifierData q in method.Qualifiers)
                    {
                        Console.WriteLine(q.Name);
                    }
                    Console.WriteLine();
                }
            }
        }

        public static void VMI_Invorke1()
        {
            // Get the object on which the
            // method will be invoked
            ManagementClass processClass = new ManagementClass("Win32_Process");

            MethodDataCollection methods = processClass.Methods;
            foreach (MethodData item in methods)
            {
                Console.WriteLine(item.Name + "  " + item.InParameters + "  " + item.OutParameters);
            }
            // Create an array containing all
            // arguments for the method
            object[] methodArgs = { "notepad.exe", null, null, 0 };

            //Execute the method
            object result = processClass.InvokeMethod("Create", methodArgs);

            //Display results
            Console.WriteLine("Creation of process returned: " + result);
            Console.WriteLine("Process id: " + methodArgs[3]);
        }

        public static void VMI_Invorke2()
        {
            // Get the object on which the method will be invoked
            ManagementClass processClass = new ManagementClass("Win32_Process");
            processClass.Options.UseAmendedQualifiers = true;

            // Get an input parameters object for this method
            ManagementBaseObject inParams = processClass.GetMethodParameters("Create");

            PropertyDataCollection paramsInfo = inParams.Properties;
            foreach (PropertyData item in paramsInfo)
            {
                Console.WriteLine(item.Name + "    " + item.Value);
            }
            // Fill in input parameter values
            inParams["CommandLine"] = "notepad.exe";
            inParams["CurrentDirectory"] = Environment.CurrentDirectory;
            // Execute the method
            MethodDataCollection mcc = processClass.Methods;
            foreach (MethodData method in mcc)
            {
                if (method.Name == "Create")
                {
                    Console.WriteLine(method.Name);
                    Console.WriteLine("Description: " + method.Qualifiers["Description"].Value);
                }
            }
            ManagementBaseObject outParams = processClass.InvokeMethod("Create", inParams, null);

            // Display results
            // Note: The return code of the method is
            // provided in the "returnValue" property
            // of the outParams object
            Console.WriteLine("Creation of calculator process returned: " + outParams["returnValue"]);
            Console.WriteLine("Process ID: " + outParams["processId"]);
        }

        private static void WqlObjectQueryDemo()
        {
            RelationshipQuery query1 = new RelationshipQuery("references of {Win32_ComputerSystem.Name='mymachine'}");

            // Only the object of interest is
            // specified to the constructor
            RelationshipQuery query2 = new RelationshipQuery("Win32_Service.Name='Alerter'");

            WqlObjectQuery wqlQuery = new WqlObjectQuery("SELECT * FROM Win32_LogicalDisk WHERE FreeSpace > 300000000000");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wqlQuery);
            foreach (ManagementObject disk in searcher.Get())
            {
                PropertyDataCollection p = disk.Properties;
                foreach (PropertyData item in p)
                {
                    Console.WriteLine(item.Origin + "  " + item.Value);
                }
                Console.WriteLine(disk.ToString());
            }
        }

        private static void SelectQueryDemo1()
        {
            SelectQuery s = new SelectQuery();
            s.QueryString = "SELECT * FROM Win32_Process";

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(s);

            foreach (ManagementObject o in searcher.Get())
            {
                // show the class
                Console.WriteLine(o.ToString());
            }
        }

        private static void SelectQueryDemo2()
        {
            SelectQuery s = new SelectQuery(true, "__CLASS = 'Win32_Service'");

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(s);

            foreach (ManagementObject service in searcher.Get())
            {
                Console.WriteLine(service.ToString());
            }
        }

        private static void SelectQueryDemo3()
        {
            //SelectQuery sQuery = new SelectQuery("SELECT * FROM Win32_Service WHERE State='Stopped'");

            //SelectQuery query = new SelectQuery("Win32_Service");

            SelectQuery lquery = new SelectQuery("SELECT * FROM Meta_Class");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(lquery);
            foreach (ManagementObject service in searcher.Get())
            {
                // show the class
                Console.WriteLine(service.ToString());
            }
        }

        private static void SelectQueryDemo4()
        {
            SelectQuery s = new SelectQuery("Win32_Service", "State = 'Stopped'");

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(s);

            foreach (ManagementObject service in searcher.Get())
            {
                // show the class
                Console.WriteLine(service.ToString());
            }
        }

        private static void SelectQueryDemo5()
        {
            string[] properties = { "Name", "Handle" };

            SelectQuery s = new SelectQuery("Win32_Process", "Name = 'notepad.exe'", properties);

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(s);

            foreach (ManagementObject o in searcher.Get())
            {
                Console.WriteLine(o.ToString());
            }
        }

        private static void SelectQueryDemo6()
        {
            SelectQuery selectQuery = new SelectQuery("Win32_LogicalDisk");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(selectQuery);

            foreach (ManagementObject disk in searcher.Get())
            {
                Console.WriteLine(disk.ToString());
            }
        }
    }
}
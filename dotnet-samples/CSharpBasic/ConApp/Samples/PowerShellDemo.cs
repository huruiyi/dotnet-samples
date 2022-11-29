using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;

namespace ConApp
{
    public class PowerShellDemo
    {
        public class PsParam
        {
            public string Key { get; set; }

            public object Value { get; set; }
        }

        public class Info
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Z { get; set; }
        }

        /// <summary>
        /// 计算操作的对象
        /// Author:chenkai Date：2010年11月9日13:54:49
        /// </summary>
        public class ConvertPatameter
        {
            public int FirstNum { get; set; }
            public int SecondNum { get; set; }
            public int Sum { get; set; }
        }

        public class OperatorPatameter
        {
            public string Operatorkey { get; set; }
            public object OperatorValue { get; set; }
        }

        /// <summary>
        /// 定义一个封装Shell脚本命令参数实体类
        /// Author：chenkai Date:2010年11月9日10:27:55
        /// </summary>
        public class ShellParameter
        {
            public string ShellKey { get; set; }
            public string ShellValue { get; set; }
        }

        private static void Demo1()
        {
            List<string> ps = new List<string>
            {
                "Get-WmiObject -Class Win32_UserAccount"
            };
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            Pipeline pipeline = runspace.CreatePipeline();
            foreach (var scr in ps)
            {
                pipeline.Commands.AddScript(scr);
            }
            pipeline.Invoke();

            Console.WriteLine(pipeline.Output);
            runspace.Close();
        }

        private static void Demo2()
        {
            List<string> ps = new List<string>
            {
                "Set-ExecutionPolicy RemoteSigned"
            };
            //先执行启动安全策略，，使系统可以执行powershell脚本文件

            string path = Environment.CurrentDirectory;
            string pspath = System.IO.Path.Combine(path, "ps.ps1");

            ps.Add(pspath);//执行脚本文件

            Info psobj = new Info
            {
                X = 20,
                Y = 10
            };

            PsParam par = new PsParam
            {
                Key = "arg",
                Value = psobj
            };

            Demo6(ps, new List<PsParam>
            {
                par
            });

            Console.WriteLine(psobj.X + " + " + psobj.Y + " = " + psobj.Z);
        }

        public static void Demo3(string cmd)
        {
            List<string> ps = new List<string>
            {
                "Set-ExecutionPolicy RemoteSigned",
                "Set-ExecutionPolicy -ExecutionPolicy Unrestricted",
                "& " + cmd
            };
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            Pipeline pipeline = runspace.CreatePipeline();
            foreach (var scr in ps)
            {
                pipeline.Commands.AddScript(scr);
            }
            pipeline.Invoke();//Execute the ps script
            runspace.Close();
        }

        public static void Demo4()
        {
            RunspaceConfiguration rconfig = RunspaceConfiguration.Create();
            PSSnapInException pwarn = new PSSnapInException();

            string test = "Import-Module VirtualMachineManager\r\n";
            var runspace = RunspaceFactory.CreateRunspace(rconfig); runspace.Open();
            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(test);
            pipeline.Invoke();

            using (Pipeline pipe = runspace.CreatePipeline())
            {
                //Get-VM -Name vm001
                Command cmd = new Command("Get-VM");
                cmd.Parameters.Add("Name", "vm001");
                pipe.Commands.Add(cmd);
                pipe.Invoke();
            }
        }

        private static Collection<PSObject> Demo5(string filePath, string parameters)
        {
            RunspaceConfiguration runspaceConfiguration = RunspaceConfiguration.Create();
            Runspace runspace = RunspaceFactory.CreateRunspace(runspaceConfiguration);
            runspace.Open();
            RunspaceInvoke scriptInvoker = new RunspaceInvoke(runspace);
            Pipeline pipeline = runspace.CreatePipeline();
            Command scriptCommand = new Command(filePath);
            Collection<CommandParameter> commandParameters = new Collection<CommandParameter>();

            string[] tempParas = parameters.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < tempParas.Length; i += 2)
            {
                CommandParameter commandParm = new CommandParameter(tempParas[i], tempParas[i + 1]);
                commandParameters.Add(commandParm);
                scriptCommand.Parameters.Add(commandParm);
            }

            pipeline.Commands.Add(scriptCommand);
            var psObjects = pipeline.Invoke();

            if (pipeline.Error.Count > 0)
            {
                throw new Exception("脚本执行失败");
            }

            runspace.Close();

            return psObjects;
        }

        public static string Demo6(List<string> scripts, List<PsParam> pars)
        {
            Runspace runspace = RunspaceFactory.CreateRunspace();

            runspace.Open();

            Pipeline pipeline = runspace.CreatePipeline();
            foreach (var scr in scripts)
            {
                pipeline.Commands.AddScript(scr);
            }

            //注入参数
            if (pars != null)
            {
                foreach (var par in pars)
                {
                    runspace.SessionStateProxy.SetVariable(par.Key, par.Value);
                }
            }

            //返回结果
            var results = pipeline.Invoke();
            runspace.Close();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (PSObject obj in results)
            {
                stringBuilder.AppendLine(obj.ToString());
            }
            return stringBuilder.ToString();
        }

        public static void Demo7()
        {
            Runspace runSpace = RunspaceFactory.CreateRunspace();
            runSpace.Open();

            Pipeline pipeLine = runSpace.CreatePipeline();

            Command getProcessCStarted = new Command("Get-Process");

            getProcessCStarted.Parameters.Add("name", "C*");

            pipeLine.Commands.Add(getProcessCStarted);

            // Run all commands in the current pipeline by calling Pipeline.Invoke.
            // It returns a System.Collections.ObjectModel.Collection object.
            // In this example, the executed script is "Get-Process -name C*".
            Collection<PSObject> cNameProcesses = pipeLine.Invoke();

            foreach (PSObject psObject in cNameProcesses)
            {
                Process process = psObject.BaseObject as Process;
                Console.WriteLine("Process Name: {0}", process.ProcessName);
            }
        }

        /// <summary>
        /// 执行PowserShell 脚本核心方法
        /// </summary>
        /// <param name="getshellstrlist">Shell脚本集合</param>
        /// <param name="getshellparalist">脚本中涉及对应参数</param>
        /// <returns>执行结果返回值</returns>
        public static string ExecuteShellScript(List<string> getshellstrlist, List<ShellParameter> getshellparalist)
        {
            string getresutl = null;
            //Create Runspace
            Runspace newspace = RunspaceFactory.CreateRunspace();
            Pipeline newline = newspace.CreatePipeline();

            //open runspace
            newspace.Open();

            if (getshellstrlist.Count > 0)
            {
                foreach (string getshellstr in getshellstrlist)
                {
                    //Add Command ShellString
                    newline.Commands.AddScript(getshellstr);
                }
            }

            //Check Parameter
            if (getshellparalist != null && getshellparalist.Count > 0)
            {
                int count = 0;
                foreach (ShellParameter getshellpar in getshellparalist)
                {
                    //Set parameter
                    //注入脚本一个.NEt对象 这样在powershell脚本中就可以直接通过$key访问和操作这个对象
                    //newspace.SessionStateProxy.SetVariable(getshellpar.ShellKey,getshellpar.ShellValue);
                    CommandParameter cmdpara = new CommandParameter(getshellpar.ShellKey, getshellpar.ShellValue);
                    newline.Commands[count].Parameters.Add(cmdpara);
                }
            }

            //Exec Restult
            var getresult = newline.Invoke();
            if (getresult != null)
            {
                StringBuilder getbuilder = new StringBuilder();
                foreach (var getresstr in getresult)
                {
                    getbuilder.AppendLine(getresstr.ToString());
                }
                getresutl = getbuilder.ToString();
            }

            //close
            newspace.Close();
            return getresutl;
        }

        /// <summary>
        /// 测试C#于Shell对象操作的可操作性
        /// </summary>
        /// <returns>返回计算结果</returns>
        public static void OperatorObjectShell_Demo()
        {
            string getres = string.Empty;
            //zaiShell 执行方法参数
            List<string> getlist = new List<string>
            {
                "Set-ExecutionPolicy RemoteSigned"
            };
            //先执行启动安全策略，，使系统可以执行powershell脚本文件

            string pspath = Path.Combine(new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName, "Resource", "PSDoc1.ps1");
            getlist.Add(pspath);

            //定义一个操作的实体对象
            ConvertPatameter newconvert = new ConvertPatameter
            {
                FirstNum = 200,
                SecondNum = 80,
                Sum = 0
            };

            RunspaceConfiguration runspaceConfiguration = RunspaceConfiguration.Create();
            Runspace newspace = RunspaceFactory.CreateRunspace(runspaceConfiguration);

            newspace.Open();
            Pipeline newline = newspace.CreatePipeline();
            RunspaceInvoke scriptInvoker = new RunspaceInvoke(newspace);

            Command getcmd = new Command(pspath);
            CommandParameter newcmdpara = new CommandParameter("Result", newconvert);
            getcmd.Parameters.Add(newcmdpara);
            newline.Commands.Add(getcmd);

            //注入脚本一个.NEt对象 这样在powershell脚本中就可以直接通过$key访问和操作这个对象
            //newspace.SessionStateProxy.SetVariable(getshellpar.ShellKey,getshellpar.ShellValue);
            newspace.SessionStateProxy.SetVariable("Result", newconvert);

            //执行
            var gettakeres = newline.Invoke();

            foreach (var getstr in gettakeres)
            {
                Console.WriteLine(getstr.ToString());
            }

            Console.WriteLine("计算结果:" + newconvert.FirstNum + "加上" + newconvert.SecondNum + "等于" + newconvert.Sum);
            Console.WriteLine("对象的值已经修改:" + newconvert.Sum);
        }

        public static void Demo8()
        {
            Console.WriteLine("请输入你要执行的PowserShell命名:");
            string gettakeresult = Console.ReadLine();

            //Main Method Get All Process
            List<string> getshellcmdlist = new List<string>();
            List<ShellParameter> getpatalist = new List<ShellParameter>
            {
                new ShellParameter{ ShellKey="Name",ShellValue="QQ*"}
            };

            if (!string.IsNullOrEmpty(gettakeresult))
            {
                getshellcmdlist.Add(gettakeresult);
            }
            //Execu Cmd
            string getresult = ExecuteShellScript(getshellcmdlist, getpatalist);

            //Output ExecuteResult
            Console.WriteLine("执行结果:");
            Console.WriteLine(getresult);
        }
    }
}
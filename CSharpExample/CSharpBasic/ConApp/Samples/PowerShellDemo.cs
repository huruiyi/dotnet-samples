using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
            List<string> ps = new List<string>();
            ps.Add("Set-ExecutionPolicy RemoteSigned");
            ps.Add("Set-ExecutionPolicy -ExecutionPolicy Unrestricted");
            ps.Add("& " + cmd);
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
    }
}
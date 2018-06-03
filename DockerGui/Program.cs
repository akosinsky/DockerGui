using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Docker.DotNet;
using Docker.DotNet.Models;
using System.Text.RegularExpressions;
using System.Threading;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Configuration;

namespace DockerGui
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var s=Env.ImagesCommandsFile;
            //Test3();
            //return;
            //Test2();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ImagesForm());
        }

        static void Test3()
        {
            ContextMenuItem.LoadContextMenu("ContextMenu.xml");
        }

        static void Test2()
        {
            string text = "12.2.3-beta111-postgresql-db"; //1.1.3-alpha1-postgresql-db
            string pat = @"(^[0-9.]+)[-\w*]*-postgresql-db";//"/^[0-9.]+/-postgresql-db";//@"(\w+)\s+(car)";

            //pat = @"(\w+)\s+(car)";
            //text = "One car red car blue car";
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);
            Match m = r.Match(text);
            var b = m.Success;
        }

        async static void Test()
        {
            DockerClient client = Env.Client;
            var version = await client.System.GetVersionAsync();
            var im = await client.Images.ListImagesAsync(new ImagesListParameters() { All=true});
        }
    }

    public class CommandResult
    {
        public int ExitCode;
        public string StandartError;
        public string StandardOutput;
        public string Title;
    }

    static class Env
    {
        public const string NoneTag = "<none>:<none>";
        public static void SetCommands(string tag, List<string> cmds)
        {
            var allCmds = new List<string>();
            foreach (var line in File.ReadAllLines(ImagesCommandsFile))
            {
                int p1 = line.IndexOf("=");

                if (p1 != -1 && tag == line.Substring(0, p1))
                {
                    continue;
                }
                allCmds.Add(line);
            }
            foreach (var item in cmds)
            {
                allCmds.Add($"{tag}={item}");
            }
            File.WriteAllLines(ImagesCommandsFile, allCmds.ToArray());
        }

        public static List<string> GetCommands(string tag)
        {
            List<string> ret = new List<string>();
            var commands = File.ReadAllLines(ImagesCommandsFile);
            foreach (var line in commands)
            {
                int p1 = line.IndexOf("=");
                if (p1 == -1)
                {
                    continue;
                }

                if (p1 == 0)
                {
                    ret.Add(line.Substring(p1+1));
                }
                else
                {
                    if (tag.IndexOf(line.Substring(0, p1)) == 0)
                    {
                        var cmd = line.Substring(p1 + 1);
                        int i = ret.IndexOf(cmd);
                        if (i != -1)
                        {
                            ret.RemoveAt(i);
                        }
                        ret.Add(cmd);
                    }
                }
            }

            return ret;
        }

        public static string ImagesCommandsFile
        {
            get
            {
                var fileName = ConfigurationManager.AppSettings["ImagesCommandsFile"];

                if (!File.Exists(fileName))
                {
                    fileName = "ImagesCommands.txt";
                    if (!File.Exists(fileName))
                    {
                        File.WriteAllText(fileName, "=docker run --privileged -ti ##{tag}## /bin/bash\nbusybox:=docker run --privileged -ti ##{tag}## sh");
                    }
                }

                return fileName;
            }
        }

        public static void Log(string text)
        {
            File.AppendAllText("log.txt", $"{text}\n");
        }

        public static CommandResult StartHidden(string dockerCmd)
        {
            dockerCmd = Type.GetType("Mono.Runtime") != null
                            ? $"'{dockerCmd}'"
                            : dockerCmd;
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = Env.ShellHidden,
                    Arguments = $"{Env.ShellArgsHidden} {dockerCmd}",
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            var standartError = new StringBuilder();
            var standartOutput = new StringBuilder();
            proc.Start();
            proc.OutputDataReceived += (s, e) =>
            {
                lock (standartOutput)
                {
                    standartOutput.Append(e.Data);
                    standartOutput.Append("\r\n");
                }
            };

            proc.ErrorDataReceived += (s, e) =>
            {
                lock (standartError)
                {
                    standartError.Append(e.Data);
                    standartError.Append("\r\n");
                }
            };

            proc.BeginErrorReadLine();
            proc.BeginOutputReadLine();
            proc.WaitForExit();
            return new CommandResult() { ExitCode = proc.ExitCode, StandardOutput = standartOutput.ToString(), StandartError = standartError.ToString() };
        }

        public static DockerClient Client
        {
            get
            {
                string url = Type.GetType("Mono.Runtime") != null
                ? "tcp://localhost:4243"
                : "npipe://./pipe/docker_engine";
                return new DockerClientConfiguration(new Uri(url)).CreateClient();
            }
        }

        public static string Shell
        {
            get
            {
                string shell = Type.GetType("Mono.Runtime") != null
                ? "xterm"
                : "cmd.exe";
                return shell;
            }
        }

        public static string ShellArgs
        {
            get
            {
                string shellArgs = Type.GetType("Mono.Runtime") != null
                ? "-hold -fa 'Monospace' -fs 10 -e" //-hold 
                : "/c start cmd.exe /k";
                return shellArgs;
            }
        }

        public static string ShellHidden
        {
            get
            {
                string shell = Type.GetType("Mono.Runtime") != null
                ? "bash"
                : "cmd.exe";
                return shell;
            }
        }

        public static string ShellArgsHidden
        {
            get
            {
                string shellArgs = Type.GetType("Mono.Runtime") != null
                ? "-c"
                : "/c";
                return shellArgs;
            }
        }

        public static string DockerfilesFolder
        {
            get
            {
                string shell = Type.GetType("Mono.Runtime") != null
                ? "/dockerfiles"
                : @"c:\Dockerfiles";
                return shell;
            }
        }

    }

}

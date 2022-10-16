using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.Reflection;
using GlobalOPT.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace GlobalOPT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        static bool softwareInstallation = false;
        static string strCmdText;
        static string tag = "fw";
        static string name = "opt";
        static string gitRepoURL = "https://github.com/demirmehmet0/GlobalOptFramework";
        static string gitRepoName = gitRepoURL.Split('/').Last();
        static string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        static string winDir = Path.GetPathRoot(System.Environment.GetEnvironmentVariable("WINDIR"));
        static string gitRepoClonePath = desktopPath + "\\GlobalOPTFW\\" + gitRepoName + "\\";
        static string textFilePath = desktopPath + "\\result.txt";
        static string algorithm = "", iteration = "", threshold = "", depth = "", num_matrices = "", bfi = "";
        private const int WM_VSCROLL = 277;
        private const int SB_PAGEBOTTOM = 7;
        private int dockerTimeout = 30;

        private void RunDockerBuild()//run the docker image
        {
            //Runs created docker build
            Echo("Executing...");
            Thread.Sleep(100);
            strCmdText = "/C @echo off &  cd " + gitRepoClonePath + " & docker run " + tag + ":" + name;
            string output = RunCommand();
            Echo("Execution completed!");
            //Runs created docker build
            //Saving results in result.txt file 
            Echo("Saving results...");
            string buildOutput = "------Build Time:" + DateTime.Now + "------\n" + output + "------Build Finished------\n";
            if (!File.Exists(textFilePath))
                File.Create(textFilePath).Close();//Create result.txt file if does not exist
            File.AppendAllText(textFilePath, buildOutput);
            Echo("Result file succesfully written on result file on Desktop");
            //Saving results in result.txt file
            Thread.Sleep(3000);
            this.output.Clear();
            ClearAndUpdate();
            backgroundWorker1.RunWorkerAsync();
        }
        void InstallRequiredSoftwares()//Install docker and git if its not installed
        {
            GitInstall();
            DockerInstall();
        }
        void GitInstall()//Installing Git via powershell
        {
            Echo("Checking Git...");
            strCmdText = "/C git -v";
            string output = RunCommand();//If git is installed output will be version of git. So it cant be null
            if (string.IsNullOrEmpty(output))
            {
                //Installing Git
                Echo("Git not found. Installing Git...");
                string installCommand = "$git_url = \"https://api.github.com/repos/git-for-windows/git/releases/latest\"\r\n$asset = Invoke-RestMethod -Method Get -Uri $git_url | % assets | where name -like \"*64-bit.exe\"\r\n# download installer\r\n$installer = \"$env:temp\\$($asset.name)\"\r\nInvoke-WebRequest -Uri $asset.browser_download_url -OutFile $installer\r\n# run installer\r\n$git_install_inf = \"<install inf file>\"\r\n$install_args = \"/SP- /VERYSILENT /SUPPRESSMSGBOXES /NOCANCEL /NORESTART /CLOSEAPPLICATIONS /RESTARTAPPLICATIONS /LOADINF=\"\"$git_install_inf\"\"\"\r\nStart-Process -FilePath $installer -ArgumentList $install_args -Wait";
                File.Create("gitinstaller.txt").Close();
                File.WriteAllText("gitinstaller.txt", installCommand);
                File.Move("gitinstaller.txt", Path.ChangeExtension("gitinstaller.txt", ".ps1"));
                var startInfo = new ProcessStartInfo()
                {
                    FileName = "powershell.exe",
                    Arguments = $"-NoProfile -ExecutionPolicy ByPass -File \"gitinstaller.ps1\"",
                    Verb = "runas",
                    UseShellExecute = false
                };
                Process process = new Process();
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();
                Echo("Git installed");
                softwareInstallation = true;//is any software installed
                Application.Restart();//Restarting program for git commands
                //Installing Git 
            }
            else
                Echo("Git found.");
        } 
        void DockerInstall()//Installing Docker via powershell
        {
            Echo("Checking Docker...");
            strCmdText = "/C docker -v";
            string output = RunCommand();//If docker is installed output will be version of git. So it cant be null
            if (string.IsNullOrEmpty(output))
            {
                //Installing Choco And Docker
                Echo("Docker not found. Installing Docker...");
                //choco uninstalling (for reinstall *temporary solution*) 
                try { Directory.Delete(System.Environment.GetFolderPath(System.Environment.SpecialFolder.CommonApplicationData) + "\\chocolatey"); } catch { }

                //choco uninstalling (for reinstall *temporary solution*)
                string installCommand = "Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString(\"https://chocolatey.org/install.ps1\"))\r\nchoco install docker-desktop -y";
                File.Create("dockerinstaller.txt").Close();
                File.WriteAllText("dockerinstaller.txt", installCommand);
                File.Move("dockerinstaller.txt", Path.ChangeExtension("dockerinstaller.txt", ".ps1"));
                var startInfo = new ProcessStartInfo()
                {
                    FileName = "powershell.exe",
                    Arguments = $"-NoProfile -ExecutionPolicy ByPass -File \"dockerinstaller.ps1\"",
                    Verb = "runas",
                    UseShellExecute = false
                };
                Process process = new Process();
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();
                Echo("Docker installed");
                softwareInstallation = true;//is any software installed
                //Installing Choco And Docker 
            }
            else
                Echo("Docker found.");

        }

        internal static void ScrollToBottom(RichTextBox richTextBox)
        {
            SendMessage(richTextBox.Handle, WM_VSCROLL, (IntPtr)SB_PAGEBOTTOM, IntPtr.Zero);
            richTextBox.SelectionStart = richTextBox.Text.Length;
        }
        void StartDocker()//Starts docker.backend
        {
            bool procK = false;
            var proc = Process.Start(Path.Combine(winDir + @"Program Files\Docker\Docker\resources\com.docker.backend.exe"));//Docker backend path (default)
            while (!procK)
            {
                foreach (var process in Process.GetProcessesByName("Docker Desktop"))
                { process.Kill(); procK = true; }

            }
            while (proc.MainWindowHandle == IntPtr.Zero) //note: only works as long as your process actually creates a main window.
                System.Threading.Thread.Sleep(10);
            ShowWindow(proc.MainWindowHandle, 0);//Hide command window for better visualization
        }

        void CreateDockerImage()//Building docker image with params
        {
            //Building docker imageC:\Users\kadir\OneDrive\Desktop\GlobalOPTFW\GlobalOptFramework\matrices
            Echo("Getting parameters...");
            string oldParameters = File.ReadAllText(gitRepoClonePath + "\\parameter.txt");
            string[] lines = oldParameters.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            if (algorithm != "0")//Implementing parameters if added
            {
                Echo("Implementing parameters...");
                algorithm = algorithm != "0" ? algorithm : lines[0].Split('=')[1];
                iteration = iteration != string.Empty ? iteration : lines[2].Split('=')[1];
                threshold = threshold != string.Empty ? threshold : lines[3].Split('=')[1];
                depth = depth != string.Empty ? depth : lines[4].Split('=')[1];
                num_matrices = num_matrices != string.Empty ? num_matrices : lines[5].Split('=')[1];
                bfi = bfi != string.Empty ? bfi : lines[6].Split('=')[1];
                ChangeParameters();//Change parameter.txt with inserted params
                Echo("Implementing completed");
            }
            string text = algorithm + iteration + threshold + depth + num_matrices + bfi;
            Echo(text, Color.White);
            Thread.Sleep(100);
            Echo("Building Docker Image...");
            strCmdText = "/C @echo off &  cd " + gitRepoClonePath + " & docker build . -t " + tag + ":" + name;
            RunCommand();
            Echo("Docker Image Built Succesfully!");
            //Building docker image  
        }
        void GitClone()//Cloning git repo on Desktop 
        {
            //Cloning git repo on Desktop 
            Echo("Cloning Git Repository...");
            strCmdText = "/C @echo off &  cd " + desktopPath + " & mkdir GlobalOPTFW & cd GlobalOPTFW & git clone " + gitRepoURL;
            string output = RunCommand();
            Echo(output + "Git Repo Cloned!");
            //Cloning git repo on Desktop
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            RichTextBox.CheckForIllegalCrossThreadCalls = false;
            Thread.Sleep(2000);
            Startup();
        }
        void ClearAndUpdate()//Clear old builds and update repo if need
        {
           
            //Updating repo
            Echo("Clearing old builds and updating repository...");
            if (Directory.Exists(gitRepoClonePath))//if repo exists update repo
            {
                strCmdText = "/C @echo off &  cd " + gitRepoClonePath + " & git pull";
                RunCommand();
                Echo("Git Repo Updated To Latest Version!");
            }
            else
            {
                Echo("Git Repo Not Found!", Color.Red);
            }
            //Updating repo 
            //Clearing all docker images 
            Echo("Clearing old docker images...");
            strCmdText = "/C for /F %i in ('docker images -a -q') do docker rmi -f %i";
            RunCommand(false);
            Echo("All Docker Image Cleared!");
            //Clearing all docker images
            //Clearing all docker containers   
            Echo("Clearing old docker containers...");
            strCmdText = "/C echo y|docker container prune";
            RunCommand(false);
            Echo("All Docker Containers Cleared!");
            //Clearing all docker containers
            Echo("All Cleared");
        }

        void ChangeParameters()
        {
            //Changing the parameter.txt
            string parameter = "ALGORITHM=" + algorithm + "\r\nMATRIX_PATH=matrices/matrix.txt\r\nITERATION=" + iteration + "\r\nTHRESHOLD=" + threshold + "\r\nDEPTH=" + depth + "\r\nNUM_MATRICES=" + num_matrices + "\r\nBFI=" + bfi + "";
            File.WriteAllText(gitRepoClonePath + "\\parameter.txt", parameter);
            //Changing the parameter.txt
        }
        string RunCommand()//Function that run commands on cmd.exe
        {
            Process process = new System.Diagnostics.Process();
            ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            startInfo.CreateNoWindow = true;
            startInfo.FileName = "cmd.exe";
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.Arguments = strCmdText;
            process.StartInfo = startInfo;
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Echo(output, Color.White);
            Thread.Sleep(100);
            return output;
        }
        string RunCommand(bool a)//Function that run commands on cmd.exe
        {
            Process process = new System.Diagnostics.Process();
            ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            startInfo.CreateNoWindow = true;
            startInfo.FileName = "cmd.exe";
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.Arguments = strCmdText;
            process.StartInfo = startInfo;
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            if(a)Echo(output, Color.White);
            Thread.Sleep(100);
            return output;
        }
        private void RunButton_Click(object sender, EventArgs e)
        {
            iteration = iterationNumeric.Value.ToString();
            num_matrices = matricesNumeric.Value.ToString();
            depth = depthNumeric.Value.ToString();
            threshold = thresholdNumeric.Value.ToString();
            bfi = bfiNumeric.Value.ToString();
            if (!Directory.Exists(gitRepoClonePath)) GitClone();//if repo does not exists clone it
            CreateDockerImage();//create docker image with git repo
            RunDockerBuild();//run the docker image
        }
        void Startup()
        {
            Echo("Welcome to the GlobalOPT");
            Thread.Sleep(1000);
            Echo("Checking required softwares...");

            //Is docker running checking

            InstallRequiredSoftwares();//Install docker and git if its not installed
            try
            {
                File.Delete("gitinstaller.ps1");//Delete Git Installer shell script for cleaning
                File.Delete("dockerinstaller.ps1");//Delete Docker Installer shell script for cleaning
            }
            catch { }
            if (softwareInstallation)//If any software installed
                Echo("Checking completed. System now has all required softwares");
            else
                Echo("Checking completed. System has all required softwares");

            Echo("Docker starting...");
            Echo("Waiting for docker");
        DockerStartup:
            dockerTimer.Start();
            Process[] pname = Process.GetProcessesByName("com.docker.backend");
            if (pname.Length == 0 && dockerTimeout > 0)
            {
                StartDocker();
                goto DockerStartup;
            }
            else if (dockerTimeout <= 0 && pname.Length == 0)
            {
                Echo("Docker startup failed. Restarting...");
                Thread.Sleep(2000);
                Application.Restart();
            }
            dockerTimer.Stop();

            Echo("Docker started!");
            ClearAndUpdate();//Clear old builds and update repo if need
            Echo("Insert Parameters");
            EnableInputs();
        }

        void EnableInputs()
        {
            algorithmSelection.Enabled = true;
            algorithmLabel.Enabled = true;
            RunButton.Enabled = true;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void algorithmSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            algorithm = algorithmSelection.SelectedIndex.ToString();
            if (algorithm != "0")//If 0 selected for algorithm it will use default settings(on git repo) or if you have your params from last time it will use it
            {
                switch (algorithm)
                {
                    case "2":
                        matricesNumeric.Enabled = true; matricesLabel.Enabled = true;
                        thresholdNumeric.Enabled = true; thresholdLabel.Enabled = true;
                        depthNumeric.Enabled = true; depthLabel.Enabled = true;
                        bfiNumeric.Enabled = false; bfiLabel.Enabled = false;
                        iterationNumeric.Enabled = false; iterationLabel.Enabled = false;
                        break;
                    case "6":
                        matricesNumeric.Enabled = true; matricesLabel.Enabled = true;
                        thresholdNumeric.Enabled = true; thresholdLabel.Enabled = true;
                        depthNumeric.Enabled = false; depthLabel.Enabled = false;
                        bfiNumeric.Enabled = false; bfiLabel.Enabled = false;
                        iterationNumeric.Enabled = false; iterationLabel.Enabled = false;
                        break;
                    case "7":
                        matricesNumeric.Enabled = true; matricesLabel.Enabled = true;
                        thresholdNumeric.Enabled = true; thresholdLabel.Enabled = true;
                        depthNumeric.Enabled = false; depthLabel.Enabled = false;
                        bfiNumeric.Enabled = false; bfiLabel.Enabled = false;
                        iterationNumeric.Enabled = false; iterationLabel.Enabled = false;
                        break;
                    case "16":
                        matricesNumeric.Enabled = true; matricesLabel.Enabled = true;
                        thresholdNumeric.Enabled = true; thresholdLabel.Enabled = true;
                        depthNumeric.Enabled = true; depthLabel.Enabled = true;
                        bfiNumeric.Enabled = true; bfiLabel.Enabled = true;
                        iterationNumeric.Enabled = false; iterationLabel.Enabled = false;
                        break;
                    default:
                        matricesNumeric.Enabled = false; matricesLabel.Enabled = false;
                        thresholdNumeric.Enabled = false; thresholdLabel.Enabled = false;
                        depthNumeric.Enabled = false; depthLabel.Enabled = false;
                        bfiNumeric.Enabled = false; bfiLabel.Enabled = false;
                        iterationNumeric.Enabled = true; iterationLabel.Enabled = true;
                        break;
                }
            }
            else
            {
                iterationNumeric.Enabled = false; iterationLabel.Enabled = false;
                Echo("Last parameters will be used");
            }

        }

        private void restartServicesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            KillDocker();
            Thread.Sleep(100); 
        }

        private void clearConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            output.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var procs = Process.GetProcessesByName("cmd");
            foreach (var proc in procs)
            {
                ShowWindow(proc.MainWindowHandle, 5);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void killServicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KillDocker();
        }

        private void dockerTimer_Tick(object sender, EventArgs e)
        {
            dockerTimeout--;
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/mraposka");
        }

        static void ProcKil(string proc)
        {
            string arg0 = "/F /IM " + proc + ".exe";
            string arg1 = "/F /IM " + proc;  
            Process process = new System.Diagnostics.Process();
            ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            startInfo.CreateNoWindow = true;
            startInfo.FileName = "taskkill";
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.Arguments = arg0;
            process.StartInfo = startInfo;
            process.Start(); 
            process.WaitForExit(); 
            startInfo.Arguments = arg1;
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();

        }
        static void KillDocker()
        {
            ProcKil("docker");
            ProcKil("com.docker.vpnkit");
            ProcKil("com.docker.proxy"); 
            ProcKil("com.docker.backend");
            ProcKil("Docker Desktop");
            ProcKil("Docker Desktop Service");
            ProcKil("com.docker.service");
        }

        private void Form1_Load(object sender, EventArgs e)
        { 
            string algorithms =
            "ALGORITHM = 1 - XZLBZ," +
            "ALGORITHM = 2 - BP," +
            "ALGORITHM = 3 - RNBP," +
            "ALGORITHM = 4 - A1," +
            "ALGORITHM = 5 - A2," +
            "ALGORITHM = 6 - Paar1," +
            "ALGORITHM = 7 - Paar2," +
            "ALGORITHM = 8 - LWFWSW," +
            "ALGORITHM = 9 - BFI," +
            "ALGORITHM = 10 - BFI-Paar1," +
            "ALGORITHM = 11 - BFI-RPaar1," +
            "ALGORITHM = 12 - BFI-BP," +
            "ALGORITHM = 13 - BFI-A1," +
            "ALGORITHM = 14 - BFI-A2," +
            "ALGORITHM = 15 - BFI-RNBP," +
            "ALGORITHM = 16 - BFI-BP-depthConstrained,";
            for (int i = 0; i < algorithms.Split(',').Length - 1; i++)
            {
                algorithmSelection.Items.Add(algorithms.Split(',')[i]);
            }
            StartDocker();
        }

        void Echo(string text, Color color = default)//function that logs with color on terminal 
        {
            output.SelectionStart = output.TextLength;
            output.SelectionLength = 0;
            output.SelectionColor = color == default ? Color.LimeGreen : color;
            output.AppendText(text + Environment.NewLine);
            output.SelectionColor = output.ForeColor;
            Thread.Sleep(100);
            ScrollToBottom(output);
        }
    }
}

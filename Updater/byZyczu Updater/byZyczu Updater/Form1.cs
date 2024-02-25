using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace byZyczu_Updater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        WebClient client = new WebClient();
        string exepath = "c:\\maicjadir\\byzyczu\\zyczumc.exe";
        string dir = "c:\\maicjadir\\byzyczu";
        private async void Form1_Load(object sender, EventArgs e)
        {
            await Task.Delay(100);
            client.DownloadFile("https://github.com/mksmaicja/byZyczu/raw/master/Launcher/byZyczu/bin/Release/byZyczu.exe", exepath);
            await Task.Delay(400);
            System.Diagnostics.ProcessStartInfo startinfo = new System.Diagnostics.ProcessStartInfo
            {
                FileName = exepath,
                ErrorDialog = true,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                WorkingDirectory = dir
            };
            Process.Start(startinfo);
            await Task.Delay(400);
            Application.Exit();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace byZyczu
{
    public partial class Form1 : Form
    {
        //public static string url = "109.231.27.76";
        public static string url = "dev.mksteam.ovh";
        public static string launcherdir = "C:\\maicjadir\\byzyczu";
        public static string configsdir = "C:\\maicjadir\\byzyczu\\configs";
        public Form1()
        {
            InitializeComponent();
            if (!Directory.Exists(launcherdir))
            {
                Directory.CreateDirectory(launcherdir);
            }
            if (!Directory.Exists(configsdir))
            {
                Directory.CreateDirectory(configsdir);
            }
            panel1.BackColor = Color.FromArgb(180, Color.White);
            panelsettings.BackColor = Color.FromArgb(150, Color.White);
            buttonownmods.BackColor = Color.FromArgb(5, Color.White);
            buttonlaunch.BackColor = Color.FromArgb(5, Color.White);
            buttonsettings.BackColor = Color.FromArgb(5, Color.White);
            panelsettings.Visible = false;
            panelsettings.Location = new Point(22, 66);
            paneldownload.Visible = false;
            paneldownload.Location = new Point(22, 66);
            comboBoxRAM.Items.Add("1024M");
            comboBoxRAM.Items.Add("2048M");
            comboBoxRAM.Items.Add("4096M");


            try
            {
                webClientmks.DownloadString("http://" + url + "/index.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                url = "dev.mksteam.ovh";
            }

            depsurl = "http://" + url + "/minecraft/deps/";
        }

        public static string depsurl = "";
        WebClient webClientmks = new WebClient();
        public static string versionname;
        public static string versionzip;
        public static string versionargsp1;
        public static string versionargsp2;
        public static string versionline;
        public static string javapath;
        Random rand = new Random();
        bool downloaded = false;
        public static bool premiumlaunchwait = true;
        public static string version = "1.0";

        public void DownloadFile(string urlAddress, string location)
        {
            progressBar1.Visible = true;
            using (webClient = new WebClient())
            {
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);

                // The variable that will be holding the url address (making sure it starts with http://)
                Uri URL = urlAddress.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ? new Uri(urlAddress) : new Uri("http://" + urlAddress);

                // Start the stopwatch which we will be using to calculate the download speed
                sw.Start();

                try
                {
                    // Start downloading the file
                    webClient.DownloadFileAsync(URL, location);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        WebClient webClient;
        Stopwatch sw = new Stopwatch();
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            downloadlabel.Text = string.Format("{0} kb/s", (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00")) + "\r\n" + string.Format("{0} MB's / {1} MB's",
                (e.BytesReceived / 1024d / 1024d).ToString("0.00"),
                (e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00"));

            progressBar1.Value = e.ProgressPercentage;



        }

        public static bool discordaviable = false;
        public static bool newtowsonaviable = false;
        private async void Completed(object sender, AsyncCompletedEventArgs e)
        {

            sw.Reset();
            if (!discordaviable)
            {
                downloadlabel.Text = "";
                progressBar1.Value = 0;
                progressBar1.Visible = false;
                discordaviable = true;
            }
            else if (!newtowsonaviable)
            {
                downloadlabel.Text = "";
                progressBar1.Value = 0;
                progressBar1.Visible = false;
                newtowsonaviable = true;
            }
            else
            {
                if (e.Cancelled == true)
                {
                    MessageBox.Show("Pobieranie zostało anulowane");
                    progressBar1.Visible = false;
                }
                else
                {
                    downloadlabel.Text = "Wypakowywanie...";
                    progressBar1.Value = 0;
                    progressBar1.Visible = false;

                    Thread.Sleep(100);
                    if (File.Exists(launcherdir + "\\temp.zip"))
                    {
                        await Task.Run(() => ZipFile.ExtractToDirectory(launcherdir + "\\temp.zip", launcherdir));
                        await Task.Delay(100);
                        File.Delete(launcherdir + "\\temp.zip");
                        downloadlabel.Text = "";
                        downloaded = true;
                        buttonlaunch.Text = "Uruchamianie!";
                        if (false) //kopiowanie java args
                        {
                            MessageBox.Show(javapath, "JAVA PATH");
                            MessageBox.Show(versionargsp1 + versionargsp2, "GAME ARGS");
                            Clipboard.SetText(javapath + " " + versionargsp1 + versionargsp2);
                            MessageBox.Show("java + args copied to clipboard!", "CLIPBOARD");
                        }
                        System.Diagnostics.ProcessStartInfo startinfo = new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = javapath,
                            Arguments = versionargsp1 + versionargsp2,
                            ErrorDialog = true,
                            UseShellExecute = false,
                            WorkingDirectory = launcherdir + "\\" + versionzip.Split('.')[0]
                        };
                        using (Process myProcess = Process.Start(startinfo))
                        {
                            Modules.DiscordPresence.SetPresence("Gra w " + versionname);
                            paneldownload.Visible = false;
                            while (!deatach)
                            {
                                //jak kloce wlaczone
                                if (!myProcess.HasExited)
                                {
                                    myProcess.Refresh();
                                    await Task.Delay(1000);
                                    buttonlaunch.Text = "Gra uruchomiona!";
                                }
                                else
                                {
                                    deatach = true;
                                }
                                await Task.Delay(1000);
                                buttonlaunch.Text = "Kliknij aby odpiąć!";
                            }
                        }
                        //TU PO DEATACH/EXIT
                        Modules.DiscordPresence.SetPresence("W Launcherze");
                        buttonlaunch.Text = "Uruchom grę";
                    }
                    else if (File.Exists(launcherdir + "\\tempjava.zip"))
                    {
                        await Task.Run(() => ZipFile.ExtractToDirectory(launcherdir + "\\tempjava.zip", launcherdir));
                        await Task.Delay(100);
                        File.Delete(launcherdir + "\\tempjava.zip");
                        downloadlabel.Text = "";
                        javadwnld = false;
                    }





                }
            }
        }

        public static bool javadwnld = false; public static bool deatach = false;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttoncancessett_Click(object sender, EventArgs e)
        {
            panelsettings.Visible = false;
        }

        private void buttonsettings_Click(object sender, EventArgs e)
        {
            panelsettings.Visible = true;
        }

        private void buttonsavechanges_Click(object sender, EventArgs e)
        {
            string noverify = "UNSET";
            if (checkBoxnoverify.Checked)
            {
                noverify = "true";
            }
            else
            {
                noverify = "false";
            }
            if (!File.Exists(configsdir + "\\settings.mks"))
            {
                using (FileStream fs = File.Create(configsdir + "\\settings.mks"))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes("RAM;" + comboBoxRAM.Text + "\r\nnoverify;" + noverify);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            }
            else
            {
                File.WriteAllText(configsdir + "\\settings.mks", "RAM;" + comboBoxRAM.Text + "\r\nnoverify;" + noverify);
            }
            panelsettings.Visible = false;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await Task.Delay(500);
            if (File.Exists(configsdir + "\\lastversion.mks"))
            {
                comboBox1.Text = File.ReadAllText(configsdir + "\\lastversion.mks").Split(';')[0];
                await Task.Delay(100);
                textBoxnick.Text = File.ReadAllText(configsdir + "\\lastversion.mks").Split(';')[1];
            }
            comboBox1.Items.Clear();
            webClientmks.DownloadFile(depsurl + "relases.txt", launcherdir + "\\relases.list");
            foreach (var line in File.ReadLines(launcherdir + "\\relases.list"))
            {
                string name = line.Split(';')[0];
                comboBox1.Items.Add(name);
            }
            if (File.Exists(launcherdir + "\\custom\\versions.list"))
            {
                foreach (var line in File.ReadLines(launcherdir + "\\custom\\versions.list"))
                {
                    string name = line.Split(';')[0];
                    comboBox1.Items.Add(name);
                }
            }
            if (!File.Exists(".\\DiscordRPC.dll"))
            {
                DownloadFile("http://" + url + "/minecraft/DiscordRPC.dll", ".\\DiscordRPC.dll");
                await Task.Delay(500);
            }
            else
            {
                discordaviable = true;
            }
            while (!discordaviable)
            {
                await Task.Delay(100);
            }
            if (!File.Exists(".\\Newtonsoft.Json.dll"))
            {
                DownloadFile("http://" + url + "/minecraft/Newtonsoft.Json.dll", ".\\Newtonsoft.Json.dll");
                await Task.Delay(500);
            }
            else
            {
                newtowsonaviable = true;
            }
            while (!newtowsonaviable)
            {
                await Task.Delay(100);
            }
            Modules.DiscordPresence.initializediscord("W Launcherze");
            if (File.Exists(configsdir + "\\settings.mks"))
            {
                string ram = "UNSET0";
                bool noverify = false;
                foreach (string s in File.ReadAllLines(configsdir + "\\settings.mks"))
                {
                    if (s.Contains("RAM"))
                    {
                        string state = s.Split(';')[1];
                        ram = state;
                    }
                    else if (s.Contains("noverify"))
                    {
                        string state = s.Split(';')[1];
                        if (state == "true")
                        {
                            noverify = true;
                        }
                        else
                        {
                            noverify = false;
                        }
                    }
                }
                comboBoxRAM.Text = ram;
                checkBoxnoverify.Checked = noverify;            }
        }
        public static bool mclaunched = false;
        private async void buttonlaunch_Click(object sender, EventArgs e)
        {
            string versionselected = comboBox1.Text;
            if (!File.Exists(configsdir + "\\lastversion.mks"))
            {
                using (FileStream fs = File.Create(configsdir + "\\lastversion.mks"))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(versionselected + ";" + textBoxnick.Text);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            }
            else
            {
                File.WriteAllText(configsdir + "\\lastversion.mks", versionselected + ";" + textBoxnick.Text);
            }
            
            if (mclaunched)
            {
                deatach = true;
            }
            else
            {
                paneldownload.Visible = true;

                deatach = false;
                downloaded = false;
                javadwnld = true;
                if (textBoxnick.Text == "")
                {
                    MessageBox.Show("Enter username!");
                }
                else if (textBoxnick.Text.Contains(" "))
                {
                    MessageBox.Show("Username can't contain space!");
                }
                else
                {
                    
                    bool iscustom = true;

                    foreach (var line in File.ReadLines(launcherdir + "\\relases.list"))
                    {
                        string name = line.Split(';')[0];
                        if (name == comboBox1.Text)
                        {

                            iscustom = false;
                            versionname = name;
                            versionzip = line.Split(';')[1];
                            versionargsp1 = webClientmks.DownloadString(depsurl + line.Split(';')[2]).Replace("--username", "&").Split('&')[0];
                            versionargsp2 = "--username" + webClientmks.DownloadString(depsurl + line.Split(';')[2]).Replace("--username", "&").Split('&')[1];
                            string ram = comboBoxRAM.Text.ToString().Replace("M", "");
                            versionargsp1 = versionargsp1.Replace("RAMMB", ram);
                            versionargsp1 = versionargsp1.Replace("LAUNCHERPATHJAVA", launcherdir);
                            versionargsp1 = versionargsp1.Replace("LAUNCHERPATH", launcherdir + "\\" + versionzip.Split('.')[0]);
                            versionargsp2 = versionargsp2.Replace("LAUNCHERPATH", launcherdir + "\\" + versionzip.Split('.')[0]);
                            versionargsp2 = versionargsp2.Replace("USERNAMEMOD", textBoxnick.Text);
                            string uuid = "mks";
                            string token = "mks";
                            for (int i = 3; i < 32; i++)
                            {
                                uuid = uuid + rand.Next(0, 9).ToString();
                                token = token + rand.Next(0, 9).ToString();
                            }

                            premiumlaunchwait = false;
                            versionargsp2 = versionargsp2.Replace("UUID32", uuid);
                            versionargsp2 = versionargsp2.Replace("TOKEN32", token);


                            javapath = versionargsp1.Split('|')[0];
                            versionargsp1 = versionargsp1.Split('|')[1];


                        }
                    }
                    if (iscustom)
                    {
                        foreach (var line in File.ReadLines(launcherdir + "\\custom\\versions.list"))
                        {
                            string name = line.Split(';')[0];
                            if (name == comboBox1.Text)
                            {

                                versionname = name;
                                versionzip = line.Split(';')[1];
                                versionargsp1 = File.ReadAllText(launcherdir + "\\custom\\" + line.Split(';')[2]).Replace("--username", "&").Split('&')[0];
                                versionargsp2 = "--username" + File.ReadAllText(launcherdir + "\\custom\\" + line.Split(';')[2]).Replace("--username", "&").Split('&')[1];
                                string ram = comboBoxRAM.Text.ToString().Replace("M", "");
                                versionargsp1 = versionargsp1.Replace("RAMMB", ram);
                                versionargsp1 = versionargsp1.Replace("LAUNCHERPATHJAVA", launcherdir);
                                versionargsp1 = versionargsp1.Replace("LAUNCHERPATH", launcherdir + "\\custom\\" + versionzip.Split('.')[0]);
                                versionargsp2 = versionargsp2.Replace("LAUNCHERPATH", launcherdir + "\\custom\\" + versionzip.Split('.')[0]);
                                versionargsp2 = versionargsp2.Replace("USERNAMEMOD", textBoxnick.Text);
                                string uuid = "mks";
                                string token = "mks";
                                for (int i = 3; i < 32; i++)
                                {
                                    uuid = uuid + rand.Next(0, 9).ToString();
                                    token = token + rand.Next(0, 9).ToString();
                                }

                                    premiumlaunchwait = false;
                                    versionargsp2 = versionargsp2.Replace("UUID32", uuid);
                                    versionargsp2 = versionargsp2.Replace("TOKEN32", token);

                                javapath = versionargsp1.Split('|')[0];
                                versionargsp1 = versionargsp1.Split('|')[1];


                            }
                        }
                    }
                    if (false) //to do reinstallu javy
                    {
                        if (Directory.Exists(launcherdir + "\\jre"))
                        {
                            Directory.Delete(launcherdir + "\\jre", true);
                        }
                    }
                    if (false) //do reinstallu wersji
                    {
                        if (Directory.Exists(launcherdir + "\\" + versionzip.Split('.')[0]))
                        {
                            Directory.Delete(launcherdir + "\\" + versionzip.Split('.')[0], true);
                        }
                    }

                    if (!Directory.Exists(launcherdir + "\\" + "jre"))
                    {
                        downloadlabel.Text = "JAVA nie jest pobrana!";
                        await Task.Delay(1000);
                        downloadlabel.Text = "Pobieranie środowiska java...";
                        await Task.Delay(1000);
                        DownloadFile(depsurl + "MCJAVA.zip", launcherdir + "\\tempjava.zip");
                        await Task.Delay(100);
                    }
                    else
                    {
                        javadwnld = false;
                    }
                    while (javadwnld)
                    {
                        await Task.Delay(1000);
                    }
                    if (!iscustom)
                    {
                        if (!Directory.Exists(launcherdir + "\\" + versionzip.Split('.')[0]))
                        {
                            DownloadFile(depsurl + versionzip, launcherdir + "\\temp.zip");
                        }
                        else
                        {
                            downloaded = true;
                        }
                    }

                    if (downloaded)
                    {
                        buttonlaunch.Text = "LAUNCHING!";
                        if (false) //kopiowanie java args
                        {
                            MessageBox.Show(javapath, "JAVA PATH");
                            MessageBox.Show(versionargsp1 + versionargsp2, "GAME ARGS");
                            Clipboard.SetText(javapath + " " + versionargsp1 + versionargsp2);
                            MessageBox.Show("java + args copied to clipboard!", "CLIPBOARD");
                        }
                        System.Diagnostics.ProcessStartInfo startinfo = new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = javapath,
                            Arguments = versionargsp1 + versionargsp2,
                            ErrorDialog = true,
                            UseShellExecute = false,
                            WorkingDirectory = launcherdir + "\\" + versionzip.Split('.')[0]
                        };
                        using (Process myProcess = Process.Start(startinfo))
                        {


                            Modules.DiscordPresence.SetPresence("Gra w " + versionname);
                            paneldownload.Visible = false;
                            while (!deatach)
                            {
                                if (!myProcess.HasExited)
                                {
                                    mclaunched = true;
                                    myProcess.Refresh();
                                    await Task.Delay(1000);
                                    buttonlaunch.Text = "Gra uruchomiona!";
                                }
                                else
                                {
                                    deatach = true;
                                }
                                await Task.Delay(1000);
                                buttonlaunch.Text = "Kliknij aby odpiąć!";
                            }
                        }
                        //TU PO DEATACH/EXIT
                        Modules.DiscordPresence.SetPresence("W Launcherze");
                        mclaunched = false;
                        buttonlaunch.Text = "Uruchom grę";
                    }
                }
            }
        }
    }
}

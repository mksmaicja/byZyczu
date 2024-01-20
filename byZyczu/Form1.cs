using byZyczu.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace byZyczu
{
    public partial class Form1 : Form
    {
        //public static string url = "109.231.27.76";
        public static string url = "mksteam.ovh";
        public static string launcherdir = "C:\\maicjadir\\byzyczu";
        public static string configsdir = "C:\\maicjadir\\byzyczu\\configs";
        
        public Form1()
        {
            InitializeComponent();
            
            
            if (!Directory.Exists(configsdir))
            {
                Directory.CreateDirectory(configsdir);
            }
            panel1.BackColor = Color.FromArgb(180, Color.White);
            panelconsole.BackColor = Color.FromArgb(160, Color.White);
            panelsettings.BackColor = Color.FromArgb(150, Color.White);
            buttonownmods.BackColor = Color.FromArgb(5, Color.White);
            buttonlaunch.BackColor = Color.FromArgb(5, Color.White);
            buttonsettings.BackColor = Color.FromArgb(5, Color.White);
            panelsettings.Visible = false;
            panelsettings.Location = new Point(22, 66);
            paneldownload.Visible = false;
            paneldownload.Location = new Point(22, 66);
            paneldownload.BackColor = Color.FromArgb(150, Color.White);
            panelmodsmain.Visible = false;
            panelmodsmain.Location = new Point(22, 66);
            panelmodsmain.BackColor = Color.FromArgb(150, Color.White);
            panelmodpacks.BackColor = Color.FromArgb(180, Color.White);
            panelcreatenewmodpack.BackColor = Color.FromArgb(180, Color.White);
            panelcreatenewmodpack.Location = new Point(22, 66);
            panelcreatenewmodpack.Visible = false;
            comboBoxRAM.Items.Add("1024M");
            comboBoxRAM.Items.Add("2048M");
            comboBoxRAM.Items.Add("3072M");
            comboBoxRAM.Items.Add("4096M");
            comboBoxRAM.Items.Add("5120M");
            comboBoxRAM.Items.Add("6144M");
            comboBoxRAM.Items.Add("7164M");
            comboBoxRAM.Items.Add("8192M");
            comboBoxRAM.Items.Add("9216M");
            comboBoxRAM.Items.Add("10240M");
            comboBoxRAM.Items.Add("11264M");
            comboBoxRAM.Items.Add("12288M");
            try
            {
                webClientmks.DownloadString("http://" + url + "/index.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\nPrzełączam na lokalny serwer...", "BŁĄD POŁĄCZENIA");
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
        public static string version = "1.3";

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
            downloadlabel.Text = string.Format("{0} kb/s", (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00")) + string.Format("\r\n{0} MB's / {1} MB's",
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
                        if (checkBoxnoverify.Checked)
                        {
                            versionargsp1 = "-noverify " + versionargsp1;
                        }
                        

                            if (File.Exists(launcherdir + "\\" + versionzip.Split('.')[0] + "\\game\\tempModList-1703628101391"))
                            {
                                string ddd = File.ReadAllText(launcherdir + "\\" + versionzip.Split('.')[0] + "\\game\\tempModList-1703628101391");
                                if (ddd.Contains("LAUNCHERPATH"))
                                {
                                    string fixedfor1122optifine = launcherdir + "\\" + versionzip.Split('.')[0];
                                    fixedfor1122optifine = fixedfor1122optifine.Replace("\\", "\\\\");
                                    ddd = ddd.Replace("LAUNCHERPATH", fixedfor1122optifine);

                                    File.WriteAllText(launcherdir + "\\" + versionzip.Split('.')[0] + "\\game\\tempModList-1703628101391", ddd);
                                }
                                else
                                {
                                    string libspath = ddd.Replace("{\"repositoryRoot\":\"absolute:", "").Replace("\",\"modRef\":[\"optifine:OptiFine:1.12.2_HD_U_G5\"]}", "");
                                    if (!Directory.Exists(libspath))
                                    {
                                        ddd = ddd.Replace(libspath, "LAUNCHERPATH" + "\\game\\libraries");
                                        string fixedfor1122optifine = launcherdir + "\\" + versionzip.Split('.')[0];
                                        fixedfor1122optifine = fixedfor1122optifine.Replace("\\", "\\\\");
                                        ddd = ddd.Replace("LAUNCHERPATH", fixedfor1122optifine);
                                        File.WriteAllText(launcherdir + "\\" + versionzip.Split('.')[0] + "\\game\\tempModList-1703628101391", ddd);
                                    }
                                }
                            }
                        

                        System.Diagnostics.ProcessStartInfo startinfo = new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = javapath,
                            Arguments = versionargsp1 + versionargsp2,
                            ErrorDialog = true,
                            RedirectStandardError = true,
                            RedirectStandardOutput = true,
                            UseShellExecute = false,
                            WorkingDirectory = launcherdir + "\\" + versionzip.Split('.')[0]

                        };
                        using (Process myProcess = Process.Start(startinfo))
                        {
                            stream = myProcess.StandardOutput;

                            Modules.DiscordPresence.SetPresence("Gra w " + versionname);
                            paneldownload.Visible = false;
                            buttonlaunch.Text = "Gra uruchomiona!";
                            Task.Run(() => {
                                readstream();
                            });
                            while (!deatach)
                            {
                                //jak kloce wlaczone
                                if (!myProcess.HasExited)
                                {
                                    myProcess.Refresh();

                                    
                                }
                                else
                                {
                                    deatach = true;
                                }
                                await Task.Delay(1000);
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
        static void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            Console.WriteLine(outLine.Data);
        }
        public static bool javadwnld = false; 
        public static bool deatach = false;
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
            if (!File.Exists(launcherdir + "\\usermodpacks.mks"))
            {
                using (FileStream fs = File.Create(launcherdir + "\\usermodpacks.mks"))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(" ");
                    fs.Write(info, 0, info.Length);
                }
            }
            label1.Text = version + " C# version by maicja";
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
            foreach (var line in File.ReadLines(launcherdir + "\\usermodpacks.mks"))
            {
                if (line.Contains("-"))
                {
                    string name = line.Split(';')[0];
                    comboBox1.Items.Add(name);
                }
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
            await Task.Delay(10);
            while (!discordaviable)
            {
                await Task.Delay(100);
            }
            await Task.Delay(10);
            if (!File.Exists(".\\Newtonsoft.Json.dll"))
            {
                DownloadFile("http://" + url + "/minecraft/Newtonsoft.Json.dll", ".\\Newtonsoft.Json.dll");
                await Task.Delay(500);
            }
            else
            {
                newtowsonaviable = true;
            }
            await Task.Delay(10);
            while (!newtowsonaviable)
            {
                await Task.Delay(100);
            }
            await Task.Delay(10);
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
                checkBoxnoverify.Checked = noverify;            
            }


            

            while (true)
            {
                if (mclaunched)
                {
                    if (stream2 == " ")
                    {

                    }
                    else
                    {
                        if (richTextBoxconsole.Text.Length > 2147480647)
                        {
                            richTextBoxconsole.Text = "LOGI GRY:";
                        }
                        panelconsole.Visible = true;
                        richTextBoxconsole.Text = richTextBoxconsole.Text + "\r\n" + stream2;
                        stream2 = " ";
                        richTextBoxconsole.SelectionStart = richTextBoxconsole.TextLength;
                        richTextBoxconsole.ScrollToCaret();
                    }
                    
                }
                else
                {
                    panelconsole.Visible = false;
                    stream2 = "LOGI GRY:";
                    richTextBoxconsole.Text = "";
                }
                await Task.Delay(1000);
            }
        }
        public static PrivateFontCollection fr = new PrivateFontCollection();
        public static bool mclaunched = false;
        private async void buttonlaunch_Click(object sender, EventArgs e)
        {
            try
            {
                int rel = rand.Next(0, 3);
                switch (rel)
                {
                    case 0:
                        webBrowserdownload.Url = new Uri("http://minecraft.zyczu.pl/");
                        break;
                    case 1:
                        webBrowserdownload.Url = new Uri("https://classic.minecraft.net/");
                        break;
                    case 2:
                        webBrowserdownload.Url = new Uri("https://kypello.itch.io/kill-the-ice-age-baby-adventure-the-game/");
                        break;

                }
                
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
                        MessageBox.Show("Wpisz nick!");
                    }
                    else if (textBoxnick.Text.Contains(" "))
                    {
                        MessageBox.Show("Nick nie może zawierać spacji!");
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
                                
                                if (File.Exists(launcherdir + "\\" + versionzip.Split('.')[0] + "\\game\\tempModList-1703628101391"))
                                {
                                    string ddd = File.ReadAllText(launcherdir + "\\" + versionzip.Split('.')[0] + "\\game\\tempModList-1703628101391");
                                    if (ddd.Contains("LAUNCHERPATH"))
                                    {
                                        string fixedfor1122optifine = launcherdir + "\\" + versionzip.Split('.')[0];
                                        fixedfor1122optifine = fixedfor1122optifine.Replace("\\", "\\\\");
                                        ddd = ddd.Replace("LAUNCHERPATH", fixedfor1122optifine);

                                        File.WriteAllText(launcherdir + "\\" + versionzip.Split('.')[0] + "\\game\\tempModList-1703628101391", ddd);
                                    }
                                    else
                                    {
                                        string libspath = ddd.Replace("{\"repositoryRoot\":\"absolute:", "").Replace("\",\"modRef\":[\"optifine:OptiFine:1.12.2_HD_U_G5\"]}", "");
                                        if (!Directory.Exists(libspath))
                                        {
                                            ddd = ddd.Replace(libspath, "LAUNCHERPATH" + "\\game\\libraries");
                                            string fixedfor1122optifine = launcherdir + "\\" + versionzip.Split('.')[0];
                                            fixedfor1122optifine = fixedfor1122optifine.Replace("\\", "\\\\");
                                            ddd = ddd.Replace("LAUNCHERPATH", fixedfor1122optifine);
                                            File.WriteAllText(launcherdir + "\\" + versionzip.Split('.')[0] + "\\game\\tempModList-1703628101391", ddd);
                                        }
                                    }
                                }
                                string uuid = "892";
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
                            foreach (var line in File.ReadLines(launcherdir + "\\usermodpacks.mks"))
                            {
                                string name = line.Split(';')[0];
                                if (name == comboBox1.Text)
                                {
                                    versionname = name;
                                    versionzip = line.Split(';')[1];
                                    string argsfile = "unset";
                                    foreach (var line2 in File.ReadLines(launcherdir + "\\relases.list"))
                                    {
                                        if (line2.Contains(name.Split('-')[1] + ";"))
                                        {
                                            argsfile = line2.Split(';')[2];
                                        }
                                    }
                                    versionargsp1 = webClientmks.DownloadString(depsurl + argsfile).Replace("--username", "&").Split('&')[0];
                                    versionargsp2 = "--username" + webClientmks.DownloadString(depsurl + argsfile).Replace("--username", "&").Split('&')[1];
                                    string ram = comboBoxRAM.Text.ToString().Replace("M", "");
                                    versionargsp1 = versionargsp1.Replace("RAMMB", ram);
                                    versionargsp1 = versionargsp1.Replace("LAUNCHERPATHJAVA", launcherdir);
                                    versionargsp1 = versionargsp1.Replace("LAUNCHERPATH", launcherdir + "\\" + versionzip);
                                    versionargsp2 = versionargsp2.Replace("LAUNCHERPATH", launcherdir + "\\" + versionzip);
                                    versionargsp2 = versionargsp2.Replace("USERNAMEMOD", textBoxnick.Text);
                                    if (File.Exists(launcherdir + "\\" + versionzip + "\\game\\tempModList-1703628101391"))
                                    {
                                        string ddd = File.ReadAllText(launcherdir + "\\" + versionzip + "\\game\\tempModList-1703628101391");
                                        if (ddd.Contains("LAUNCHERPATH"))
                                        {
                                            string fixedfor1122optifine = launcherdir + "\\" + versionzip;
                                            fixedfor1122optifine = fixedfor1122optifine.Replace("\\", "\\\\");
                                            ddd = ddd.Replace("LAUNCHERPATH", fixedfor1122optifine);
                                            
                                            File.WriteAllText(launcherdir + "\\" + versionzip + "\\game\\tempModList-1703628101391", ddd);
                                        }
                                        else
                                        {
                                            string libspath = ddd.Replace("{\"repositoryRoot\":\"absolute:", "").Replace("\",\"modRef\":[\"optifine:OptiFine:1.12.2_HD_U_G5\"]}", "");
                                            if (!Directory.Exists(libspath))
                                            {
                                                ddd = ddd.Replace(libspath, "LAUNCHERPATH" + "\\game\\libraries");
                                                string fixedfor1122optifine = launcherdir + "\\" + versionzip;
                                                fixedfor1122optifine = fixedfor1122optifine.Replace("\\", "\\\\");
                                                ddd = ddd.Replace("LAUNCHERPATH", fixedfor1122optifine);
                                                File.WriteAllText(launcherdir + "\\" + versionzip + "\\game\\tempModList-1703628101391", ddd);
                                            }
                                        }
                                    }
                                    string uuid = "892";
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
                            javadwnld = true;
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
                        else
                        {
                            downloaded = true;
                        }

                        if (downloaded)
                        {
                            
                            string wersjaczycosnwm = versionzip.Split('.')[0];
                            if (iscustom)
                            {
                                wersjaczycosnwm = versionzip;
                            }
                            buttonlaunch.Text = "Włączanie!";
                            if (false) //kopiowanie java args
                            {
                                MessageBox.Show(javapath, "JAVA PATH");
                                MessageBox.Show(versionargsp1 + versionargsp2, "GAME ARGS");
                                Clipboard.SetText(javapath + " " + versionargsp1 + versionargsp2);
                                MessageBox.Show("java + args copied to clipboard!", "CLIPBOARD");
                            }
                            if (checkBoxnoverify.Checked)
                            {
                                versionargsp1 = "-noverify " + versionargsp1;
                            }
                            System.Diagnostics.ProcessStartInfo startinfo = new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = javapath,
                                Arguments = versionargsp1 + versionargsp2,
                                ErrorDialog = true,
                                RedirectStandardError = true,
                                RedirectStandardOutput = true,
                                UseShellExecute = false,

                                WorkingDirectory = launcherdir + "\\" + wersjaczycosnwm
                            };
                            using (Process myProcess = Process.Start(startinfo))
                            {
                                stream = myProcess.StandardOutput;

                                Modules.DiscordPresence.SetPresence("Gra w " + versionname);
                                paneldownload.Visible = false;
                                buttonlaunch.Text = "Gra uruchomiona!";
                                Task.Run(() => {
                                    readstream();
                                });
                                while (!deatach)
                                {
                                    if (!myProcess.HasExited)
                                    {
                                        mclaunched = true;
                                        myProcess.Refresh();
                                        
                                    }
                                    else
                                    {
                                        deatach = true;
                                    }
                                    await Task.Delay(1000);
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
            catch (Exception ex)
            {
                deatach = true;
                MessageBox.Show("Paczka z którą chcesz włączyć grę prawdopodobnie została przez ciebie usunięta! Jeżeli uważasz, że gre wywala z winy programu wyślij screena tego błędu na naszego discorda!\r\nSzczegółowy błąd: " + ex.Message, "BŁĄD PODCZAS WŁĄCZANIA GRY!");
                Modules.DiscordPresence.SetPresence("W Launcherze");
                paneldownload.Visible = false;
                mclaunched = false;
                buttonlaunch.Text = "Uruchom grę";
            }
        }
        public static StreamReader stream;
        public static async void readstream()
        {
            while (!deatach)
            {
                try
                {
                    while (!stream.EndOfStream)
                    {
                        stream2 = stream2 + "\r\n" + stream.ReadLine();
                        
                    }
                }
                catch (Exception) { }
            }
        }
        public static string stream2 = "LOGI GRY:";
        public async void updateusermodpacks()
        {
            await Task.Delay(50);
            comboBoxmodpacks.Items.Clear();
            foreach (string line in File.ReadAllLines(launcherdir + "\\usermodpacks.mks"))
            {
                if (line.Contains(';'))
                {
                    string modpackname = line.Split(';')[0];
                    comboBoxmodpacks.Items.Add(modpackname);
                }
            }
            comboBox1.Items.Clear();
            webClientmks.DownloadFile(depsurl + "relases.txt", launcherdir + "\\relases.list");
            foreach (var line in File.ReadLines(launcherdir + "\\relases.list"))
            {
                string name = line.Split(';')[0];
                comboBox1.Items.Add(name);
            }
            foreach (var line in File.ReadLines(launcherdir + "\\usermodpacks.mks"))
            {
                if (line.Contains("-"))
                {
                    string name = line.Split(';')[0];
                    comboBox1.Items.Add(name);
                }
            }
        }

        private void buttonownmods_Click(object sender, EventArgs e)
        {
            updateusermodpacks();
            panelmodsmain.Visible = true;
        }

        private void buttonclosemods_Click(object sender, EventArgs e)
        {
            panelmodsmain.Visible = false;
        }

        private void comboBoxmodpacks_SelectionChangeCommitted(object sender, EventArgs e)
        {

            string mcver = comboBoxmodpacks.SelectedItem.ToString().Split('-')[0];

            string modpackname = comboBoxmodpacks.SelectedItem.ToString().Split('-')[1];
            textBoxmodsmcversion.Text = modpackname;
            textboxmodpackname.Text = mcver;
        }

        private async void button1_Click(object sender, EventArgs e) //zmiana nazwy
        {
            try
            {
                if (textboxmodpackname.Text.StartsWith(" "))
                {
                    MessageBox.Show("Nazwa paczki nie może zaczynać się spacją!");
                }
                else if (textboxmodpackname.Text.EndsWith(" "))
                {
                    MessageBox.Show("Nazwa paczki nie może kończyć się spacją!");
                }
                else if (textboxmodpackname.Text.Contains('\\') || textboxmodpackname.Text.Contains('/') || textboxmodpackname.Text.Contains(':') || textboxmodpackname.Text.Contains('*') || textboxmodpackname.Text.Contains('?') || textboxmodpackname.Text.Contains('"') || textboxmodpackname.Text.Contains('<') || textboxmodpackname.Text.Contains('>') || textboxmodpackname.Text.Contains('|') || textboxmodpackname.Text.Contains('-'))
                {
                    MessageBox.Show("Nazwa paczki zawiera niedozwolone znaki!");
                }
                else
                {
                    comboBoxmodpacks.Items.Clear();
                    string newfile = "";
                    foreach (string line in File.ReadAllLines(launcherdir + "\\usermodpacks.mks"))
                    {
                        string fr;
                        if (line.Split(';')[0] == comboBoxmodpacks.Text)
                        {
                            string args = line.Split(';')[2];
                            string mcver2 = line.Split(';')[1];
                            string mcver = line.Split(';')[0];
                            string tomove = mcver2;
                            mcver = mcver.Split('-')[1];
                            string modpackname = textboxmodpackname.Text;
                            string modpacknamemyslnik = modpackname.Replace(" ", "-");
                            fr = modpackname + "-" + mcver + ";" + modpacknamemyslnik + "-" + mcver.Replace(" ", "-") + ";" + args;
                            Directory.Move(launcherdir + "\\" + tomove, launcherdir + "\\" + modpacknamemyslnik + "-" + mcver.Replace(" ", "-"));
                            newfile = newfile + "\r\n" + fr;
                        }
                        else if (line.Contains('-'))
                        {
                            fr = line;
                            newfile = newfile + "\r\n" + fr;
                        }

                    }
                    File.WriteAllText(launcherdir + "\\usermodpacks.mks", newfile);
                    await Task.Delay(100);
                    updateusermodpacks();
                }
            }
            catch (Exception) { }
        }

        private async void button2_Click(object sender, EventArgs e) //chyba delete modpack 
        {
            comboBoxmodpacks.Items.Clear();
            string newfile = "";
            foreach (string line in File.ReadAllLines(launcherdir + "\\usermodpacks.mks"))
            {
                string fr;
                if (line.Contains(comboBoxmodpacks.Text))
                {
                    
                    Directory.Delete(launcherdir + "\\" + line.Split(';')[1], true);
                }
                else
                {
                    fr = line;
                    newfile = newfile + "\r\n" + fr;
                }
            }
            File.WriteAllText(launcherdir + "\\usermodpacks.mks", newfile);
            if (comboBox1.Text == comboBoxmodpacks.Text)
            {
                comboBox1.Text = "";
            }
            comboBoxmodpacks.Text = "";
            updateusermodpacks();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panelcreatenewmodpack.Visible = false;
            panelmodsmain.Visible = true;
        }

        private async void button5_Click(object sender, EventArgs e) //dalej w tworzeniu modpacka
        {
            string modpackver = comboBoxmodpackcreate.Text;
            string modpackname = textBoxpackcreatename.Text;
            if (modpackname.StartsWith(" "))
            {
                MessageBox.Show("Nazwa paczki nie może zaczynać się spacją!");
            }
            else if (modpackname.EndsWith(" "))
            {
                MessageBox.Show("Nazwa paczki nie może kończyć się spacją!");
            }
            else if (modpackname.Contains('\\') || modpackname.Contains('/') || modpackname.Contains(':') || modpackname.Contains('*') || modpackname.Contains('?') || modpackname.Contains('"') || modpackname.Contains('<') || modpackname.Contains('>') || modpackname.Contains('|') || modpackname.Contains('-'))
            {
                MessageBox.Show("Nazwa paczki zawiera niedozwolone znaki!");
            }
            else
            {
                panelcreatenewmodpack.Visible = false;
                
                foreach (string line in File.ReadAllLines(launcherdir + "\\relases.list"))
                {
                    if (line.Contains(modpackver + ";"))
                    {
                        if (Directory.Exists(launcherdir + "\\" + modpackname + "-" + line.Split(';')[1]))
                        {
                            MessageBox.Show("Paczka modów z taką nazwą już istnieje!");
                        }
                        else
                        {
                            modpackname = modpackname.Replace(" ", "-");
                            CopyDirectory(launcherdir + "\\" + line.Split(';')[1].Replace(".zip", ""), launcherdir + "\\" + modpackname + "-" + line.Split(';')[1]);
                            string userversions = File.ReadAllText(launcherdir + "\\usermodpacks.mks");
                            userversions = userversions + "\r\n" + modpackname.Replace("-", " ") + "-" + modpackver + ";" + modpackname + "-" + line.Split(';')[1] + ";" + line.Split(';')[2];
                            await Task.Delay(100);
                            File.WriteAllText(launcherdir + "\\usermodpacks.mks", userversions);
                        }
                    }
                }
                updateusermodpacks();
                panelmodsmain.Visible = true;


            }
        }
        private static void CopyDirectory(string sourcePath, string targetPath)
        {
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            }
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            panelcreatenewmodpack.Visible = true;
            panelmodsmain.Visible = false;
            comboBoxmodpackcreate.Items.Clear();
            foreach (string line in File.ReadAllLines(launcherdir + "\\relases.list"))
            {
                if (line.Contains("Forge") || line.Contains("Fabric") || line.Contains("mods"))
                {
                    if (Directory.Exists(launcherdir + "\\" + line.Split(';')[1].Replace(".zip", "")))
                    {
                        comboBoxmodpackcreate.Items.Add(line.Split(';')[0]);
                    }
                }
            }
        }

        private void comboBoxmodpackcreate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonmanagemods_Click(object sender, EventArgs e)
        {
            try
            {
                foreach(string line in File.ReadAllLines(launcherdir + "\\usermodpacks.mks"))
                {
                    if (line.Split(';')[0] == comboBoxmodpacks.Text)
                    {
                        Process.Start(launcherdir + "\\" + line.Split(';')[1] + "\\game\\mods");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie wybrałeś paczki modów! Pełny błąd:\r\n" + ex.Message, "BŁĄD");
            }
        }
    }
}

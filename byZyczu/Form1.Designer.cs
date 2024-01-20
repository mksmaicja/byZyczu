using byZyczu.Properties;
using System.Drawing.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Linq;
using System.IO;

namespace byZyczu
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            if (!Directory.Exists(launcherdir))
            {
                Directory.CreateDirectory(launcherdir);
            }
            if (!File.Exists(launcherdir + "\\minecraftzyczu.ttf"))
            {
                using (FileStream fs = File.Create(launcherdir + "\\minecraftzyczu.ttf"))
                {
                    byte[] info = Resources.minecraftzyczu;
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            }
            else
            {
                File.WriteAllBytes(launcherdir + "\\minecraftzyczu.ttf", Resources.minecraftzyczu);
            }







            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBoxnick = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonsettings = new System.Windows.Forms.Button();
            this.buttonownmods = new System.Windows.Forms.Button();
            this.buttonlaunch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelsettings = new System.Windows.Forms.Panel();
            this.checkBoxnoverify = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxRAM = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttoncancessett = new System.Windows.Forms.Button();
            this.buttonsavechanges = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.paneldownload = new System.Windows.Forms.Panel();
            this.webBrowserdownload = new System.Windows.Forms.WebBrowser();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.downloadlabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panelmodsmain = new System.Windows.Forms.Panel();
            this.panelmanageversions = new System.Windows.Forms.Panel();
            this.comboBoxmanageversions = new System.Windows.Forms.ComboBox();
            this.button7 = new System.Windows.Forms.Button();
            this.buttonclosemods = new System.Windows.Forms.Button();
            this.comboBoxmodpacks = new System.Windows.Forms.ComboBox();
            this.panelmodpacks = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textboxmodpackname = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxmodsmcversion = new System.Windows.Forms.TextBox();
            this.buttonmanageversions = new System.Windows.Forms.Button();
            this.buttonmodpacks = new System.Windows.Forms.Button();
            this.buttonmanagemods = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.panelcreatenewmodpack = new System.Windows.Forms.Panel();
            this.textBoxpackcreatename = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.comboBoxmodpackcreate = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panelconsole = new System.Windows.Forms.Panel();
            this.richTextBoxconsole = new System.Windows.Forms.RichTextBox();






            fr.AddFontFile(launcherdir + "\\minecraftzyczu.ttf");





            this.panel1.SuspendLayout();
            this.panelsettings.SuspendLayout();
            this.paneldownload.SuspendLayout();
            this.panelmodsmain.SuspendLayout();
            this.panelmanageversions.SuspendLayout();
            this.panelmodpacks.SuspendLayout();
            this.panelcreatenewmodpack.SuspendLayout();
            this.panelconsole.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.textBoxnick);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.buttonsettings);
            this.panel1.Controls.Add(this.buttonownmods);
            this.panel1.Controls.Add(this.buttonlaunch);
            this.panel1.Location = new System.Drawing.Point(480, 303);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(348, 152);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font(fr.Families[0], 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(60, 74);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(273, 23);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // textBoxnick
            // 
            this.textBoxnick.Font = new System.Drawing.Font(fr.Families[0], 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxnick.Location = new System.Drawing.Point(96, 43);
            this.textBoxnick.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxnick.Name = "textBoxnick";
            this.textBoxnick.Size = new System.Drawing.Size(240, 21);
            this.textBoxnick.TabIndex = 6;
            this.textBoxnick.Text = "twoj_nick";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font(fr.Families[0], 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 77);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Mody:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font(fr.Families[0], 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 45);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Twój Nick:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font(fr.Families[0], 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Minecraft Launcher by Zyczu";
            // 
            // buttonsettings
            // 
            this.buttonsettings.BackgroundImage = global::byZyczu.Properties.Resources.package_settings;
            this.buttonsettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonsettings.Location = new System.Drawing.Point(8, 109);
            this.buttonsettings.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonsettings.Name = "buttonsettings";
            this.buttonsettings.Size = new System.Drawing.Size(40, 40);
            this.buttonsettings.TabIndex = 2;
            this.buttonsettings.UseVisualStyleBackColor = true;
            this.buttonsettings.Click += new System.EventHandler(this.buttonsettings_Click);
            // 
            // buttonownmods
            // 
            this.buttonownmods.Location = new System.Drawing.Point(53, 109);
            this.buttonownmods.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonownmods.Name = "buttonownmods";
            this.buttonownmods.Size = new System.Drawing.Size(140, 40);
            this.buttonownmods.TabIndex = 1;
            this.buttonownmods.Text = "Własne mody";
            this.buttonownmods.UseVisualStyleBackColor = true;
            this.buttonownmods.Click += new System.EventHandler(this.buttonownmods_Click);
            // 
            // buttonlaunch
            // 
            this.buttonlaunch.Font = new System.Drawing.Font(fr.Families[0], 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonlaunch.Location = new System.Drawing.Point(200, 109);
            this.buttonlaunch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonlaunch.Name = "buttonlaunch";
            this.buttonlaunch.Size = new System.Drawing.Size(136, 40);
            this.buttonlaunch.TabIndex = 0;
            this.buttonlaunch.Text = "Uruchom grę";
            this.buttonlaunch.UseVisualStyleBackColor = true;
            this.buttonlaunch.Click += new System.EventHandler(this.buttonlaunch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(660, 458);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "1.0 C# version by maicja";
            // 
            // panelsettings
            // 
            this.panelsettings.Controls.Add(this.checkBoxnoverify);
            this.panelsettings.Controls.Add(this.label10);
            this.panelsettings.Controls.Add(this.label11);
            this.panelsettings.Controls.Add(this.comboBoxRAM);
            this.panelsettings.Controls.Add(this.label8);
            this.panelsettings.Controls.Add(this.label7);
            this.panelsettings.Controls.Add(this.buttoncancessett);
            this.panelsettings.Controls.Add(this.buttonsavechanges);
            this.panelsettings.Controls.Add(this.label6);
            this.panelsettings.Controls.Add(this.label5);
            this.panelsettings.Location = new System.Drawing.Point(824, 66);
            this.panelsettings.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelsettings.Name = "panelsettings";
            this.panelsettings.Size = new System.Drawing.Size(805, 405);
            this.panelsettings.TabIndex = 2;
            // 
            // checkBoxnoverify
            // 
            this.checkBoxnoverify.AutoSize = true;
            this.checkBoxnoverify.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxnoverify.Location = new System.Drawing.Point(52, 227);
            this.checkBoxnoverify.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxnoverify.Name = "checkBoxnoverify";
            this.checkBoxnoverify.Size = new System.Drawing.Size(66, 17);
            this.checkBoxnoverify.TabIndex = 9;
            this.checkBoxnoverify.Text = "-noverify";
            this.checkBoxnoverify.UseVisualStyleBackColor = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font(fr.Families[0], 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(48, 181);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(425, 30);
            this.label10.TabIndex = 8;
            this.label10.Text = "Dodaje do argumentów uruchamiania opcje \"-noverify\" dzięki czemu wyłącza\r\nweryfik" +
    "ację dodatkowych klas w wybranej wersji gry.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font(fr.Families[0], 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 156);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 20);
            this.label11.TabIndex = 7;
            this.label11.Text = "No verify";
            // 
            // comboBoxRAM
            // 
            this.comboBoxRAM.FormattingEnabled = true;
            this.comboBoxRAM.Location = new System.Drawing.Point(192, 120);
            this.comboBoxRAM.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxRAM.Name = "comboBoxRAM";
            this.comboBoxRAM.Size = new System.Drawing.Size(120, 21);
            this.comboBoxRAM.TabIndex = 6;
            this.comboBoxRAM.Text = "2048M";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font(fr.Families[0], 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(48, 122);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 15);
            this.label8.TabIndex = 5;
            this.label8.Text = "Ilość pamięci RAM:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font(fr.Families[0], 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(48, 79);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(414, 30);
            this.label7.TabIndex = 4;
            this.label7.Text = "Dzięki temu ustawieniu możesz przypisać ile java ma używać pamięci ram,\r\npamiętaj" +
    " żeby nie ustawiać więcej niż masz wolnej pamięci!\r\n";
            // 
            // buttoncancessett
            // 
            this.buttoncancessett.Location = new System.Drawing.Point(405, 354);
            this.buttoncancessett.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttoncancessett.Name = "buttoncancessett";
            this.buttoncancessett.Size = new System.Drawing.Size(140, 40);
            this.buttoncancessett.TabIndex = 3;
            this.buttoncancessett.Text = "Anuluj";
            this.buttoncancessett.UseVisualStyleBackColor = true;
            this.buttoncancessett.Click += new System.EventHandler(this.buttoncancessett_Click);
            // 
            // buttonsavechanges
            // 
            this.buttonsavechanges.Location = new System.Drawing.Point(260, 354);
            this.buttonsavechanges.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonsavechanges.Name = "buttonsavechanges";
            this.buttonsavechanges.Size = new System.Drawing.Size(140, 40);
            this.buttonsavechanges.TabIndex = 2;
            this.buttonsavechanges.Text = "Zapisz zmiany";
            this.buttonsavechanges.UseVisualStyleBackColor = true;
            this.buttonsavechanges.Click += new System.EventHandler(this.buttonsavechanges_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font(fr.Families[0], 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(336, 10);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 24);
            this.label6.TabIndex = 1;
            this.label6.Text = "Ustawienia";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font(fr.Families[0], 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 54);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Pamięć ram";
            // 
            // paneldownload
            // 
            this.paneldownload.Controls.Add(this.webBrowserdownload);
            this.paneldownload.Controls.Add(this.progressBar1);
            this.paneldownload.Controls.Add(this.downloadlabel);
            this.paneldownload.Controls.Add(this.label9);
            this.paneldownload.Location = new System.Drawing.Point(836, 55);
            this.paneldownload.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.paneldownload.Name = "paneldownload";
            this.paneldownload.Size = new System.Drawing.Size(805, 405);
            this.paneldownload.TabIndex = 10;
            // 
            // webBrowserdownload
            // 
            this.webBrowserdownload.Location = new System.Drawing.Point(24, 96);
            this.webBrowserdownload.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.webBrowserdownload.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserdownload.Name = "webBrowserdownload";
            this.webBrowserdownload.ScriptErrorsSuppressed = true;
            this.webBrowserdownload.Size = new System.Drawing.Size(756, 290);
            this.webBrowserdownload.TabIndex = 3;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(16, 72);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(772, 17);
            this.progressBar1.TabIndex = 2;
            // 
            // downloadlabel
            // 
            this.downloadlabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadlabel.AutoSize = true;
            this.downloadlabel.BackColor = System.Drawing.Color.Transparent;
            this.downloadlabel.Location = new System.Drawing.Point(328, 44);
            this.downloadlabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.downloadlabel.Name = "downloadlabel";
            this.downloadlabel.Size = new System.Drawing.Size(91, 13);
            this.downloadlabel.TabIndex = 1;
            this.downloadlabel.Text = "Ukończono 69 % ";
            this.downloadlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font(fr.Families[0], 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(275, 11);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(216, 24);
            this.label9.TabIndex = 0;
            this.label9.Text = "Trwa instalacja modów...";
            // 
            // panelmodsmain
            // 
            this.panelmodsmain.Controls.Add(this.panelmanageversions);
            this.panelmodsmain.Controls.Add(this.buttonclosemods);
            this.panelmodsmain.Controls.Add(this.comboBoxmodpacks);
            this.panelmodsmain.Controls.Add(this.panelmodpacks);
            this.panelmodsmain.Controls.Add(this.buttonmanageversions);
            this.panelmodsmain.Controls.Add(this.buttonmodpacks);
            this.panelmodsmain.Controls.Add(this.buttonmanagemods);
            this.panelmodsmain.Controls.Add(this.label16);
            this.panelmodsmain.Location = new System.Drawing.Point(13, 36);
            this.panelmodsmain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelmodsmain.Name = "panelmodsmain";
            this.panelmodsmain.Size = new System.Drawing.Size(805, 405);
            this.panelmodsmain.TabIndex = 10;
            // 
            // panelmanageversions
            // 
            this.panelmanageversions.Controls.Add(this.comboBoxmanageversions);
            this.panelmanageversions.Controls.Add(this.button7);
            this.panelmanageversions.Location = new System.Drawing.Point(12, 72);
            this.panelmanageversions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelmanageversions.Name = "panelmanageversions";
            this.panelmanageversions.Size = new System.Drawing.Size(780, 329);
            this.panelmanageversions.TabIndex = 8;
            // 
            // comboBoxmanageversions
            // 
            this.comboBoxmanageversions.Font = new System.Drawing.Font(fr.Families[0], 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxmanageversions.FormattingEnabled = true;
            this.comboBoxmanageversions.Location = new System.Drawing.Point(24, 12);
            this.comboBoxmanageversions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxmanageversions.Name = "comboBoxmanageversions";
            this.comboBoxmanageversions.Size = new System.Drawing.Size(623, 21);
            this.comboBoxmanageversions.TabIndex = 6;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(655, 11);
            this.button7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(103, 23);
            this.button7.TabIndex = 4;
            this.button7.Text = "Usuń";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // buttonclosemods
            // 
            this.buttonclosemods.BackColor = System.Drawing.Color.Transparent;
            this.buttonclosemods.BackgroundImage = global::byZyczu.Properties.Resources.zamknij;
            this.buttonclosemods.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonclosemods.Location = new System.Drawing.Point(765, 42);
            this.buttonclosemods.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonclosemods.Name = "buttonclosemods";
            this.buttonclosemods.Size = new System.Drawing.Size(27, 26);
            this.buttonclosemods.TabIndex = 6;
            this.buttonclosemods.UseVisualStyleBackColor = false;
            this.buttonclosemods.Click += new System.EventHandler(this.buttonclosemods_Click);
            // 
            // comboBoxmodpacks
            // 
            this.comboBoxmodpacks.Font = new System.Drawing.Font(fr.Families[0], 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxmodpacks.FormattingEnabled = true;
            this.comboBoxmodpacks.Location = new System.Drawing.Point(439, 45);
            this.comboBoxmodpacks.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxmodpacks.Name = "comboBoxmodpacks";
            this.comboBoxmodpacks.Size = new System.Drawing.Size(325, 21);
            this.comboBoxmodpacks.TabIndex = 5;
            this.comboBoxmodpacks.SelectionChangeCommitted += new System.EventHandler(this.comboBoxmodpacks_SelectionChangeCommitted);
            // 
            // panelmodpacks
            // 
            this.panelmodpacks.Controls.Add(this.button3);
            this.panelmodpacks.Controls.Add(this.button2);
            this.panelmodpacks.Controls.Add(this.button1);
            this.panelmodpacks.Controls.Add(this.textboxmodpackname);
            this.panelmodpacks.Controls.Add(this.label12);
            this.panelmodpacks.Controls.Add(this.textBoxmodsmcversion);
            this.panelmodpacks.Location = new System.Drawing.Point(12, 72);
            this.panelmodpacks.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelmodpacks.Name = "panelmodpacks";
            this.panelmodpacks.Size = new System.Drawing.Size(780, 329);
            this.panelmodpacks.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(668, 11);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Nowa paczka";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(605, 11);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Usuń";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(499, 11);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Zmień nazwę";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textboxmodpackname
            // 
            this.textboxmodpackname.Location = new System.Drawing.Point(220, 11);
            this.textboxmodpackname.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textboxmodpackname.Name = "textboxmodpackname";
            this.textboxmodpackname.Size = new System.Drawing.Size(272, 20);
            this.textboxmodpackname.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font(fr.Families[0], 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(196, 9);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 18);
            this.label12.TabIndex = 1;
            this.label12.Text = "-";
            // 
            // textBoxmodsmcversion
            // 
            this.textBoxmodsmcversion.Enabled = false;
            this.textBoxmodsmcversion.Location = new System.Drawing.Point(16, 11);
            this.textBoxmodsmcversion.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxmodsmcversion.Name = "textBoxmodsmcversion";
            this.textBoxmodsmcversion.Size = new System.Drawing.Size(180, 20);
            this.textBoxmodsmcversion.TabIndex = 0;
            // 
            // buttonmanageversions
            // 
            this.buttonmanageversions.Location = new System.Drawing.Point(261, 53);
            this.buttonmanageversions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonmanageversions.Name = "buttonmanageversions";
            this.buttonmanageversions.Size = new System.Drawing.Size(170, 23);
            this.buttonmanageversions.TabIndex = 7;
            this.buttonmanageversions.Text = "Zarządzaj wersjami";
            this.buttonmanageversions.UseVisualStyleBackColor = true;
            this.buttonmanageversions.Click += new System.EventHandler(this.buttonmanageversions_Click);
            // 
            // buttonmodpacks
            // 
            this.buttonmodpacks.Location = new System.Drawing.Point(12, 53);
            this.buttonmodpacks.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonmodpacks.Name = "buttonmodpacks";
            this.buttonmodpacks.Size = new System.Drawing.Size(101, 23);
            this.buttonmodpacks.TabIndex = 3;
            this.buttonmodpacks.Text = "Paczki modów";
            this.buttonmodpacks.UseVisualStyleBackColor = true;
            this.buttonmodpacks.Click += new System.EventHandler(this.buttonmodpacks_Click);
            // 
            // buttonmanagemods
            // 
            this.buttonmanagemods.Location = new System.Drawing.Point(117, 53);
            this.buttonmanagemods.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonmanagemods.Name = "buttonmanagemods";
            this.buttonmanagemods.Size = new System.Drawing.Size(140, 23);
            this.buttonmanagemods.TabIndex = 4;
            this.buttonmanagemods.Text = "Zarządzaj modami";
            this.buttonmanagemods.UseVisualStyleBackColor = true;
            this.buttonmanagemods.Click += new System.EventHandler(this.buttonmanagemods_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font(fr.Families[0], 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(267, 15);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(199, 24);
            this.label16.TabIndex = 1;
            this.label16.Text = "Stwórz paczkę modów";
            // 
            // panelcreatenewmodpack
            // 
            this.panelcreatenewmodpack.Controls.Add(this.textBoxpackcreatename);
            this.panelcreatenewmodpack.Controls.Add(this.label17);
            this.panelcreatenewmodpack.Controls.Add(this.comboBoxmodpackcreate);
            this.panelcreatenewmodpack.Controls.Add(this.label15);
            this.panelcreatenewmodpack.Controls.Add(this.button5);
            this.panelcreatenewmodpack.Controls.Add(this.button4);
            this.panelcreatenewmodpack.Controls.Add(this.label13);
            this.panelcreatenewmodpack.Controls.Add(this.label14);
            this.panelcreatenewmodpack.Location = new System.Drawing.Point(817, 76);
            this.panelcreatenewmodpack.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelcreatenewmodpack.Name = "panelcreatenewmodpack";
            this.panelcreatenewmodpack.Size = new System.Drawing.Size(805, 405);
            this.panelcreatenewmodpack.TabIndex = 11;
            // 
            // textBoxpackcreatename
            // 
            this.textBoxpackcreatename.Font = new System.Drawing.Font(fr.Families[0], 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxpackcreatename.Location = new System.Drawing.Point(232, 308);
            this.textBoxpackcreatename.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxpackcreatename.Name = "textBoxpackcreatename";
            this.textBoxpackcreatename.Size = new System.Drawing.Size(348, 21);
            this.textBoxpackcreatename.TabIndex = 8;
            this.textBoxpackcreatename.Text = "Moja paczka modów";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font(fr.Families[0], 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(91, 308);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(105, 18);
            this.label17.TabIndex = 7;
            this.label17.Text = "Nazwa paczki:";
            // 
            // comboBoxmodpackcreate
            // 
            this.comboBoxmodpackcreate.Font = new System.Drawing.Font(fr.Families[0], 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxmodpackcreate.FormattingEnabled = true;
            this.comboBoxmodpackcreate.Location = new System.Drawing.Point(232, 205);
            this.comboBoxmodpackcreate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxmodpackcreate.Name = "comboBoxmodpackcreate";
            this.comboBoxmodpackcreate.Size = new System.Drawing.Size(348, 23);
            this.comboBoxmodpackcreate.TabIndex = 6;
            this.comboBoxmodpackcreate.SelectedIndexChanged += new System.EventHandler(this.comboBoxmodpackcreate_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font(fr.Families[0], 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(32, 206);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(137, 18);
            this.label15.TabIndex = 5;
            this.label15.Text = "Wybierz wersję gry:";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(709, 375);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(76, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "Dalej";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(24, 375);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(76, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Anuluj";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font(fr.Families[0], 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(16, 57);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(582, 285);
            this.label13.TabIndex = 2;
            this.label13.Text = resources.GetString("label13.Text");
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font(fr.Families[0], 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(216, 13);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(281, 24);
            this.label14.TabIndex = 1;
            this.label14.Text = "Tworzenie nowej paczki modów";
            // 
            // panelconsole
            // 
            this.panelconsole.Controls.Add(this.richTextBoxconsole);
            this.panelconsole.Location = new System.Drawing.Point(23, 186);
            this.panelconsole.Name = "panelconsole";
            this.panelconsole.Size = new System.Drawing.Size(394, 270);
            this.panelconsole.TabIndex = 12;
            // 
            // richTextBoxconsole
            // 
            this.richTextBoxconsole.Location = new System.Drawing.Point(4, 4);
            this.richTextBoxconsole.Name = "richTextBoxconsole";
            this.richTextBoxconsole.ReadOnly = true;
            this.richTextBoxconsole.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBoxconsole.Size = new System.Drawing.Size(387, 262);
            this.richTextBoxconsole.TabIndex = 0;
            this.richTextBoxconsole.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::byZyczu.Properties.Resources.nowetlo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(853, 478);
            this.Controls.Add(this.paneldownload);
            this.Controls.Add(this.panelcreatenewmodpack);
            this.Controls.Add(this.panelmodsmain);
            this.Controls.Add(this.panelsettings);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelconsole);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font(fr.Families[0], 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Minecraft Launcher";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelsettings.ResumeLayout(false);
            this.panelsettings.PerformLayout();
            this.paneldownload.ResumeLayout(false);
            this.paneldownload.PerformLayout();
            this.panelmodsmain.ResumeLayout(false);
            this.panelmodsmain.PerformLayout();
            this.panelmanageversions.ResumeLayout(false);
            this.panelmodpacks.ResumeLayout(false);
            this.panelmodpacks.PerformLayout();
            this.panelcreatenewmodpack.ResumeLayout(false);
            this.panelcreatenewmodpack.PerformLayout();
            this.panelconsole.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonsettings;
        private System.Windows.Forms.Button buttonownmods;
        private System.Windows.Forms.Button buttonlaunch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBoxnick;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelsettings;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttoncancessett;
        private System.Windows.Forms.Button buttonsavechanges;
        private System.Windows.Forms.ComboBox comboBoxRAM;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox checkBoxnoverify;
        private System.Windows.Forms.Panel paneldownload;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label downloadlabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panelmodsmain;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panelmodpacks;
        private System.Windows.Forms.Button buttonmodpacks;
        private System.Windows.Forms.Button buttonclosemods;
        private System.Windows.Forms.ComboBox comboBoxmodpacks;
        private System.Windows.Forms.Button buttonmanagemods;
        private System.Windows.Forms.TextBox textboxmodpackname;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxmodsmcversion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panelcreatenewmodpack;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBoxpackcreatename;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox comboBoxmodpackcreate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.WebBrowser webBrowserdownload;
        private System.Windows.Forms.Panel panelconsole;
        private System.Windows.Forms.RichTextBox richTextBoxconsole;
        private System.Windows.Forms.Button buttonmanageversions;
        private System.Windows.Forms.Panel panelmanageversions;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ComboBox comboBoxmanageversions;
    }
}


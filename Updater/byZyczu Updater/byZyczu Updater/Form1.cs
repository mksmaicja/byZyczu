using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private async void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Aktualizowanie Launchera...";
            client.DownloadFile("")
        }
    }
}

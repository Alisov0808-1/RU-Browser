using CefSharp.Example;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RU_Browser
{
    public partial class Download_man : Form
    {
        int s = 1000; string ded3 = DownloadHandler.Dedok(); bool k;
        public Download_man()
        {
            // Timer timer;

            //int count = 0;

            InitializeComponent();
            //  LoadFileIcon("browser/down.txt");
            string[] down = File.ReadAllLines("browser/down.txt");
            //  listBox1.Items.AddRange(down);
            string a = "", b = "";
            // int p = 0;
            CefSharp.Example.DownloadHandler downloadHandler = new CefSharp.Example.DownloadHandler(a, b); progressBar1.Minimum = 0;
            int poz = 10;


            progressBar1.Maximum = DownloadHandler.Ded2() / 1000000; ;
            progressBar1.Value = DownloadHandler.Ded() / 1000000; ;
            label1.Text = $"{DownloadHandler.Ded() / (1024 * 2)}/{DownloadHandler.Ded2() / (1024 * 2)}";
            try
            {




            }
            catch { }
            int h = 0;
            vScrollBar1.Minimum = 0; vScrollBar1.Maximum = 1200;
            vScrollBar1.Value = 5;

        
            foreach (string s in File.ReadAllLines("browser/down.txt"))
            {
                LinkLabel linkLabel = new LinkLabel();
                panel1.Controls.Add(linkLabel);
                //  tabPage1.Controls.Add(linkLabel);
                linkLabel.Size = new Size(380, 25);
                linkLabel.Text = s;

                linkLabel.Location = new Point(1, poz);
                linkLabel.Font = new Font("Arial", 7.0f);
                linkLabel.BringToFront();

                poz += 25;
                try
                {
                    int index = h;
                    string[] urls = File.ReadAllLines("browser/url.txt");
                    linkLabel.LinkClicked += (sender, e) =>
                    {
                        try
                        {


                            List<string> down3 = File.ReadAllLines("browser/url.txt").ToList();
                            int lastIndex = urls[index].LastIndexOf(@"\");
                            string trimmedString = "";

                            List<string> down2 = File.ReadAllLines("browser/down.txt").ToList();
                            trimmedString = urls[index].Substring(0, lastIndex);
                            // Теперь trimmedString содержит "путь\\к\\файлу"


                            System.Diagnostics.Process.Start("explorer.exe", trimmedString);
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                    };
                    h++;
                }
                catch { }
            }

            timer1.Start();
            if (!DownloadHandler.Dedok2() && DownloadHandler.pau == true)
            {

                linkLabel3.Text = "Возобновить";
            }


        }



        private void button11_Click(object sender, EventArgs e)
        {
            foreach (string s in File.ReadAllLines("browser/down.txt"))
            {
                for (int i = 0; i < panel1.Controls.Count; i++)
                {
                    panel1.Controls[i].Dispose();
                }
            }
            //listBox1.Items.Clear();
            File.WriteAllText("browser/down.txt", " ");
            File.WriteAllText("browser/url.txt", " ");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            s = s - 1;

            s = 1000;
            progressBar1.Refresh();
            int dedValue = DownloadHandler.Ded() / 1000000;
            int ded2Value = DownloadHandler.Ded2() / 1000000;
            int ded3Value = DownloadHandler.Ded4() / 1000000;
            ded3 = DownloadHandler.Dedok();
            string a = DownloadHandler.Ded3();
            progressBar1.Value = DownloadHandler.Ded() / 1000000;
            label1.Text = $"Скачивается файл: {a}, \nзагружено: {dedValue}/{ded2Value} МБ, скорость: {ded3Value} МБ/c";

            if (ded2Value == dedValue) { label1.Text = "Загрузка завершена!"; }
            if (k == true) { label1.Text = "Отменено"; }
            timer1.Start();
        }

        private void ScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                int lastIndex = ded3.LastIndexOf(@"\");
                string trimmedString = "";
                if (lastIndex != -1)
                {
                    trimmedString = ded3.Substring(0, lastIndex);
                    // Теперь trimmedString содержит "путь\\к\\файлу"
                }
                System.Diagnostics.Process.Start("explorer.exe", trimmedString);
            }
            catch { }

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DownloadHandler.ch = true;
            k = true;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkLabel3.Text == "Пауза")
            {
                DownloadHandler.ch2 = true;
                linkLabel3.Text = "Возобновить";
            }
            else
            {
                DownloadHandler.ch2 = false;
                linkLabel3.Text = "Пауза";
            }
        }

        private void Download_man_Load(object sender, EventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            panel1.Top = -vScrollBar1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            egg egg = new egg();
            egg.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

      
    }
}

using CefSharp;
using CefSharp.WinForms;
using RU_Browser;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Windows.Forms;
using static TIMBrowser.Settings;
using Image = System.Drawing.Image;
using Settings = TIMBrowser.Settings;
using TabControl = System.Windows.Forms.TabControl;
using TextBox = System.Windows.Forms.TextBox;


namespace C_Browser
{
    public partial class Form1 : Form
    {

        private PictureBox arrowPictureBox;
        Settings.SettingPar setp;
        string adress;
        public bool checus = false;
        public ImageList list = new ImageList();


        Image CloseImage = Image.FromFile("browser/img/del.png"), AddImage = Image.FromFile("browser/img/add.png");
        Point _imageLocation = new Point(25, 4);
        Point imageHitArea = new Point(25, 4);
        bool first;
        string ad;
        public Form1(bool fir, string add)
        {
            ad = add;
            //list.ImageSize = new Size(16, 16);
            first = fir;
            InitializeComponent();
            arrowPictureBox = new PictureBox
            {
                Location = new Point(comboBox1.Location.X, comboBox1.Location.Y),
                Size = new Size(comboBox1.Width / 8, comboBox1.Height),


            };

            arrowPictureBox.BackgroundImage = Image.FromFile("browser/img/arrow.png");
            arrowPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            // arrowPictureBox.Paint += ArrowPictureBox_Paint;
            this.Controls.Add(arrowPictureBox);
            // Подписка на событие клика по PictureBox
            arrowPictureBox.Click += (sender, e) => comboBox1.DroppedDown = true;
            TabDragger DragTabs = new TabDragger(this.tabControl1, TabDragBehavior.TabDragOut);
            // textBox1.BackColor = Color.FromArgb();
        }


        private void ArrowPictureBox_Paint(object sender, PaintEventArgs e)
        {
            // Рисуем стрелку на PictureBox
            using (Brush brush = new SolidBrush(Color.Red)) // Задайте цвет стрелки
            {
                e.Graphics.FillPolygon(brush, new Point[]
                {
                new Point(0, 0),
                new Point(20, 0),
                new Point(10, 10)
                });
            }
        }

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        string mbtoget = "";
        public static void Aply_set(Form1 form, int y = 0)
        {
            if (y == 0)
            {
                form.Aply_to();
            }
            else { form.Aply_litle(); }
        }
        string cuswin = File.ReadAllText("browser/rgb/cuswin.txt");
        public void Aply_litle()
        {
            string[] dos = System.IO.File.ReadAllLines("browser/dostyp.txt");
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(dos);
        }
        public void Aply_to()
        {

            cuswin = File.ReadAllText("browser/rgb/cuswin.txt");
            //if (cuswin == "n")
            //{
            //    // MessageBox.Show("G");
            //    panel2.Visible = false;
            //    button13.Visible = false;
            //    button14.Visible = false;
            //    button15.Visible = false;
            //    this.FormBorderStyle = FormBorderStyle.Sizable;
            //}

            use = File.ReadAllText("browser/use.txt");
            mbtoget = File.ReadAllText("browser/mb.txt");
            if (mbtoget != "Авто")
            {
                timer1.Start();
            }
            CefSettings set = new CefSettings();
            a0 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/3/r.txt"));
            a1 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/3/g.txt"));
            a2 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/3/b.txt"));

            textBox1.ForeColor = Color.FromArgb(a0, a1, a2);
            comboBox1.ForeColor = Color.FromArgb(a0, a1, a2);
            label1.ForeColor = Color.FromArgb(a0, a1, a2);
            tabControl1.Invalidate();
            int a00c = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/b.txt"));
            int a11c = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/b1.txt"));
            int a22c = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/b2.txt"));
            a00 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/b.txt"));
            a11 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/b1.txt"));
            a22 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/b2.txt"));
            this.BackColor = Color.FromArgb(a00c, a11c, a22c);
            string[] dos = System.IO.File.ReadAllLines("browser/dostyp.txt");
            comboBox1.Items.Clear();
            setp = JsonSerializer.Deserialize<SettingPar>(System.IO.File.ReadAllText("browser/settings.json"));
            comboBox1.Items.AddRange(dos);
            try
            {



                button11.BackgroundImage = Image.FromFile("browser/img/srch_small.png");
                button10.BackgroundImage = Image.FromFile("browser/img/home.png");
                button3.BackgroundImage = Image.FromFile("browser/img/right.png");
                button2.BackgroundImage = Image.FromFile("browser/img/rel.png");
                button1.BackgroundImage = Image.FromFile("browser/img/left.png");
                button12.BackgroundImage = Image.FromFile("browser/img/min.png");
                button6.BackgroundImage = Image.FromFile("browser/img/plus.png");
                button7.BackgroundImage = Image.FromFile("browser/img/set.png");
                button9.BackgroundImage = Image.FromFile("browser/img/star.png");
                button4.BackgroundImage = Image.FromFile("browser/img/srch.png");
                button5.BackgroundImage = Image.FromFile("browser/img/down.png");
                label1.Image = Image.FromFile("browser/img/k2.png");
                panel2.BackgroundImage = Image.FromFile("browser/img/k3.png");
                button14.Image = Image.FromFile("browser/img/k2.png");
                button13.Image = Image.FromFile("browser/img/k2.png");
                button15.Image = Image.FromFile("browser/img/k2.png");
            }
            catch (Exception)
            {

                MessageBox.Show("Одно из изображений по путю 'browser/img/' не найдено!", "");
            }
            try
            {


                //         this.tabControl1.TabPages[tabControl1.TabCount - 1].Text = "";

                AddImage = Image.FromFile("browser/img/add.png");
                CloseImage = Image.FromFile("browser/img/del.png");


                //  tabControl1.ContextMenuStrip = contextMenuStrip1; 

                //  tabControl1.Padding = new Point(20, 4);
                tabControl1.Font = new Font(File.ReadAllText("browser/rgb/2/r.txt"), Convert.ToInt32(File.ReadAllText("browser/rgb/2/sh.txt")));
                textBox1.Font = new Font(File.ReadAllText("browser/rgb/2/r.txt"), 16.8f);


                button11.BackgroundImageLayout = ImageLayout.Stretch;

                // tabControl1.SelectedIndex = 0;
                //button11.Left += 340;
                button11.Height = comboBox1.Height;
                //comboBox1.Left += 377;


                b13 = new Point(button13.Location.X); b14 = new Point(button14.Location.X); b15 = new Point(button15.Location.X);
                int a00000 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/c.txt"));
                int a100 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/c1.txt"));
                int a200 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/c2.txt"));
                textBox1.BackColor = Color.FromArgb(a00000, a100, a200);
                int a00d = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/b.txt"));
                int a11d = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/b1.txt"));
                int a22d = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/b2.txt"));
                this.BackColor = Color.FromArgb(a00d, a11d, a22d);
                int a000 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/s1.txt"));
                int a111 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/s2.txt"));
                int a222 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/s3.txt"));
                comboBox1.BackColor = Color.FromArgb(a000, a111, a222);
                int a0000 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/r.txt"));
                int a1111 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/g.txt"));
                int a2222 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/b5.txt"));
                button1.BackColor = Color.FromArgb(a0000, a1111, a2222);
                button2.BackColor = Color.FromArgb(a0000, a1111, a2222);
                button3.BackColor = Color.FromArgb(a0000, a1111, a2222);
                button4.BackColor = Color.FromArgb(a0000, a1111, a2222);
                button6.BackColor = Color.FromArgb(a0000, a1111, a2222);
                button12.BackColor = Color.FromArgb(a0000, a1111, a2222);
                button5.BackColor = Color.FromArgb(a0000, a1111, a2222);
                button7.BackColor = Color.FromArgb(a0000, a1111, a2222);
                button8.BackColor = Color.FromArgb(a0000, a1111, a2222);
                button9.BackColor = Color.FromArgb(a0000, a1111, a2222);
                button10.BackColor = Color.FromArgb(a0000, a1111, a2222);
                button11.BackColor = Color.FromArgb(a0000, a1111, a2222);
                a0a = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/3/r2.txt"));

                a1a = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/3/g2.txt"));

                a2a = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/3/b2.txt"));

                a0a6 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/3/r3.txt"));

                a1a6 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/3/g3.txt"));

                a2a6 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/3/b3.txt"));
                comboBox1.SelectedItem = "Быстрый доступ";
                //  tabControl1.Width = Width + 10; tabControl1.Height = Height - 55;
                int a055 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/3/r.txt"));
                int a155 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/3/g.txt"));
                int a255 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/3/b.txt"));


                textBox1.ForeColor = Color.FromArgb(a055, a155, a255);
                comboBox1.ForeColor = Color.FromArgb(a0, a1, a2);
                label1.ForeColor = Color.FromArgb(a055, a155, a255);



                int a0d = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/4/r.txt"));
                int a1d = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/4/g.txt"));
                int a2d = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/4/b.txt"));
                panel2.BackColor = Color.FromArgb(a0d, a1d, a2d);
                button13.BackColor = panel2.BackColor;
                button14.BackColor = panel2.BackColor;
                button15.BackColor = panel2.BackColor;



                comboBox1.Font = new Font(File.ReadAllText("browser/rgb/2/r.txt"), 11.6f);


                string ch9 = File.ReadAllText("browser/ch.txt");
                var comLines = File.ReadAllLines("browser/com.txt");
                var bb2Lines = File.ReadAllLines("browser/bb2.txt");

                w = this.Width; h = this.Height;
                set.RemoteDebuggingPort = 0;
                set.IgnoreCertificateErrors = false;
                CefSharp.Cookie c = new CefSharp.Cookie();
                if (setp.Style == "Popup")
                {
                    button1.FlatStyle = FlatStyle.Popup;
                    button2.FlatStyle = FlatStyle.Popup;
                    button3.FlatStyle = FlatStyle.Popup;
                    button4.FlatStyle = FlatStyle.Popup;
                    button6.FlatStyle = FlatStyle.Popup;
                    button12.FlatStyle = FlatStyle.Popup;
                    button7.FlatStyle = FlatStyle.Popup;
                    button8.FlatStyle = FlatStyle.Popup;
                    button9.FlatStyle = FlatStyle.Popup;
                    button10.FlatStyle = FlatStyle.Popup;
                    button11.FlatStyle = FlatStyle.Popup;
                    button5.FlatStyle = FlatStyle.Popup;


                }
                else if (setp.Style == "Standard")
                {
                    button1.FlatStyle = FlatStyle.Standard;
                    button2.FlatStyle = FlatStyle.Standard;
                    button3.FlatStyle = FlatStyle.Standard;
                    button4.FlatStyle = FlatStyle.Standard;
                    button6.FlatStyle = FlatStyle.Standard;
                    button12.FlatStyle = FlatStyle.Standard;
                    button5.FlatStyle = FlatStyle.Standard;
                    button7.FlatStyle = FlatStyle.Standard;
                    button8.FlatStyle = FlatStyle.Standard;
                    button9.FlatStyle = FlatStyle.Standard;
                    button10.FlatStyle = FlatStyle.Standard;
                    button11.FlatStyle = FlatStyle.Standard;

                }
                else if (setp.Style == "Flat")
                {
                    button1.FlatStyle = FlatStyle.Flat;
                    button2.FlatStyle = FlatStyle.Flat;
                    button3.FlatStyle = FlatStyle.Flat;
                    button4.FlatStyle = FlatStyle.Flat;
                    button5.FlatStyle = FlatStyle.Flat;
                    button7.FlatStyle = FlatStyle.Flat;
                    button8.FlatStyle = FlatStyle.Flat;
                    button6.FlatStyle = FlatStyle.Flat;
                    button12.FlatStyle = FlatStyle.Flat;
                    button9.FlatStyle = FlatStyle.Flat;
                    button10.FlatStyle = FlatStyle.Flat;
                    button11.FlatStyle = FlatStyle.Flat;

                }
                if (setp.saveURL == "URL")
                {
                    System.IO.File.WriteAllText("browser/c.txt", "yu");
                }


                else if (setp.saveURL == "Название файла")
                {
                    System.IO.File.WriteAllText("browser/c.txt", "ys");
                }
                if (setp.saveCash == true)
                {

                    set.CachePath = Environment.CurrentDirectory + @"\browser\cash\";

                }
                else { set.CefCommandLineArgs.Add("disable-application-cache", "1"); }
                set.Locale = "ru";

                set.UserAgent = File.ReadAllText("browser/useragent.txt");
                arrowPictureBox.BackColor = comboBox1.BackColor;
                for (int i = 0; i < comLines.Count(); i++)
                {


                    set.CefCommandLineArgs.Add(comLines[i], bb2Lines[i]);

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Возможно, вы не правильно указали RGB цвета, поэтому появилась ошибка!", "");


            }

        }
        public static bool IsConnectedToInternet()
        {
            int Desc;

            return InternetGetConnectedState(out Desc, 0);
        }
        [DllImport("kernel32.dll")]
        static extern bool SetProcessWorkingSetSize(IntPtr proc, int min, int max);
        int delimoe = 0;
        void upt()
        {

            // if (tabControl1.SelectedIndex == tabControl1.TabCount-1) { tabControl1.SelectedIndex = tabControl1.TabCount - 1; }

            Process[] processes = Process.GetProcessesByName("CefSharp.BrowserSubprocess");
            if (processes.Count() + 1 < Convert.ToInt32(mbtoget))
            {
                delimoe = Convert.ToInt32(mbtoget) / (processes.Count() + 1);
            }
            else { delimoe = Convert.ToInt32(mbtoget); }
            foreach (Process r in processes)
            {
                try
                {
                    SetProcessWorkingSetSize(r.Handle, 1 * 1024 * 1024, delimoe * 1024 * 1024);
                }
                catch { }
            }
            SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, 1 * 1024 * 1024, delimoe * 1024 * 1024);

        }

        public void AddHistory(string site)
        {



            // File.WriteAllLines("browser/pages.txt",p);
            if (setp.saveHist)
            {
                if (setp.saveDate)
                {
                    DateTime dt = DateTime.UtcNow;
                    System.IO.File.AppendAllText("browser/history.txt", "\n" + site + "\t" + dt.ToString("HH:mm dd.MM.yy"));
                }
                else
                {
                    System.IO.File.AppendAllText("browser/history.txt", "\n" + site);
                }
            }
        }
        int ind = 0;
        public ChromiumWebBrowser getCurrentBrowser()
        {

            return (ChromiumWebBrowser)tabControl1.TabPages[ind].Controls[0];

        }
        Point b13 = new Point(); Point b14 = new Point(); Point b15 = new Point();

        int a0 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/3/r.txt"));
        int a1 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/3/g.txt"));
        int a2 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/3/b.txt"));



        int a00 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/b.txt"));
        int a11 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/b1.txt"));
        int a22 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/b2.txt"));
        void IsLoading(object sender, LoadingStateChangedEventArgs e)
        {
            try
            {
                ChromiumWebBrowser crome = tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0] as ChromiumWebBrowser;

                if (crome.IsLoading)
                {
                    button2.BackgroundImage = load;

                }
                if (!crome.IsLoading)
                {
                    button2.BackgroundImage = reload;


                }

            }
            catch { }
        }


        public bool cashend = false;
        int a0a; int a1a; int a2a; int a0a6; int a1a6; int a2a6;

        public void Form1_Load(object sender, EventArgs e)
        {


            mbtoget = File.ReadAllText("browser/mb.txt");
            if (mbtoget != "Авто")
            {
                timer1.Start();
            }
            CefSettings set = new CefSettings();
            this.Width = 1100;
            this.Height = 700; string[] dos = System.IO.File.ReadAllLines("browser/dostyp.txt"); comboBox1.Items.Clear(); setp = JsonSerializer.Deserialize<SettingPar>(System.IO.File.ReadAllText("browser/settings.json"));
            comboBox1.Items.AddRange(dos);
            try
            {



                button11.BackgroundImage = Image.FromFile("browser/img/srch_small.png");
                button10.BackgroundImage = Image.FromFile("browser/img/home.png");
                button3.BackgroundImage = Image.FromFile("browser/img/right.png");
                button2.BackgroundImage = Image.FromFile("browser/img/rel.png");
                button1.BackgroundImage = Image.FromFile("browser/img/left.png");
                button12.BackgroundImage = Image.FromFile("browser/img/min.png");
                button6.BackgroundImage = Image.FromFile("browser/img/plus.png");
                button7.BackgroundImage = Image.FromFile("browser/img/set.png");
                button9.BackgroundImage = Image.FromFile("browser/img/star.png");
                button4.BackgroundImage = Image.FromFile("browser/img/srch.png");
                button5.BackgroundImage = Image.FromFile("browser/img/down.png");
                //button14.BackgroundImage = Image.FromFile("browser/img/sver.png");
                //button13.BackgroundImage = Image.FromFile("browser/img/max.png");
                //button15.BackgroundImage = Image.FromFile("browser/img/cls.png");
                label1.Image = Image.FromFile("browser/img/k2.png");
                panel2.BackgroundImage = Image.FromFile("browser/img/k3.png");
                button14.Image = Image.FromFile("browser/img/k2.png");
                button13.Image = Image.FromFile("browser/img/k2.png");
                button15.Image = Image.FromFile("browser/img/k2.png");
            }
            catch (Exception)
            {

                MessageBox.Show("Одно из изображений по пути 'browser/img/' не найдено!", "");
            }

            for (int i = 0; i < 100; i++)
            {
                bools.Add(false);
            }
            try
            {
                cuswin = File.ReadAllText("browser/rgb/cuswin.txt");
                if (cuswin == "n")
                {
                    // MessageBox.Show("G");
                    panel2.Visible = false;
                    button13.Visible = false;
                    button14.Visible = false;
                    button15.Visible = false;
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    foreach (Control control in Controls)
                    {
                        if (control != panel2) control.Top -= 1;

                    }
                }
                else
                {
                    foreach (Control control in Controls)
                    {
                        if (control != panel2) control.Top += 25;

                    }
                }

                this.tabControl1.TabPages[tabControl1.TabCount - 1].Text = "";
                string ch2 = File.ReadAllText("browser/ch.txt");
                if (ch2 == "y") { tabControl1.TabPages.RemoveAt(tabControl1.TabCount - 1); }
                AddImage = Image.FromFile("browser/img/add.png");
                CloseImage = Image.FromFile("browser/img/del.png");


                //  tabControl1.ContextMenuStrip = contextMenuStrip1; 

                tabControl1.Padding = new Point(20, 4);
                tabControl1.Font = new Font(File.ReadAllText("browser/rgb/2/r.txt"), Convert.ToInt32(File.ReadAllText("browser/rgb/2/sh.txt")));
                textBox1.Font = new Font(File.ReadAllText("browser/rgb/2/r.txt"), 16.8f);
                tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
                tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
                tabControl1.DrawItem += new DrawItemEventHandler(tabControl1_DrawItem);
                button11.BackgroundImageLayout = ImageLayout.Stretch;

                tabControl1.SelectedIndex = 0;
                button11.Left += 340;
                button11.Height = comboBox1.Height;
                comboBox1.Left += 377;


                b13 = new Point(button13.Location.X); b14 = new Point(button14.Location.X); b15 = new Point(button15.Location.X);
                int a00000 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/c.txt"));
                int a100 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/c1.txt"));
                int a200 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/c2.txt"));
                textBox1.BackColor = Color.FromArgb(a00000, a100, a200);
                int a00 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/b.txt"));
                int a11 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/b1.txt"));
                int a22 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/b2.txt"));
                this.BackColor = Color.FromArgb(a00, a11, a22);
                int a000 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/s1.txt"));
                int a111 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/s2.txt"));
                int a222 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/s3.txt"));
                comboBox1.BackColor = Color.FromArgb(a000, a111, a222);
                int a0000 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/r.txt"));
                int a1111 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/g.txt"));
                int a2222 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/b5.txt"));
                button1.BackColor = Color.FromArgb(a0000, a1111, a2222);
                button2.BackColor = Color.FromArgb(a0000, a1111, a2222);
                button3.BackColor = Color.FromArgb(a0000, a1111, a2222);
                button4.BackColor = Color.FromArgb(a0000, a1111, a2222);
                button6.BackColor = Color.FromArgb(a0000, a1111, a2222);
                button12.BackColor = Color.FromArgb(a0000, a1111, a2222);
                button5.BackColor = Color.FromArgb(a0000, a1111, a2222);
                button7.BackColor = Color.FromArgb(a0000, a1111, a2222);
                button8.BackColor = Color.FromArgb(a0000, a1111, a2222);
                button9.BackColor = Color.FromArgb(a0000, a1111, a2222);
                button10.BackColor = Color.FromArgb(a0000, a1111, a2222);
                button11.BackColor = Color.FromArgb(a0000, a1111, a2222);
                a0a = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/3/r2.txt"));

                a1a = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/3/g2.txt"));

                a2a = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/3/b2.txt"));

                a0a6 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/3/r3.txt"));

                a1a6 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/3/g3.txt"));

                a2a6 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/3/b3.txt"));
                comboBox1.SelectedItem = "Быстрый доступ";
                tabControl1.Width = Width + 10; tabControl1.Height = Height - 55;
                int a05 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/3/r.txt"));
                int a15 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/3/g.txt"));
                int a25 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/3/b.txt"));


                textBox1.ForeColor = Color.FromArgb(a05, a15, a25);
                comboBox1.ForeColor = Color.FromArgb(a0, a1, a2);
                label1.ForeColor = Color.FromArgb(a0, a1, a2);



                int a0d = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/4/r.txt"));
                int a1d = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/4/g.txt"));
                int a2d = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/4/b.txt"));
                panel2.BackColor = Color.FromArgb(a0d, a1d, a2d);
                button13.BackColor = panel2.BackColor;
                button14.BackColor = panel2.BackColor;
                button15.BackColor = panel2.BackColor;



                comboBox1.Font = new Font(File.ReadAllText("browser/rgb/2/r.txt"), 11.6f);

            }
            catch (Exception)
            {
                MessageBox.Show("Возможно, вы не правильно указали RGB цвета, поэтому появилась ошибка!", "");
                setp = new SettingPar
                {
                    //searchSys = "Яндекс",
                    //startPage = "ya.ru",
                    saveHist = true,
                    saveType = "Адрес",
                    saveDate = false,
                    saveCash = true,
                    saveDown = true,
                    saveURL = "URL",
                    Style = "Flat",


                };

            }
            string ch9 = File.ReadAllText("browser/ch.txt");
            var comLines = File.ReadAllLines("browser/com.txt");
            var bb2Lines = File.ReadAllLines("browser/bb2.txt");

            w = this.Width; h = this.Height;
            set.RemoteDebuggingPort = 0;
            set.IgnoreCertificateErrors = false;
            CefSharp.Cookie c = new CefSharp.Cookie();
            if (setp.Style == "Popup")
            {
                button1.FlatStyle = FlatStyle.Popup;
                button2.FlatStyle = FlatStyle.Popup;
                button3.FlatStyle = FlatStyle.Popup;
                button4.FlatStyle = FlatStyle.Popup;
                button6.FlatStyle = FlatStyle.Popup;
                button12.FlatStyle = FlatStyle.Popup;
                button7.FlatStyle = FlatStyle.Popup;
                button8.FlatStyle = FlatStyle.Popup;
                button9.FlatStyle = FlatStyle.Popup;
                button10.FlatStyle = FlatStyle.Popup;
                button11.FlatStyle = FlatStyle.Popup;
                button5.FlatStyle = FlatStyle.Popup;


            }
            else if (setp.Style == "Standard")
            {
                button1.FlatStyle = FlatStyle.Standard;
                button2.FlatStyle = FlatStyle.Standard;
                button3.FlatStyle = FlatStyle.Standard;
                button4.FlatStyle = FlatStyle.Standard;
                button6.FlatStyle = FlatStyle.Standard;
                button12.FlatStyle = FlatStyle.Standard;
                button5.FlatStyle = FlatStyle.Standard;
                button7.FlatStyle = FlatStyle.Standard;
                button8.FlatStyle = FlatStyle.Standard;
                button9.FlatStyle = FlatStyle.Standard;
                button10.FlatStyle = FlatStyle.Standard;
                button11.FlatStyle = FlatStyle.Standard;

            }
            else if (setp.Style == "Flat")
            {
                button1.FlatStyle = FlatStyle.Flat;
                button2.FlatStyle = FlatStyle.Flat;
                button3.FlatStyle = FlatStyle.Flat;
                button4.FlatStyle = FlatStyle.Flat;
                button5.FlatStyle = FlatStyle.Flat;
                button7.FlatStyle = FlatStyle.Flat;
                button8.FlatStyle = FlatStyle.Flat;
                button6.FlatStyle = FlatStyle.Flat;
                button12.FlatStyle = FlatStyle.Flat;
                button9.FlatStyle = FlatStyle.Flat;
                button10.FlatStyle = FlatStyle.Flat;
                button11.FlatStyle = FlatStyle.Flat;

            }
            if (setp.saveURL == "URL")
            {
                System.IO.File.WriteAllText("browser/c.txt", "yu");
            }


            else if (setp.saveURL == "Название файла")
            {
                System.IO.File.WriteAllText("browser/c.txt", "ys");
            }
            if (setp.saveCash == true)
            {

                set.CachePath = Environment.CurrentDirectory + @"\browser\cash\";

            }
            else { set.CefCommandLineArgs.Add("disable-application-cache", "1"); }
            set.Locale = "ru";

            set.UserAgent = File.ReadAllText("browser/useragent.txt");

            for (int i = 0; i < comLines.Count(); i++)
            {


                set.CefCommandLineArgs.Add(comLines[i], bb2Lines[i]);

            }

            //   MessageBox.Show(set.CachePath, "");


            //  set.CefCommandLineArgs.Add("proxy-server", "72.10.164.178:9311");
            try
            {
                if (first != false)
                {
                    Cef.Initialize(set);
                }
            }
            catch { }


            string tes = setp.startPage;

            ChromiumWebBrowser chromium = new ChromiumWebBrowser(setp.startPage);
            string a9 = "", b = "";

            //   RU_Browser.ExtensionHandlerM extensionHandlerM = new ExtensionHandlerM();
            // chromium.RequestContext.LoadExtensionFromDirectory(@"D:\\Старый дедус HDD сиквел\\Моёёё\\Cnjk\\RU Browser\\C Browser\\bin\\x64\\Debug\\browser\\EXT\\6.1.0_0", extensionHandlerM);
            button15.Location = new Point(this.ClientSize.Width - 40);
            button13.Location = new Point(this.ClientSize.Width - 80); button14.Location = new Point(this.ClientSize.Width - 120);
            if (first == false)
            { chromium.Load(ad); }


            if (ch9 != "y")
            {


                TabPage page1 = new TabPage();
                tabControl1.Controls.Add(page1);
                ChromiumWebBrowser chromiuma = new ChromiumWebBrowser(setp.startPage);
                tabControl1.SelectedTab.Controls.Add(chromiuma);
                //   SetProxy(chromium, "http://45.77.248.104:8888");
                chromiuma.AddressChanged += Chromium_AddressChanged;
                chromiuma.TitleChanged += Chromium_TitleChanged;
                chromiuma.LoadingStateChanged += IsLoading;
                // chromiuma.FrameLoadEnd += NavigationEnd;
                FullScreen.DisplayHandler displayera = new FullScreen.DisplayHandler();
                chromiuma.DisplayHandler = displayera;
                chromiuma.Dock = DockStyle.Fill;
                RU_Browser_rec.CustomResourceRequestHandler requestHandler2a = new RU_Browser_rec.CustomResourceRequestHandler();
                chromiuma.RequestHandler = requestHandler2a;
                //   CefSharp.Example.Handlers.ExtensionHandler extension = new CefSharp.Example.Handlers.ExtensionHandler();
                C_Browser0.CustomMenuHandler customMenua = new C_Browser0.CustomMenuHandler();
                chromiuma.MenuHandler = customMenua;
                string a91 = "", b1 = "";
                CefSharp.Example.DownloadHandler downloadHandlera = new CefSharp.Example.DownloadHandler(a91, b1);
                chromiuma.DownloadHandler = downloadHandlera;
                chromiuma.Margin = Padding.Empty;
                Ded.MyCustomLifeSpanHandler myCustomLifeSpanHandlera = new Ded.MyCustomLifeSpanHandler();
                chromiuma.LifeSpanHandler = myCustomLifeSpanHandlera;
                tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex + 1);
            }

            if (ch9 == "y")
            {


                //page.AddRange(File.ReadAllLines("browser/pages.txt"));

                int p = Convert.ToInt32(File.ReadAllText("browser/count.txt"));

                string filePath = "browser/pages.txt";
                List<string> page = File.ReadAllLines(filePath).ToList();




                int a = 0;
                if (page.Count != 0)
                {
                    foreach (string a5 in page)
                    {
                        TabPage tab = new TabPage();
                        //  Добавляем PictureBox на форму
                        //tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                        //  tab.Controls.Add(pictureBox);
                        tabControl1.TabPages.Add(tab);
                        //   tabControl1.SelectedTab = tab;
                        tab.Text = page[a];

                        ChromiumWebBrowser chromium2 = new ChromiumWebBrowser(page[a]);
                        tab.Controls.Add(chromium2);
                        a++;

                        chromium2.AddressChanged += Chromium_AddressChanged;
                        chromium2.TitleChanged += Chromium_TitleChanged;
                        RU_Browser_rec.CustomResourceRequestHandler requestHandler = new RU_Browser_rec.CustomResourceRequestHandler();
                        chromium2.RequestHandler = requestHandler;
                        C_Browser0.CustomMenuHandler customMenu2 = new C_Browser0.CustomMenuHandler();
                        chromium2.MenuHandler = customMenu2;
                        //string a92 = "", b2 = "";
                        //   chromium2.FrameLoadEnd += NavigationEnd;
                        CefSharp.Example.DownloadHandler downloadHandler2 = new CefSharp.Example.DownloadHandler(a9, b);
                        chromium2.DownloadHandler = downloadHandler2;
                        chromium2.Margin = Padding.Empty;
                        Ded.MyCustomLifeSpanHandler myCustomLifeSpanHandle2 = new Ded.MyCustomLifeSpanHandler();
                        chromium2.LifeSpanHandler = myCustomLifeSpanHandle2;
                        chromium2.RequestContext = new RequestContext();
                        //  RU_Browser.ExtensionHandlerM extensionHandlerM2 = new ExtensionHandlerM();
                        chromium.Margin = Padding.Empty;


                    }
                    TabPage tab2 = new TabPage();
                    ////  Добавляем PictureBox на форму
                    ////tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                    ////  tab.Controls.Add(pictureBox);
                    button15.Location = new Point(this.ClientSize.Width - 40);
                    button13.Location = new Point(this.ClientSize.Width - 80); button14.Location = new Point(this.ClientSize.Width - 120);
                    tabControl1.TabPages.Add(tab2);
                    tabControl1.SelectedIndex = tabControl1.TabCount - 2; tabControl1.Invalidate();
                    tabControl1.TabPages.RemoveAt(0); tabControl1.TabPages.RemoveAt(0);


                    // } if (first == false)
                    //{ 
                    //     ChromiumWebBrowser ch = (ChromiumWebBrowser)tabControl1.TabPages[ind].Controls[0];
                    //     TabDragger.del(tabControl1, tabControl1.SelectedTab,chromium); 
                }
                else { tabControl1.SelectedTab.Controls.Add(chromium); }
            }
            // button11.Left += 340;
            button11.Height = comboBox1.Height;
            arrowPictureBox.BackColor = comboBox1.BackColor;
            // comboBox1.Left += 377;
        }



        private void Chromium_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            //bool check = IsConnectedToInternet();
            //if (!check)
            //        {
            //    PictureBox pictureBox = new PictureBox();
            //    pictureBox.Location = new Point(0, 0);
            //    pictureBox.Size = new Size(tabControl1.Width, tabControl1.Height);
            //    pictureBox.Image = Image.FromFile("browser/img/error.png");
            //    tabControl1.TabPages[ind].Controls.Add(pictureBox);
            //    pictureBox.BringToFront();

            //}

            this.Invoke(new MethodInvoker(() =>
        {



            TextBox textBoxOnTab = new TextBox();
            textBoxOnTab.Text = tabControl1.TabPages[ind].Text;
            textBoxOnTab.MaxLength = 1;
            string a = e.Title;
            int y = a.Length;
            if (a.Length > 20 || (CountUppercaseChars(a) > a.Length / 2)) // Проверяем, содержит ли строка более половины символов в капслоге
            {
                a = a.Substring(0, Math.Min(a.Length, 20)); // Обрезаем строку до 10 символов
            }
            {
                a = TrimStringWithoutSpaces(a, 19);



            }
            tabControl1.Invalidate();
            if (setp.saveType != "Адрес" && File.ReadAllLines("browser/history.txt").Last() != e.Title)
            {

                AddHistory(e.Title);
            }


            tabControl1.TabPages[ind].Text = a;



        }));


        }
        static int CountUppercaseChars(string input)
        {
            int count = 0;
            foreach (char c in input)
            {
                if (char.IsLetter(c) && char.IsUpper(c))
                {
                    count++;
                }
            }
            return count;
        }

        static string TrimStringWithoutSpaces(string input, int maxLength)
        {
            int actualLength = input.Length;
            int spaceCount = input.Count(c => c == ' ');

            if (actualLength - spaceCount <= maxLength)
            {
                return input;
            }
            else
            {
                int count = 0;
                string result = string.Concat(input.TakeWhile(c =>
                {
                    if (count >= maxLength)
                    {
                        return false;
                    }

                    if (c != ' ')
                    {
                        count++;
                    }

                    return true;
                }));

                return result;
            }
        }
        string use = File.ReadAllText("browser/use.txt");

        private void Chromium_AddressChanged(object sender, AddressChangedEventArgs e)
        {

            GC.Collect();
            ChromiumWebBrowser crome = (ChromiumWebBrowser)tabControl1.SelectedTab.Controls[0];

            if (use == "y")
            {

                Extension.Loadded(crome);
            }
            try { images.RemoveAt(ind); } catch { }
            try
            {

                WebClient wc = new WebClient();
                MemoryStream memorystream2 = new MemoryStream(wc.DownloadData($"https://t1.gstatic.com/faviconV2?client=SOCIAL&type=FAVICON&fallback_opts=TYPE,SIZE,URL&url=http://" + new Uri(getCurrentBrowser().Address.ToString()).Host + "&size=32"));
                Image icon = Image.FromStream(memorystream2);

                Bitmap bitmap = new Bitmap(icon, new Size(32, 32));
                images.Insert(ind, bitmap);
                ;
            }
            catch (Exception ex)
            {
                // Обработка исключений, если загрузка изображения не удалась
                Console.WriteLine("Ошибка загрузки изображения: " + ex.Message);
            }
            this.Invoke(new MethodInvoker(() =>
           {


               textBox1.Text = e.Address;

               adress = e.Address;
               if (setp.saveType == "Адрес" && File.ReadAllLines("browser/history.txt").Last() != adress)
               {
                   AddHistory(adress);
               }



           }));


        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChromiumWebBrowser crome = tabControl1.TabPages[ind].Controls[0] as ChromiumWebBrowser;
            crome.Stop();
            if (crome.CanGoForward)
            {

                crome.Forward();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {



            if (textBox1.Text == "Я молодец? (Не холодец)")
            {
                SoundPlayer simpleSound = new SoundPlayer("browser/rgb/p.wav");
                simpleSound.Play(); textBox1.Text = "Нет, ты огурец!";
            }
            else
            {
                ChromiumWebBrowser crome = tabControl1.SelectedTab.Controls[0] as ChromiumWebBrowser;
                if (crome != null)
                {
                    string sys = "https://www.google.com/search?q=";
                    if (setp.searchSys == "Яндекс")
                    {

                        sys = "https://yandex.ru/search/?text=";
                        if (textBox1.Text.StartsWith("http") || textBox1.Text.StartsWith("https") || textBox1.Text.TrimEnd().EndsWith(".com") || textBox1.Text.TrimEnd().EndsWith(".ru"))
                        {

                            crome.Load(textBox1.Text);
                        }
                        else
                        {
                            crome.Load(sys + textBox1.Text);

                        }
                    }
                    else if (setp.searchSys == "Google")
                    {
                        sys = "https://www.google.ru/search?q=";
                        if (textBox1.Text.StartsWith("http") || textBox1.Text.StartsWith("https") || textBox1.Text.TrimEnd().EndsWith(".com") || textBox1.Text.TrimEnd().EndsWith(".ru"))
                        {

                            crome.Load(textBox1.Text);
                        }
                        else
                        {
                            crome.Load(sys + textBox1.Text);

                        }
                    }
                    else if (setp.searchSys == "Mail.ru")
                    {
                        sys = "https://mail.ru/search?search_source=mailru_desktop_safe&text=";
                        if (textBox1.Text.StartsWith("http") || textBox1.Text.StartsWith("https") || textBox1.Text.TrimEnd().EndsWith(".com") || textBox1.Text.TrimEnd().EndsWith(".ru"))
                        {

                            crome.Load(textBox1.Text);
                        }
                        else
                        {
                            crome.Load(sys + textBox1.Text);

                        }
                    }
                    else if (setp.searchSys == "DuckDuckGo")
                    {
                        sys = "https://duckduckgo.com/?q=";
                        if (textBox1.Text.StartsWith("http") || textBox1.Text.StartsWith("https") || textBox1.Text.TrimEnd().EndsWith(".com") || textBox1.Text.TrimEnd().EndsWith(".ru"))
                        {

                            crome.Load(textBox1.Text);
                        }
                        else
                        {
                            crome.Load(sys + textBox1.Text);

                        }
                    }


                }
            }
        }



        private void button6_Click(object sender, EventArgs e)
        {

            // button6.Top = tabControl1.SelectedTab.Top;
            // button6.Left = tabControl1.SelectedTab.Left;

            if (tabControl1.TabCount > 1)
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }




        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChromiumWebBrowser crome = tabControl1.SelectedTab.Controls[0] as ChromiumWebBrowser;
            crome.Stop();
            if (crome.CanGoBack)
            {

                crome.Back();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChromiumWebBrowser crome = tabControl1.TabPages[ind].Controls[0] as ChromiumWebBrowser;
            if (crome != null)
            {

                if (crome.IsLoading) { button2.BackgroundImage = load; } else { button2.BackgroundImage = reload; }
                crome.Reload(); try { images.RemoveAt(tabControl1.SelectedIndex); } catch { }
                if (crome.IsLoading) { crome.Stop(); }
            }
        }





        private void button7_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings(this);
            settings.Show();
        }



        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                string title;

                title = textBox1.Text;
                System.IO.File.AppendAllText("browser/save.txt", "\n" + title);
                MessageBox.Show("Добавленно в избранное!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }));

        }

        private void button10_Click(object sender, EventArgs e)
        {

            ChromiumWebBrowser crome = tabControl1.SelectedTab.Controls[0] as ChromiumWebBrowser;
            crome.Load(setp.startPage);

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string ch = File.ReadAllText("browser/ch.txt");
            if (ch == "y")
            {
                for (int i = 0; i < tabControl1.TabPages.Count - 1; i++)
                {
                    ChromiumWebBrowser chromium = (ChromiumWebBrowser)tabControl1.TabPages[i].Controls[0];
                    chromium.Stop();

                }
                File.WriteAllText("browser/pages.txt", " ");
                File.WriteAllText("browser/count.txt", Convert.ToString(tabControl1.TabCount - 1));
                for (int i = 0; i < tabControl1.TabCount - 1; i++)
                {


                    ChromiumWebBrowser chromium = (ChromiumWebBrowser)tabControl1.TabPages[i].Controls[0];

                    if (File.ReadAllLines("browser/pages.txt").First() == "")
                    {
                        File.AppendAllText("browser/pages.txt", chromium.Address);
                    }
                    else { File.AppendAllText("browser/pages.txt", "\n" + chromium.Address); }


                }

            }

            Cef.Shutdown();

            if (cashend)
            {
                //  Thread.Sleep(3000);
                string directoryPath = Environment.CurrentDirectory + @"\browser\cash\";




                foreach (string file in Directory.GetFiles(directoryPath))
                {
                    try
                    {



                        File.Delete(file);

                    }
                    catch (Exception)
                    {


                    }
                }


                foreach (string dir in Directory.GetDirectories(directoryPath))
                {
                    try
                    {
                        Directory.Delete(dir, true);
                    }
                    catch (Exception)
                    {


                    }
                }


            }
        }



        private void button11_Click(object sender, EventArgs e)
        {

            ChromiumWebBrowser crome = tabControl1.SelectedTab.Controls[0] as ChromiumWebBrowser;
            crome.Load(comboBox1.SelectedItem.ToString().Replace("https://", "").Replace("http://", "").Replace("www.", ""));



        }


        static public List<Image> images = new List<Image>();




        int index = 0;
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = tabControl1.SelectedIndex;

            //try
            //{
            //    MemoryStream memorystream2 = new MemoryStream(wc.DownloadData("http://" + new Uri(getCurrentBrowser().Address.ToString()).Host + "/favicon.ico"));
            //    icon = Image.FromStream(memorystream2);
            //}
            //catch { }
            // tabControl1.Invalidate();
        }

        GraphicsPath path = new GraphicsPath();

        WebClient wc2 = new WebClient();

        private void button5_Click_1(object sender, EventArgs e)
        {
            Download_man _Man = new Download_man();
            _Man.Show();
        }

        List<int> ints = new List<int>();
        float d = 0;
        private void button6_Click_1(object sender, EventArgs e)
        {
            ChromiumWebBrowser chromium = (ChromiumWebBrowser)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
            d += 0.2f;
            chromium.SetZoomLevel(d);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ChromiumWebBrowser chromium = (ChromiumWebBrowser)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
            d -= 0.2f;
            chromium.SetZoomLevel(d);
        }
        bool drag = false;
        Point point = new Point(0, 0);
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            point = new Point(e.X, e.Y);
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
        bool l = false;
        int w, h;
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        bool chy = false;

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {


            if (drag && l == false)
            {
                Point p = PointToScreen(e.Location);
                p = PointToScreen(e.Location); this.Location = new Point(p.X - point.X, p.Y - point.Y);

                if (p.Y < 3)
                {
                    this.WindowState = FormWindowState.Normal;
                    this.Width = Screen.PrimaryScreen.WorkingArea.Width;
                    this.Height = Screen.PrimaryScreen.WorkingArea.Height;

                    int centerX = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
                    int centerY = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;
                    tabControl1.Width = Screen.PrimaryScreen.WorkingArea.Width - this.Width; tabControl1.Height = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
                    tabControl1.Invalidate();
                    button15.Location = new Point(this.ClientSize.Width - 40);
                    button13.Location = new Point(this.ClientSize.Width - 80); button14.Location = new Point(this.ClientSize.Width - 120);
                    // Устанавливаем позицию окна по центру экрана
                    this.Location = new Point(centerX, centerY);
                    tabControl1.Width = Screen.PrimaryScreen.WorkingArea.Width + 10; tabControl1.Height = Screen.PrimaryScreen.WorkingArea.Height - 55;
                    l = false; chy = true;
                }
                else if (p.X < 3)
                {
                    this.WindowState = FormWindowState.Normal;
                    this.Height = Screen.PrimaryScreen.WorkingArea.Height;
                    this.Width = Screen.PrimaryScreen.WorkingArea.Width / 2;

                    int centerX = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 260;
                    button15.Location = new Point(this.ClientSize.Width - 40);
                    button13.Location = new Point(this.ClientSize.Width - 80); button14.Location = new Point(this.ClientSize.Width - 120);

                    tabControl1.Width = Width + 10; tabControl1.Height = Height;

                    // Устанавливаем позицию окна по центру экрана
                    this.Location = new Point(centerX); tabControl1.Invalidate();
                    l = false; chy = true;
                }
                else if (p.X > Screen.PrimaryScreen.WorkingArea.Width - 3)
                {
                    this.WindowState = FormWindowState.Normal;
                    this.Height = Screen.PrimaryScreen.WorkingArea.Height;
                    this.Width = Screen.PrimaryScreen.WorkingArea.Width / 2;

                    int centerX = (Screen.PrimaryScreen.WorkingArea.Width - this.Width);
                    button15.Location = new Point(this.ClientSize.Width - 40);
                    button13.Location = new Point(this.ClientSize.Width - 80); button14.Location = new Point(this.ClientSize.Width - 120);
                    this.Location = new Point(centerX);
                    tabControl1.Invalidate();
                    tabControl1.Width = Width + 10; tabControl1.Height = Height;
                    // Устанавливаем позицию окна по центру экрана

                    l = false; chy = true;
                }
                else if (p.X > Screen.PrimaryScreen.WorkingArea.Width - 3 && p.Y < 3)
                {

                }
            }
            if (drag && l == true && chy)
            {
                this.WindowState = FormWindowState.Normal;
                Point p = PointToScreen(e.Location);
                p = PointToScreen(e.Location);
                this.Location = new Point(p.X - point.X, p.Y - point.Y);
                this.Width = w;
                this.Height = h; l = false;
                button13.Location = b13; button14.Location = b14; button15.Location = b15; this.Width = w; this.Height = h;
                chy = false; button15.Location = new Point(this.ClientSize.Width - 40);
                button13.Location = new Point(this.ClientSize.Width - 80); button14.Location = new Point(this.ClientSize.Width - 120);
                tabControl1.Width = Width + 10; tabControl1.Height = Height;
                tabControl1.Invalidate();

            }
            if (chy) { l = true; }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; if (!l) { button13.Location = b13; button14.Location = b14; button15.Location = b15; l = true; }

        }

        private void button13_Click(object sender, EventArgs e)
        {

            if (!l)
            {
                this.WindowState = FormWindowState.Normal;
                this.Width = Screen.PrimaryScreen.WorkingArea.Width;


                this.Height = Screen.PrimaryScreen.WorkingArea.Height;
                int centerX = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
                int centerY = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;
                tabControl1.Invalidate();
                // Устанавливаем позицию окна
                this.Location = new Point(centerX, centerY); tabControl1.Width = Screen.PrimaryScreen.WorkingArea.Width + 10; tabControl1.Height = Screen.PrimaryScreen.WorkingArea.Height - 55;
                l = false; chy = true;
                l = true;


            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.Width = w;
                this.Height = h; l = false;
                button13.Location = b13; button14.Location = b14; button15.Location = b15; chy = false;
                tabControl1.Width = Width + 20; tabControl1.Height = Height - 55;
                tabControl1.Invalidate();

            }
            button15.Location = new Point(this.ClientSize.Width - 40);
            button13.Location = new Point(this.ClientSize.Width - 80); button14.Location = new Point(this.ClientSize.Width - 120);

        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (first == true)
            {
                Application.Exit();
            }
            else { this.Visible = false; this.Dispose(); }

        }



        Bitmap bitmap; WebClient wc;

        private void button15_MouseEnter(object sender, EventArgs e)
        {
            button15.BackColor = Color.FromArgb(255, 120, 110);
        }

        private void button15_MouseLeave(object sender, EventArgs e)
        {


            button15.BackColor = panel2.BackColor;
        }

        private void button13_MouseEnter(object sender, EventArgs e)
        {
            button13.BackColor = Color.DeepSkyBlue;
        }

        private void button13_MouseLeave(object sender, EventArgs e)
        {

            button13.BackColor = panel2.BackColor;
        }

        private void button14_MouseLeave(object sender, EventArgs e)
        {

            button14.BackColor = panel2.BackColor;
        }

        private void button14_MouseEnter(object sender, EventArgs e)
        {
            button14.BackColor = Color.DeepSkyBlue;
        }





        Rectangle tabBound;

        private void timer1_Tick(object sender, EventArgs e)
        {
            //GC.Collect();
            upt();
        }


        private void новаяВкладкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage tab = new TabPage();

            ChromiumWebBrowser chromium = new ChromiumWebBrowser("https://" + setp.startPage);
            tabControl1.Controls.Add(tab); tab.Controls.Add(chromium);
            tabControl1.SelectedTab = tab;
            chromium.AddressChanged += Chromium_AddressChanged;
            chromium.TitleChanged += Chromium_TitleChanged;
            tabControl1.SelectedTab = tab; TabPage tab2 = new TabPage();
            tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex - 1); tabControl1.Controls.Add(tab2);
            tab.Controls.Add(chromium);

            // button5.Top +=3;
            // button5.Left = tabControl1.SelectedTab.Left;

            FullScreen.DisplayHandler displayer = new FullScreen.DisplayHandler();
            chromium.DisplayHandler = displayer;
            chromium.Dock = DockStyle.Fill;
            // CefSharp.Example.Handlers.ExtensionHandler extension = new CefSharp.Example.Handlers.ExtensionHandler();
            RU_Browser_rec.CustomResourceRequestHandler requestHandler = new RU_Browser_rec.CustomResourceRequestHandler();
            chromium.RequestHandler = requestHandler;

            Ded.MyCustomLifeSpanHandler myCustomLifeSpanHandler = new Ded.MyCustomLifeSpanHandler();
            chromium.LifeSpanHandler = myCustomLifeSpanHandler;
            C_Browser0.CustomMenuHandler customMenu = new C_Browser0.CustomMenuHandler();
            chromium.MenuHandler = customMenu;
            string a99 = "", b = "";
            CefSharp.Example.DownloadHandler downloadHandler = new CefSharp.Example.DownloadHandler(a99, b);
            chromium.DownloadHandler = downloadHandler;
            chromium.Margin = Padding.Empty;
        }

        private void дублироватьВкладкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage tab = new TabPage();
            try
            {
                ChromiumWebBrowser chromium = (ChromiumWebBrowser)tabControl1.SelectedTab.Controls[0];
                tabControl1.Controls.Add(tab); tab.Controls.Add(chromium);
                tabControl1.SelectedTab = tab;
                chromium.AddressChanged += Chromium_AddressChanged;
                chromium.TitleChanged += Chromium_TitleChanged; TabPage tab2 = new TabPage();
                tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex - 1); tabControl1.Controls.Add(tab2);
                tab.Controls.Add(chromium);
                chromium.Reload();
                chromium.AddressChanged += Chromium_AddressChanged;
                chromium.TitleChanged += Chromium_TitleChanged;

                // button5.Top +=3;
                // button5.Left = tabControl1.SelectedTab.Left;

                FullScreen.DisplayHandler displayer = new FullScreen.DisplayHandler();
                chromium.DisplayHandler = displayer;
                chromium.Dock = DockStyle.Fill;
                // CefSharp.Example.Handlers.ExtensionHandler extension = new CefSharp.Example.Handlers.ExtensionHandler();
                RU_Browser_rec.CustomResourceRequestHandler requestHandler = new RU_Browser_rec.CustomResourceRequestHandler();
                chromium.RequestHandler = requestHandler;

                Ded.MyCustomLifeSpanHandler myCustomLifeSpanHandler = new Ded.MyCustomLifeSpanHandler();
                chromium.LifeSpanHandler = myCustomLifeSpanHandler;
                C_Browser0.CustomMenuHandler customMenu = new C_Browser0.CustomMenuHandler();
                chromium.MenuHandler = customMenu;
                string a99 = "", b = "";
                CefSharp.Example.DownloadHandler downloadHandler = new CefSharp.Example.DownloadHandler(a99, b);
                chromium.DownloadHandler = downloadHandler;
                chromium.Margin = Padding.Empty;
            }
            catch { }
        }

        private void открытьВкладкуВНовомОкнеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabDragger.newwin(tabControl1);
        }

        private void закрытьВсеВкладкиКромеВыбраннойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<TabPage> tabsToRemove = new List<TabPage>();
            for (int i = 0; i < tabControl1.TabCount - 1; i++)
            {

                TabPage tabPage = (TabPage)tabControl1.TabPages[i];
                // tabControl.SelectedIndex = 0;
                try
                {
                    if (i != tabControl1.SelectedIndex)
                    {
                        if (bools != null && i < bools.Count)
                        {
                            bools[i] = true;
                        }
                        if (images != null && i < images.Count)
                        {
                            images.RemoveAt(i);
                        }
                        tabsToRemove.Add(tabPage);
                        //ChromiumWebBrowser chromium = (ChromiumWebBrowser)tabControl1.TabPages[i].Controls[0];
                        //tabPage.Dispose(); 
                        //tabControl1.TabPages.Remove(tabPage);

                    }


                }
                catch { tabControl1.TabPages.Remove(tabPage); }
            }
            foreach (var tab in tabsToRemove)
            {
                tabControl1.TabPages.Remove(tab);
            }
        }

        private void разместитьСлеваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width / 2;

            int centerX = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 260;
            button15.Location = new Point(this.ClientSize.Width - 40);
            button13.Location = new Point(this.ClientSize.Width - 80); button14.Location = new Point(this.ClientSize.Width - 120);

            tabControl1.Width = Width + 10; tabControl1.Height = Height;

            // Устанавливаем позицию окна по центру экрана
            this.Location = new Point(centerX); tabControl1.Invalidate();
            l = false; chy = true;
        }



        private void разместитьСправаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width / 2;

            int centerX = (Screen.PrimaryScreen.WorkingArea.Width - this.Width);
            button15.Location = new Point(this.ClientSize.Width - 40);
            button13.Location = new Point(this.ClientSize.Width - 80); button14.Location = new Point(this.ClientSize.Width - 120);
            this.Location = new Point(centerX);
            tabControl1.Invalidate();
            tabControl1.Width = Width + 10; tabControl1.Height = Height;
            // Устанавливаем позицию окна по центру экрана

            l = false; chy = true;
        }

        private void наВесьЭкранToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            button15.Location = new Point(this.ClientSize.Width - 40);
            button13.Location = new Point(this.ClientSize.Width - 80); button14.Location = new Point(this.ClientSize.Width - 120);

            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            int centerX = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
            int centerY = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;
            tabControl1.Invalidate(); button15.Location = new Point(this.ClientSize.Width - 40);
            button13.Location = new Point(this.ClientSize.Width - 80); button14.Location = new Point(this.ClientSize.Width - 120);
            // Устанавливаем позицию окна
            this.Location = new Point(centerX, centerY); tabControl1.Width = Screen.PrimaryScreen.WorkingArea.Width + 10; tabControl1.Height = Screen.PrimaryScreen.WorkingArea.Height;
            l = false; chy = true;
            l = true;
        }

        private void наВесьРабочийЭкранToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            button15.Location = new Point(this.ClientSize.Width - 40);
            button13.Location = new Point(this.ClientSize.Width - 80); button14.Location = new Point(this.ClientSize.Width - 120);
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;

            button15.Location = new Point(this.ClientSize.Width - 40);
            button13.Location = new Point(this.ClientSize.Width - 80); button14.Location = new Point(this.ClientSize.Width - 120);
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            int centerX = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
            int centerY = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;
            tabControl1.Invalidate();
            // Устанавливаем позицию окна
            this.Location = new Point(centerX, centerY); tabControl1.Width = Screen.PrimaryScreen.WorkingArea.Width + 10; tabControl1.Height = Screen.PrimaryScreen.WorkingArea.Height - 55;
            l = false; chy = true;
            l = true;
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (first == true)
            {
                Application.Exit();
            }
            else { this.Visible = false; this.Dispose(); }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) { button4.PerformClick(); }
        }

        private void tabControl1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                ChromiumWebBrowser chromium = (ChromiumWebBrowser)tabControl1.SelectedTab.Controls[0];
                textBox1.Text = chromium.Address;
            }
            catch { }
        }

        private void разместитьВПравыйВерхнийУголToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height / 2 + 25;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width / 2;

            int centerX = (Screen.PrimaryScreen.WorkingArea.Width - this.Width);
            button15.Location = new Point(this.ClientSize.Width - 40);
            button13.Location = new Point(this.ClientSize.Width - 80); button14.Location = new Point(this.ClientSize.Width - 120);
            this.Location = new Point(centerX);
            tabControl1.Invalidate();
            tabControl1.Width = Width + 10; tabControl1.Height = Height;


            l = false; chy = true;
        }

        private void разместитьВЛевыйВерхнийУголToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height / 2 + 25;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width / 2;

            int centerX = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 966;
            button15.Location = new Point(this.ClientSize.Width - 40);
            button13.Location = new Point(this.ClientSize.Width - 80); button14.Location = new Point(this.ClientSize.Width - 120);
            this.Location = new Point(centerX);
            tabControl1.Invalidate();
            tabControl1.Width = Width + 10; tabControl1.Height = Height;


            l = false; chy = true;
        }

        private void разместитьВПравыйНижнийУголToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height / 2 + 25;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width / 2;

            int centerX = (Screen.PrimaryScreen.WorkingArea.Width - this.Width);
            int y = (Screen.PrimaryScreen.WorkingArea.Height - this.Height);
            button15.Location = new Point(this.ClientSize.Width - 40);
            button13.Location = new Point(this.ClientSize.Width - 80); button14.Location = new Point(this.ClientSize.Width - 120);
            this.Location = new Point(centerX, y);
            tabControl1.Invalidate();
            tabControl1.Width = Width + 10; tabControl1.Height = Height;
            // Устанавливаем позицию окна по центру экрана

            l = false; chy = true;

        }

        private void разместитьВЛевыйНижнийУголToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height / 2 + 25;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width / 2;

            int centerX = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 966;
            int y = (Screen.PrimaryScreen.WorkingArea.Height - this.Height);
            button15.Location = new Point(this.ClientSize.Width - 40);
            button13.Location = new Point(this.ClientSize.Width - 80); button14.Location = new Point(this.ClientSize.Width - 120);
            this.Location = new Point(centerX, y);
            tabControl1.Invalidate();
            tabControl1.Width = Width + 10; tabControl1.Height = Height;


            l = false; chy = true;
        }





        Image load = Image.FromFile("browser/img/load.png");
        Image reload = Image.FromFile("browser/img/rel.png");
        public static Image im = Image.FromFile("browser/img/k.png");

        MemoryStream memorystream2;
        Point[] points; Brush textBrush; Rectangle backArea; Point[] points1; GraphicsPath pat; Point[] points2;
        public void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {


            // Рисуем стрелку
            using (Brush brush = new SolidBrush(Color.Red)) // Измените цвет по своему усмотрению
            {
                int arrowX = this.Width - 15; // Позиция стрелки по X
                int arrowY = (this.Height - 10) / 2; // Позиция стрелки по Y
                e.Graphics.FillPolygon(brush, new Point[]
                {
                   new Point(arrowX, arrowY),
                   new Point(arrowX + 10, arrowY),
                   new Point(arrowX + 5, arrowY + 10)
                });
            }
        }
        public void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {

            Graphics g = e.Graphics;
            Bitmap bitmap1 = new Bitmap(im, 328, 60);

            Rectangle r = e.Bounds;


            r = this.tabControl1.GetTabRect(e.Index);
            r.Offset(2, 2);

            TabPage tabPage = tabControl1.TabPages[e.Index];
            //  Rectangle tabBounds = tabControl1.GetTabRect(e.Index);
            Rectangle tabBounds2 = tabControl1.GetTabRect(e.Index);

            // Визуальное изменение размера только второй вкладки
            points = new Point[] {
        new Point(tabBounds2.Left + 20, tabBounds2.Top),
        new Point(tabBounds2.Left, tabBounds2.Bottom+8),
        new Point(tabBounds2.Right, tabBounds2.Bottom+8),
        new Point(tabBounds2.Right - 20, tabBounds2.Top)

    }; GraphicsPath p = new GraphicsPath(); // Создаем новый path для каждой вкладки
            p.AddLines(points);


            this.BackColor = Color.FromArgb(a00, a11, a22);
            Rectangle pageArea = tabControl1.DisplayRectangle;

            textBrush = new SolidBrush(Color.FromArgb(a0, a1, a2));
            // Устанавливаем область для рисования фона
            backArea = new Rectangle(0, 0, tabControl1.Width, tabControl1.Height);

            // Рисуем фон за пределами области вкладок

            using (Brush backBrush = new SolidBrush(Color.FromArgb(a00, a11, a22))) // Цвет фона
            {
                // Проходим по всем вкладкам
                for (int i = 0; i < tabControl1.TabCount; i++)
                {
                    if (i == tabControl1.TabCount - 1)
                    {

                        pat = new GraphicsPath(); // Создаем новый path для каждой вкладки
                        tabBound = tabControl1.GetTabRect(i);

                        // Определите точки для создания заостренного угла
                        points1 = new Point[] {
            new Point(tabBound.Left +50, tabBound.Top),
            new Point(tabBound.Left+30, tabBound.Bottom),
            new Point(tabBound.Right-145, tabBound.Bottom),
            new Point(tabBound.Right - 165, tabBound.Top)
        };

                        // Добавление линий в path и закрытие фигуры
                        pat.AddLines(points1);
                        ;

                        // Исключаем область вкладки из рисования фона
                        g.SetClip(pat, CombineMode.Exclude);

                    }
                    else
                    {

                        path = new GraphicsPath(); // Создаем новый path для каждой вкладки
                        tabBound = tabControl1.GetTabRect(i);

                        // Определите точки для создания заостренного угла
                        points2 = new Point[] {
            new Point(tabBound.Left + 20, tabBound.Top),
            new Point(tabBound.Left, tabBound.Bottom+8),
            new Point(tabBound.Right, tabBound.Bottom+8),
            new Point(tabBound.Right - 20, tabBound.Top)
        };

                        // Добавление линий в path и закрытие фигуры
                        path.AddLines(points2);


                        // Исключаем область вкладки из рисования фона
                        g.SetClip(path, CombineMode.Exclude);


                    }
                }
                g.FillRegion(backBrush, new Region(new Rectangle(0, 0, tabControl1.Width, tabControl1.Height)));
            }
            g.ResetClip();


            string tabText = this.tabControl1.TabPages[e.Index].Text + "     ";
            // Задаем шрифт и цвет текста

            Font tabFont = new Font(File.ReadAllText("browser/rgb/2/r.txt"), Convert.ToInt32(File.ReadAllText("browser/rgb/2/sh.txt")), FontStyle.Bold, GraphicsUnit.Pixel);


            // Получаем область контрола TabControl



            // Задаем цвет фона вкладки
            if (e.Index == tabControl1.TabCount)
            {

                g.FillPath(new SolidBrush(Color.Black), p);


            }
            if (e.Index == tabControl1.SelectedIndex)
            {


                // Цвет активной вкладки

                // g.FillRectangle(new SolidBrush(Color.FromArgb(a0a, a1a, a2a)), e.Bounds);
                g.FillPath(new SolidBrush(Color.FromArgb(a0a, a1a, a2a)), p);
                g.DrawPath(new Pen(Color.Black), p);

            }
            else
            {




                //g.FillRectangle(new SolidBrush(Color.FromArgb(a0a, a1a, a2a)), e.Bounds);
                //Rectangle tabBound = tabControl1.GetTabRect(tabControl1.TabPages.Count);
                g.FillPath(new SolidBrush(Color.FromArgb(a0a6, a1a6, a2a6)), p);

                //             points = new Point[] {
                //new Point(tabBound.Left +36, tabBound.Top+2),
                //     new Point(tabBound.Left+18, tabBound.Bottom-1),
                //     new Point(tabBound.Right-131, tabBound.Bottom-1),
                //     new Point(tabBound.Right - 150, tabBound.Top+2)

                //}; // Создаем новый path для каждой вкладки
                // p.AddLines(points);





            }


            g.DrawImage(bitmap1, new Point(r.X + (
                      this.tabControl1.GetTabRect(e.Index).Width - _imageLocation.X - 232), _imageLocation.Y - 2));

            Image img = new Bitmap(AddImage);
            // Рисуем текст вкладки
            g.DrawString("             " + tabText, tabFont, textBrush, new PointF(e.Bounds.X - 1, e.Bounds.Y + 10));
            bool Ch = false;
            // Освобождаем ресурсы
            if (tabControl1.TabCount == 1)
            {
                if (first == true)
                {
                    Application.Exit();
                }
                else { this.Visible = false; this.Dispose(); }
            }
            if (e.Index == this.tabControl1.TabCount - 1)
            {
                img = new Bitmap(AddImage);
                Ch = true;

                tabControl1.Padding = new Point(20, 4);
            }
            else
            {
                img = new Bitmap(CloseImage);

            }


            Brush TitleBrush = new SolidBrush(Color.Black);
            Font f = this.Font;
            string title = this.tabControl1.TabPages[e.Index].Text;
            // e.Graphics.DrawString(title, f, TitleBrush, new PointF(r.X, r.Y));
            if (Ch == true)
            {
                e.Graphics.DrawImage(img, new Point(r.X + (
                    this.tabControl1.GetTabRect(e.Index).Width / 5 + 5),

                    _imageLocation.Y + 1));

            }
            else
            {
                if (e.Index == tabControl1.SelectedIndex)
                {
                    e.Graphics.DrawImage(img, new Point(r.X + (
              this.tabControl1.GetTabRect(e.Index).Width - _imageLocation.X - 18),

              _imageLocation.Y + 4));
                }
                else
                {
                    e.Graphics.DrawImage(img, new Point(r.X + (
              this.tabControl1.GetTabRect(e.Index).Width - _imageLocation.X - 17),

              _imageLocation.Y + 4));
                }
            }
            // e.Graphics.DrawImage(img, new Point(800, 8));


            try
            {

                // img2 = new Bitmap(icon);





                // tabControl1.Padding = new Point(20, 4);

                //  tabControl1.TabPages[tabControl1.TabCount].Size = new Size(200, 20);

                tabControl1.Padding = new Point(20, 4);
                ind = e.Index;
                if (e.Index >= 0 && e.Index < images.Count && images[e.Index] != null)
                {


                    if (e.Index != tabControl1.TabCount - 1)
                    {

                        if (e.Index == tabControl1.SelectedIndex)
                        {
                            g.DrawImage(images[e.Index], new Point(r.X + (
                                this.tabControl1.GetTabRect(e.Index).Width + 3 - _imageLocation.X - 208), _imageLocation.Y));
                        }
                        else
                        {
                            g.DrawImage(images[e.Index], new Point(r.X + (
                                this.tabControl1.GetTabRect(e.Index).Width + 4 - _imageLocation.X - 207), _imageLocation.Y));
                        }
                    }
                }
                else if (e.Index >= 0 && e.Index < tabControl1.TabCount - 1)
                {
                    // Если индекс выходит за пределы списка или изображение равно null,
                    // и текущая вкладка не является последней, добавляем изображение
                    try
                    {
                        wc = new WebClient();
                        memorystream2 = new MemoryStream(wc.DownloadData($"https://t1.gstatic.com/faviconV2?client=SOCIAL&type=FAVICON&fallback_opts=TYPE,SIZE,URL&url=http://" + new Uri(getCurrentBrowser().Address.ToString()).Host + "&size=32"));
                        Image icon = Image.FromStream(memorystream2);
                        ind = e.Index;
                        bitmap = new Bitmap(icon, new Size(32, 32));
                        images.Insert(e.Index, bitmap);

                    }
                    catch (Exception ex)
                    {
                        // Обработка исключений, если загрузка изображения не удалась
                        Console.WriteLine("Ошибка загрузки изображения: " + ex.Message);
                    }
                }


            }
            catch { }
            //   tabControl1.TabPages[tabControl1.SelectedIndex].Width = 20;
            arrowPictureBox.BringToFront();
            double d = comboBox1.Location.X + 108;
            arrowPictureBox.Size = new Size(comboBox1.Width / 8, comboBox1.Height - 5);
            arrowPictureBox.Location = new Point(Convert.ToInt32(d)+1, comboBox1.Location.Y+3);
            textBrush.Dispose();
            tabFont.Dispose();
            TitleBrush.Dispose();
            panel1.Focus();









        }




        int _tabWidth = 0;
        string[] comLines = File.ReadAllLines("browser/com.txt");

        private void panel2_DoubleClick(object sender, EventArgs e)
        {
            if (l && chy)
            {
                this.WindowState = FormWindowState.Normal;
                this.Width = w;
                this.Height = h; l = false;
                button13.Location = b13; button14.Location = b14; button15.Location = b15; chy = false;
                tabControl1.Width = Width + 20; tabControl1.Height = Height - 55;
                tabControl1.Invalidate();
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                button15.Location = new Point(this.ClientSize.Width - 40);
                button13.Location = new Point(this.ClientSize.Width - 80); button14.Location = new Point(this.ClientSize.Width - 120);
                this.Width = Screen.PrimaryScreen.WorkingArea.Width;

                button15.Location = new Point(this.ClientSize.Width - 40);
                button13.Location = new Point(this.ClientSize.Width - 80); button14.Location = new Point(this.ClientSize.Width - 120);
                this.Height = Screen.PrimaryScreen.WorkingArea.Height;
                int centerX = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
                int centerY = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;
                tabControl1.Invalidate();
                // Устанавливаем позицию окна
                this.Location = new Point(centerX, centerY); tabControl1.Width = Screen.PrimaryScreen.WorkingArea.Width + 10; tabControl1.Height = Screen.PrimaryScreen.WorkingArea.Height - 55;
                l = false; chy = true;
                l = true;
            }
        }



        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (Cef.IsInitialized)
            {
                try
                {
                    tabControl1.Width = this.Width - 8;
                    tabControl1.Height = this.Height - 80;
                    //button6.Location = new Point((int)(this.Width / 0.73548), button6.Location.Y);
                    //button9.Location = new Point((int)(this.Width * 0.73548), button9.Location.Y);
                }
                catch (Exception)
                {
                    // Обработка исключений
                }
            }
        }
        List<bool> bools = new List<bool>();

        private void звукНаСтраницеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChromiumWebBrowser chromium = tabControl1.SelectedTab.Controls[0] as ChromiumWebBrowser;
            if (bools[tabControl1.SelectedIndex] == false)
            {
                if (chromium != null)
                {
                    //contextMenuStrip1.Items[0].Text = "Включить вук на странице";
                    chromium.GetBrowserHost().SetAudioMuted(true);
                    bools.Insert(tabControl1.SelectedIndex, true);
                }
            }
            else
            {
                if (chromium != null)
                {
                    //contextMenuStrip1.Items[0].Text = "Выключить звук на странице";
                    chromium.GetBrowserHost().SetAudioMuted(false);
                    bools[tabControl1.SelectedIndex] = false;
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (bools[tabControl1.SelectedIndex] == null || bools[tabControl1.SelectedIndex] == false)
            {

                contextMenuStrip1.Items[0].Text = "Выключить звук на странице";

            }
            else
            {
                contextMenuStrip1.Items[0].Text = "Включить звук на странице";


            }
        }

        string[] bb2Lines = File.ReadAllLines("browser/bb2.txt");
        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {




            TabControl tabControl = (TabControl)sender;
            Point p = e.Location;


            Rectangle r = this.tabControl1.GetTabRect(ind);
            r.Offset(_tabWidth - 18, imageHitArea.Y);
            r.Width = 32;
            _tabWidth = this.tabControl1.GetTabRect(ind).Width - (imageHitArea.X);
            r.Height = 32;
            if (tabControl1.SelectedIndex == this.tabControl1.TabCount - 1)
            {


                //  comboBox1.Font = new Font(File.ReadAllText("browser/rgb/2/r.txt"), 11.6f);

                if (setp.startPage == "дед")
                {
                    PictureBox pictureBox = new PictureBox();

                    // Задаем режим размера, чтобы изображение подгонялось под размеры PictureBox
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                    // Загружаем изображение
                    pictureBox.Image = Image.FromFile("browser/rgb/ded.jpg");

                    // Устанавливаем размер и положение PictureBox на форме
                    pictureBox.Width = tabPage1.Width;
                    pictureBox.Height = tabPage1.Height;
                    pictureBox.Left = 10;
                    pictureBox.Top = 10;

                    TabPage tab7 = new TabPage();
                    // Добавляем PictureBox на форму
                    tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex - 1);
                    tab7.Controls.Add(pictureBox);
                    tabControl1.TabPages.Add(tab7);
                    tabControl1.SelectedTab = tab7;

                }
                TabPage tab = new TabPage();
                tab.Text = "";
                tabControl1.Controls.Add(tab);

                setp = JsonSerializer.Deserialize<SettingPar>(System.IO.File.ReadAllText("browser/settings.json"));
                // 
                //comboBox1.Font = new Font(File.ReadAllText("browser/rgb/2/r.txt"), 1);
                //textBox1.Font = new Font(File.ReadAllText("browser/rgb/2/r.txt"), 16.8f);
                //int a0000 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/r.txt"));
                //int a1111 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/g.txt"));
                //int a2222 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/b5.txt"));
                //button1.BackColor = Color.FromArgb(a0000, a1111, a2222);
                //button2.BackColor = Color.FromArgb(a0000, a1111, a2222);
                //button3.BackColor = Color.FromArgb(a0000, a1111, a2222);
                //button4.BackColor = Color.FromArgb(a0000, a1111, a2222);
                //button5.BackColor = Color.FromArgb(a0000, a1111, a2222);
                //button7.BackColor = Color.FromArgb(a0000, a1111, a2222);
                //button6.BackColor = Color.FromArgb(a0000, a1111, a2222);
                //button12.BackColor = Color.FromArgb(a0000, a1111, a2222);
                //button8.BackColor = Color.FromArgb(a0000, a1111, a2222);
                //button9.BackColor = Color.FromArgb(a0000, a1111, a2222);
                //button10.BackColor = Color.FromArgb(a0000, a1111, a2222);
                //button11.BackColor = Color.FromArgb(a0000, a1111, a2222); button13.BackColor = panel2.BackColor;
                //button14.BackColor = panel2.BackColor;
                //button15.BackColor = panel2.BackColor;

                CefSettings set = new CefSettings();
                CefSharp.Cookie c = new CefSharp.Cookie();
                //if (setp.Style == "Popup")
                //{
                //    button1.FlatStyle = FlatStyle.Popup;
                //    button2.FlatStyle = FlatStyle.Popup;
                //    button3.FlatStyle = FlatStyle.Popup;
                //    button4.FlatStyle = FlatStyle.Popup;
                //    button6.FlatStyle = FlatStyle.Popup;
                //    button12.FlatStyle = FlatStyle.Popup; button5.FlatStyle = FlatStyle.Popup;
                //    button7.FlatStyle = FlatStyle.Popup;
                //    button8.FlatStyle = FlatStyle.Popup;
                //    button9.FlatStyle = FlatStyle.Popup;
                //    button10.FlatStyle = FlatStyle.Popup;
                //    button11.FlatStyle = FlatStyle.Popup;


                //}
                //if (setp.Style == "Standard")
                //{
                //    button1.FlatStyle = FlatStyle.Standard;
                //    button2.FlatStyle = FlatStyle.Standard;
                //    button3.FlatStyle = FlatStyle.Standard;
                //    button4.FlatStyle = FlatStyle.Standard; button5.FlatStyle = FlatStyle.Standard;
                //    button6.FlatStyle = FlatStyle.Standard;
                //    button12.FlatStyle = FlatStyle.Standard;
                //    button5.FlatStyle = FlatStyle.Standard;
                //    button7.FlatStyle = FlatStyle.Standard;
                //    button8.FlatStyle = FlatStyle.Standard;
                //    button9.FlatStyle = FlatStyle.Standard;
                //    button10.FlatStyle = FlatStyle.Standard;
                //    button11.FlatStyle = FlatStyle.Standard;

                //}
                //if (setp.Style == "Flat")
                //{
                //    button1.FlatStyle = FlatStyle.Flat;
                //    button2.FlatStyle = FlatStyle.Flat;
                //    button3.FlatStyle = FlatStyle.Flat;
                //    button4.FlatStyle = FlatStyle.Flat;
                //    button5.FlatStyle = FlatStyle.Flat;
                //    button7.FlatStyle = FlatStyle.Flat;
                //    button8.FlatStyle = FlatStyle.Flat; button6.FlatStyle = FlatStyle.Flat; button5.FlatStyle = FlatStyle.Flat;
                //    button12.FlatStyle = FlatStyle.Flat;
                //    button9.FlatStyle = FlatStyle.Flat;
                //    button10.FlatStyle = FlatStyle.Flat;
                //    button11.FlatStyle = FlatStyle.Flat;

                //}
                //if (setp.saveURL == "URL")
                //{
                //    System.IO.File.WriteAllText("browser/c.txt", "yu");
                //}


                //else if (setp.saveURL == "Название файла")
                //{
                //    System.IO.File.WriteAllText("browser/c.txt", "ys");
                //}
                //if (setp.saveCash == true)
                //{




                //}
                //else { set.CefCommandLineArgs.Add("disable-application-cache", "1"); }

                //int a0 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/c.txt"));
                //int a1 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/c1.txt"));
                //int a2 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/c2.txt"));
                //set.UserAgent = File.ReadAllText("browser/useragent.txt");

                //textBox1.BackColor = Color.FromArgb(a0, a1, a2);
                //a0 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/3/r.txt"));
                //a1 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/3/g.txt"));
                //a2 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/3/b.txt"));
                //textBox1.ForeColor = Color.FromArgb(a0, a1, a2);
                //comboBox1.ForeColor = Color.FromArgb(a0, a1, a2);
                //// Заполняем фон за вкладками

                //int a000 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/s1.txt"));
                //int a111 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/s2.txt"));
                //int a222 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/s3.txt"));
                //comboBox1.BackColor = Color.FromArgb(a000, a111, a222);
                //comboBox1.SelectedItem = "Быстрый доступ";

                //string[] dos = System.IO.File.ReadAllLines("browser/dostyp.txt");
                //set.CefCommandLineArgs.Add("enable-extensions", "1"); // Включить расширения
                //a0 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/4/r.txt"));
                //a1 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/4/g.txt"));
                //a2 = Convert.ToInt32(System.IO.File.ReadAllText("browser/rgb/4/b.txt"));
                //panel2.BackColor = Color.FromArgb(a0, a1, a2);
                //comboBox1.Items.Clear();
                //comboBox1.Items.AddRange(dos);
                //comboBox1.Font = new Font(File.ReadAllText("browser/rgb/2/r.txt"), 11.6f);
                //tabControl1.SelectedIndex = tabControl1.TabCount - 2;
                ChromiumWebBrowser chromium = new ChromiumWebBrowser("https://" + setp.startPage);
                tabControl1.SelectedTab.Controls.Add(chromium);
                //button13.BackColor = panel2.BackColor;
                //button14.BackColor = panel2.BackColor;
                //button15.BackColor = panel2.BackColor;
                chromium.AddressChanged += Chromium_AddressChanged;
                chromium.TitleChanged += Chromium_TitleChanged;
                chromium.LoadingStateChanged += IsLoading;
                set.RemoteDebuggingPort = 0; // Отключение удаленного отладчика
                set.IgnoreCertificateErrors = false; // Не игнорировать ошибки сертификатов
                set.CefCommandLineArgs.Add("enable-begin-frame-scheduling");

                set.CefCommandLineArgs.Add("disable-software-rasterizer");
                // button5.Top +=3;
                // button5.Left = tabControl1.SelectedTab.Left;



                set.UserAgent = File.ReadAllText("browser/useragent.txt");


                FullScreen.DisplayHandler displayer = new FullScreen.DisplayHandler();
                chromium.DisplayHandler = displayer;
                chromium.Dock = DockStyle.Fill;
                // CefSharp.Example.Handlers.ExtensionHandler extension = new CefSharp.Example.Handlers.ExtensionHandler();

                RU_Browser_rec.CustomResourceRequestHandler requestHandler = new RU_Browser_rec.CustomResourceRequestHandler();
                chromium.RequestHandler = requestHandler;
                Ded.MyCustomLifeSpanHandler myCustomLifeSpanHandler = new Ded.MyCustomLifeSpanHandler();
                chromium.LifeSpanHandler = myCustomLifeSpanHandler;
                C_Browser0.CustomMenuHandler customMenu = new C_Browser0.CustomMenuHandler();
                //  chromium.FrameLoadEnd += NavigationEnd;
                chromium.MenuHandler = customMenu;
                string a99 = "", b = "";
                CefSharp.Example.DownloadHandler downloadHandler = new CefSharp.Example.DownloadHandler(a99, b);
                chromium.DownloadHandler = downloadHandler;
                chromium.Margin = Padding.Empty;




            }
            else
            {
                if (r.Contains(p))
                {
                    TabPage tabPage = (TabPage)tabControl.TabPages[ind];
                    // tabControl.SelectedIndex = 0;
                    try
                    {
                        ChromiumWebBrowser chromium = (ChromiumWebBrowser)tabControl1.SelectedTab.Controls[0];
                        images.RemoveAt(ind);
                        tabPage.Dispose();
                        tabControl.TabPages.Remove(tabPage);
                        bools[ind] = true;


                    }
                    catch { tabControl.TabPages.Remove(tabPage); }





                }


            }

        }
    }

}





using C_Browser;
using CefSharp;
using RU_Browser;
using System;
using System.Diagnostics;
using System.Media;
using System.Text.Json;
using System.Windows.Forms;
using Directory = System.IO.Directory;
using File = System.IO.File;

namespace TIMBrowser
{
    public partial class Settings : Form
    {
        public string rgb_S = "";
        public string rgb_S1 = "";
        public string rgb_S2 = "";
        public class SettingPar
        {

            public string searchSys { get; set; }
            public string startPage { get; set; }
            public bool saveHist { get; set; }
            public string saveType { get; set; }
            public bool saveDate { get; set; }
            public bool saveCash { get; set; }
            public bool saveDown { get; set; }
            public string saveURL { get; set; }
            public string Style { get; set; }
            public bool Ext { get; set; }

        }
        Form1 frm;
        public Settings(Form1 form)
        {

            frm = form;
            InitializeComponent();
            this.TopMost = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SettingPar setp = new SettingPar
            {
                searchSys = comboBox1.Text,
                startPage = comboBox2.Text,
                saveHist = checkBox1.Checked,
                saveType = comboBox3.Text,
                saveDate = checkBox2.Checked,
                saveCash = checkBox3.Checked,
                saveDown = checkBox4.Checked,
                saveURL = comboBox4.Text,
                Style = comboBox5.Text,
                Ext = checkBox5.Checked,
            };
            rgb_S = textBox2.Text;
            rgb_S1 = textBox3.Text;
            rgb_S2 = textBox4.Text;
            try
            {

          
            if (checkBox6.Checked == true) { File.WriteAllText("browser/ch.txt", "y"); }
            else { File.WriteAllText("browser/ch.txt", "n"); }  }
            catch 
            {

               
            }
         
            if (checkBox7.Checked == true) { File.WriteAllText("browser/inc.txt", "y"); }
            else { File.WriteAllText("browser/inc.txt", "n"); }
            if (checkBox11.Checked == true) { File.WriteAllText("browser/rgb/cuswin.txt", "y"); }
            else { File.WriteAllText("browser/rgb/cuswin.txt", "n"); }
            if (checkBox8.Checked == true) { File.WriteAllText("browser/poz.txt", "y"); }
            else
            {
                File.WriteAllText("browser/poz.txt", "n");
            }
            if (checkBox9.Checked == true) { File.WriteAllText("browser/mb.txt", "Авто"); }
            else
            {
                File.WriteAllText("browser/mb.txt", textBox32.Text);
            }

            if (checkBox7.Checked == true)
            {
                setp.saveHist = false;
                setp.saveCash = false;
                setp.saveDown = false;
            }
            else
            {
                setp.saveHist = true;
                setp.saveCash = true;
                setp.saveDown = true;
            }
            if (checkBox9.Checked) { textBox32.Enabled = false; }
            else
            {
                textBox32.Enabled = true;
            }

            File.WriteAllText("browser/rgb/c.txt", rgb_S);
            File.WriteAllText("browser/rgb/c1.txt", rgb_S1);
            File.WriteAllText("browser/rgb/c2.txt", rgb_S2);

            File.WriteAllText("browser/rgb/b.txt", textBox5.Text);
            File.WriteAllText("browser/rgb/b1.txt", textBox6.Text);
            File.WriteAllText("browser/rgb/b2.txt", textBox7.Text);
            if (checkBox5.Checked == true) { File.WriteAllText("browser/extm.txt", "y"); } else { File.WriteAllText("browser/extm.txt", "n"); }

            if (checkBox10.Checked == true) { File.WriteAllText("browser/use.txt", "y"); } else { File.WriteAllText("browser/use.txt", "n"); }
            File.WriteAllText("browser/rgb/s1.txt", textBox8.Text);
            File.WriteAllText("browser/rgb/s2.txt", textBox9.Text);
            File.WriteAllText("browser/rgb/s3.txt", textBox10.Text);

            File.WriteAllText("browser/rgb/b5.txt", textBox11.Text);
            File.WriteAllText("browser/rgb/g.txt", textBox12.Text);
            File.WriteAllText("browser/rgb/r.txt", textBox13.Text);

            File.WriteAllText("browser/rgb/3/r.txt", textBox18.Text);
            File.WriteAllText("browser/rgb/3/g.txt", textBox16.Text);
            File.WriteAllText("browser/rgb/3/b.txt", textBox15.Text);

            File.WriteAllText("browser/rgb/4/r.txt", textBox29.Text);
            File.WriteAllText("browser/rgb/4/g.txt", textBox28.Text);
            File.WriteAllText("browser/rgb/4/b.txt", textBox27.Text);

            File.WriteAllText("browser/rgb/3/r2.txt", textBox21.Text);
            File.WriteAllText("browser/rgb/3/g2.txt", textBox20.Text);
            File.WriteAllText("browser/rgb/3/b2.txt", textBox19.Text);

            File.WriteAllText("browser/rgb/3/r3.txt", textBox24.Text);
            File.WriteAllText("browser/rgb/3/g3.txt", textBox23.Text);
            File.WriteAllText("browser/rgb/3/b3.txt", textBox22.Text);

            File.WriteAllText("browser/rgb/2/sh.txt", textBox17.Text);
            File.WriteAllText("browser/rgb/2/r.txt", textBox14.Text);

            File.WriteAllText("browser/com.txt", textBox30.Text);
            File.WriteAllText("browser/bb2.txt", textBox31.Text);

            File.WriteAllText("browser/useragent.txt", textBox33.Text);

            string json = JsonSerializer.Serialize(setp);
            File.WriteAllText("browser/settings.json", json);
            if (setp.saveURL == "URL")
            {
                File.WriteAllText("browser/c.txt", "yu");
            }
            else if (setp.saveURL == "Название файла")
            {
                File.WriteAllText("browser/c.txt", "ys");
            }

            Form1.Aply_set(frm);


        }

        private void Settings_Load(object sender, EventArgs e)
        {

            foreach (var directory in Directory.GetDirectories("browser/exen/"))
            {
                int lastIndex = directory.ToString().LastIndexOf("/");
                string trimmedString = "";
                if (lastIndex != -1)
                {
                    trimmedString = directory.ToString().Substring(lastIndex);
                    trimmedString = trimmedString.Substring(1);
                   
                }

                listBox4.Items.Add(trimmedString);
            }

            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            string a = Cef.ChromiumVersion.ToString();
            label14.Text = $"Версия Chromium: {a}";
            string a2 = Cef.CefSharpVersion.ToString();
            label15.Text = $"Версия CefSharp: {a2}";
            string[] hist = File.ReadAllLines("browser/history.txt");
            listBox1.Items.AddRange(hist);
            string[] down = File.ReadAllLines("browser/down.txt");
            listBox3.Items.AddRange(down);
            string[] save = File.ReadAllLines("browser/save.txt");
            listBox2.Items.AddRange(save);

            string ch = File.ReadAllText("browser/ch.txt");
            if (ch == "y") { checkBox6.Checked = true; }
            else { checkBox6.Checked = false; }

            string coswin = File.ReadAllText("browser/rgb/cuswin.txt");
            if (coswin == "y") { checkBox11.Checked = true; }
            else { checkBox11.Checked = false; }

            string inc = File.ReadAllText("browser/inc.txt");
            if (inc == "y") { checkBox7.Checked = true; }
            else { checkBox7.Checked = false; }

            string poz = File.ReadAllText("browser/poz.txt");
            if (poz == "y") { checkBox8.Checked = true; }
            else { checkBox8.Checked = false; }
            string use = File.ReadAllText("browser/use.txt");
            if (use == "y") { checkBox10.Checked = true; }
            else { checkBox10.Checked = false; }
            textBox2.Text = File.ReadAllText("browser/rgb/c.txt");
            textBox3.Text = File.ReadAllText("browser/rgb/c1.txt");
            textBox4.Text = File.ReadAllText("browser/rgb/c2.txt");

            textBox5.Text = File.ReadAllText("browser/rgb/b.txt");
            textBox6.Text = File.ReadAllText("browser/rgb/b1.txt");
            textBox7.Text = File.ReadAllText("browser/rgb/b2.txt");

            textBox8.Text = File.ReadAllText("browser/rgb/s1.txt");
            textBox9.Text = File.ReadAllText("browser/rgb/s2.txt");
            textBox10.Text = File.ReadAllText("browser/rgb/s3.txt");
            textBox11.Text = File.ReadAllText("browser/rgb/b5.txt");
            textBox12.Text = File.ReadAllText("browser/rgb/g.txt");
            textBox13.Text = File.ReadAllText("browser/rgb/r.txt");


            textBox17.Text = File.ReadAllText("browser/rgb/2/sh.txt");
            textBox14.Text = File.ReadAllText("browser/rgb/2/r.txt");

            textBox18.Text = File.ReadAllText("browser/rgb/3/r.txt");
            textBox16.Text = File.ReadAllText("browser/rgb/3/g.txt");
            textBox15.Text = File.ReadAllText("browser/rgb/3/b.txt");

            textBox29.Text = File.ReadAllText("browser/rgb/4/r.txt");
            textBox28.Text = File.ReadAllText("browser/rgb/4/g.txt");
            textBox27.Text = File.ReadAllText("browser/rgb/4/b.txt");

            textBox21.Text = File.ReadAllText("browser/rgb/3/r2.txt");
            textBox20.Text = File.ReadAllText("browser/rgb/3/g2.txt");
            textBox19.Text = File.ReadAllText("browser/rgb/3/b2.txt");

            textBox24.Text = File.ReadAllText("browser/rgb/3/r3.txt");
            textBox23.Text = File.ReadAllText("browser/rgb/3/g3.txt");
            textBox22.Text = File.ReadAllText("browser/rgb/3/b3.txt");
            textBox32.Text = File.ReadAllText("browser/mb.txt");

            textBox33.Text = File.ReadAllText("browser/useragent.txt");
            if (textBox32.Text == "Авто") { checkBox9.Checked = true; }
            textBox30.Text = File.ReadAllText("browser/com.txt"); textBox31.Text = File.ReadAllText("browser/bb2.txt");

            if (System.IO.File.ReadAllText("browser/extm.txt") == "y")
            {
                checkBox5.Checked = true;
            }
            else { checkBox5.Checked = false; }


            try
            {
                SettingPar setp = JsonSerializer.Deserialize<SettingPar>(File.ReadAllText("browser/settings.json"));
                comboBox1.Text = setp.searchSys;
                comboBox2.Text = setp.startPage;
                checkBox1.Checked = setp.saveHist;
                comboBox3.Text = setp.saveType;
                checkBox2.Checked = setp.saveDate;
                checkBox3.Checked = setp.saveCash;
                checkBox4.Checked = setp.saveDown;
                comboBox4.Text = setp.saveURL;
                comboBox5.Text = setp.Style;
            }
            catch (Exception) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.WriteAllText("browser/history.txt", " ");
            listBox1.Items.Clear();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox26.Text = listBox1.Text;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SoundPlayer simpleSound = new SoundPlayer(@"K:\Users\vnuch\Downloads\Internet Explorer 1.0 Commercial (1995) (online-audio-converter.com).wav");
            simpleSound.Play();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            File.WriteAllText("browser/save.txt", "");
            listBox2.Items.Clear();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = listBox2.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Add add = new Add();
            add.Show();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = listBox2.Text;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox25.Text = listBox3.Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            File.WriteAllText("browser/down.txt", " ");
            listBox3.Items.Clear();
            File.WriteAllText("browser/url.txt", " ");
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                File.WriteAllText("browser/c.txt", "y");
            }
            else
            {

                File.WriteAllText("browser/c.txt", "n");

            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Кеш будет удалён при закрытии браузера!","!");
          frm.cashend = true;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }



        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox2.Text = "215";
            textBox3.Text = "228";
            textBox4.Text = "242";

            textBox5.Text = "185";
            textBox6.Text = "209";
            textBox7.Text = "234";

            textBox8.Text = "255";
            textBox9.Text = "255";
            textBox10.Text = "255";

            textBox13.Text = "255";
            textBox12.Text = "255";
            textBox11.Text = "255";

            textBox18.Text = "0";
            textBox16.Text = "0";
            textBox15.Text = "0";

            textBox20.Text = "255";
            textBox21.Text = "255";
            textBox19.Text = "255";

            textBox24.Text = "220";
            textBox23.Text = "220";
            textBox22.Text = "220";

            textBox29.Text = "215";
            textBox28.Text = "228";
            textBox27.Text = "255";

            textBox17.Text = "14";
            textBox14.Text = "Bahnschrift";
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Alisov0808/RU-Browser");
        }

        private void label14_Click(object sender, EventArgs e)
        {


        }

        private void button3_Click_1(object sender, EventArgs e)
        {


            File.AppendAllText("browser/dostyp.txt", "\n" + listBox2.Text.ToString().Replace("https://", "").Replace("http://", "").Replace("www.", ""));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            File.WriteAllText("browser/dostyp.txt", "");
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox25.Text);
        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {
            textBox25.Text = listBox3.Text;
        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {
            textBox26.Text = listBox1.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox26.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox31_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void checkBox8_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked) { textBox32.Enabled = false; }
            else
            {
                textBox32.Enabled = true;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button10_Click_1(object sender, EventArgs e)
        {
          
            textBox33.Text =   "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/125.0.6613.120 Safari/537.36 /CefSharp Browser" + Cef.CefSharpVersion;
        }

        private void textBox33_TextChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Environment.CurrentDirectory + @"\browser\exen");

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RU_Browser.about_exen about_ = new RU_Browser.about_exen();
            about_.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Directory.Delete("browser/exen/" + listBox4.SelectedItem, true);
            foreach (var directory in Directory.GetDirectories("browser/exen/"))
            {
                int lastIndex = directory.ToString().LastIndexOf("/");
                string trimmedString = "";
                if (lastIndex != -1)
                {
                    trimmedString = directory.ToString().Substring(lastIndex);
                    trimmedString = trimmedString.Substring(1);
                    // Теперь trimmedString содержит "путь\\к\\файлу"
                }
                listBox4.Items.Clear();
                listBox4.Items.Add(trimmedString);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string helloFilePath = Environment.CurrentDirectory + @"\browser\exen\" + listBox4.SelectedItem + @"\hellowindow.html";
            hellowindow_ex hellowindow = new hellowindow_ex(helloFilePath);
            hellowindow.Show();
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.Aply_set(frm,1);
        }
    }
}

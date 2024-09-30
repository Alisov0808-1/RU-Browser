using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RU_Browser
{
    public partial class hellowindow_ex : Form
    {
        string a = "";
        public hellowindow_ex(string url)
        {

            InitializeComponent();
            a = url;
        }

        private void hellowindow_ex_Load(object sender, EventArgs e)
        {
            var uri = new Uri(a);
            webBrowser1.Navigate(uri);
        }
    }
}

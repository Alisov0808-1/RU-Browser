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
    public partial class egg : Form
    {
        public egg()
        {
            InitializeComponent(); 
            axWindowsMediaPlayer1.URL = "browser/rgb/v.mp4";
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
          
        }

        private void axWindowsMediaPlayer1_Enter_1(object sender, EventArgs e)
        {

        }
    }
}

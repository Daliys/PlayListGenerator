using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayListGenerator
{
    public partial class VideoForm : UserControl
    {
        public VideoForm()
        {
            InitializeComponent();
        }


        public void SetImage(Image image)
        {
            pictureBox1.Image = image;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        public void SetText(String str)
        {
            label1.Text = str;
        }
    }
}

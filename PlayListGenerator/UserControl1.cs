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

    public partial class UserControl1 : UserControl
    {
        private static UserControl1 _instance;
        public static UserControl1 instance
        {
            get
            {
                if (_instance == null) _instance = new UserControl1();
                return _instance;
            }
        }
        public UserControl1()
        {
            InitializeComponent();
            InitializeImage();
        }

        void InitializeImage()
        {
            //Form1.fileManager.
            PictureBox picture1 = new PictureBox();
            picture1.Image = Form1.fileManager.listVideoFiles[4].image;
            picture1.Parent = flowLayoutPanel1;
            picture1.Width = 50;
            picture1.Height = 50;
            picture1.SizeMode = PictureBoxSizeMode.StretchImage;

        }
    }
}

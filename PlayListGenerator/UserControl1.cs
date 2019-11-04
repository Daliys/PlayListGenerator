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
            foreach (var item in Form1.fileManager.listVideoFiles)
            {
                VideoForm picture1 = new VideoForm();
                picture1.SetImage(item.image);
                picture1.SetText(item.name);
                picture1.Parent = flowLayoutPanel1;
               
            }


        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Schedule;
using FolderManager;
using XmlFileManager;

using System.Runtime.InteropServices;



namespace PlayListGenerator
{

    public partial class Form1 : Form
    {
        // <>для перетаскивания панели мышью
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        // </>
        public static Form1 form1Instance;

        public static TimeSchedule timeSchedule;
        public static FileManager fileManager;
        public static VideoPrefaber videoPrefaber;

        public Form1()
        {
            InitializeComponent();
            
            fileManager = new FileManager();
            videoPrefaber = new VideoPrefaber();

            

            AllowDrop = true;
            this.DragDrop += new DragEventHandler(Form_DragDrop);
            this.DragEnter += new DragEventHandler(Form_DragEnter);

            form1Instance = this;
        }

        void Form_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }
        void Form_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files) Console.WriteLine(file);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public static void WriteExeption (string exeption)
        {
            MessageBox.Show(exeption, "ERROR",MessageBoxButtons.OK ,MessageBoxIcon.Error);
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void panelBackground_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }


        
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!panelOne.Controls.Contains(FileLoader.instance))
            {
                panelOne.Controls.RemoveAt(0);
                panelOne.Controls.Add(FileLoader.instance);
                FileLoader.instance.Dock = DockStyle.Fill;
                FileLoader.instance.BringToFront();
            }
            


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!panelOne.Controls.Contains(UserControl1.instance))
            {
                panelOne.Controls.RemoveAt(0);
                panelOne.Controls.Add(UserControl1.instance);
                UserControl1.instance.Dock = DockStyle.Fill;
                UserControl1.instance.BringToFront();
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            XmlManager xml = new XmlManager();

            xml.LoadSchedule();
            xml.GenerateXml();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }
    }
  
}

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

            form1Instance = this;

            FileLoader fl = FileLoader.instance;

        }

       

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public static void WriteExeption(string exeption)
        {
            MessageBox.Show(exeption, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (!panelWorkArea.Controls.Contains(FileLoader.instance))
            {
                if (panelWorkArea.Controls.Count != 0)
                    panelWorkArea.Controls.RemoveAt(0);
                panelWorkArea.Controls.Add(FileLoader.instance);
                FileLoader.instance.Dock = DockStyle.Fill;
                FileLoader.instance.BringToFront();
            }

            SwitchButtonColor((Button)sender);
        }

        private void SwitchButtonColor(Button button)
        {
            buttonMenu1.BackColor = System.Drawing.Color.Green;
            buttonMenu2.BackColor = System.Drawing.Color.Green;
            buttonMenu3.BackColor = System.Drawing.Color.Green;

            Random rand = new Random();
            switch (button.Name)
            {
                case "buttonMenu1":
                    buttonMenu1.BackColor = System.Drawing.Color.FromArgb(rand.Next(0,256), rand.Next(0, 256), rand.Next(0, 256));
                    break;
                case "buttonMenu2":
                    buttonMenu2.BackColor = System.Drawing.Color.FromArgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256));
                    break;
                case "buttonMenu3":
                    buttonMenu3.BackColor = System.Drawing.Color.FromArgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256));
                    break;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!panelWorkArea.Controls.Contains(UserControl1.instance))
            {
                if (panelWorkArea.Controls.Count != 0)
                    panelWorkArea.Controls.RemoveAt(0);
                panelWorkArea.Controls.Add(UserControl1.instance);
                UserControl1.instance.Dock = DockStyle.Fill;
                UserControl1.instance.BringToFront();
            }
            SwitchButtonColor((Button)sender);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            SwitchButtonColor((Button)sender);
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Schedule;
using FolderManager;
using System.Xml;


namespace PlayListGenerator
{

    public partial class Form1 : Form
    {
        public static TimeSchedule timeSchedule;
        public static FileManager fileManager;
        public static VideoPrefaber videoPrefaber;

        public Form1()
        {
            InitializeComponent();
            fileManager = new FileManager();
            videoPrefaber = new VideoPrefaber();

            backgroundWorker1.DoWork += (sender,_event) => fileManager.Syncronize();
            backgroundWorker1.RunWorkerAsync();
            backgroundWorker1.RunWorkerCompleted += (sender, _events) => { label2.Text = fileManager.str; };
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

        string path = @"C:\Users\User\Source\Repos\Daliys\PlayListGenerator\PlayListGenerator\Futuris.xlsx";
        private void button2_Click(object sender, EventArgs e)
        {
            backgroundWorker1.DoWork += (sender1, _1event) => { _1event = LoadExel(_1event); };

            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.ProgressChanged += ((sender1, _event) => { progressBar1.Value = _event.ProgressPercentage; });
            backgroundWorker1.RunWorkerAsync();
            backgroundWorker1.RunWorkerCompleted += (sn, _e) => { label1.Text = _e.Result.ToString(); };
        }


        public DoWorkEventArgs LoadExel(DoWorkEventArgs e)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(path);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            //label1.Text = "Row " + xlRange.Rows.Count + " Col " + xlRange.Columns.Count;
            string[,] res = new string[40, 61];
            for (int i = 8, indexI = 0; i < 48; i++, indexI++)
            {
                for (int j = 2, indexJ = 0; j < 63; j++, indexJ++)
                {
                    if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                        res[indexI, indexJ] = xlRange.Cells[i, j].Value2.ToString();
                    else res[indexI, indexJ] = " ";

                    backgroundWorker1.ReportProgress((100* (indexI * 61 + indexJ + 1)) /(40 * 61));
                }

            }
            string ts = "";
            for (int i = 0; i < res.GetLength(0); i++)
            {
                for (int j = 0; j < res.GetLength(1); j++)
                {
                    ts += res[i, j];
                }
                ts += "\n";
            }
          
           
            timeSchedule = new TimeSchedule(res);
            // ts = "";
            // foreach (var item in timeSchedule.workTimeMorning)
            // {
            //    ts += item.ToString() + "\n";
            // }
             
            e.Result = ts;
            return e;
            
            // label1.Text = ts;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
        
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!panelOne.Controls.Contains(UserControl1.instance))
            {
                panelOne.Controls.Add(UserControl1.instance);
                UserControl1.instance.Dock = DockStyle.Fill;
                UserControl1.instance.BringToFront();
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            XmlManager xml = new XmlManager();
            // xml.AddVideo("pari");
            // xml.AddVideo("ochag");
            ////xml.AddVideo("sony");
            ///  xml.AddVideo("logo");
            xml.LoadSchedule();
            xml.GenerateXml();
        }
    }

    public class XmlManager
    {
        XmlWriter xmlFile;
        List<String> listVideos;

        public XmlManager()
        {
            xmlFile = XmlWriter.Create("TimedDate.xml");    
            listVideos = new List<string>();
        }

        public void AddVideo(String str)
        {
            listVideos.Add(str);
        }

        public void LoadSchedule()
        {
            foreach (var item in Form1.timeSchedule.GetListVideoDay())
            {
                listVideos.Add(Form1.videoPrefaber.GetNameByID(item));
            }
            
        }

        public void GenerateXml()
        {

            xmlFile.WriteStartDocument();
            xmlFile.WriteStartElement("TimmingPlayer");
            xmlFile.WriteAttributeString("ListFilter", "0");

            xmlFile.WriteStartElement("List");
            xmlFile.WriteAttributeString("Name", "PIZDAAD");
            xmlFile.WriteAttributeString("Active", "True");

            xmlFile.WriteStartElement("Time");
            xmlFile.WriteAttributeString("Style", "1");
            xmlFile.WriteAttributeString("BeginTime", "22:00:00");
            xmlFile.WriteAttributeString("EndTime", "23:59:59");
            xmlFile.WriteAttributeString("Week", "1111111");

            xmlFile.WriteEndElement();
            xmlFile.WriteStartElement("Animation");
            foreach (var item in listVideos)
            {

               
                xmlFile.WriteStartElement("Item");
                xmlFile.WriteAttributeString("Times", "1");
                xmlFile.WriteString(@"..\RGB\" + item+".cel");
                xmlFile.WriteEndElement();
            }

            // xmlFile.WriteEndElement();
            xmlFile.WriteEndElement();
            xmlFile.WriteEndDocument();
            xmlFile.Close();
        }
    }

  
}

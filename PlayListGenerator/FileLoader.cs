using System;
using System.ComponentModel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using Schedule;
using System.IO;

namespace PlayListGenerator
{
    public partial class FileLoader : UserControl
    {
        private static FileLoader _instance;
        public static FileLoader instance
        {
            get
            {
                if (_instance == null) _instance = new FileLoader();
                return _instance;
            }
        }

        public FileLoader()
        {
            InitializeComponent();

            Form1.form1Instance.backgroundWorker1.DoWork += (sender, _event) => Form1.fileManager.Syncronize();
            Form1.form1Instance.backgroundWorker1.RunWorkerAsync();
            Form1.form1Instance.backgroundWorker1.RunWorkerCompleted += (sender, _events) => { label2.Text = Form1.fileManager.str; };


            AllowDrop = true;
            this.DragDrop += new DragEventHandler(Form_DragDrop);
            this.DragEnter += new DragEventHandler(Form_DragEnter);

        }

        string path = @"C:\Users\User\Source\Repos\Daliys\PlayListGenerator\PlayListGenerator\Футурис 03.11-04.11.xlsx";
        private void button2_Click(object sender, EventArgs e)
        {
            Form1.form1Instance.backgroundWorker1.DoWork += (sender1, _1event) => { _1event = LoadExel(_1event); };

            Form1.form1Instance.backgroundWorker1.WorkerReportsProgress = true;
            Form1.form1Instance.backgroundWorker1.ProgressChanged += ((sender1, _event) => { progressBar1.Value = _event.ProgressPercentage; });
            Form1.form1Instance.backgroundWorker1.RunWorkerAsync();
            Form1.form1Instance.backgroundWorker1.RunWorkerCompleted += (sn, _e) => { label1.Text = _e.Result.ToString(); };
           
        }

        void Form_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.None;
            String[] files = (String[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 1) e.Effect = DragDropEffects.None;
            else{
                //if(files[0])
                if (Path.GetExtension(files[0]) == ".xlsx") e.Effect = DragDropEffects.Copy;
                else e.Effect = DragDropEffects.None;
            }
            
        }
        void Form_DragDrop(object sender, DragEventArgs e)
        {
            
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length == 1)
            {
                if (Path.GetExtension(files[0]) == ".xlsx")
                {
                    label1.Text = files[0];
                    path = files[0];
                }
            }
            
            foreach (string file in files) Console.WriteLine(file);
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

                    Form1.form1Instance.backgroundWorker1.ReportProgress((100 * (indexI * 61 + indexJ + 1)) / (40 * 61));
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

            Form1.timeSchedule = new TimeSchedule(res);
            e.Result = ts;
            return e;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "excel file *.xlsx|*.xlsx";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                label1.Text = filename;
                path = filename;
            }

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }
    }



}

using System;
using System.ComponentModel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using Schedule;

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
            // ts = "";
            // foreach (var item in timeSchedule.workTimeMorning)
            // {
            //    ts += item.ToString() + "\n";
            // }

            e.Result = ts;
            return e;

            // label1.Text = ts;
        }

    }



}

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


namespace PlayListGenerator
{

    public partial class Form1 : Form
    {
        TimeSchedule timeSchedule;
        FileManager fileManager;

        public Form1()
        {
            InitializeComponent();
            fileManager = new FileManager();

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
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(path);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            //label1.Text = "Row " + xlRange.Rows.Count + " Col " + xlRange.Columns.Count;
            string[,] res = new string[40,61];
            for (int i = 8, indexI = 0; i < 48; i++, indexI++)
            {
                for (int j = 2, indexJ = 0; j < 63; j++, indexJ++)
                {
                    if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                        res[indexI,indexJ] = xlRange.Cells[i, j].Value2.ToString();
                    else res[indexI,indexJ] = " ";
                }

            }
            label1.Text = "Finish";

            string ts = "";
            for (int i = 0; i < res.GetLength(0); i++)
            {
                for (int j = 0; j < res.GetLength(1); j++)
                {
                    ts += res[i, j];
                }
                ts += "\n";
            }
            label1.Text = ts;
            timeSchedule = new TimeSchedule(res);

            ts = "";
            foreach (var item in timeSchedule.workTimeMorning)
            {
                ts += item.ToString() + "\n";
            }

           // label1.Text = ts;
        }

    }

  
}

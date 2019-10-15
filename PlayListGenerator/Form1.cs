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

namespace PlayListGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
            string res = "";
            for (int i = 8; i < 48; i++)
            {
                for (int j = 2; j < 63; j++)
                {
                    if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                        res += xlRange.Cells[i, j].Value2.ToString() + " ";
                    else res += " ";
                }
                res += "\n";
            }
            label1.Text = res;
        }
    }
}

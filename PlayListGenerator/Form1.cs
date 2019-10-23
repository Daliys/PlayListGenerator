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
        TimeSchedule timeSchedule;

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

    public class TimeSchedule
    {
        public List<Time> workTimeMorning;
        public List<Time> workTimeDay;

        List<List<int>> listVideosMorning;
        List<List<int>> listVideosDay;
        const bool hasSheduleMorning = true;

        public TimeSchedule(string[,] str)
        {
            workTimeMorning = new List<Time>();
            workTimeDay = new List<Time>();
            listVideosMorning = new List<List<int>>();
            listVideosDay = new List<List<int>>();

            bool isFillMorning = false;

            for (int i = 0; i < str.GetLength(0); i++)
            {
                List<int> row = new List<int>();

                for (int j = 1; j < str.GetLength(1); j++)
                {
                    if (str[i, j] != null && str[i, j] != " " && str[i, j] != "-")
                    {
                        try
                        {
                            row.Add(int.Parse(str[i, j]));
                        }
                        catch (Exception e) { Program.isErrorr = true; Program.strError = e.ToString(); }
                    }
                }

                if(row.Count > 0)
                {
                    if (!isFillMorning && hasSheduleMorning)
                    {
                        workTimeMorning.Add(new Time(str[i, 0]));
                        listVideosMorning.Add(new List<int>(row));
                    }
                    else
                    {
                        workTimeDay.Add(new Time(str[i, 0]));
                        listVideosDay.Add(new List<int>(row));
                    }
                }
                else
                {
                    isFillMorning = true;
                }
            }
        }
    }

    public class Time
    {
        public int beginHour;
        public int beginMinut;
        public int beginSecond;
        public int endHour;
        public int endMinut;
        public int endSecond;

        public Time(string strTime)
        {
            try
            {
                string[] strTimeSplit = strTime.Split('-');
                string[] strTimeSplitBegin = strTimeSplit[0].Split(':');
                string[] strTimeSplitEnd = strTimeSplit[1].Split(':');

                beginHour = int.Parse(strTimeSplitBegin[0]);
                beginMinut = int.Parse(strTimeSplitBegin[1]);
                beginSecond = int.Parse(strTimeSplitBegin[2]);

                endHour = int.Parse(strTimeSplitEnd[0]);
                endMinut = int.Parse(strTimeSplitEnd[1]);
                endSecond = int.Parse(strTimeSplitEnd[2]);
            }
            catch (Exception e) { Program.isErrorr = true; Program.strError = e.ToString();}
        }

        public override string ToString()
        {
            return beginHour + ":" + beginMinut + ":" + beginSecond + "-" + endHour + ":" + endMinut + ":" + endSecond;
        }
    }


}

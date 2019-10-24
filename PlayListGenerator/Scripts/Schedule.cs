using System.Collections.Generic;
using System;

namespace Schedule
{
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
                        catch (Exception e) { PlayListGenerator.Form1.WriteExeption(e.ToString()); return; }
                    }
                }

                if (row.Count > 0)
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
            catch (Exception e) { PlayListGenerator.Form1.WriteExeption(e.ToString()); }
        }

        public override string ToString()
        {
            return beginHour + ":" + beginMinut + ":" + beginSecond + "-" + endHour + ":" + endMinut + ":" + endSecond;
        }
    }



}
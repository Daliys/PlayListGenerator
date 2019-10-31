using System.Collections.Generic;
using System;

namespace Schedule
{
    public class TimeSchedule
    {
        public List<Time> workTimeMorning;
        public List<Time> workTimeDay;

        public List<List<int>> listVideosMorning;
        public List<List<int>> listVideosDay;
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

        public static bool CompateSheduleLine(List<int> lineOne, List<int> lineTwo)
        {
            if (lineOne.Count != lineTwo.Count) return false;

            for (int i = 0; i < lineOne.Count; i++)
            {
                if(lineOne[i] != lineTwo[i]) { return false; }
            }
            return true;
        }

        public List<int> GetListVideoDay()
        {
            // хуйня переделать  
            List<int> returnList = new List<int>();
            for (int i = 0; i < listVideosDay.Count; i++)
            {
                for (int j = 0; j < listVideosDay[i].Count; j++)
                {
                    returnList.Add(listVideosDay[i][j]);
                }
            
            }
            return returnList;
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

        public string GetBeginTime()
        {
            return beginHour + ":" + beginMinut + ":" + beginSecond;
        }
        public string GetEndTime()
        {
            return endHour + ":" + endMinut + ":" + endSecond;
        }
    }

    public class VideoPrefaber
    {
        public struct structVideos
        {
           public string videoName;
            public int id;
            public structVideos( int id, string videoName)
            {
                this.videoName = videoName;
                this.id = id;
            }
        }
        public List<structVideos> listPrefabs;
        public VideoPrefaber()
        {
            listPrefabs = new List<structVideos>();
            listPrefabs.Add(new structVideos(1, "pari_new_375"));
            listPrefabs.Add(new structVideos(3, "Karat_158_376"));
            listPrefabs.Add(new structVideos(6, "maunfild4_450"));
            listPrefabs.Add(new structVideos(7, "olimpic2_500"));
            listPrefabs.Add(new structVideos(8, "Arenda20_09_375"));
            listPrefabs.Add(new structVideos(9, "X-fit20_09_375"));
            listPrefabs.Add(new structVideos(10, "Futuris_reklama_158_40sec_1000"));
            listPrefabs.Add(new structVideos(12, "ochag2_375"));
            listPrefabs.Add(new structVideos(13, "Dom_mebel_158_375"));
            listPrefabs.Add(new structVideos(16, "Minsk_626"));
            listPrefabs.Add(new structVideos(18, "Lebiajiy_158_376"));
            listPrefabs.Add(new structVideos(19, "evro_part158_375"));
            listPrefabs.Add(new structVideos(20, "aeg_158(1)_375"));
            listPrefabs.Add(new structVideos(23, "Mazeraty_158_375"));




         
           
 
            
     
            //listPrefabs.Add(new structVideos(3, "Karat_158_376"));
        ///S
 

        }

        public string GetNameByID(int id)
        {
            if (listPrefabs.Find((x) => x.id == id).videoName != null) return (listPrefabs.Find((x) => x.id == id)).videoName;
            return "Minsk_626";
            
        }
    }

}
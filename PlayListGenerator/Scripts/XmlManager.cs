using System.Collections.Generic;
using System.Xml;
using System;
using PlayListGenerator;
using Schedule;

namespace XmlFileManager
{
    public class XmlManager
    {
        XmlWriter xmlFile;
        List<ListXml> dayListSchedules;
        List<ListXml> morningListSchedules;

        public XmlManager()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            xmlFile = XmlWriter.Create("TimedData.xml", settings);
            dayListSchedules = new List<ListXml>();
            morningListSchedules = new List<ListXml>();
        }

        public void LoadSchedule()
        {
            LoadScheduleDay();
            if (Form1.timeSchedule.hasSheduleMorning) LoadScheduleMorning();
        }

        private void LoadScheduleDay()
        {
            int trigger = 0;
            int count = 0;
            string date = string.Format("{0:d2}.{1:d2}", DateTime.Now.Day, DateTime.Now.Month);
            for (int i = 0; i < Form1.timeSchedule.listVideosDay.Count; i++)
            {
                if (i != 0 && !TimeSchedule.CompateSheduleLine(Form1.timeSchedule.listVideosDay[i - 1], Form1.timeSchedule.listVideosDay[i]))
                {
                    dayListSchedules.Add(new ListXml("Day" + count + "_" + date, true, Form1.timeSchedule.workTimeDay[trigger].GetBeginTime().ToString(), Form1.timeSchedule.workTimeDay[i - 1].GetEndTime().ToString(), "1111111"));
                    dayListSchedules[dayListSchedules.Count - 1].AddVideos(Form1.timeSchedule.listVideosDay[i - 1]);
                    trigger = i;
                    count++;

                }
            }
            dayListSchedules.Add(new ListXml("Day" + count + "_" + date, true, Form1.timeSchedule.workTimeDay[trigger].GetBeginTime().ToString(), Form1.timeSchedule.workTimeDay[Form1.timeSchedule.workTimeDay.Count - 1].GetEndTime().ToString(), "1111111"));
            dayListSchedules[dayListSchedules.Count - 1].AddVideos(Form1.timeSchedule.listVideosDay[Form1.timeSchedule.listVideosDay.Count - 1]);
        }

        private void LoadScheduleMorning()
        {
            int trigger = 0;
            int count = 0;
            string date = string.Format("{0:d2}.{1:d2}", DateTime.Now.Day, DateTime.Now.Month);
            for (int i = 0; i < Form1.timeSchedule.listVideosMorning.Count; i++)
            {
                if (i != 0 && !TimeSchedule.CompateSheduleLine(Form1.timeSchedule.listVideosMorning[i - 1], Form1.timeSchedule.listVideosMorning[i]))
                {
                    morningListSchedules.Add(new ListXml("Morning" + count + "_" + date, true, Form1.timeSchedule.workTimeMorning[trigger].GetBeginTime().ToString(), Form1.timeSchedule.workTimeMorning[i - 1].GetEndTime().ToString(), "1111111"));
                    morningListSchedules[morningListSchedules.Count - 1].AddVideos(Form1.timeSchedule.listVideosMorning[i - 1]);
                    trigger = i;
                    count++;

                }
            }
            morningListSchedules.Add(new ListXml("Morning" + count + "_" + date, true, Form1.timeSchedule.workTimeMorning[trigger].GetBeginTime().ToString(), Form1.timeSchedule.workTimeMorning[Form1.timeSchedule.workTimeMorning.Count - 1].GetEndTime().ToString(), "1111111"));
            morningListSchedules[morningListSchedules.Count - 1].AddVideos(Form1.timeSchedule.listVideosMorning[Form1.timeSchedule.listVideosMorning.Count - 1]);
        }

        public void GenerateXml()
        {
            xmlFile.WriteStartDocument();
            xmlFile.WriteStartElement("TimmingPlayer");
            xmlFile.WriteAttributeString("ListFilter", "0");



            foreach (var item in dayListSchedules)
            {
                xmlFile.WriteStartElement("List");
                xmlFile.WriteAttributeString("Name", item.name);
                xmlFile.WriteAttributeString("Active", "True");
                xmlFile.WriteStartElement("Time");
                xmlFile.WriteAttributeString("Style", "1");
                xmlFile.WriteAttributeString("BeginTime", item.beginTime);
                xmlFile.WriteAttributeString("EndTime", item.endTime);
                xmlFile.WriteAttributeString("Week", item.week);

                xmlFile.WriteEndElement();
                xmlFile.WriteStartElement("Animation");
                foreach (var videoItem in item.xmlListVideos)
                {


                    xmlFile.WriteStartElement("Item");
                    xmlFile.WriteAttributeString("Times", "1");
                    xmlFile.WriteString(@"..\RGB\" + videoItem + ".cel");
                    xmlFile.WriteEndElement();

                }
                xmlFile.WriteEndElement();
                xmlFile.WriteEndElement();
            }

            foreach (var item in morningListSchedules)
            {
                xmlFile.WriteStartElement("List");
                xmlFile.WriteAttributeString("Name", item.name);
                xmlFile.WriteAttributeString("Active", "True");
                xmlFile.WriteStartElement("Time");
                xmlFile.WriteAttributeString("Style", "1");
                xmlFile.WriteAttributeString("BeginTime", item.beginTime);
                xmlFile.WriteAttributeString("EndTime", item.endTime);
                xmlFile.WriteAttributeString("Week", item.week);

                xmlFile.WriteEndElement();
                xmlFile.WriteStartElement("Animation");
                foreach (var videoItem in item.xmlListVideos)
                {


                    xmlFile.WriteStartElement("Item");
                    xmlFile.WriteAttributeString("Times", "1");
                    xmlFile.WriteString(@"..\RGB\" + videoItem + ".cel");
                    xmlFile.WriteEndElement();

                }
                xmlFile.WriteEndElement();
                xmlFile.WriteEndElement();
            }

            // xmlFile.WriteEndElement();
            //xmlFile.WriteEndElement();
            xmlFile.WriteEndDocument();
            xmlFile.Close();
        }

        class ListXml
        {
            public string name;
            public bool isActive;
            public List<string> xmlListVideos;
            public string beginTime;
            public string endTime;
            public string week;

            public ListXml(string name, bool isActive, string beginTime, string endTime, string week)
            {
                this.name = name;
                this.isActive = isActive;
                this.beginTime = beginTime;
                this.endTime = endTime;
                this.week = week;
                xmlListVideos = new List<string>();
            }

            public void AddVideos(List<int> listVideos)
            {
                foreach (var item in listVideos)
                {
                    xmlListVideos.Add(Form1.videoPrefaber.GetNameByID(item));
                }
            }

        }
    }

}
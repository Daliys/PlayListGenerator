using System.IO;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace FolderManager
{

    public class FileManager
    {
        public const string pathFolder = @"C:\Users\User\Desktop\TestMF\New Project 1_EN508_158W670H\RGB";
        public string str = "";
        public List<VideoFileInfo> listVideoFiles;
        public void Syncronize()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(pathFolder);
            FileInfo[] files = directoryInfo.GetFiles("*.cel");

            try
            {
                foreach (var item in files)
                {
                    listVideoFiles.Add(new VideoFileInfo(item.Name));
                    str += item.Name + "   " + listVideoFiles[listVideoFiles.Count - 1].name + "   " + listVideoFiles[listVideoFiles.Count - 1].frameCount + "\n";
                }
            }
            catch (Exception e) { PlayListGenerator.Form1.WriteExeption(e.ToString()); return; }
        }

        public FileManager()
        {
            listVideoFiles = new List<VideoFileInfo>();
        }
    }


    public class VideoFileInfo
    {
        public string fullName;
        public string name;
        public int frameCount;
        public Image image;

        public VideoFileInfo(string strVideoFile)
        {
            fullName = strVideoFile;
            string[] temp = strVideoFile.Split('_');
            frameCount = int.Parse(temp[temp.Length - 1].Substring(0, temp[temp.Length - 1].Length - 4));
            name = strVideoFile.Substring(0, (strVideoFile.Length - 1 - temp[temp.Length - 1].Length));

            image = Image.FromFile(FileManager.pathFolder+"\\Preview\\"+fullName+".png");
        }
    }

}
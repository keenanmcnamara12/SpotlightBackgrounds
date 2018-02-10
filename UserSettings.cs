using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotlightBackgrounds
{
    public class UserSettings
    {
        /// <summary>
        /// Path to the application data file
        /// </summary>
        private string _path;

        /// <summary>
        /// Setting for the where the backgrounds are stored
        /// </summary>
        public string BackgroundFolderPath { get; set; }

        /// <summary>
        /// Setting for the minimum pixel height
        /// </summary>
        public int MinPixelHeight { get; set; }

        /// <summary>
        /// Setting for the minimum pixel height
        /// </summary>
        public int MinPixelWidth { get; set; }

        private const string BackgroundFolderPathToken = "BackgroundFolderPath";
        private const string MinPixelHeightToken = "MinPixelHeight";
        private const string MinPixelWidthToken = "MinPixelWidth";
        private const char Delim = '=';


        public UserSettings()
        {
            _path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SpotlightBackground\\preferences.txt";
            if (File.Exists(_path))
            {
                using (StreamReader sr = new StreamReader(_path))
                {
                    string line = sr.ReadLine();
                    if (line.Contains(BackgroundFolderPathToken + Delim))
                    {
                        string[] sides = line.Split(Delim);
                        string potentialDirectory = sides[1];
                        if (Directory.Exists(potentialDirectory))
                            BackgroundFolderPath = potentialDirectory;
                        else
                            BackgroundFolderPath = null;
                    }

                    line = sr.ReadLine();
                    if (line.Contains(MinPixelHeightToken + Delim))
                    {
                        string[] sides = line.Split(Delim);
                        int pixels = Int32.Parse(sides[1]);
                        if (pixels > 0)
                            MinPixelHeight = pixels;
                        else
                            MinPixelHeight = 1080;
                    }

                    line = sr.ReadLine();
                    if (line.Contains(MinPixelWidthToken + Delim))
                    {
                        string[] sides = line.Split('=');
                        int pixels = Int32.Parse(sides[1]);
                        if (pixels > 0)
                            MinPixelWidth = pixels;
                        else
                            MinPixelWidth = 1920;
                    }

                }
            }
            else
            {
                // First we'll likely need to create the directory
                FileInfo fi = new FileInfo(_path);
                if (!fi.Directory.Exists)
                {
                    Directory.CreateDirectory(fi.DirectoryName);
                }

                // create the file (this is the first time the application has been run I guess)
                using (StreamWriter sw = File.AppendText(_path))
                {
                    sw.WriteLine(BackgroundFolderPathToken + Delim);
                    sw.WriteLine(MinPixelHeightToken + Delim);
                    sw.WriteLine(MinPixelWidthToken + Delim);
                }
                BackgroundFolderPath = null;
            }
        }

        /// <summary>
        /// The user specified background folder path.
        /// </summary>
        /// <returns>A valid directory or null.</returns>
        public string getBackgroundFolderPath()
        {
            return BackgroundFolderPath;
        }

        public int getMinPixelHeight()
        {
            return MinPixelHeight;
        }

        public int getMinPixelWidth()
        {
            return MinPixelWidth;
        }

        /// <summary>
        /// Committ current property values to the AppData file.
        /// </summary>
        /// <returns>True - on success. False otherwise.</returns>
        public Boolean saveUserSettings()
        {
            Console.WriteLine("User settings saving!");
            using (StreamWriter sw = new StreamWriter(_path, false))
            {
                sw.WriteLine(BackgroundFolderPathToken + Delim + BackgroundFolderPath);
                sw.WriteLine(MinPixelHeightToken + Delim + MinPixelHeight);
                sw.WriteLine(MinPixelWidthToken + Delim + MinPixelWidth);
            }

            return true;
        }
    }
}

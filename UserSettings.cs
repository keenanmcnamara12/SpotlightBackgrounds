using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotlightBackgrounds
{
    class UserSettings
    {
        /// <summary>
        /// Path to the application data file
        /// </summary>
        private string _path;

        /// <summary>
        /// Setting for the where the backgrounds are stored
        /// </summary>
        private string _backgroundFolderPath;

        /// <summary>
        /// Setting for the minimum pixel height
        /// </summary>
        private int _minPixelHeight;

        /// <summary>
        /// Setting for the minimum pixel height
        /// </summary>
        private int _minPixelWidth;


        public UserSettings()
        {
            _path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SpotlightBackground\\preferences.txt";
            if (File.Exists(_path))
            {
                using (StreamReader sr = new StreamReader(_path))
                {
                    string line = sr.ReadLine();
                    if (line.Contains("BackgroundFolderPath="))
                    {
                        string[] sides = line.Split('=');
                        string potentialDirectory = sides[1];
                        if (Directory.Exists(potentialDirectory))
                            _backgroundFolderPath = potentialDirectory;
                        else
                            _backgroundFolderPath = null;
                    }

                    line = sr.ReadLine();
                    if (line.Contains("MinPixelHeight="))
                    {
                        string[] sides = line.Split('=');
                        int pixels = Int32.Parse(sides[1]);
                        if (pixels > 0)
                            _minPixelHeight = pixels;
                        else
                            _minPixelHeight = 1920;
                    }

                    line = sr.ReadLine();
                    if (line.Contains("MinPixelWidth="))
                    {
                        string[] sides = line.Split('=');
                        int pixels = Int32.Parse(sides[1]);
                        if (pixels > 0)
                            _minPixelWidth = pixels;
                        else
                            _minPixelWidth = 1080;
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
                    sw.WriteLine("BackgroundFolderPath=");
                    sw.WriteLine("MinPixelHeight=");
                    sw.WriteLine("MinPixelWidth=");
                }
                _backgroundFolderPath = null;
            }
        }

        /// <summary>
        /// The user specified background folder path.
        /// </summary>
        /// <returns>A valid directory or null.</returns>
        public string getBackgroundFolderPath()
        {
            return _backgroundFolderPath;
        }

        public int getMinPixelHeight()
        {
            return _minPixelHeight;
        }

        public int getMinPixelWidth()
        {
            return _minPixelWidth;
        }
    }
}

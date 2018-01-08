using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotlightBackgrounds
{
    class Program
    {
        static void Main(string[] args)
        {
            UserSettings us = new UserSettings();
            string userBackgroundDirectory = us.getBackgroundFolderPath();

            // Make sure user background folder exists
            if (String.IsNullOrWhiteSpace(userBackgroundDirectory))
                return;

            string local = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string spotlightDirectory = local + "\\Packages\\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\\LocalState\\Assets\\";

            // In case this stuff gets moved in the future
            if (!Directory.Exists(spotlightDirectory))
                return;

            string[] spotlightFiles = Directory.GetFiles(spotlightDirectory);
            string[] backgroundFiles = Directory.GetFiles(userBackgroundDirectory);

            for (int i = 0; i < spotlightFiles.Length; i++)
            {
                // Only copy files from the spotlight directory that aren't already in the background directory
                if (!(Array.IndexOf(backgroundFiles, spotlightFiles[i] + ".jpg") > -1))
                {
                    // Verify the file is a jpeg
                    if (!hasJpegHeader(spotlightFiles[i]))
                        continue;

                    // Ensure dimensions are okie dokie per user specification (which actually defaults if the user doesn't specify)
                    System.Drawing.Image img = System.Drawing.Image.FromFile(spotlightFiles[i]);
                    if ((img.Width < us.getMinPixelWidth()) || (img.Height < us.getMinPixelHeight()))
                        continue;

                    File.Copy(spotlightFiles[i], userBackgroundDirectory + "\\" + getFileName(spotlightFiles[i]) + ".jpg", true);
                }
            }
        }

        // https://stackoverflow.com/questions/772388/c-sharp-how-can-i-test-a-file-is-a-jpeg
        // Users the magic number in jpeg to verify the file type
        static bool hasJpegHeader(string fileName)
        {
            using (BinaryReader br = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                UInt16 soi = br.ReadUInt16();       // Start of image (SOI) marker (FFD8)
                UInt16 marker = br.ReadUInt16();    // JFIF marker (FFEO) or EXIF marker (FF01)
                return soi == 0xd8ff && (marker & 0xe0ff) == 0xe0ff;
            }
        }

        static string getFileName(string filePath)
        {
            string[] tmp = filePath.Split('\\');
            return tmp[tmp.Length - 1];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace _2_1_galleriet.Model
{
    public class Gallery
    {
        private static readonly Regex ApprovedExtension;
        private static string PhysicalUploadImagesPath;
        private static readonly Regex SantizePath;

        public static Gallery()
        {

        }
        public IEnumerable<string> GetImagesNames()
        {
            
        }

        public static bool ImageExists(string name)
        {
            return true;
        }

        private bool IsValidImage(Image image)
        {
            return true;
        }

        public string SaveImage(Stream stream, string fileName)
        {
            return fileName;
        }

    }
}
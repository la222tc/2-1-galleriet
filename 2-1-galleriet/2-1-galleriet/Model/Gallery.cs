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

        static Gallery()
        {
            ApprovedExtension = new Regex("^.*.(gif|jpg|png)$");
            PhysicalUploadImagesPath = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), "Content", "Pics");
            var invalidChars = new string(Path.GetInvalidFileNameChars());
            SantizePath = new Regex(string.Format("[{0}]", Regex.Escape(invalidChars)));
        }
        public IEnumerable<Images> GetImagesNames()
        {
            var files = new DirectoryInfo(PhysicalUploadImagesPath);
            return (from fi in files.GetFiles()
                    select new Images
                    {
                        Name = fi.Name,
                        FullImgUrl = String.Format("Default.aspx/Content/Pics/{0}", fi.Name),
                        ThumbImgUrl = String.Format("Content/Pics/Thumbnails/{0}", fi.Name)

                    }).AsEnumerable();
        }


        public static bool ImageExists(string name)
        {
            return File.Exists(Path.Combine(PhysicalUploadImagesPath, name));
        }

        private bool IsValidImage(Image image)
        {
            if (image.RawFormat.Guid == ImageFormat.Gif.Guid ||
               image.RawFormat.Guid == ImageFormat.Jpeg.Guid ||
               image.RawFormat.Guid == ImageFormat.Png.Guid)
            {
                return true;
            }
            return false;
        }

        public string SaveImage(Stream stream, string fileName)
        {
            var image = Image.FromStream(stream);
            fileName = SantizePath.Replace(fileName, String.Empty);

            if (!IsValidImage(image))
            {
                throw new ArgumentException("Fel format av bild");
            }

            if (ImageExists(fileName))
	        {
                int count = 0;

                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
                string extenstion = Path.GetExtension(fileName);
                string path = Path.GetDirectoryName(fileName);

                while(ImageExists(fileName))
                {
                    fileName = string.Format("{0}({1}){2}", fileNameWithoutExtension, ++count, extenstion);
                }
            }

            var thubnail = image.GetThumbnailImage(60, 45, null, IntPtr.Zero);
            image.Save(Path.Combine(PhysicalUploadImagesPath, fileName));
            thubnail.Save(PhysicalUploadImagesPath + "/Thumbnails/" + fileName);

            return fileName;
        }

    }
}
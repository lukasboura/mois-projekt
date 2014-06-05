using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace ProjektMOIS.Utils
{
    public class ImageHelper
    {
        public static byte[] Thumbnail(HttpPostedFileBase file)
        {
            var newImage = new WebImage(file.InputStream);

            var width = newImage.Width;
            var height = newImage.Height;

            if (width > height)
            {
                var leftRightCrop = (width - height) / 2;
                newImage.Crop(0, leftRightCrop, 0, leftRightCrop);
            }
            else if (height > width)
            {
                var topBottomCrop = (height - width) / 2;
                newImage.Crop(topBottomCrop, 0, topBottomCrop, 0);
            }
            newImage.Resize(256, 256);
            return newImage.GetBytes();
            /*var fileName = Path.GetFileName(file.FileName);
            var imageFile = Path.Combine(Server.MapPath("~/Images"), fileName);
            file.SaveAs(imageFile);
            using (var srcImage = Image.FromFile(imageFile))
            using (var newImage = new Bitmap(width, height))
            using (var graphics = Graphics.FromImage(newImage))
            using (var stream = new MemoryStream())
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.DrawImage(srcImage, new Rectangle(0, 0, width, height));
                newImage.Save(stream, ImageFormat.Png);
                return stream.ToArray();
            }*/
        }
        public static byte[] GetDefault()
        {
            byte[] imageArray = File.ReadAllBytes(HttpContext.Current.Server.MapPath("~/Content/DefaultImage.png"));
            return imageArray;
        }
    }
}
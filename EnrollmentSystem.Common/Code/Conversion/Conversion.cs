using System;
using System.Drawing;
using System.IO;
using System.Web;

namespace EnrollmentSystem.Common.Code.Conversion
{
    public static class Conversion
    {
        public static byte[] ToByteArray(this Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public static Image ToImage(this byte[] byteArray)
        {
            MemoryStream ms = new MemoryStream(byteArray);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static string ToDataString(this byte[] byteArray, string type = "image/jpeg")
        {
            return string.Format("data:{0};base64,{1}", type, Convert.ToBase64String(byteArray));
        }

        public static Image ToImage(this HttpPostedFileBase httpPostedFileBase)
        {
            var a = httpPostedFileBase.ToString();
            return Image.FromStream(httpPostedFileBase.InputStream, true, true);
        }

        public static Byte[] ToByteArray(this HttpPostedFileBase httpPostedFileBase)
        {
            Image image = httpPostedFileBase.ToImage();
            return image.ToByteArray();
        }

        public static string ToCustomDateString(this DateTime dateTime, string format = "MMMM d, yyyy")
        {
            return (dateTime != null) ? dateTime.ToString(format) : null;
        }

        public static string ToCustomDateString(this DateTime? dateTime, string format = "MMMM d, yyyy")
        {
            return (dateTime != null) ? dateTime.Value.ToString(format) : null;
        }
    }
}

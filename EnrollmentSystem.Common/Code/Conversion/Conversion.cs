using System.Drawing;
using System.IO;
using System.Web;

namespace EnrollmentSystem.Common.Code.Conversion
{
    public class Conversion
    {
        public byte[] ImageToByteArray(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public Image ByteArrayToImage(byte[] byteArray)
        {
            MemoryStream ms = new MemoryStream(byteArray);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public Image HttpPostedFileBaseToImage(HttpPostedFileBase httpPostedFileBase)
        {
            var a = httpPostedFileBase.ToString();
            return Image.FromStream(httpPostedFileBase.InputStream, true, true);
        }
    }
}

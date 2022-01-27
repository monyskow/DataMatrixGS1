using System.Drawing;
using System.Drawing.Imaging;
using DataMatrix.net;

namespace DataMatrixGS1
{
    public class DataMatrixGS1
    {
        private static Bitmap ResizeBitmap(Bitmap bmp, int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage((Image)bitmap))
                graphics.DrawImage((Image)bmp, 0, 0, width, height);
            return bitmap;
        }

        private static Image generateCode(string content, int width, int height)
        {
            DmtxImageEncoderOptions imageEncoderOptions = new DmtxImageEncoderOptions();
            imageEncoderOptions.Scheme = DmtxScheme.DmtxSchemeAsciiGS1;
            DmtxImageEncoder dmtxImageEncoder = new DmtxImageEncoder();
            content = content.Replace('#', char.ConvertFromUtf32(29).ToCharArray()[0]);
            string val = content;
            DmtxImageEncoderOptions options = imageEncoderOptions;
            return (Image)DataMatrixGS1.ResizeBitmap(dmtxImageEncoder.EncodeImage(val, options), width, height);
        }

        public static Image generateDataMatrix(string content, int width, int height)
        {
            return DataMatrixGS1.generateCode(content, width, height);
        }

        public static void generateDataMatrix(string content, int width, int height, string fileName)
        {
            DataMatrixGS1.generateCode(content, width, height).Save(fileName, ImageFormat.Png);
        }
    }
}

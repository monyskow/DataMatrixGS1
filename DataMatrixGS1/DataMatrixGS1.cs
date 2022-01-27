using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using DataMatrix.net;

namespace DataMatrixGS1
{
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [Guid("8050C40E-CB1D-49F4-A8B6-915BEA3F6CFF")]
    [ComVisible(true)]    
    public interface IDataMatrixGS1
    {        
        Image generateDataMatrix2(string content, int width, int height);
        void generateDataMatrix2(string content, int width, int height, string fileName);
    }

    [Guid("2A1F8F87-CE33-4C03-AB0E-EB403FCC0338")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    public class DataMatrixGS1: IDataMatrixGS1
    {
        [ComVisible(false)]
        private static Bitmap ResizeBitmap(Bitmap bmp, int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage((Image)bitmap))
                graphics.DrawImage((Image)bmp, 0, 0, width, height);
            return bitmap;
        }

        [ComVisible(false)]
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

        [ComVisible(false)]
        public static Image generateDataMatrix(string content, int width, int height)
        {
            return DataMatrixGS1.generateCode(content, width, height);
        }


        [ComVisible(false)]
        public static void generateDataMatrix(string content, int width, int height, string fileName)
        {
            DataMatrixGS1.generateCode(content, width, height).Save(fileName, ImageFormat.Png);
        }

        [ComVisible(true)]
        public Image generateDataMatrix2(string content, int width, int height)
        {
            return DataMatrixGS1.generateCode(content, width, height);
        }

        [ComVisible(true)]
        public void generateDataMatrix2(string content, int width, int height, string fileName)
        {
            DataMatrixGS1.generateCode(content, width, height).Save(fileName, ImageFormat.Png);
        }        
    }
}

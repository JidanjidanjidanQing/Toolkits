using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic;
using OpenCvSharp;


namespace Toolkits.QRCode
{
    public class QRCodeService : ToolkitsAppService
    {
        public async Task<string> CreateQRCodeAysnc(string data, int height = 200, int width = 200, int margin = 0)
        {
            byte[] bytes = null;
            var filepath=string.Empty;

            var barcodeWriter = new ZXing.BarcodeWriter()
            {
                Format = ZXing.BarcodeFormat.QR_CODE,
                Options = new ZXing.QrCode.QrCodeEncodingOptions()
                {
                    Height = height,
                    Width = width,
                    Margin = margin
                }
            };



            using (var image = barcodeWriter.Write(data))
            {
                using (var stream = new System.IO.MemoryStream())
                {
                    DateTime dateTime = DateTime.Now;

                    image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    bytes = stream.ToArray();

                    string currentTime = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");

                    if (!Directory.Exists("qrcode/"))
                    {
                        Directory.CreateDirectory("qrcode/");
                    }

                    //filepath = "qrcode/" + currentTime + ".png";
                    filepath = Path.Combine("qrcode/", currentTime+ ".png");
                    //filename = currentTime + ".png";
                    File.WriteAllBytes(filepath, bytes);
                }
            }

            return filepath;
        }


        public async Task<string> GetScanQRCodeAsync(byte[] bytes)
        {
            var result = string.Empty;
            using (var stream = new System.IO.MemoryStream(bytes))
            {
                using (var image = System.Drawing.Image.FromStream(stream))
                {
                    var barcodeReader = new ZXing.BarcodeReader();
                    var decoded = barcodeReader.Decode((System.Drawing.Bitmap)image);
                    if (decoded != null)
                    {
                        result = decoded.Text;
                    }
                }
            }

            return result;
        }
    }
}

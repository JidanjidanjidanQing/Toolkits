using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using OpenCvSharp;
using Sdcb.PaddleOCR;
using Sdcb.PaddleOCR.KnownModels;
using Sdcb.PaddleOCR.Models.Local;
using Sdcb.PaddleInference;
using Sdcb.PaddleOCR.Models;
using SharpCompress.Common;
using System.IO;
using System.Reflection.PortableExecutable;

using System.Drawing;

namespace Toolkits.OCR
{
    public class OcrService : ToolkitsAppService
    {
        private readonly ILogger<OcrService> _logger;
        public OcrService(ILogger<OcrService> logger)
        {
            _logger = logger;
        }

        //public string Get()
        //{
        //    var ocrResult = PostFilePath().Result;
        //    return ocrResult;
        //}
        public async Task<string> GetBase64Code(string filepath)
        {
            Console.WriteLine("开始编码");
            byte[] fileBytes = File.ReadAllBytes(filepath);
            string base64String = Convert.ToBase64String(fileBytes);
            Console.WriteLine("编码结束");
            return base64String;
        }


        public async Task<string> PostReadBase64(string filepath)
        {
            // 解码Base64字符串
            byte[] imageBytes = Convert.FromBase64String(await GetBase64Code(filepath));

            Console.WriteLine(imageBytes);

            var strResult = string.Empty;

            //OCRModel model = KnownOCRModel.PPOcrV2;
            FullOcrModel model = LocalFullModels.ChineseV3;

            //await model.EnsureAll();

            //byte[] sampleImageData;
            //string sampleImageUrl = @"https://www.tp-link.com.cn/content/images/detail/2164/TL-XDR5450易展Turbo版-3840px_03.jpg";

            //using (HttpClient http = new HttpClient())
            //{
            //    Console.WriteLine("Download sample image from: " + sampleImageUrl);
            //    sampleImageData = await http.GetByteArrayAsync(sampleImageUrl);
            //}

            using (PaddleOcrAll all = new PaddleOcrAll(model, PaddleDevice.Mkldnn())
            {
                AllowRotateDetection = true, /* 允许识别有角度的文字 */
                Enable180Classification = false, /* 允许识别旋转角度大于90度的文字 */
            })

            {
                // Load local file by following code:
                //using (Mat src2 = Cv2.ImRead(@"C:\Users\zyq\Desktop\invoice_test.jpg"))

                //using (Mat src = Cv2.ImDecode(sampleImageData, ImreadModes.Color))
                //using (Mat src = Cv2.ImRead(@"C:\Users\zyq\Desktop\invoice_test.jpg"))


                //using (Mat src = Cv2.ImRead(filepath))
                //{
                //    PaddleOcrResult result = all.Run(src);
                //    Console.WriteLine("Detected all texts: \n" + result.Text);
                //    strResult = result.Text;
                //    foreach (PaddleOcrResultRegion region in result.Regions)
                //    {
                //        Console.WriteLine($"Text: {region.Text}, Score: {region.Score}, RectCenter: {region.Rect.Center}, RectSize:    {region.Rect.Size}, Angle: {region.Rect.Angle}");
                //    }
                //}



                using (Mat src = Mat.FromArray(imageBytes))
                {
                    Console.WriteLine("调用ocr");
                    PaddleOcrResult result = all.Run(src);
                    Console.WriteLine("ocr结束");


                    Console.WriteLine("Detected all texts: \n" + result.Text);
                    strResult = result.Text;

                    foreach (PaddleOcrResultRegion region in result.Regions)
                    {
                        Console.WriteLine($"Text: {region.Text}, Score: {region.Score}, RectCenter: {region.Rect.Center}, RectSize:    {region.Rect.Size}, Angle: {region.Rect.Angle}");
                    }
                }
            }
            return strResult;
        }


        public async Task<string> PostReadImage(string filepath)
        {
            var strResult = string.Empty;

            FullOcrModel model = LocalFullModels.ChineseV3;

            using (PaddleOcrAll all = new PaddleOcrAll(model, PaddleDevice.Mkldnn())
            {
                AllowRotateDetection = true, /* 允许识别有角度的文字 */
                Enable180Classification = false, /* 允许识别旋转角度大于90度的文字 */
            })

            {
                using (Mat src = Cv2.ImRead(filepath))
                {
                    PaddleOcrResult result = all.Run(src);
                    Console.WriteLine("Detected all texts: \n" + result.Text);
                    strResult = result.Text;
                    foreach (PaddleOcrResultRegion region in result.Regions)
                    {
                        Console.WriteLine($"Text: {region.Text}, Score: {region.Score}, RectCenter: {region.Rect.Center}, RectSize:    {region.Rect.Size}, Angle: {region.Rect.Angle}");
                    }
                }
            }
            return strResult;
        }
    }
}

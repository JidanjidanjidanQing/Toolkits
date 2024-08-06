using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace Toolkits.PDF
{
    public class PDFService : ToolkitsAppService
    {
        public async Task<string> PostReadPDF(string filepath)
        {
            string text = string.Empty;
            try
            {
                string pdffilename = filepath;
                StringBuilder buffer = new StringBuilder();

                //Create a pdf document.
                using (Spire.Pdf.PdfDocument doc = new Spire.Pdf.PdfDocument())
                {
                    // Load the PDF Document
                    doc.LoadFromFile(pdffilename);
                    // String for hold the extracted text

                    foreach (Spire.Pdf.PdfPageBase page in doc.Pages)
                    {
                        buffer.Append(page.ExtractText());
                    }
                    doc.Close();
                }
                //save text
                text = buffer.ToString();
                return text;
            }
            catch (Exception ex)
            {
                //DHC.EAS.Common.LogInfo.Debug("读取PDF文件返回=" + text);
                //DHC.EAS.Common.LogInfo.Debug("读取PDF文件错误", ex);
                return null;
            }
        }
    }
}

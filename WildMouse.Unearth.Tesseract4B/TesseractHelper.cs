using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace WildMouse.Unearth.Tesseract4B
{
    public static class TesseractHelper
    {
        public static OCRResult OCRImageWithTesseract(Image theImage)
        {
            if (theImage is Bitmap)
            {
                var bmp = (Bitmap)theImage;
                return OCRImageWithTesseract(bmp);
            }
            else
            {
                throw new ApplicationException("OCRImageWithTesseract: Image must be Bitmap");
            }
        }

        [HandleProcessCorruptedStateExceptions]
        public static OCRResult OCRImageWithTesseract(Bitmap theBmp)
        {
            var ocrResult = new OCRResult() { OcrText = string.Empty, HocrText = string.Empty, MeanConfidence = 0.0f };
            try
            {
                using (var engine = new Tesseract.TesseractEngine(@".\tessdata\", "eng", Tesseract.EngineMode.LstmOnly))
                {
                    using (var pix = Tesseract.PixConverter.ToPix(theBmp))
                    {
                        using (var tessPage = engine.Process(pix, Tesseract.PageSegMode.Auto))
                        {
                            ocrResult.OcrText = tessPage.GetText();
                            ocrResult.HocrText = tessPage.GetHOCRText(1);
                            ocrResult.MeanConfidence = tessPage.GetMeanConfidence();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is AccessViolationException || ex is InvalidOperationException)
                {
                    Trace.TraceError("Tesseract Error: " + ex.Message);
                }
                else
                {
                    throw;
                }
            }
            return ocrResult;
        }
    }
}

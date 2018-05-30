using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildMouse.Unearth.Tesseract4B;

namespace WildMouse.Unearth.TestTessWebApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var jabberwock = Image.FromFile(Environment.CurrentDirectory + @"\Images\Jabberwock.JPG");
            var ocrResult = TesseractHelper.OCRImageWithTesseract(jabberwock);
            Console.WriteLine($"Confidence: {ocrResult.MeanConfidence}");
            Console.WriteLine(ocrResult.OcrText);
            Console.ReadLine();
        }
    }
}

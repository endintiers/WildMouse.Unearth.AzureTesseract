using System;
using System.Drawing;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using WildMouse.Unearth.Tesseract4B;

namespace WildMouse.Unearth.TestTessAzureFunction
{
    public static class TessTestFunction
    {
        [FunctionName("TessTestFunction")]
        public static void Run([TimerTrigger("0 0 * * * *", RunOnStartup = true)]TimerInfo myTimer, TraceWriter log, ExecutionContext context)
        {
            log.Info($"C# Timer trigger function executed at: {DateTime.Now}");
            try
            {
                var jabberwock = Image.FromFile(context.FunctionAppDirectory + @"\Images\Jabberwock.JPG");
                var ocrResult = TesseractHelper.OCRImageWithTesseract(jabberwock);
                log.Info($"Confidence: {ocrResult.MeanConfidence}");
                log.Info(ocrResult.OcrText);
            }
            catch (Exception ex)
            {
                log.Error($"Exception: {ex}");
            }
            log.Info($"C# Timer trigger function finished at: {DateTime.Now}");

        }

    }
}

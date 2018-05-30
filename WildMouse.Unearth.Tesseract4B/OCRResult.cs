using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildMouse.Unearth.Tesseract4B
{
    public class OCRResult
    {
        public string OcrText { get; set; }
        public string HocrText { get; set; }
        public float MeanConfidence { get; set; }
    }
}

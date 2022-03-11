using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinkToPdf;

namespace Vivel.Helpers
{
    public class HtmlToPdfHelper
    {
        public static HtmlToPdfDocument GetPdfDocument(string html)
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings
                {
                    Top = 10,
                    Bottom = 10,
                    Left = 10,
                    Right = 10,
                },
                DocumentTitle = "report"
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = html,
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = null }
            };

            var pdf = new HtmlToPdfDocument
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };


            return pdf;
        }
    }
}

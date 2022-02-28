using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SelectPdf;

namespace Vivel.Helpers
{
    public class HtmlToByteArrayHelper
    {
        public static byte[] GetBytes(string html)
        {
            var htmlToPdf = new HtmlToPdf();
            var pdfdoc = htmlToPdf.ConvertHtmlString(html);

            var pdf = pdfdoc.Save();
            pdfdoc.Close();

            return pdf;
        }
    }
}

using ChromeHtmlToPdfLib;
using ChromeHtmlToPdfLib.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PdfFromPartial.Models;
using PdfFromPartial.Renderers;
using PdfFromPartial.Services;
using System.Net.Mime;

namespace PdfFromPartial.Pages
{
    public class ChromeVersionModel : PageModel
    {
        private readonly IProductManager productManager;
        private readonly IRazorTemplateRenderer renderer;

        public ChromeVersionModel(IProductManager productManager, IRazorTemplateRenderer renderer)
        {
            this.productManager = productManager;
            this.renderer = renderer;
        }
        public List<Product> Products { get; set; } = new();
        public string BaseHref => $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
        public async Task<FileResult> OnGetReportFromPartialAsync()
        {
            Products = await productManager.GetProducts();
            var html = await renderer.RenderPartialToStringAsync("_ProductReport-v2", this);
            var pageSettings = new PageSettings(ChromeHtmlToPdfLib.Enums.PaperFormat.A4);
            var stream = new MemoryStream();
            using var converter = new Converter();
            converter.ConvertToPdf(html, stream, pageSettings);
            return File(stream.ToArray(), MediaTypeNames.Application.Pdf, "Reorder Report (Chrome from partial).pdf");
        }
    }
}


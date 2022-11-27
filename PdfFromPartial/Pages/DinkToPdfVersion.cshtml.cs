using DinkToPdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PdfFromPartial.Models;
using PdfFromPartial.Renderers;
using PdfFromPartial.Services;
using System.Net.Mime;

namespace PdfFromPartial.Pages
{
    public class DinkToPdfVersionModel : PageModel
    {
        private readonly IProductManager productManager;
        private readonly IWebHostEnvironment environment;
        private readonly IRazorTemplateRenderer renderer;
        private readonly IPdfGenerator pdfGenerator;

        public DinkToPdfVersionModel(IProductManager productManager,
            IWebHostEnvironment environment,
            IRazorTemplateRenderer renderer,
            IPdfGenerator pdfGenerator)
        {
            this.productManager = productManager;
            this.environment = environment;
            this.renderer = renderer;
            this.pdfGenerator = pdfGenerator;
        }

        public List<Product> Products { get; set; }
        public string WebRootPath => environment.WebRootPath;
        public async Task<FileResult> OnGetReportFromPartialAsync()
        {
            Products = await productManager.GetProducts();
            var html = await renderer.RenderPartialToStringAsync("_ProductReport", this);
            var globalSettings = new GlobalSettings
            {
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
            };
            var objectSettings = new ObjectSettings()
            {
                HtmlContent = html,

            };
            return File(pdfGenerator.Render(globalSettings, objectSettings), MediaTypeNames.Application.Pdf, "Reorder Report (DinkToPDF from partial.pdf");
        }

        public async Task<FileResult> OnGetReportFromUrlAsync()
        {
            var globalSettings = new GlobalSettings
            {
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
            };
            var objectSettings = new ObjectSettings()
            {
                Page = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{Url.Page("/Pdfs/ReorderReport")}"
            };
            return File(pdfGenerator.Render(globalSettings, objectSettings), MediaTypeNames.Application.Pdf, "Reorder Report (DinkToPDF from partial.pdf");
        }
    }
}

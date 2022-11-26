using AngleSharp.Dom;
using AngleSharp.Io;
using ChromeHtmlToPdfLib;
using ChromeHtmlToPdfLib.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PdfFromPartial.Models;
using PdfFromPartial.Renderers;
using PdfFromPartial.Services;
using System;
using System.Diagnostics;
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
        public async Task<FileResult> OnGetAsync()
        {
            Products = await productManager.GetProducts();
            var html = await renderer.RenderPartialToStringAsync("_ProductReport-v2", this);
            using var converter = new Converter();
            var stream = new MemoryStream();
            var pageSettings = new PageSettings(ChromeHtmlToPdfLib.Enums.PaperFormat.A4);
            converter.ConvertToPdf(html, stream, pageSettings);
            stream.Position = 0;
            return File(stream, MediaTypeNames.Application.Pdf, "Reorder Report (Chrome).pdf");
        }
    }
}

//using var converter = new Converter();
//var stream = new MemoryStream();
//var pageSettings = new PageSettings(ChromeHtmlToPdfLib.Enums.PaperFormat.A4);
//var url = $"{Request.Scheme}://{Request.Host}{Url.Page("/Pdfs/ReorderReport")}";
//converter.ConvertToPdf(new ConvertUri(url), stream, pageSettings);
//stream.Position = 0;
//return File(stream, MediaTypeNames.Application.Pdf, "Reorder Report (Chrome).pdf");
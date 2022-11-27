using iText.Html2pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PdfFromPartial.Models;
using PdfFromPartial.Renderers;
using PdfFromPartial.Services;
using System.Diagnostics;
using System.Net.Mime;

namespace PdfFromPartial.Pages
{
    public class ITextVersionModel : PageModel
    {
        private readonly IProductManager productManager;
        private readonly IRazorTemplateRenderer renderer;

        public ITextVersionModel(IProductManager productManager, IRazorTemplateRenderer renderer)
        {
            this.productManager = productManager;
            this.renderer = renderer;
        }
        string BaseHref => $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
        public List<Product> Products { get; set; } = new();
        public async Task<FileResult> OnGetReportFromPartialAsync()
        {
            Products = await productManager.GetProducts();
            var html = await renderer.RenderPartialToStringAsync("_ProductReport-v3", this);
            ConverterProperties converterProperties = new();
            converterProperties.SetBaseUri(BaseHref);
            using var stream = new MemoryStream();
            HtmlConverter.ConvertToPdf(html, stream, converterProperties);
            return File(stream.ToArray(), MediaTypeNames.Application.Pdf, "Reorder Report (iText from partial).pdf");
        }
    }
}

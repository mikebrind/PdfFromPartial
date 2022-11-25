using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PdfFromPartial.Models;
using PdfFromPartial.Renderers;
using PdfFromPartial.Services;

namespace PdfFromPartial.Pages
{
    public class ProductReportModel : PageModel
    {
        private readonly IProductManager productManager;
        private readonly IWebHostEnvironment environment;
        private readonly IRazorTemplateRenderer renderer;
        private readonly IPdfGenerator pdf;

        public ProductReportModel(IProductManager productManager, IWebHostEnvironment environment, IRazorTemplateRenderer renderer, IPdfGenerator pdf)
        {
            this.productManager = productManager;
            this.environment = environment;
            this.renderer = renderer;
            this.pdf = pdf;
        }

        public List<Product> Products { get; set; }
        public string WebRootPath => environment.WebRootPath;
        public async Task<FileResult> OnGetAsync()
        {
            Products = await productManager.GetProducts();
            var html = await renderer.RenderPartialToStringAsync("_ProductReport", this);
            return File("", "");
        }
    }
}

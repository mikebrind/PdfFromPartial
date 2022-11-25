using PdfFromPartial.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using PdfFromPartial.Renderers;

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

        public string WebRootPath => environment.WebRootPath;
        public async Task<FileResult> OnGet()
        {

        }
    }
}

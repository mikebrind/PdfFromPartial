using Microsoft.AspNetCore.Mvc.RazorPages;
using PdfFromPartial.Models;
using PdfFromPartial.Services;

namespace PdfFromPartial.Pages
{
    public class ReorderReportModel : PageModel
    {
        private readonly IProductManager productManager;

        public ReorderReportModel(IProductManager productManager) => this.productManager = productManager;
        public List<Product> Products { get; set; } = new();
        public async Task OnGetAsync() => Products = await productManager.GetProducts();
    }
}

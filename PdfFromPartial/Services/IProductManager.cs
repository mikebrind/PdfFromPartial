using PdfFromPartial.Models;

namespace PdfFromPartial.Services;
public interface IProductManager
{
    Task<List<Product>> GetFilteredProducts(string filter);
    Task<List<Product>> GetProducts();
}
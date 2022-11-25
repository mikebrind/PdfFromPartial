using PdfFromPartial.Models;

namespace BlazorWasmReleaseNotes.Server.Services;
public interface IProductManager
{
    Task<List<Product>> GetFilteredProducts(string filter);
}
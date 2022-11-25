using PdfFromPartial.Models;

namespace BlazorWasmReleaseNotes.Server.Services;

public interface ICustomerManager
{
    Task<List<Customer>> GetFilteredCustomers(string filter);
}
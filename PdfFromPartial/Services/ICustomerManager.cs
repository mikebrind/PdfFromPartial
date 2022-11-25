using PdfFromPartial.Models;

namespace PdfFromPartial.Services;

public interface ICustomerManager
{
    Task<List<Customer>> GetFilteredCustomers(string filter);
}
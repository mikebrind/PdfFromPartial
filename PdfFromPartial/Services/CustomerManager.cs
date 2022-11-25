using PdfFromPartial.Server.Data;
using PdfFromPartial.Models;
using Microsoft.EntityFrameworkCore;

namespace PdfFromPartial.Services;

public class CustomerManager : ICustomerManager
{
	private readonly NorthwindContext context;

	public CustomerManager(NorthwindContext context) => this.context = context;

	public async Task<List<Customer>> GetFilteredCustomers(string filter) =>
		await context.Customers
		.Where(x => x.CompanyName.ToLower().Contains(filter.ToLower()))
		.OrderBy(x => x)
		.ToListAsync();
}

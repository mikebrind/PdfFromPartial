using DinkToPdf.Contracts;
using DinkToPdf;
using PdfFromPartial.Renderers;
using PdfFromPartial.Services;
using PdfFromPartial.Server.Data;
using PdfFromPartial.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<NorthwindContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("Northwind")));
builder.Services.AddScoped<ICustomerManager, CustomerManager>();
builder.Services.AddScoped<IProductManager, ProductManager>();
builder.Services.AddSingleton<IConverter>(provider => new SynchronizedConverter(new PdfTools()));
builder.Services.AddScoped<IRazorTemplateRenderer, IRazorTemplateRenderer>();
builder.Services.AddSingleton<IPdfGenerator, PdfGenerator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

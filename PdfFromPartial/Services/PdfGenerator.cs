using DinkToPdf.Contracts;
using DinkToPdf;

namespace PdfFromPartial.Services;

public class PdfGenerator : IPdfGenerator
{
    private readonly IConverter converter;
    public PdfGenerator(IConverter converter) => this.converter = converter;
    public byte[] Render(GlobalSettings globalSettings, ObjectSettings objectSettings) => converter.Convert(new HtmlToPdfDocument() { GlobalSettings = globalSettings, Objects = { objectSettings } });
}


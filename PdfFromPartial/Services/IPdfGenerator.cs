using DinkToPdf;

namespace PdfFromPartial.Services;

public interface IPdfGenerator
{
    byte[] Render(GlobalSettings globalSettings, ObjectSettings objectSettings);
}
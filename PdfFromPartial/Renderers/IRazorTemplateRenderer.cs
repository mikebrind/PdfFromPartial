namespace PdfFromPartial.Renderers;

public interface IRazorTemplateRenderer
{
    Task<string> RenderPartialToStringAsync<TModel>(string partialName, TModel model);
}

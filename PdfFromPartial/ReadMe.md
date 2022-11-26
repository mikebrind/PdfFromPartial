# Generating PDFs from Partials in Razor Pages



1. Add a package reference from DinkToPdf `<PackageReference Include="DinkToPdf" Version="1.0.8" />` and copy the wkhtml libraries (3 of them) to the root of the web application project.
2. Register the IConverter as a singleton with the service container
3. Add the renderer interface and implementation from [Rendering A Partial To A String In Razor Pages](https://www.mikesdotnetting.com/article/332/rendering-a-partial-to-a-string-in-razor-pages).
4. Register with the services container with a scoped lifetime, because it depends on other scoped services
5. Add the IPdfGenerator and implementation and register as a singleton with the container
6. Add older vertsion of bootstrap (3) because flex is not supported by wkhtml
7. Create additional styles in pdf.css
8. Add web fonts to the wwwroot folder
9. Create a template, referencing WebRootPath to generate file paths at runtime
10. Use WebRootPath to reference css files, ensuring that  `rel="stylesheet"` is included in the link
11. 



 Note: This demo application includes the 64 bit version of the wkhtml libraries. The libraries for 32 bit operating systems are available from here: https://github.com/rdvojmoc/DinkToPdf/tree/master/v0.12.4
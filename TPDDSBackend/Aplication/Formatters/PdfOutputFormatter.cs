using Microsoft.AspNetCore.Mvc.Formatters;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace TPDDSBackend.Aplication.Formatters
{
    public class PdfOutputFormatter : OutputFormatter
    {
        public PdfOutputFormatter()
        {
            SupportedMediaTypes.Add("application/pdf");
        }

        protected override bool CanWriteType(Type type)
        {
            return typeof(IEnumerable<>).IsAssignableFrom(type) || typeof(object).IsAssignableFrom(type);
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
        {
            var response = context.HttpContext.Response;
            var data = context.Object as IEnumerable<object>;

            if (data == null || !data.Any()) // Verifica si 'data' es null o vacío
            {
                response.StatusCode = 204; // No Content
                return;
            }

            var pdfData = GeneratePdf(data);

            response.ContentType = "application/pdf";
            await response.Body.WriteAsync(pdfData, 0, pdfData.Length);
        }

        public byte[] GeneratePdf(IEnumerable<object> data)
        {
            using var stream = new MemoryStream();

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(50);
                    page.Header().Text("Reporte de Datos").FontSize(20).Bold();
                    page.Content().Table(table =>
                    {
                        // Obtenemos las propiedades del primer objeto de los datos
                        var properties = data.First().GetType().GetProperties();

                        // Definir las columnas con 'ColumnsDefinition'
                        table.ColumnsDefinition(columns =>
                        {
                            foreach (var property in properties)
                            {
                                columns.RelativeColumn(); // Esto crea una columna para cada propiedad
                            }
                        });

                        // Agregar el encabezado de la tabla
                        table.Header(header =>
                        {
                            foreach (var property in properties)
                            {
                                header.Cell().Text(property.Name).Bold();
                            }
                        });

                        // Agregar los datos de la tabla
                        foreach (var item in data)
                        {
                            table.Cell().Text(item.GetType().GetProperty(properties[0].Name)?.GetValue(item)?.ToString() ?? string.Empty);
                            foreach (var property in properties.Skip(1)) // Comienza con la siguiente propiedad
                            {
                                var value = property.GetValue(item)?.ToString() ?? string.Empty;
                                table.Cell().Text(value);
                            }
                        }
                    });
                });
            }).GeneratePdf(stream);

            return stream.ToArray();
        }
    }
}

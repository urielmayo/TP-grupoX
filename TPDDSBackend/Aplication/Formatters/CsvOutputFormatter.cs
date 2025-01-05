using CsvHelper.Configuration;
using CsvHelper;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Globalization;

namespace TPDDSBackend.Aplication.Formatters
{
    public class CsvOutputFormatter : OutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add("text/csv");
        }
        protected override bool CanWriteType(Type type)
        {
            return typeof(IEnumerable<>).IsAssignableFrom(type) || typeof(object).IsAssignableFrom(type);
        }
        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
        {
            var response = context.HttpContext.Response;
            var data = context.Object as IEnumerable<object>;

            if (data == null || !data.Any())
            {
                response.StatusCode = 204; // No Content
                return;
            }

            response.ContentType = "text/csv"; // Definimos el tipo de contenido

            // Usamos un MemoryStream para escribir el CSV
            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                // Escribimos los registros en el CSV
                await csv.WriteRecordsAsync(data);
                writer.Flush(); 

                // Volvemos al principio del MemoryStream antes de escribirlo en la respuesta
                stream.Seek(0, SeekOrigin.Begin);

                // Escribimos los datos CSV en la respuesta HTTP
                await stream.CopyToAsync(response.Body);
            }
        }
    }
}

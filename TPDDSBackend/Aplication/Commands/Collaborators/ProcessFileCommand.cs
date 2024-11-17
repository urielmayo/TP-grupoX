using CsvHelper;
using MediatR;
using System.Globalization;
using System.Threading;
using TPDDSBackend.Aplication.Dtos.File;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Services;
using TPDDSBackend.Domain.Entitites;
namespace TPDDSBackend.Aplication.Commands.Collaborators
{
    public class ProcessFileCommand : IRequest<CustomResponse<ProcessFileResponse>>
    {
        public ProcessFileRequest Request { get; set; }

        public ProcessFileCommand(ProcessFileRequest request)
        {
            Request = request;
        }
    }

    public class ProcessFileCommandHandler : IRequestHandler<ProcessFileCommand, CustomResponse<ProcessFileResponse>>
    {
        private readonly IFileProcessorService _fileProcessorService;
        public ProcessFileCommandHandler(IFileProcessorService fileProcessorService)
        {
            _fileProcessorService = fileProcessorService;
        }

        public async Task<CustomResponse<ProcessFileResponse>> Handle(ProcessFileCommand command, CancellationToken ct)
        {
            var contributions = new List<ContributionsCsv>();

            var newUsers = new List<string>();

            using (var reader = new StreamReader(command.Request.File.OpenReadStream()))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                csv.Context.TypeConverterOptionsCache.GetOptions<DateTime>().Formats = new[] { "dd/MM/yyyy" };

                while (csv.Read())
                {
                    try
                    {
                        var registro = new ContributionsCsv
                        {
                            TipoDoc = Enum.Parse<TipoDoc>(csv.GetField<string>(0), true),
                            Documento = csv.GetField<long>(1),
                            Nombre = csv.GetField<string>(2),
                            Apellido = csv.GetField<string>(3),
                            Mail = csv.GetField<string>(4),
                            FechaColaboracion = csv.GetField<DateTime>(5),
                            FormaColaboracion = Enum.Parse<TypeContribution>(csv.GetField<string>(6), true)
                        };

                        contributions.Add(registro);
                    }
                    catch (Exception ex)
                    {
                        // Log o manejo de error para la fila actual
                        Console.WriteLine($"Error en la fila: {ex.Message}");
                    }
                }
            }

            foreach(var contribution in contributions)
            {
                var newUser = await _fileProcessorService.ProcessContributionAsync(contribution);
                if (newUser)
                {
                    newUsers.Add(contribution.Mail);
                }
            }
            var response = new ProcessFileResponse("Se ha enviado un correo a lo siguientes correos con sus credenciales para ingresar al sistema", newUsers);

            return new CustomResponse<ProcessFileResponse>("Se ha procesado correctamente el archivo", response);
        }
    }
}

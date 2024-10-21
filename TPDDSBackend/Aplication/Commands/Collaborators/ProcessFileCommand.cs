using MediatR;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
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

        public ProcessFileCommandHandler()
        {

        }

        public async Task<CustomResponse<ProcessFileResponse>> Handle(ProcessFileCommand command, CancellationToken ct)
        {
            
            
            return new CustomResponse<ProcessFileResponse>("Se ha procesado correctamente el archivo");
        }
    }
}

using AutoMapper;
using MediatR;
using System.Net;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Commands
{
    public class UpdateTechnicianCommand : IRequest<CustomResponse<UpdateTechnicianResponse>>
    {
        public UpdateTechnicianRequest Request { get; set; }
        public int Id { get; set; }
        public UpdateTechnicianCommand(UpdateTechnicianRequest request, int id)
        {
            Request = request;
            Id = id;
        }
    }

    public class UpdateTechnicianCommandHandler : IRequestHandler<UpdateTechnicianCommand, CustomResponse<UpdateTechnicianResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Technician> _techRepository;


        public UpdateTechnicianCommandHandler(IMapper mapper,
            IGenericRepository<Technician> techRepository)
        {
            _techRepository = techRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponse<UpdateTechnicianResponse>> Handle(UpdateTechnicianCommand command, CancellationToken ct)
        {
            var entity = _mapper.Map<Technician>(command.Request);
            entity.Id = command.Id;


            //TODO: Revisar que exista el tipo de documento al que se hace referencia


            try
            {
                _techRepository.Update(entity);
            }
            catch(Exception ex)
            {
                throw new ApiCustomException("Error Actualizando Técnico", HttpStatusCode.InternalServerError);
            }

            var responseDTO = new UpdateTechnicianResponse()
            {
                Id = entity.Id,
                Name = entity.Name,
                Surname = entity.Surname
            };

            return new CustomResponse<UpdateTechnicianResponse>("Se ha actualizado el técnico", responseDTO);
        }
    }
}



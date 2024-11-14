using AutoMapper;
using MediatR;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Commands
{
    public class CreateTechnicianCommand : IRequest<CustomResponse<CreateTechnicianResponse>>
    {
        public CreateTechnicianRequest Request { get; set; }
        public CreateTechnicianCommand(CreateTechnicianRequest request)
        {
            Request = request;
        }
    }

    public class CreateTechnicianCommandHandler : IRequestHandler<CreateTechnicianCommand, CustomResponse<CreateTechnicianResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Technician> _genericRepository;


        public CreateTechnicianCommandHandler(IMapper mapper,
            IGenericRepository<Technician> genericRepository)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponse<CreateTechnicianResponse>> Handle(CreateTechnicianCommand command, CancellationToken ct)
        {
            var entity = _mapper.Map<Technician>(command.Request);

            await _genericRepository.Insert(entity);

            //TODO: Revisar que exista el tipo de documento al que se hace referencia.

            var responseDTO = new CreateTechnicianResponse()
            {
                Id = entity.Id,
                Name = entity.Name,
                Surname = entity.Surname
            };

            return new CustomResponse<CreateTechnicianResponse>("Se ha creado el técnico", responseDTO);
        }
    }
}



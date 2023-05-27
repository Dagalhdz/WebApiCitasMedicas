using AutoMapper;
using WebApiCitasMedicas.DTOS;
using WebApiCitasMedicas.Entities;

namespace WebApiCitasMedicas.Utils
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {


            CreateMap<GeneroDTO, Genero>();
            CreateMap<Genero, GeneroDTO>();

            CreateMap<CreateUserDto, Medico>();
            CreateMap<Medico, CreateUserDto>();

            CreateMap<Medico, GetUserDTO>();
            CreateMap<GetUserDTO, Medico>();

            CreateMap<ParentescoDTO, Parentesco>();
            CreateMap<Parentesco, ParentescoDTO>();

            //CreateMap<fuente, destino>
            CreateMap<FamiliarDTO, Familiares>();
            CreateMap<Familiares, FamiliarDTO>();
            //.ForMember(f => f.PacienteId, p => p.MapFrom(n => n.Paciente.Nombre))
            //.ForMember(f => f.FamiliarId, p => p.MapFrom(n => n.Paciente.Nombre))
            //.ForMember(f => f.ParentescoId, p => p.MapFrom(n => n.Parentesco.Name));
        }
    }
}

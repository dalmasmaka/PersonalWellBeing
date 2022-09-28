using AutoMapper;
using PersonalWellBeing.DTO;
using PersonalWellBeing.Models;

namespace PersonalWellBeing.Services
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateDoctorDTO, Ddoctor>();
            CreateMap<UpdateDoctorDTO, Ddoctor>();
            CreateMap<CreateExercisesItemsDTO, DexercisesItem>();
        }
    }
}

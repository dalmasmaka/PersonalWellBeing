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
            CreateMap<UpdateExercisesItemsDTO, DexercisesItem>();
            CreateMap<CreateFoodItemDTO, DnutritionFooodItem>();
            CreateMap<UpdateFoodItemDTO, DnutritionFooodItem>();
            CreateMap<CreateYogaItemDTO, DyogaItem>();
            CreateMap<UpdateYogaItemDTO, DyogaItem>();
            CreateMap<CreateSleepDTO, DsleepHygiene>();
            CreateMap<UpdateSleepDTO, DsleepHygiene>();
        }
    }
}

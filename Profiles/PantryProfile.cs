using AutoMapper;
using pantry_service.DTOs;
using pantry_service.Models;

namespace pantry_service.Profiles
{
    public class PantryProfile : Profile
    {
        public PantryProfile()
        {
            //source -> target
            CreateMap<ReadUser,User>();
            CreateMap<User, ReadUser>();

            CreateMap<ReadNutritionalValue, NutritionalValue>();
            CreateMap<NutritionalValue, ReadNutritionalValue>();
            CreateMap<CreateNutritionalValue, NutritionalValue>();

            CreateMap<ReadIngredient, Ingredient>();
            CreateMap<Ingredient, ReadIngredient>();
            CreateMap<CreateIngredient, Ingredient>();
        }
    }
}
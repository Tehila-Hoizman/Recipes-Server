using AutoMapper;
using Common.Entity;
using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MapperProfile:Profile
    {
        public MapperProfile() 
        {
            CreateMap< Category,CategoryDto > ().ReverseMap();
            CreateMap< User, UserDto>().ReverseMap();
            CreateMap< Measure, MeasureDto>().ReverseMap();
            CreateMap<Recipe,RecipeDto>().ReverseMap();
            CreateMap< Ingredient, IngredientDto>().ReverseMap();
            CreateMap<Follower, FollowerDto>().ReverseMap();
            CreateMap<Comment, CommentDto > ().ReverseMap();

        }
    }
}

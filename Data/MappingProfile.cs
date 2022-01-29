using AutoMapper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<Game, GameDTO>()
                .ForMember(
                    dto => dto.Categories,
                    opt => opt.MapFrom(x => x.Categories.Select(y => new CategoryDTO { Id = y.Id, Name = y.Name })
                        .ToList()));
            CreateMap<GameDTO, Game>();

            //CreateMap<GameCategory, GameDTO>();          
            CreateMap<CategoryDTO, Category>();
        }
    }
}

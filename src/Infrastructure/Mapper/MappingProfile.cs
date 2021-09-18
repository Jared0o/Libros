using AutoMapper;
using Core.Dtos.Author;
using Core.Entities;

namespace Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateAuthorRequest, Author>()
                .ForMember(a => a.NormalizedName, cr => cr.MapFrom( cr => cr.FirstName.ToUpper() + " " + cr.LastName.ToUpper()));
            CreateMap<Author, AuthorResponseDto>();
            CreateMap<UpdateAuthorRequest, Author>()
                .ForMember(a => a.NormalizedName, cr => cr.MapFrom(cr => cr.FirstName.ToUpper() + " " + cr.LastName.ToUpper()));
        }
    }
}

using AutoMapper;
using Core.Dtos.Author;
using Core.Dtos.Book;
using Core.Dtos.Borrow;
using Core.Dtos.Publisher;
using Core.Dtos.User;
using Core.Entities;
using Core.Entities.Identity;

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

            CreateMap<CreatePublisherRequest, Publisher>();
            CreateMap<Publisher, PublisherResponseDto>();
            CreateMap<UpdatePublisherRequest, Publisher>();

            CreateMap<CreateBookRequest, Book>();
            CreateMap<Book, BookResponseDto>();
            CreateMap<UpdateBookRequest, Book>();

            CreateMap<CreateBorrowRequest, BorrowList>();
            CreateMap<BorrowList, BorrowResponseDto>();
            CreateMap<User, UserDto>();
        }
    }
}

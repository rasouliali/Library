using AutoMapper;
using Library.Application.Dto;
using Library.Application.UseCases.Books.Commands.Add;
using Library.Application.UseCases.Books.Commands.Update;
using Library.Application.UseCases.UserManager.Commands.Register;
using Library.Domain.Entities.BookEntities;

namespace Library.Application.UseCases.Commons.Mappings
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, AddBookCommand>()
                .ReverseMap();
            CreateMap<Book, UpdateBookCommand>()
                .ReverseMap();
            CreateMap<Book, BookSimpleDto>().AfterMap((s, t) => { t.Title = s.Title + "-" + s.Author + "-" + s.PublishYear; });
            CreateMap<Book, BookDto>()
                .ReverseMap();
        }
    }
}

using AutoMapper;
using Library.Application.Dto;
using Library.Application.UseCases.Borrowings.Commands.Add;
using Library.Application.UseCases.Borrowings.Commands.Update;
using Library.Domain.Entities.BookEntities;

namespace Library.Application.UseCases.Commons.Mappings
{
    public class BorrowingProfile : Profile
    {
        public BorrowingProfile()
        {
            CreateMap<UpdateBorrowingCommand, Borrowing>();
            CreateMap<Borrowing, AddBorrowingCommand>()
                .ReverseMap();
            CreateMap<Borrowing, BorrowingDto>().AfterMap((s, d) =>
            {
                if(s.CurrentCreatedUser!=null)
                    d.CurrentUserFullname = s.CurrentCreatedUser.FullName;
                d.BookId=s.CurrentBook.Id;
                d.BookPublishYear = s.CurrentBook.PublishYear;
                d.BookTitle=s.CurrentBook.Title;
                d.BookAuthor = s.CurrentBook.Author;
            });
            CreateMap<BorrowingDto, Borrowing>();
        }
    }
}

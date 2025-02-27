using Library.Application.UseCases.Commons.Bases;
using Library.Domain.Entities.BookEntities;
using Library.Domain.Entities.UserEntities;
using MediatR;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Application.UseCases.Borrowings.Commands.Add
{
    public class AddBorrowingCommand : IRequest<BaseResponse<int>>
    {
        public int BookId { get; set; }
        public int CreatedUserId { get; set; }
        public required string BorrowingFullName { set; get; }
        public required string BorrowingNationalCode { set; get; }
        public required string BorrowingMobile { set; get; }
    }
}
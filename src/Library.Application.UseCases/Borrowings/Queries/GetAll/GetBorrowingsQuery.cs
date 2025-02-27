using Library.Application.Dto;
using Library.Application.UseCases.Commons.Bases;
using MediatR;

namespace Library.Application.UseCases.Borrowings.Queries.GetAll
{
    public class GetBorrowingsQuery : IRequest<BaseResponse<List<BorrowingDto>>>
    {
        //public int BookId { get; set; }
    }
}
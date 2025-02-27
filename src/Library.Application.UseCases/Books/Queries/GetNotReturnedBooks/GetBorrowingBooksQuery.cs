using Library.Application.UseCases.Commons.Bases;
using Library.Application.Dto;
using MediatR;

namespace Library.Application.UseCases.Books.Queries.GetNotReturnedBooks
{
    public class GetNotReturnedBooksQuery : IRequest<BaseResponse<List<BookDto>>>
    {
    }
}
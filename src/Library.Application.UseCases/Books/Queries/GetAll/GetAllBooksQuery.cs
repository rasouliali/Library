using Library.Application.UseCases.Commons.Bases;
using Library.Application.Dto;
using MediatR;

namespace Library.Application.UseCases.Books.Queries.GetAll
{
    public class GetAllBooksQuery : IRequest<BaseResponse<List<BookDto>>>
    {
    }
}
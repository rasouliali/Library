using Library.Application.UseCases.Commons.Bases;
using Library.Application.Dto;
using MediatR;

namespace Library.Application.UseCases.Books.Queries.GetAll
{
    public class GetBookByIdQuery : IRequest<BaseResponse<BookDto>>
    {
        public int Id { get; set; }
    }
}
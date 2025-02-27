using Library.Application.UseCases.Commons.Bases;
using Library.Application.Dto;
using MediatR;

namespace Library.Application.UseCases.Books.Queries.GetRemainsBook
{
    public class GetRemainsBookQuery : IRequest<BaseResponse<List<BookSimpleDto>>>
    {
    }
}
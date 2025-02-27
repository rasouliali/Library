using Library.Application.UseCases.Commons.Bases;
using Library.Application.Dto;
using MediatR;

namespace Library.Application.UseCases.Books.Queries.GetFiltersBooks
{
    public class GetFiltersBooksQuery : IRequest<BaseResponse<List<BookDto>>>
    {
        public int? PublishYear { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Category { get; set; }
    }
}
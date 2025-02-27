using Library.Application.UseCases.Commons.Bases;
using MediatR;

namespace Library.Application.UseCases.Books.Commands.Update
{
    public class UpdateBookCommand : IRequest<BaseResponse<bool>>
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required string BookCategory { get; set; }
        public required int PublishYear { get; set; }
    }
}
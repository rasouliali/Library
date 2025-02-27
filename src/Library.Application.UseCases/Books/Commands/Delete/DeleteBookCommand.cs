using Library.Application.UseCases.Commons.Bases;
using MediatR;

namespace Library.Application.UseCases.Books.Commands.Delete
{
    public class DeleteBookCommand : IRequest<BaseResponse<bool>>
    {
        public int Id { get; set; }
    }
}
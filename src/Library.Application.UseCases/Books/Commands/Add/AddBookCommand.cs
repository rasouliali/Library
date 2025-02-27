using Library.Application.UseCases.Commons.Bases;
using Library.Application.UseCases.Commons.Bases;
using Library.Domain.Entities.BookEntities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Library.Application.UseCases.Books.Commands.Add
{
    public class AddBookCommand : IRequest<BaseResponse<int>>
    {
        public void SetCreatedUserId(int createdUserId)
        {
            CreatedUserId = createdUserId;
        }
        public int CreatedUserId { get;internal set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required string BookCategory { get; set; }
        public required int PublishYear { get; set; }

    }
}
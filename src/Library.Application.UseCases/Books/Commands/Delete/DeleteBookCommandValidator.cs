using FluentValidation;

namespace Library.Application.UseCases.Books.Commands.Delete
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
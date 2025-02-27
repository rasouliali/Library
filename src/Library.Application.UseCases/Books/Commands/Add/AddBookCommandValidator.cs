using FluentValidation;

namespace Library.Application.UseCases.Books.Commands.Add
{
    public class AddBookCommandValidator : AbstractValidator<AddBookCommand>
    {
        public AddBookCommandValidator()
        {
            RuleFor(x => x.CreatedUserId).GreaterThan(0);
            RuleFor(x => x.Title).NotNull().MinimumLength(1).MaximumLength(4000);
            RuleFor(x => x.Author).NotNull().MinimumLength(3).MaximumLength(250);
            RuleFor(x => x.BookCategory).NotNull().MinimumLength(1).MaximumLength(50);

        }
    }
}
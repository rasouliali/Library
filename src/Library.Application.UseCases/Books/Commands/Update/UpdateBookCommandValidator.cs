using FluentValidation;

namespace Library.Application.UseCases.Books.Commands.Update
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Title).NotNull().MinimumLength(1).MaximumLength(4000);
            RuleFor(x => x.Author).NotNull().MinimumLength(3).MaximumLength(250);
            RuleFor(x => x.BookCategory).NotNull().MinimumLength(1).MaximumLength(50);
        }
    }
}
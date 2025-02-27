using FluentValidation;
using Library.Application.UseCases.Borrowings.Commands.Add;

namespace Library.Application.Commands.PostComment.AddEdit
{
    public class AddBorrowingCommandValidator : AbstractValidator<AddBorrowingCommand>
    {
        public AddBorrowingCommandValidator()
        {
            RuleFor(x => x.BookId).NotNull().GreaterThan(0);
            RuleFor(x => x.CreatedUserId).NotNull().GreaterThan(0);
            RuleFor(x => x.BorrowingFullName).NotNull().MinimumLength(3).MaximumLength(250);
            RuleFor(x => x.BorrowingMobile).NotNull().MinimumLength(10).MaximumLength(50);
            RuleFor(x => x.BorrowingNationalCode).NotNull().MinimumLength(10).MaximumLength(10);
        }
    }
}
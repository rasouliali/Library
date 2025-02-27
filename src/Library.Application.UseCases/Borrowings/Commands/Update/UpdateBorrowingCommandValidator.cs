using FluentValidation;
using Library.Application.UseCases.Borrowings.Commands.Add;

namespace Library.Application.UseCases.Borrowings.Commands.Update
{
    public class UpdateBorrowingCommandValidator : AbstractValidator<UpdateBorrowingCommand>
    {
        public UpdateBorrowingCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThanOrEqualTo(0);
            RuleFor(x => x.UpddaterUserId).GreaterThanOrEqualTo(0);
        }
    }
}
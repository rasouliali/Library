//using FluentValidation;

//namespace Library.Application.UseCases.ExtentBorrowings.Commands.Add
//{
//    public class AddExtentBorrowingCommandValidator : AbstractValidator<AddExtentBorrowingCommand>
//    {
//        public AddExtentBorrowingCommandValidator()
//        {
//            RuleFor(x => x.Id).GreaterThanOrEqualTo(0);
//            RuleFor(x => x.CreatedUserId).NotNull().GreaterThan(0);
//            RuleFor(x => x.PostId).NotNull().GreaterThan(0);
//            RuleFor(x => x.Comment).NotNull().MinimumLength(1).MaximumLength(4000);
//        }
//    }
//}
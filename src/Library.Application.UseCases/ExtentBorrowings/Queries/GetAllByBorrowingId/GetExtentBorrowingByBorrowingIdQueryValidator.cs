//using FluentValidation;
//using Library.Application.UseCases.Borrowings.Queries.GetAllByBookId;

//namespace Library.Application.UseCases.ExtentBorrowings.Queries.GetAllByBorrowingId
//{
//    public class GetExtentBorrowingByBorrowingIdQueryValidator : AbstractValidator<GetBorrowingByBookIdQuery>
//    {
//        public GetExtentBorrowingByBorrowingIdQueryValidator()
//        {
//            RuleFor(x => x.BookId).GreaterThan(0);
//            RuleFor(x => x.BookId).NotNull();
//        }
//    }
//}
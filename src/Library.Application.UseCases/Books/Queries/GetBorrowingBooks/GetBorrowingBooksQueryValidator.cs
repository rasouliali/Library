using FluentValidation;

namespace Library.Application.UseCases.Books.Queries.GetBorrowingBooks
{
    public class GetBorrowingBooksQueryValidator : AbstractValidator<GetBorrowingBooksQuery>
    {
        public GetBorrowingBooksQueryValidator()
        {
            //RuleFor(x => x.Id).GreaterThan(0);
            //RuleFor(x => x.Id).NotNull();
        }
    }
}
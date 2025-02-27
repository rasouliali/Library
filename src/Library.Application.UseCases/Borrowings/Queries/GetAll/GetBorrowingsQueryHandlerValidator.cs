using FluentValidation;

namespace Library.Application.UseCases.Borrowings.Queries.GetAll
{
    public class GetBorrowingsQueryHandlerValidator : AbstractValidator<GetBorrowingsQuery>
    {
        public GetBorrowingsQueryHandlerValidator()
        {
            //RuleFor(x => x.BookId).GreaterThan(0);
            //RuleFor(x => x.BookId).NotNull();
        }
    }
}
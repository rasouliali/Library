using FluentValidation;

namespace Library.Application.UseCases.Books.Queries.GetNotReturnedBooks
{
    public class GetNotReturnedBooksQueryValidator : AbstractValidator<GetNotReturnedBooksQuery>
    {
        public GetNotReturnedBooksQueryValidator()
        {
            //RuleFor(x => x.Id).GreaterThan(0);
            //RuleFor(x => x.Id).NotNull();
        }
    }
}
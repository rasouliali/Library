using FluentValidation;

namespace Library.Application.UseCases.Books.Queries.GetAll
{
    public class GetAllBooksQueryValidator : AbstractValidator<GetAllBooksQuery>
    {
        public GetAllBooksQueryValidator()
        {
            //RuleFor(x => x.Id).GreaterThan(0);
            //RuleFor(x => x.Id).NotNull();
        }
    }
}
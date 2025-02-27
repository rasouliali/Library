using FluentValidation;

namespace Library.Application.UseCases.Books.Queries.GetFiltersBooks
{
    public class GetFiltersBooksQueryValidator : AbstractValidator<GetFiltersBooksQuery>
    {
        public GetFiltersBooksQueryValidator()
        {
            //RuleFor(x => x.Id).GreaterThan(0);
            //RuleFor(x => x.Id).NotNull();
        }
    }
}
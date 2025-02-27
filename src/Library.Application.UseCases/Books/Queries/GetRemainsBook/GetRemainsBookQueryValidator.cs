using FluentValidation;

namespace Library.Application.UseCases.Books.Queries.GetRemainsBook
{
    public class GetRemainsBookQueryValidator : AbstractValidator<GetRemainsBookQuery>
    {
        public GetRemainsBookQueryValidator()
        {
            //RuleFor(x => x.Id).GreaterThan(0);
            //RuleFor(x => x.Id).NotNull();
        }
    }
}
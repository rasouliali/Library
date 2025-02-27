using FluentValidation;

namespace Library.Application.UseCases.Books.Queries.GetAll
{
    public class GetBookByIdQueryValidator : AbstractValidator<GetBookByIdQuery>
    {
        public GetBookByIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            //RuleFor(x => x.Id).NotNull();
        }
    }
}
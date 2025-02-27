using FluentValidation;

namespace Library.Application.UseCases.UserManager.Queries.TokenValidation
{
    public class TokenValidationQueryValidator : AbstractValidator<TokenValidationQuery>
    {
        public TokenValidationQueryValidator()
        {
            RuleFor(x => x.UserId).GreaterThan(0);
            RuleFor(x => x.Token).MinimumLength(1).MaximumLength(36);
            RuleFor(x => x.Token).Must((r, s) =>
            {
                Guid myguid;
                return Guid.TryParse(r.Token, out myguid);
            }).WithMessage("Token must be GUID(unique Identifier)");
        }
    }
}
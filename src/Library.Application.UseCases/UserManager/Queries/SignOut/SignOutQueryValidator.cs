using FluentValidation;

namespace Library.Application.UseCases.UserManager.Queries.SignOut
{
    public class SignOutQueryValidator : AbstractValidator<SignOutQuery>
    {
        public SignOutQueryValidator()
        {
            RuleFor(x => x.Token).MinimumLength(1).MaximumLength(36);
            RuleFor(x => x.Token).Must((r,s) => { 
                Guid myguid;
                return Guid.TryParse(r.Token, out myguid);
            }).WithMessage("Token must be GUID(unique Identifier)");
        }
    }
}
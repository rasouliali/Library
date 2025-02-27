using FluentValidation;

namespace Library.Application.UseCases.UserManager.Queries.SignIn
{
    public class SignInQueryValidator : AbstractValidator<SignInQuery>
    {
        public SignInQueryValidator()
        {
            RuleFor(x => x.UserName).MinimumLength(1).MaximumLength(250);
            RuleFor(x => x.Password).MinimumLength(1).MaximumLength(250);
        }
    }
}
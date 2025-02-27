using FluentValidation;

namespace Library.Application.UseCases.UserManager.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.UserName).NotNull().MinimumLength(1).MaximumLength(250);
            RuleFor(x => x.FullName).NotNull().MinimumLength(1).MaximumLength(250);
            RuleFor(x => x.Password).NotNull().MinimumLength(1).MaximumLength(250);
            RuleFor(x => x.Tel).MaximumLength(50);
        }
    }
}
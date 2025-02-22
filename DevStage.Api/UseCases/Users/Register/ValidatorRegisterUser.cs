using DevStage.Communication.Requests;
using FluentValidation;

namespace DevStage.Api.UseCases.Users.Register
{
    public class ValidatorRegisterUser : AbstractValidator<RequestUserJson>
    {
        public ValidatorRegisterUser()
        {
            RuleFor(request => request.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(request => request.Email).EmailAddress().WithMessage("E-mail is not valid.");
            RuleFor(request => request.Password).NotEmpty().WithMessage("Password is required.");

            When(request => !string.IsNullOrEmpty(request.Password), () =>
            {
                RuleFor(request => request.Password.Length).GreaterThanOrEqualTo(6).WithMessage("Password must have at least 6 characters.");
            });
        }
    }
}

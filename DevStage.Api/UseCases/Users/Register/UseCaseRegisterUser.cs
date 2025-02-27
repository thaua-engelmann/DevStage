using DevStage.Api.Domain.Entities;
using DevStage.Api.Infrastructure.DataAccess;
using DevStage.Api.Infrastructure.Security.Cryptography;
using DevStage.Api.Infrastructure.Security.Tokens.AccessToken;
using DevStage.Communication.Requests;
using DevStage.Communication.Responses;
using DevStage.Exception;
using FluentValidation.Results;

namespace DevStage.Api.UseCases.Users.Register
{
    public class UseCaseRegisterUser
    {

        public ResponseRegisteredUserJson Execute(RequestUserJson request)
        {
            var dbContext = new DevStageDbContext();

            Validate(request, dbContext);

            var criptography = new BCryptAlgorithms();

            var entity = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = criptography.HashPassword(request.Password),
            };

            dbContext.Users.Add(entity);
            dbContext.SaveChanges();

            var tokenGenerator = new JwtTokenGenerator();

            return new ResponseRegisteredUserJson
            {
                Name = entity.Name,
                AccessToken = tokenGenerator.Generate(entity)
            };
        }

        private void Validate(RequestUserJson request, DevStageDbContext dbContext)
        {
            var validator = new ValidatorRegisterUser();
            var result = validator.Validate(request);

            // Check if e-mail is already registered.
            var isEmailAlreadyRegistered = dbContext.Users.Any(user => user.Email.Equals(request.Email));

            if (isEmailAlreadyRegistered)
            {
                result.Errors.Add(new ValidationFailure("email-registered", "E-mail is already registered."));
            }

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(err => err.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
                
    }
}

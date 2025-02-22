using DevStage.Api.Domain.Entities;
using DevStage.Api.Infrastructure.DataAccess;
using DevStage.Api.Infrastructure.Security.Cryptography;
using DevStage.Communication.Requests;
using DevStage.Communication.Responses;
using DevStage.Exception;

namespace DevStage.Api.UseCases.Users.Register
{
    public class UseCaseRegisterUser
    {

        public ResponseRegisteredUserJson Execute(RequestUserJson request)
        {
            Validate(request);

            var criptography = new BCryptAlgorithms();

            var entity = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = criptography.HashPassword(request.Password),
            };

            var dbContext = new DevStageDbContext();

            dbContext.Users.Add(entity);
            dbContext.SaveChanges();

            return new ResponseRegisteredUserJson
            {
                Name = entity.Name
            };
        }

        private void Validate(RequestUserJson request)
        {
            var validator = new ValidatorRegisterUser();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(err => err.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
                
    }
}

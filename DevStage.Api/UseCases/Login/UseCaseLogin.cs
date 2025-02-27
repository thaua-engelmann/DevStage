using DevStage.Api.Infrastructure.DataAccess;
using DevStage.Api.Infrastructure.Security.Cryptography;
using DevStage.Api.Infrastructure.Security.Tokens.AccessToken;
using DevStage.Communication.Requests;
using DevStage.Communication.Responses;
using DevStage.Exception;

namespace DevStage.Api.UseCases.Login
{
    public class UseCaseLogin
    {

        public ResponseRegisteredUserJson Execute(RequestLoginJson request)
        {

            var dbContext = new DevStageDbContext();

            var user = dbContext.Users.FirstOrDefault(user => user.Email.Equals(request.email));

            if (user is null)
            {
                throw new InvalidLoginException();
            }

            var cryptography = new BCryptAlgorithms();
            var isPasswordValid = cryptography.VerifyPassword(request.password, user.Password);

            if (!isPasswordValid)
            {
                throw new InvalidLoginException();
            }

            return new ResponseRegisteredUserJson
            {
                Name = user.Name,
                AccessToken = new JwtTokenGenerator().Generate(user)
            };
        }

    }
}

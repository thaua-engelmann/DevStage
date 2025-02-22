using DevStage.Communication.Requests;
using DevStage.Communication.Responses;

namespace DevStage.Api.UseCases.Users.Register
{
    public class UseCaseRegisterUser
    {

        public ResponseRegisteredUserJson Execute(RequestUserJson request)
        {
            Console.WriteLine($"request: {request}");
            return new ResponseRegisteredUserJson
            {

            };
        }

    }
}

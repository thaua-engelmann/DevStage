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

            return new ResponseRegisteredUserJson
            {

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

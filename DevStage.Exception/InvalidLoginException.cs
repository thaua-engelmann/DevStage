
using System.Net;

namespace DevStage.Exception
{
    public class InvalidLoginException : DevStageException
    {

        public override List<string> GetErrorMessages() => ["Email or password invalid."];

        public override HttpStatusCode GetStatusCode() => HttpStatusCode.Unauthorized;
    }
}

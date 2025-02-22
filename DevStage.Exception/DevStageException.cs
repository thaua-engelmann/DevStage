using System.Net;

namespace DevStage.Exception
{
    public abstract class DevStageException : SystemException
    {
        public abstract List<string> GetErrorMessages();
        public abstract HttpStatusCode GetStatusCode();
    }
}

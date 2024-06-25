using System;

namespace FigureMvcWebApi.Model.CustomExceptions
{
    public class ResultAlreadySetAOResultException : AOResultException
    {
        public ResultAlreadySetAOResultException()
            : base("Result already setted")
        {
        }

        public ResultAlreadySetAOResultException(string message)
            : base(message)
        {
        }

        public ResultAlreadySetAOResultException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureMvcWebApi.Model.CustomExceptions
{
    public class LoggerNotInitAOResultException : AOResultException
    {
        public LoggerNotInitAOResultException()
            : base("IAOresultLogger not registered in Locator")
        {
        }

        public LoggerNotInitAOResultException(string message)
            : base(message)
        {
        }

        public LoggerNotInitAOResultException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}

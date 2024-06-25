using FigureMvcWebApi.Model;
using FigureMvcWebApi.Model.HeadLog;

namespace FigureMvcWebApi
{
    public class AOResultLogger : IAOResultLogger
    {
        private readonly IHeadLog _headlog;

        public AOResultLogger(IHeadLog headlog)
        {
            _headlog = headlog;
        }

        public void LogAOResult<T>(AOResult<T> aoResult)
        {
            _headlog.LogError(aoResult.Exception, aoResult.Message);
        }
    }
}
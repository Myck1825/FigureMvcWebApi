using FigureMvcWebApi.Model;
using FigureMvcWebApi.Model.HeadLog;

namespace FigureMvcWebApi
{
    /// <summary>
    /// Logger
    /// </summary>
    public class AOResultLogger : IAOResultLogger
    {
        private readonly IHeadLog _headlog;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="headlog"></param>
        public AOResultLogger(IHeadLog headlog)
        {
            _headlog = headlog;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="aoResult"></param>
        public void LogAOResult<T>(AOResult<T> aoResult)
        {
            _headlog.LogError(aoResult.Exception, aoResult.Message);
        }
    }
}
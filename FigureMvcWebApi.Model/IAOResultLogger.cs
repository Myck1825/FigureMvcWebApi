using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureMvcWebApi.Model
{
    public interface IAOResultLogger
    {
        void LogAOResult<T>(AOResult<T> aoResult);
    }
}

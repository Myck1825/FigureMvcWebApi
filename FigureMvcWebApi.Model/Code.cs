using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureMvcWebApi.Model
{
    public enum Code
    {
        //If method executed successfully
        Ok = 0,

        //if some error happens
        Error = 1,
        EntityAlreadyExists = 2,
        EntityNotFound = 3,
    }
}

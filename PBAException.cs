using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBAExceptionLib
{
    public class PBAException:Exception
    {
        public PBAException(string errMsg):base(errMsg)
        {

        }
    }
}

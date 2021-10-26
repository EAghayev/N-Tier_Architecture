using System;
using System.Collections.Generic;
using System.Text;

namespace QuarterApp.Service.CustomExceptions
{
    public class RecordAlreadyExistException:Exception
    {
        public RecordAlreadyExistException(string msg):base(msg)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace QuarterApp.Service.CustomExceptions
{
    public class FileFormatException:Exception
    {
        public FileFormatException(string msg):base(msg)
        {

        }
    }
}

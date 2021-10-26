using System;
using System.Collections.Generic;
using System.Text;

namespace QuarterApp.Service.CustomExceptions
{
    public class PageIndexFormatException:Exception
    {
        public PageIndexFormatException(string msg):base(msg)
        {

        }
    }
}

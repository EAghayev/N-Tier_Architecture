using System;
using System.Collections.Generic;
using System.Text;

namespace QuarterApp.Service.CustomExceptions
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(string msg):base(msg)
        {

        }
    }
}

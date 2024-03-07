using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6Activity3
{
    public class InputNullException : Exception //Custom exception class :)
    {
        public InputNullException(string message)   //works similar to method 
            :base(message)
        {
        }
    }
}

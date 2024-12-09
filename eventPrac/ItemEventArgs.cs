using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoletest
{
    public class ItemEventArgs : EventArgs
    {
        public string Message { get;}

        public ItemEventArgs(string message)
        {
            Message = message;
        }
    }
}

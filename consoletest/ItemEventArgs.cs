using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoletest
{
    public class ItemEventArgs : EventArgs
    {
        public Item Item { get; }

        public string Message { get;}

        public ItemEventArgs(Item item, string message)
        {
            Item = item;
            Message = message;
        }
    }
}

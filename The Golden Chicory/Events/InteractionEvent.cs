using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Golden_Chicory.Events
{
    public class InteractionEvent : EventArgs
    {
        public bool isOpened { get; set; }

        public InteractionEvent(bool isOpened)
        {
            this.isOpened = isOpened;
        }
    }
}

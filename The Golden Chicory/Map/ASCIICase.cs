using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map
{
    class ASCIICase
    {
        public string leftElement { get; set; }
        public string centralElement { get; set; }
        public string rightElement { get; set; }

        public ASCIICase(string leftElement, string centralElement, string rightElement)
        {
            this.leftElement = leftElement;
            this.centralElement = centralElement;
            this.rightElement = rightElement;
        }


        


    }
}


using Characters;
using Interactions;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Golden_Chicory;
using The_Golden_Chicory.Events;

namespace Structures
{
    //TODO Finir Door
    public class Door : Structure, Observer
    {
        public bool isLocked { get; set; }
        public bool isOpen { get; set; }
        public string symbolClosed { get; set; }
        public string symbolOpened { get; set; }

        public Door(bool isLocked, bool isOpen) : base()
        {
            name = "Door";
            description = "Hmm, this is a door";
            symbolOpened = "|";
            symbolClosed = "_";
            if (isOpen) symbol = symbolOpened;
            else symbol = symbolClosed;
            this.isLocked = isLocked;
            this.isOpen = isOpen;
            isInteractible = true;
            OpenClose openClose = new OpenClose(this);
            openClose.registerObserver(this);
            interactions.Add(openClose);
        }

        public void update(bool special)
        {
            if (!special)
            {
                if (symbol.Equals(symbolOpened))
                {
                    symbol = symbolClosed;
                    isOpen = false;
                }
                else
                {
                    symbol = symbolOpened;
                    isOpen = true;
                }
            }
            else
            {

            }
        }
    }
}

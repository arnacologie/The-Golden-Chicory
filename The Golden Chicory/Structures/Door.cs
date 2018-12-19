
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
        public bool isSpecial;
        public static readonly string campusDoorName = "Campus Doorway";

        public Door(bool isLocked, bool isOpen, bool special) : base()
        {
            name = "Door";
            description = "Hmm, this is a door";
            symbolOpened = "_";
            symbolClosed = "|";
            if (isOpen) symbol = symbolOpened;
            else symbol = symbolClosed;
            this.isLocked = isLocked;
            this.isOpen = isOpen;
            isInteractible = true;
            if (special)
            {
                interactions.Add(new FakeInspect(this));
                isSpecial = true;
            }
            else
            {
                OpenClose openClose = new OpenClose(this);
                openClose.registerObserver(this);
                interactions.Add(openClose);
                isSpecial = false;
            }
        }

        public void update(bool fromKey)
        {
            if (!fromKey && !isSpecial)
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
        }
    }
}

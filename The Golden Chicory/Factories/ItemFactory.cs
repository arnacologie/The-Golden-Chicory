using System;
using Items;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Golden_Chicory;

namespace Factories
{
    public class ItemFactory
    {
        public enum ItemType { StudentCard, GoldenKey }

        public ItemType itemType;

        public Item createItem(ItemType itemType)
        {
            switch (itemType)
            {
                case ItemType.StudentCard:
                    return new Key("Student Card");
                case ItemType.GoldenKey:
                    return new Key("Golden Key");
                default:
                    Console.WriteLine("Error in {0} {1}", Stage.getFunctionName(), GetType().Name);
                    return null;
            }
        }
    }
}

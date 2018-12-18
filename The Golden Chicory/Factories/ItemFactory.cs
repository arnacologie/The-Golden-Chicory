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
        public enum ItemType { SimpleKey, GoldenKey }

        public ItemType itemType;

        public Item createItem(ItemType itemType)
        {
            switch (itemType)
            {
                case ItemType.SimpleKey:
                    return new Key("Simple Key");
                case ItemType.GoldenKey:
                    return new Key("Golden Key");
                default:
                    Console.WriteLine("Error in {0} {1}", Stage.getFunctionName(), GetType().Name);
                    return null;
            }
        }
    }
}

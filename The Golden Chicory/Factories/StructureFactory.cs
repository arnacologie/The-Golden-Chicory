using The_Golden_Chicory;
using Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories
{
    public class StructureFactory
    {
        public enum StructureType {Door, Floor, Stairs, Wall}

        public StructureType structureType;
        

        public Structure createStructure(StructureType structureType)
        {
            switch (structureType)
            {
                case StructureType.Door:
                    return new Door(false, false);
                case StructureType.Floor:
                    return new Floor();
                case StructureType.Stairs:
                    return new Stairs();
                case StructureType.Wall:
                    return new Wall();
                default:
                    Console.WriteLine("Error in createStructure StructureFactory");
                    return null;
            }
        }
    }
}

using The_Golden_Chicory;
using Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories
{
    class ASCIICaseFactory
    {
        string leftElement = "╔═══╗";
        string centralElement;
        string rightElement = "╚═══╝";

        public List<ASCIICase> createASCIICaseList()
        {
            List<ASCIICase> aSCIICaseList = new List<ASCIICase>();

            for (int y = 0; y < Stage.MATRIX_SIZE; y++)
            {
                for (int x = 0; x < Stage.MATRIX_SIZE; x++)
                {
                    Case c = Stage.getInstance().MATRIX[x,y];
                    ASCIICase aSCIICase = createASCIICase(c.getEntitySymbol());
                    //ASCIICase aSCIICase = createASCIICase(c.x + "," + c.y);
                    //Console.WriteLine(c.x + "," + c.y + " ");
                    aSCIICaseList.Add(aSCIICase);
                }
            }
            return aSCIICaseList;
        }

        private ASCIICase createASCIICase(string symbol)
        {
            centralElement = "║ "+symbol+" ║";
            //centralElement = "║"+symbol+"║";
            return new ASCIICase(leftElement, centralElement, rightElement);
        }


    }
}

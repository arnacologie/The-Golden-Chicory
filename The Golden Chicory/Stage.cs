using Characters;
using Factories;
using Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Golden_Chicory
{
    class Stage
    {
        private static Stage instance;
        public static readonly int MATRIX_SIZE = 10;
        public Case[,] MATRIX { get; set; }
        private CaseFactory caseFactory;
        public StructureFactory structureFactory { get; set; }
        public static Player player { get; set; }

        private Stage()
        {
            MATRIX = new Case[MATRIX_SIZE, MATRIX_SIZE];
            caseFactory = new CaseFactory();
            structureFactory = new StructureFactory();
            player = new Player(0, 0);
        }

        public static Stage getInstance()
        {
            if (instance == null)
            {
                instance = new Stage();
            }
            return instance;
        }

        public void initMATRIX()
        {
            for (int y = 0; y < MATRIX_SIZE; y++)
            {
                for (int x = 0; x < MATRIX_SIZE; x++)
                {
                    MATRIX[x, y] = caseFactory.createCase(x, y);
                }
            }
        }

        public void initConsole()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WindowHeight = 40;
        }

        public void showMATRIX()
        {
            Console.Clear();
            ASCIICasePrinter.printASCIIMap();
        }
    }
}

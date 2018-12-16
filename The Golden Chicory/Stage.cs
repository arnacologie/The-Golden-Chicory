using Characters;
using Factories;
using Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public static List<string> debugList;
        public static List<string> interactionAvailable;
 
        public static string getFunctionName([CallerMemberName] string caller = null)
        {
            return caller;
        }

        private Stage()
        {
            MATRIX = new Case[MATRIX_SIZE, MATRIX_SIZE];
            caseFactory = new CaseFactory();
            structureFactory = new StructureFactory();
            player = new Player(0, 0);
            debugList = new List<string>();
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

        public static void printDebug()
        {
            Console.WriteLine("Debug:");
            Console.WriteLine(debugList.Count);
            foreach (string debug in debugList)
            {
                Console.WriteLine(debug);
            }
            debugList.Clear();
        }

        public static void printInteractionAvailable()
        {
            Console.WriteLine("Debug:");
            foreach (string interactionDetail in interactionAvailable)
            {
                Console.WriteLine(interactionDetail);
            }
            interactionAvailable.Clear();
        }
    }
}

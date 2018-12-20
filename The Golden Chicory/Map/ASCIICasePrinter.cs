using Factories;
using The_Golden_Chicory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map
{
    class ASCIICasePrinter
    {
        private static ASCIICaseFactory aSCIICaseFactory;

        public static void printASCIIMap()
        {
            if (aSCIICaseFactory == null)
            {
                aSCIICaseFactory = new ASCIICaseFactory();
            }
            List<ASCIICase> aSCIICaseList = aSCIICaseFactory.createASCIICaseList();
            List<ASCIICase> aSCIICaseRow = new List<ASCIICase>();
            int positionInRow = 0;
            int positionRow = 0;

            foreach (ASCIICase aSCIICase in aSCIICaseList)
            {
                //si derniere case (non modulo MATRIX_SIZE), afficher la derniere ligne
                if (positionInRow == Stage.getInstance().MATRIX.Length - 1)
                {
                    aSCIICaseRow.Add(aSCIICase);
                    printASCIIRow(aSCIICaseRow);
                }
                else if (positionInRow > 0 && positionInRow % Stage.MATRIX_SIZE != 0)
                {
                    //ajoute chaque case non modulo MATRIX_SIZE dans row
                    aSCIICaseRow.Add(aSCIICase);
                }
                else
                {
                    //traiter la row
                    //vider la row
                    //ajouter current asciicase dans la row
                    if(positionInRow != 0) printASCIIRow(aSCIICaseRow);
                    positionRow++;
                    aSCIICaseRow.Clear();
                    aSCIICaseRow.Add(aSCIICase);
                }
                positionInRow++;
            }
        }

        private static void printASCIIRow(List<ASCIICase> aSCIICaseRow)
        {
            for (int i = 0; i < 3; i++)
            {
                printASCIIRowPart(aSCIICaseRow, i);
            }
        }

        private static void printASCIIRowPart(List<ASCIICase> aSCIICaseRow, int part)
        {
            foreach (ASCIICase aSCIICase in aSCIICaseRow)
            {
                switch (part)
                {
                    case 0:
                        Console.Write(aSCIICase.leftElement + " ");
                        break;
                    case 1:
                        int count = 0;
                        foreach (char c in aSCIICase.centralElement)
                        {
                            if(count == 2)
                            {
                                if( c =='±' || c == '↑' || c == '←' || c == '→' || c == '↓' || c == '≡' )
                                    Console.ForegroundColor = ConsoleColor.Green;
                                else if (c == '■')
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                else if (c == 'ß' || c== '▀' )
                                    Console.ForegroundColor = ConsoleColor.Red;
                                else if (c == '_' || c == '|')
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                else if (c == 'ß')
                                    Console.ForegroundColor = ConsoleColor.Red;
                                else if (c == '¯')
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                else if (c == '¤')
                                    Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(c);
                                Console.ForegroundColor = ConsoleColor.Blue;
                            }
                            else Console.Write(c);
                            count++;
                        }
                        Console.Write(" ");
                        break;
                    case 2:
                        Console.Write(aSCIICase.rightElement + " ");
                        break;
                    default:
                        Console.WriteLine("Error in printASCIIRowPart");
                        break;
                }
            }
            Console.WriteLine();
        }
    }
}

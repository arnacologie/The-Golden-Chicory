
using Events;
using The_Golden_Chicory;
using Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Factories.StructureFactory;

namespace Characters
{
    public class Player : Character
    {
        public static string namePlayer = "Endive";
        public event EventHandler<MovedEvent> OnPlayerMove;
        public string symbolUp { get; set; }
        public string symbolLeft { get; set; }
        public string symbolRight { get; set; }
        public string symbolDown { get; set; }
        public Dictionary<string, int[]> closeCases;

        public Player(int x, int y)
        {
            this.x = x;
            this.y = y;
            name = namePlayer;
            description = "It's the player";
            symbol = "±";
            symbolUp = "↑";
            symbolLeft = "←";
            symbolRight = "→";
            symbolDown = "↓";
            health = 10;
            isInteractible = true;
            behavior = Behavior.Neutral;
        }

        public bool moveOrTurn()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Z:
                    return move(x, y - 1, symbolUp);
                case ConsoleKey.S:
                    return move(x, y + 1, symbolDown);
                case ConsoleKey.Q:
                    return move(x - 1, y, symbolLeft);
                case ConsoleKey.D:
                    return move(x + 1, y, symbolRight);
                case ConsoleKey.UpArrow:
                    return turn(symbolUp);
                case ConsoleKey.DownArrow:
                    return turn(symbolDown);
                case ConsoleKey.LeftArrow:
                    return turn(symbolLeft);
                case ConsoleKey.RightArrow:
                    return turn(symbolRight);
                default:
                    Stage.getInstance().showMATRIX();
                    Console.WriteLine("Error WRONG KEY {0} {1} (Z,Q,S,D,↑,←,↓,→)", Stage.getFunctionName(), this.GetType().Name);
                    return false;
            }
        }

        private bool move(int x, int y, string symbolDirection)
        {
            if (checkMovement(x, y))
            {
                //OnPlayerMove(this, new MovedEvent(x, y));
                Case currentCase = Stage.getInstance().MATRIX[this.x, this.y];
                Case nextCase = Stage.getInstance().MATRIX[x, y];
                nextCase.onThis = this;
                currentCase.onThis = Stage.getInstance().structureFactory.createStructure(StructureType.Floor);
                this.x = x;
                this.y = y;
                symbol = symbolDirection;
                Stage.getInstance().showMATRIX();
                Console.WriteLine("{0} {1} called, SUCCESS", Stage.getFunctionName(), this.GetType().Name);
                initCloseCases();
                return true;
            }
            else
            {
                symbol = symbolDirection;
                Stage.getInstance().showMATRIX();
                Console.WriteLine("{0} {1} called, FAIL (Collision avec {2})", Stage.getFunctionName(), this.GetType().Name, Stage.getInstance().MATRIX[x, y].onThis.name);
                getCloseCases();
                return false;
            }
        }

        private bool checkMovement(int x, int y)
        {
            if (Validator.isCaseEmpty(x, y))
            {
                return true;
            }
            return false;
        }

        private bool turn(string symbolDirection)
        {
            symbol = symbolDirection;
            Stage.getInstance().showMATRIX();
            Console.WriteLine("{0} {1} called, SUCCESS", Stage.getFunctionName(), this.GetType().Name);
            return true;
        }

        public bool scanForInteraction()
        {
            int xCloseCase;
            int yCloseCase;
            int[] closeCaseCoordinates = new int[2];
            initCloseCases();
            return true;
        }

        public void initCloseCases()
        {
            closeCases = new Dictionary<string, int[]>();
            int xCloseCase;
            int yCloseCase;

            xCloseCase = x - 1;
            yCloseCase = y;
            addValidCloseCase(symbolLeft, xCloseCase, yCloseCase, new int[2]);
            xCloseCase = x + 1;
            addValidCloseCase(symbolRight, xCloseCase, yCloseCase, new int[2]);
            xCloseCase = x;
            yCloseCase = y - 1;
            addValidCloseCase(symbolUp, xCloseCase, yCloseCase, new int[2]);
            yCloseCase = y + 1;
            addValidCloseCase(symbolDown, xCloseCase, yCloseCase, new int[2]);
            foreach (KeyValuePair<string, int[]> item in closeCases)
            {
                Stage.debugList.Add(string.Format("Direction {0} = {1},{2}", item.Key, item.Value[0], item.Value[1]));
            }
        }

        private bool addValidCloseCase(string symbolDirection, int xCloseCase, int yCloseCase, int[] closeCaseCoordinates)
        {
            if (Validator.isCaseValid(xCloseCase, yCloseCase))
            {
                closeCaseCoordinates[0] = xCloseCase;
                closeCaseCoordinates[1] = yCloseCase;
                closeCases.Add(symbolDirection, closeCaseCoordinates);
                return true;
            }
            return false;
        }

        private void getCloseCases()
        {
            foreach (KeyValuePair<string, int[]> item in closeCases)
            {
                Stage.debugList.Add(string.Format("Direction {0} = {1},{2}", item.Key, item.Value[0], item.Value[1]));
            }
        }

        public void printDebug()
        {
            Console.WriteLine("Debug:");
            foreach (string debug in Stage.debugList)
            {
                Console.WriteLine(debug);
            }
            Stage.debugList.Clear();
        }

        
    }
}


using Events;
using The_Golden_Chicory;
using Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Factories.StructureFactory;
using Interactions;

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
        public Tuple<string, int[]> facingCase;

        public Player(int x, int y) : base()
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

        public bool action()
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
                case ConsoleKey.D1:
                    return true;
                case ConsoleKey.D2:
                    return true;
                case ConsoleKey.D3:
                    return true;
                case ConsoleKey.D4:
                    return true;
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
                scanForInteraction();
                return true;
            }
            else
            {
                symbol = symbolDirection;
                Stage.getInstance().showMATRIX();
                Console.WriteLine("{0} {1} called, FAIL (Collision avec {2})", Stage.getFunctionName(), this.GetType().Name, Stage.getInstance().MATRIX[x, y].onThis.name);
                initFacingCase();
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
            initFacingCase();
            return true;
        }

        //private bool interact(int touchNumber)
        //{
        //    if(closeCases.Count > 0)
        //    {
        //        switch (closeCases.Count)
        //        {
        //            case 1:
        //                if(touchNumber, 1)
        //                break;
        //            case 2:
        //                break;
        //            case 3:
        //                break;
        //            case 4:
        //                break;
        //        }
        //    }
        //    return true;
        //}
        //TODO finir uncomment
        //private bool getPossibleInteractions(int touchNumber,  int closeCasesCount)
        //{
        //    if(touchNumber > 0 && touchNumber <= closeCasesCount)
        //    {
        //        closeCases[]
        //    }
        //}

        public bool scanForInteraction()
        {
            initCloseCases();
            initFacingCase();

            //foreach (KeyValuePair<string, int[]> item in closeCases)
            //{
            //    List<Interaction> interactions = Stage.getInstance().MATRIX[item.Value[0], item.Value[0]].onThis.interactions;
            //    string output = string.Format("Direction {0} = {1}({2},{3})", item.Key, Stage.getInstance().MATRIX[item.Value[0], item.Value[1]].onThis.name, item.Value[0], item.Value[1]);

            //}
            
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
                Stage.closeInteractionsOutput.Add(string.Format("Direction {0} = {1}({2},{3})", item.Key, Stage.getInstance().MATRIX[item.Value[0],
                    item.Value[1]].onThis.name, item.Value[0], item.Value[1]));
            }
        }

        private void initFacingCase()
        {
            facingCase = null;
            foreach (KeyValuePair<string, int[]> item in closeCases)
            {
                if (item.Key.Equals(symbol)) facingCase = new Tuple<string, int[]>(item.Key, item.Value);
            }
            if (facingCase != null)
            {
                Stage.facingInteractionOutput.Add(string.Format("Direction {0} = {1}({2},{3})", facingCase.Item1,
                    Stage.getInstance().MATRIX[facingCase.Item2[0], facingCase.Item2[1]].onThis.name, facingCase.Item2[0], facingCase.Item2[1]));
            }
        }
    }
}


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
            behavior = Behavior.Neutral;
            Console.WriteLine();
        }

        public bool move()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.UpArrow:
                    return move(x, y - 1, "↑");
                case ConsoleKey.DownArrow:
                    return move(x, y + 1, "↓");
                case ConsoleKey.LeftArrow:
                    return move(x - 1, y, "←");
                case ConsoleKey.RightArrow:
                    return move(x + 1, y, "→");
                default:
                    Stage.getInstance().showMATRIX();
                    Console.WriteLine("Erreur WRONG KEY move() Player");
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
                Console.WriteLine("move Player called, SUCCESS");
                return true;
            }
            else
            {
                symbol = symbolDirection;
                Stage.getInstance().showMATRIX();
                Console.WriteLine("move Player called, FAIL (Collision avec {0})", Stage.getInstance().MATRIX[x, y].onThis.name);
                return false;
            }
        }

        private bool checkMovement(int x, int y)
        {
            if(Validator.isCaseEmpty(x, y))
            {
                return true;
            }
            return false;
        }
    }
}

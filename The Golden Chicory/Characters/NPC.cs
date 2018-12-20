using Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Characters.Character;

namespace Characters
{
    public class NPC : Character
    {
        public string dialog1;
        public string dialog2;
        public static string Abdel = "to Abdel";

        public NPC(string name, string dialog1, string dialog2)
        {
            this.name = name;
            description = "C'est "+name+" !";
            this.dialog1 = dialog1;
            this.dialog2 = dialog2;
            symbol = "¤";
            isInteractible = true;
            behavior = Behavior.Pacific;
            interactions.Add(new Talk(this));
        }
    }
}

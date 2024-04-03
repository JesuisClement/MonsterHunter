using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunter.Classes
{
    public class Nain : Personnages 
    {
        De des = new De();
        public Nain(string Nom) : base(Nom)
        {
            _endurance = des.Best3In4De6() + 2;
            _race = "Nain";
        }
        public override bool EnVie()
        {
            if (_pvRestant > 0)
                return true;
            Console.WriteLine("Vous êtes morts, c'est une fin de partie");
            return false;
        }
        public override bool EnVie(out int n, out int n1)
        {
            n = n1 = 0;

            return false;
        }
    }
}

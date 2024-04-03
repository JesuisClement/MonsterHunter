using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunter.Classes
{
    public class Dragonnnets : Personnages
    {
        De des = new De();
        public Dragonnnets(string Nom) : base(Nom)
        {
            _endurance = des.Best3In4De6() + 1;
            _qteCopper = des.De4();
            _qteGold = des.De6();
            lettreAffichage = 'D';

        }

        public override bool EnVie(out int Copper, out int Gold)
        {
            Copper = _qteCopper;
            Gold = _qteGold;
            if (_pvRestant > 0)
                return true; //  [0, 0]; //butin;
            Console.WriteLine($"Vous avez vaincu ce loup! Vous gagnez {_qteCopper} cuivre(s) et {_qteGold} gold(s)");
            return false; // butin;
        }
        public override bool EnVie()
        {
            if (_pvRestant > 0)
                return true;

            return false;


        }
    }
}

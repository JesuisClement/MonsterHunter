using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunter.Classes
{
    public class Orques : Personnages
    {
        De des = new De();
        public Orques(string Nom) : base(Nom)
        {
            _force = des.Best3In4De6() + 1;
            _qteGold = des.De6();
            lettreAffichage = 'O';

        }
        public override bool EnVie(out int Copper, out int Gold)
        {
            Copper = _qteCopper;
            Gold = _qteGold;
            if (_pvRestant > 0)
                return true; 
            Console.WriteLine($"Vous avez vaincu ce loup! Vous gagnez {_qteCopper} cuivre(s) et {_qteGold} gold(s)");
            return false; 
        }
        public override bool EnVie()
        {
            if (_pvRestant > 0)
                return true;

            return false;


        }
    }
}

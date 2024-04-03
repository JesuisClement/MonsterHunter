using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunter.Classes
{
    public class Loups : Personnages
    {
        De des = new De();
        public Loups(string Nom) : base(Nom)
        {
            _qteCopper = des.De4();
            lettreAffichage = 'L';
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

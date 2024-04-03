using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MonsterHunter.Classes
{
    public class Humain : Personnages 
    {
        protected int _copper;
        protected int _gold;
        De des = new De();
        public Humain(string Nom) : base(Nom)
        {
            _endurance = des.Best3In4De6()+1;
            _force = des.Best3In4De6()+1;
            _race = "Humain";
        }

        public override bool EnVie()
        {
            Console.WriteLine("ok");
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MonsterHunter.Classes
{
    public abstract class Personnages
    {
        protected string _name;
        protected string _race;
        internal char lettreAffichage;
        protected int _endurance;
        protected int _force;
        protected int _pv;
        protected int _pvRestant;
        protected int _modificateurEndurance;
        protected int _modificateurForce;
        protected int _armure;
        public int _qteCopper;
        public int _qteGold;
        public List<string[]> equipement = new List<string[]> ();
        internal int x {  get;  set; }
        internal int y {  get;  set; }


        De des = new De();
        
        public int Endurance// Tu appeleras chien.Name et tu modifieras _name
        { get { return _endurance; }  }
       
        public Personnages(string Nom)
        {
            _name = Nom;
            
            _endurance = des.Best3In4De6();
            _force = des.Best3In4De6();
            _modificateurEndurance = FindModificateur(_endurance);
            _pv = _endurance + _modificateurEndurance;
            _modificateurForce = FindModificateur(_force);
            _pvRestant = _pv;
            _qteCopper = 0;
            _qteGold = 0;
            x = 0;
            y = 0;
            lettreAffichage = 'H';
            _armure = 0;

    }

    public int Frappe()
        {
            return des.De4() + _modificateurForce;
        }



        public void AfficherPersonnage()
        {

            Console.WriteLine();
            Console.WriteLine(_name + " race : " + _race);
            Console.WriteLine("Point de vie : " + _pvRestant + "/" + _pv);
            Console.WriteLine("Endurance : " + _endurance + " Modificateur d'enduracne : " + _modificateurEndurance);
            Console.WriteLine("Force : " + _force + " Modificateur de force : " + _modificateurForce);

        }
        public void SubirDegat(int degat)
        {
            Console.WriteLine($"Dégats subit: {degat-_armure}");
            _pvRestant -= degat-_armure;
            AfficherPersonnage();
        }


        internal int FindModificateur( int caracteristique)
        {
            switch (caracteristique)
            {
                case int n when n < 5:
                    return -1;

                case int n when n < 10:
                    return 0;
                case int n when n < 15:
                    return 1;
                default:
                    return 2;
            }
        }

        public void Combat(Personnages monstre)
        {
            Console.WriteLine($"Début du Combat" +
                $"");
            ShowInventaire();
            Thread.Sleep(1500);
            do              //{   a modifier pour que ça marche
            {
                Console.WriteLine("Veuillez appuiyer sur une touche pour attaquer le monstre");
                Console.ReadLine();
                 Console.Clear();
                monstre.SubirDegat(Frappe());
                if (monstre.EnVie(out int copperWin, out int goldWin)) SubirDegat(monstre.Frappe());
                else
                {
                    Console.Clear() ;
                    _qteCopper += copperWin;
                    _qteGold += goldWin;
                    _pvRestant = _pv;
                    Console.WriteLine($"Vous avez donc {_qteCopper} cuivre(s) et {_qteGold} or(s)");
                    Console.WriteLine("Vous avez pris le temps de vous soigner, vos PV sont restaurés");
                }
            } while (EnVie() && monstre.EnVie());
        }

        public void ResetRessource(string goldDepense, string cuirDepense, bool reset)
        {
            if (reset)
            {
                _qteGold = 0;
                _qteCopper = 0;
            }
            else
            { 
            if (_qteGold >= int.Parse(goldDepense))
                _qteGold -= int.Parse(goldDepense);
            if (_qteCopper >= int.Parse(cuirDepense))
                _qteCopper -= int.Parse(cuirDepense);
            }

        }
        public void ModifDps(string att, string def , int Moins1Soustrac1Add) // signe : -
        {
            int.TryParse(att, out int a);
            _modificateurForce += a* Moins1Soustrac1Add;
            int.TryParse(def, out  a);
            _armure += a* Moins1Soustrac1Add;

        }
        public void AddItem(string[] item)
        {
            equipement.Add(item);
        }
        public void RemoveItem(string[] item)
        {
            if (!equipement.Contains(item))
                Console.WriteLine("Vous n'aviez pas cette item dans votre inventaire");
            else
            {
                Console.WriteLine($"L'équipement {item} a été revendu, gain : une piece d'or");
                equipement.Remove(item);
                ModifDps(item[0], item[3], -1);
            }
        }
        public void ShowInventaire()
        {
            if (equipement.Count > 0)
                for (int i = 0; i < equipement.Count; i++)
                    Console.WriteLine(equipement[i]);
        }

        public abstract bool EnVie();
        public abstract bool EnVie(out int n1, out int n2);




    }
}

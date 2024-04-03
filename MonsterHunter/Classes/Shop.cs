using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MonsterHunter.Classes
{
    public class Shop
    {               //  Name [attaque, PRIX, cuire, def]
        private string[] _dague = { "1", "3", "1", "0" };
        private string[] _zSword = { "4", "25", "0", "0" };
        private string[] _arc = { "2", "9", "1", "0" };
        private string[] _vesteCuir = { "0", "9", "10", "2" };
        private string[] _chapeauCuir = { "0", "3","6", "1" };
        private string[] _shield = { "1", "4", "4", "1" };
        internal int x { get; set; }
        internal int y { get; set; }
        public char _lettreAffichage;



        public Shop()
        {
            
           x = new Random().Next(4, 15); 
           y = new Random().Next(4, 15);
            _lettreAffichage = 'S';
           
        }


            public void Vendre(Personnages Hero)
        {
            Console.Clear();
            Console.WriteLine($"Bienvenue dans le Shop");
            Console.WriteLine($"Votre nombre de pièce d'or est {Hero._qteGold} et {Hero._qteCopper} cuir(s)");
            Console.WriteLine("Vous aves le choix entre différents item:" +
                "Entrer le numéro de l'article que vous souhaitez acheter\n" +
                $"1) une dague pour {_dague[1]} or(s)\n" +
                $"2) la ZSword pour {_zSword[1]} or(s) \n" +
                $"3) un arc pour {_arc[1]} or(s)\n" +
                $"4) une veste en cuir pour {_vesteCuir[1]} or(s)\n" +
                $"5 un chapeau en cuir pour {_chapeauCuir[1]} or(s)\n" +
                $"6) un bouclier pour {_shield[1]} or(s)\n" +
                "s) pour supprimer un item\n" +
                $"q) quitter pour or(s)\n"); 
            switch(Console.ReadLine())
            {
                case "1":
                    Hero.ResetRessource(_dague[1], _dague[2], false);
                    Hero.t();
                    Hero.ModifDps(_dague[0], _dague[3],1 );
                    Hero.t();
                    Hero.AddItem( _dague);
                    break;
                case "2":
                    Hero.ResetRessource(_zSword[1], _zSword[2], false);
                    Hero.ModifDps(_zSword[0], _zSword[3],1 );
                    Hero.AddItem(_zSword);
                    break;
                case "3":
                    Hero.ResetRessource(_arc[1], _arc[2], false);
                    Hero.ModifDps(_arc[0], _arc[3], 1);
                    Hero.AddItem(_arc);
                    break;
                case "4":
                    Hero.ResetRessource(_vesteCuir[1], _vesteCuir[2], false);
                    Hero.ModifDps(_vesteCuir[0], _vesteCuir[3], 1);
                    Hero.AddItem(_vesteCuir);
                    break;
                case "5":
                    Hero.ResetRessource(_chapeauCuir[1], _chapeauCuir[2], false);
                    Hero.ModifDps(_chapeauCuir[0], _chapeauCuir[3], 1);
                    Hero.AddItem(_chapeauCuir);
                    break;
                case "6":
                    Hero.ResetRessource(_shield[1], _shield[2], false);
                    Hero.ModifDps(_shield[0], _shield[3], 1);
                    Hero.AddItem(_shield);
                    break;
                case "s":
                    Console.WriteLine("Veuillez entrer le numéro de l'item que vous souhaitez supprimer");
                    Hero.RemoveItem(WitchOne());
                    Hero.ResetRessource("-1", "0", false);

                    break;
                case "q":
                    Console.WriteLine("Merci de votre visite");
                    break;
                default:
                    Console.WriteLine("Entrée invalide; Vous vous êtes fait voler tout votre or et votre cuir");
                    Hero.ResetRessource("0", "0", true);
                    break;

            }           
        }
        internal string[] WitchOne()
        {
            switch (Console.ReadLine())
            {
                case "1":
                    return _dague;
                case "2":
                    return _zSword;
                case "3":
                    return _arc;
                case "4":
                    return _vesteCuir;
                case "5":
                    return _chapeauCuir;
                case "6":
                    return _shield;
                default:
                    return null;
            }
        }
    }
}

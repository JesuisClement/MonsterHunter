using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunter.Classes
{
    public class PlateauDeJeu
    {
        private char[,] _tableau;

        public PlateauDeJeu(int Nx, int Ny) 
        {
            _tableau = new char[Nx, Ny];
        }
        public void GridInit()
        {
            for (int i = 0; i < _tableau.GetLength(0); i++)
                for (int j = 0; j < _tableau.GetLength(1); j++)
                {
                    _tableau[i, j] = '.';
                }
        }

        public void GridPrint(Personnages Hero, List<Personnages> monstre, Shop S)
        {
            Console.Clear();
            bool test = true;
            for (int i = 0; i < _tableau.GetLength(0); i++)
            {            
                for (int j = 0; j < _tableau.GetLength(1); j++)
                {
                    if (Hero.x == i && Hero.y == j)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(Hero.lettreAffichage);
                        test = false;
                        Console.ResetColor(); 

                    }
                    else if (S.x == i && S.y == j)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(S._lettreAffichage);
                        test = false;
                        Console.ResetColor();

                    }


                    else 
                            {
                        //Modifier pour afficher le personnage uniquement si le perso H est cote à cote.
                        
                            for (int k = 0; k < monstre.Count; k++)
                        if (Math.Abs(monstre[k].y - Hero.y) <= 1 && Math.Abs(monstre[k].x - Hero.x) <= 1 && monstre[k].x ==i && monstre[k].y == j)
                            if ((Math.Abs(monstre[k].y - Hero.y) == 0 || Math.Abs(monstre[k].x - Hero.x) == 0 ) && monstre[k].EnVie() ) 
                                {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(monstre[k].lettreAffichage);
                                Console.ResetColor();
                                    test = false;
                                }
                        //
                        
                    }
                    if (test)
                     Console.Write($"{_tableau[j, i]}");
                    else test = true;
                    
                }
                Console.WriteLine();
            }            
        }

        
        internal Personnages MonsterCreator()
        {
            Random rnd = new Random();
            switch(rnd.Next(1, 4))
            {
                case 1:
                    Personnages personnages = new Dragonnnets("Dragonnet");                         
                    return personnages;
                case 2:
                    Personnages personnages2 = new Loups("Loup");
                    return personnages2;
                default:
                    Personnages personnages3 = new Orques("Orque");
                    return personnages3; 
            }
        }

        internal List<Personnages> MonsterSetUp(int nbMonstre, Shop S)
        {
            
            Random rnd = new Random();
            List<Personnages> monstre = new List<Personnages>();

            for (int i = 0;i < nbMonstre; i++)
            {
                int j = 0;
                monstre.Add(MonsterCreator());
                monstre[i].x = rnd.Next(0, 15);
                monstre[i].y = rnd.Next(0, 15);


                while (j < i)
                {
                    if (monstre[i].x<=1 && monstre[i].y <= 1)   // Le hero doit pouvoir bouger avant 1 combat
                    {
                        monstre[i].x = rnd.Next(0, 15);
                        monstre[i].y = rnd.Next(0, 15);
                        j = 0;
                    }

                    else if (Math.Abs(S.x - monstre[i].x) <=1 && Math.Abs(S.y - monstre[i].y )<=1 )    // Monstre pas sur shop
                    {
                        monstre[i].x = rnd.Next(0, 15);
                        monstre[i].y = rnd.Next(0, 15);
                        j = 0;
                    }

                    if (Math.Abs(monstre[j].x - monstre[i].x) + Math.Abs(monstre[j].y - monstre[i].y) <= 2 ||(Math.Abs(monstre[j].x - monstre[i].x) == 1 && Math.Abs(monstre[j].y - monstre[i].y) == 1 ) )
                    {
                        monstre[i].x = rnd.Next(0, 15);                    
                        monstre[i].y = rnd.Next(0, 15);
                        j = 0;
                    }
                    else 
                    j++;
                }
            }          

            return monstre;
        }



        public bool SeDeplacer(Personnages Hero, List<Personnages> monstre, Shop S)
        {
            Console.WriteLine("Déplacement : pavé numérique; Quitter: q");
            ConsoleKeyInfo e = Console.ReadKey();

            switch (e.Key)  // ATTRNTION    (Y , X) tableau
            {
                case ConsoleKey.UpArrow:
                    if (Hero.x > 0)
                    {
                        _tableau[Hero.y, Hero.x--] = '-';
                    }
                    break;
                case ConsoleKey.DownArrow:

                    if (Hero.x < _tableau.GetLength(0) - 1) // Ou tableau.GetLetch()-1
                    {
                        _tableau[Hero.y, Hero.x++] = '-';

                    }
                    break;

                case ConsoleKey.LeftArrow:
                    if (Hero.y > 0)
                    {
                        _tableau[Hero.y--, Hero.x] = '-';
                    }
                    break;

                case ConsoleKey.RightArrow:
                    if (Hero.y < _tableau.GetLength(1) - 1)
                    {
                        _tableau[Hero.y++, Hero.x] = '-';

                    }
                    break;

                case ConsoleKey.Q:
                    return false;
                default:
                    Console.WriteLine("Touche non définie");
                    return true;
            }
            GridPrint(Hero, monstre, S);
            return true;

        }




    }
}

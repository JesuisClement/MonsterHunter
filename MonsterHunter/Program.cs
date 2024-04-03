using MonsterHunter.Classes;
using System.Collections.Generic;

/*
 * Hero versus monster codé dans le cadre du cours de c# chez technifutur
 */

Console.WriteLine(" Bienvenue dans la forêt de « Shorewood », forêt enchantée du pays de « Stormwall ».");
Console.WriteLine(" Dans cette forêt, se livre un combat acharné entre les héros d’une part et les monstres d’autre part.");
Console.WriteLine("Régle du jeu : \n" +
    "Vous vous déplassez avec les flêches\n" +
    "Vous vous battez avec enter \n" +
    "Pour activer le shop, vous allez sur la lettre S");
Console.WriteLine("Veuillez choisir votre race de héro en entrant le numéro correspondant à la race de votre choix\n" +
    "Tapez:     1) Humain\n" +
    "           2) Nain");
 string ChoixHero = Console.ReadLine();
Personnages Hero = null;

Shop shop = new Shop();

switch (ChoixHero)
{
    case "1":
        Console.WriteLine("Veuillez entrer le pseudo de votre héro");
        Hero = new Humain(Console.ReadLine());
        break;
    case "2":
        Console.WriteLine("Veuillez entrer le pseudo de votre héro");
        Hero = new Nain(Console.ReadLine());
        break;
    default:
        Console.WriteLine("Entrée invalide, classe 'Lubberwort' appliquée par défault");
        Console.WriteLine("Veuillez entrer le pseudo de votre héro");
        Hero = new Lubberwort(Console.ReadLine() + "is a Lubberwort");
        break;
}


Thread.Sleep(200);
Console.Clear();
Hero.AfficherPersonnage();
Thread.Sleep(2000);
Console.Clear();




/////// TEST ////////
PlateauDeJeu grid = new PlateauDeJeu( 15, 15);
De des = new De();
List<Personnages> monstre = grid.MonsterSetUp(12, shop);
grid.GridInit();
grid.GridPrint(Hero, monstre, shop);

while (grid.SeDeplacer(Hero, monstre, shop ) && Hero.EnVie() && StillMonster(monstre))
{
    StartCombat(Hero, monstre,shop);
}







////////    MÉTHODE     ///////////
static void StartCombat(Personnages Hero, List<Personnages> monstre, Shop shop )
{
    if (shop.x == Hero.x && shop.y == Hero.y )
        shop.Vendre(Hero);
    else
        for(int i = 0; i < monstre.Count; i++)
        {
            if (Math.Abs(monstre[i].x - Hero.x) + Math.Abs(monstre[i].y - Hero.y) == 1 && monstre[i].EnVie())
            {
                Hero.Combat(monstre[i]);
                monstre.RemoveAt(i);
            }
     }
}
static bool StillMonster(List<Personnages> monstre)
{
    if (monstre.Count <= 0)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("FÉLICITATION, vous avez gangné");
        Console.ResetColor();
        return false;
    }
    return true;
}



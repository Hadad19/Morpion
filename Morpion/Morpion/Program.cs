using System;
using System.Security.Policy;
using System.Text.RegularExpressions;

namespace Morpion
{
    class Program
    {
        public static int[,] grille = new int[3, 3]; // matrice pour stocker les coups joués

        public static void AfficherMorpion(int j, int k)
        {
            for (var p = 0; p < grille.GetLength(0); p++)
            {
                Console.Write("\n|=====|=====|=====|\n");
                Console.Write("|");
                for (var i = 0; i < grille.GetLength(1); i++)
                {
                    if (grille[p, i] == 1)
                        Console.Write("  X ");
                    else if (grille[p, i] == 2)
                        Console.Write("  O ");
                    else
                        Console.Write("    ");

                    Console.Write(" |");
                }
            }
            Console.Write("\n|=====|=====|=====|\n");
            Console.WriteLine($"\nC'est au joueur {(j == 1 ? "X" : "O")} de jouer.");
        }

        // Fonction permettant de changer
        // dans le tableau qu'elle est le 
        // joueur qui à jouer
        // Bien vérifier que le joueur ne sort
        // pas du tableau et que la position
        // n'est pas déjà jouée 
        public static bool AJouer(int j, int k, int joueur)
        {
            if (j >= 0 && j < 3 && k >= 0 && k < 3)
            {
                if (grille[j, k] == 0)
                {
                    grille[j, k] = joueur;
                    return true;
                }
            }
            return false;
        }

        // Fonction permettant de vérifier
        // si un joueur à gagner
        public static bool Gagner(int l, int c, int joueur)
        {
            for (int i = 0; i < 3; i++)
            {
                if (grille[i, 0] == joueur && grille[i, 1] == joueur && grille[i, 2] == joueur)
                {
                    return true;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (grille[0, i] == joueur && grille[1, i] == joueur && grille[2, i] == joueur)
                {
                    return true;
                }
            }
            if (grille[0, 0] == joueur && grille[1, 1] == joueur && grille[2, 2] == joueur)
            {
                return true;
            }
            if (grille[0, 2] == joueur && grille[1, 1] == joueur && grille[2, 0] == joueur)
            {
                return true;
            }
            return false;
        }

        // Programme principal
        static void Main(string[] args)
        {
            int LigneDébut = Console.CursorTop;
            int ColonneDébut = Console.CursorLeft;

            int essais = 0;
            int joueur = 1;
            int l, c = 0;
            bool gagner = false;
            bool bonnePosition = false;

            for (int j = 0; j < grille.GetLength(0); j++)
                for (int k = 0; k < grille.GetLength(1); k++)
                    grille[j, k] = 0;

            while (!gagner && essais != 9)
            {
                AfficherMorpion(joueur, c);

                try
                {
                    Console.WriteLine("Ligne   = ");
                    Console.WriteLine("Colonne = ");

                    // Positionner le curseur pour la saisie de la ligne
                    Console.SetCursorPosition(ColonneDébut + 10, LigneDébut + 10);
                    l = int.Parse(Console.ReadLine());

                    // Positionner le curseur pour la saisie de la colonne
                    Console.SetCursorPosition(ColonneDébut + 11, LigneDébut + 11);
                    c = int.Parse(Console.ReadLine());

                    // Vérification de l'entrée
                    if (l < 0 || l > 2 || c < 0 || c > 2)
                    {
                        Console.WriteLine("Veuillez entrer des nombres entre 0 et 2.");
                        continue;
                    }

                    bonnePosition = AJouer(l, c, joueur);
                    if (!bonnePosition)
                        Console.WriteLine("Position invalide ou déjà occupée, essayez encore.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Entrée invalide, veuillez entrer des nombres entre 0 et 2.");
                    continue;
                }
                // Changement de joueur

                gagner = Gagner(l, c, joueur);

                if (!gagner)
                {
                    joueur = (joueur == 1) ? 2 : 1;
                    essais++;
                }
            }
            // Fin TQ
            // Fin de la partie
            AfficherMorpion(joueur, c);
            if (gagner)
                Console.WriteLine($"Félicitations ! Joueur {(joueur == 1 ? "X" : "O")} a gagné !");
            else
                Console.WriteLine("Match nul !");

            Console.ReadKey();
        }
    }
}


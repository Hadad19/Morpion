
namespace using System;

class Program
{
    public static int[,] grille = new int[3, 3]; // matrice pour stocker les coups joués

    // Fonction permettant l'affichage du Morpion
    public static void AfficherMorpion()
    {
        // Dessiner une grille avec les valeurs actuelles
        for (var p = 0; p < grille.GetLength(0); p++)
        {
            Console.Write("\n|====|====|====|\n");
            Console.Write("|");
            for (var i = 0; i < grille.GetLength(1); i++)
            {
                if (grille[p, i] == 1)
                    Console.Write("  X ");
                else if (grille[p, i] == 2)
                    Console.Write("  O ");
                else
                    Console.Write("    "); // Cell is empty

                Console.Write("|");
            }
        }
        Console.Write("\n|====|====|====|\n");
    }

    // Fonction permettant de changer dans le tableau qu'elle est le joueur qui a joué
    public static bool AJouer(int j, int k, int joueur)
    {
        if (j >= 0 && j < grille.GetLength(0) && k >= 0 && k < grille.GetLength(1))
        {
            if (grille[j, k] == 10) // If the position is empty (marked as 10)
            {
                grille[j, k] = joueur;
                return true;
            }
            else
            {
                Console.WriteLine("Cette position est déjà prise !");
                return false;
            }
        }
        else
        {
            Console.WriteLine("Position invalide !");
            return false;
        }
    }

    // Fonction permettant de vérifier si un joueur a gagné
    public static bool Gagner(int joueur)
    {
        // Vérifier les lignes
        for (int i = 0; i < 3; i++)
        {
            if (grille[i, 0] == joueur && grille[i, 1] == joueur && grille[i, 2] == joueur)
                return true;
        }

        // Vérifier les colonnes
        for (int i = 0; i < 3; i++)
        {
            if (grille[0, i] == joueur && grille[1, i] == joueur && grille[2, i] == joueur)
                return true;
        }

        // Vérifier les diagonales
        if (grille[0, 0] == joueur && grille[1, 1] == joueur && grille[2, 2] == joueur)
            return true;
        if (grille[0, 2] == joueur && grille[1, 1] == joueur && grille[2, 0] == joueur)
            return true;

        return false;
    }

    // Programme principal
    static void Main(string[] args)
    {
        //--- Déclarations et initialisations ---
        int ligneDébut = Console.CursorTop;     // par rapport au sommet de la fenêtre
        int colonneDébut = Console.CursorLeft;  // par rapport au sommet de la fenêtre

        int essais = 0;    // compteur d'essais
        int joueur = 1;    // 1 pour le premier joueur, 2 pour le second
        int l, c = 0;      // numéro de ligne et de colonne
        bool gagner = false; // Permet de vérifier si un joueur a gagné 

        //--- initialisation de la grille ---
        // On met chaque valeur du tableau à 10 (vide)
        for (int j = 0; j < grille.GetLength(0); j++)
            for (int k = 0; k < grille.GetLength(1); k++)
                grille[j, k] = 10;

        while (!gagner && essais < 9)
        {
            AfficherMorpion();
            Console.WriteLine($"C'est au tour du joueur N°{joueur}");

            try
            {
                Console.Write("Ligne (1-3) = ");
                l = int.Parse(Console.ReadLine()) - 1;
                Console.Write("Colonne (1-3) = ");
                c = int.Parse(Console.ReadLine()) - 1;

                // Essayer de faire jouer le joueur
                if (AJouer(l, c, joueur))
                {
                    essais++;
                    // Vérifier si le joueur a gagné
                    if (Gagner(joueur))
                    {
                        AfficherMorpion();
                        Console.WriteLine($"Le joueur N°{joueur} a gagné !");
                        gagner = true;
                    }
                    else
                    {
                        // Changer de joueur
                        joueur = (joueur == 1) ? 2 : 1;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Entrée invalide !");
            }
        }

        // Si la grille est pleine et qu'il n'y a pas de gagnant
        if (essais == 9 && !gagner)
        {
            AfficherMorpion();
            Console.WriteLine("Match nul !");
        }

        Console.ReadKey();
    }
}
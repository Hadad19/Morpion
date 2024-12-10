using System;

namespace Tableau2Dimensions
{
    class Program
    {

        // Programme principal
        static void Main(string[] args)
        {
            // Déclaration d'un tableau en 2 dimensions
            // On définit la longueur de chaque dimensions
            int [,] grilleInt = new int[3, 3];
            string[,] grilleString = { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };


            int[,] grilleInt2 = new int[6, 4];

            // Pour accéder à la longueur du tableau dans sa dimensions 
            // 0 pour la première dimensions
            Console.WriteLine("Longeur première dimension : " + grilleInt.GetLength(0));
            // 1 pour la seconde dimensions
            Console.WriteLine("Longeur deuxième dimension: " + grilleInt.GetLength(1));
            Console.WriteLine("Total : " + grilleInt.Length);
            Console.WriteLine();
            // Pour accéder à la longueur du tableau dans sa dimensions 
            // 0 pour la première dimensions
            Console.WriteLine("Longeur première dimension : " + grilleString.GetLength(0));
            // 1 pour la seconde dimensions
            Console.WriteLine("Longeur deuxième dimension: " + grilleString.GetLength(1));

            // Parcourir un tableau int sans valeurs
            for (var j = 0; j < grilleInt.GetLength(0); j++)
            {
                for (var i = 0; i < grilleInt.GetLength(1); i++)
                {
                    Console.WriteLine("Matrix : " + j.ToString() + " . " + i.ToString() + " valeur : " + grilleInt[j, i]);

                }
            }

            Console.WriteLine();

            // Parcourir un tableau string avec des valeurs
            for (var j = 0; j < grilleString.GetLength(0); j++)
            {
                for (var i = 0; i < grilleString.GetLength(1); i++)
                {
                    Console.WriteLine("Matrix : " + j.ToString() + " . " + i.ToString() + " valeur : " + grilleString[j, i]);

                }
            }

            Console.WriteLine();
            // Pour accéder à la longueur du tableau dans sa dimensions 
            // 0 pour la première dimensions
            Console.WriteLine("Longeur première dimension : " + grilleInt2.GetLength(0));
            // 1 pour la seconde dimensions
            Console.WriteLine("Longeur deuxième dimension: " + grilleInt2.GetLength(1));
            Console.WriteLine("Affichage grille");

            // Dessiner une grille
            for (var j = 0; j < grilleInt2.GetLength(0); j++)
            {
                Console.Write("\n|====|====|====|====|\n");
                Console.Write("|");
                for (var i = 0; i < grilleInt2.GetLength(1); i++)
                {
                    Console.Write(" -- ");
                    Console.Write("|");
                }
                
            }
            Console.Write("\n|====|====|====|====|");


            Console.ReadKey();
        }
    }
}

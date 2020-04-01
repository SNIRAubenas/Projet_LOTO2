using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loto;

namespace JeuDuLoto_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            //
            // On crée le génerateur
            GenerateurDeCarton fabrique = new GenerateurDeCarton();
            // et on récupère un carton
            Carton unCarton = fabrique.Generer();
            // Maintenant, on affiche ce Carton avec notre présentateur
            Presentateur pres = new Presentateur();

            //
            int nbre = -1;
            String saisie;
            while (nbre != 0)
            {
                //
                Console.SetCursorPosition(0, 0);
                Console.Clear();
                pres.Afficher(unCarton);
                if (unCarton.EstPlein)
                    Console.WriteLine("Carton Plein !!!");
                else if (unCarton.EstQuine)
                    Console.WriteLine("Quine !!!");
                else
                    Console.WriteLine();
                Console.Write("Entrez un nombre : ");
                saisie = Console.ReadLine();
                nbre = Convert.ToInt32(saisie);
                unCarton.Marquer(nbre);
            }
            //
            Console.WriteLine("----========----");
            Console.WriteLine("Merci pour cette partie.");
            Console.ReadLine();
        }
    }
}

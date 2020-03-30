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
            // On crée le génerateur
            GenerateurDeCarton fabrique = new GenerateurDeCarton();
            // et on récupère un carton
            Carton unCarton = fabrique.Generer();
            // Maintenant, on affiche ce Carton avec notre présentateur
            Presentateur pres = new Presentateur();
            pres.Afficher(unCarton);
            //
            int nbre = 0;
            String saisie;
            do
            {
                Console.Write("Entrez un nombre : ");
                saisie = Console.ReadLine();
                nbre = Convert.ToInt32(saisie);
                unCarton.Marquer(nbre);
                pres.Afficher(unCarton);
            } while (nbre != 0);
            Console.ReadLine();
        }
    }
}

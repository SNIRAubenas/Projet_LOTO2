using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loto;

namespace JeuDuLoto_Console
{
    class Presentateur
    {
        public void Afficher(Carton leCarton)
        {
            // On a 9 Colonnes, chacune contient un nombre sur 2 caractères
            // On va écrire chaque case sous la forme !XX
            // Et on ajoutera ! à la fin de la ligne pour fermer
            // On a donc besoin d'une ligne horizontale de 3 * 9 + 1 caractères
            // Maintenant, on affiche le contenu
            this.LigneHorizontale();
            this.SautLigne();
            Ligne laLigne;
            for (int i = 0; i < 3; i++)
            {
                laLigne = leCarton[i];
                for (int j = 0; j < 9; j++)
                {
                    this.SeparateurCase();
                    this.Case(laLigne[j], laLigne[1,j] == 1 );
                }
                this.SeparateurCase();
                this.SautLigne();
            }
            this.LigneHorizontale();
            this.SautLigne();
        }

        private void LigneHorizontale()
        {
            String barre = new string('-', 46);
            Console.Write(barre);
        }

        private void Case(int nombre, bool marque )
        {
            Console.Write(" ");
            if (nombre == 0)
                Console.Write("  ");
            else
                if (marque)
                Console.Write("XX");
            else
                Console.Write(String.Format("{0,2}", nombre));
            Console.Write(" ");
        }

        private void SeparateurCase()
        {
            Console.Write("!");
        }

        private void SautLigne()
        {
            Console.WriteLine();
        }
    }
}

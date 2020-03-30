using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loto
{
    public class GenerateurDeCarton
    {
        // Le générateur de nombre aléatoire utilisé pour la durée d'execution
        Random alea;

        public GenerateurDeCarton()
        {
            alea = new Random((int)DateTime.Now.Ticks);
        }

        /// <summary>
        /// Génération d'un carton en choisissant une des deux méthodes proposées
        /// </summary>
        /// <param name="methode"></param>
        /// <returns></returns>
        public Carton Generer(int methode)
        {
            if (methode == 1)
                return GenererMethode1();
            else
                return GenererMethode2();
        }

        /// <summary>
        /// Generation d'un carton
        /// </summary>
        /// <returns></returns>
        public Carton Generer()
        {
            return GenererMethode2();
        }

        /// <summary>
        ///  On tire des nombres entre 1 et 90; on les mémorise pour ne pas les tirer deux fois
        /// </summary>
        /// <returns></returns>
        private Carton GenererMethode2()
        {
            // On va générer 3 tableaux de 5 Nombres
            // 1 tableau de 5 nombres pour chaque Ligne du Carton
            int[,] contenu = new int[3, 5];
            // Un nombre ne peut apparaitre qu'une fois dans le carton
            // On garde donc la liste de tous les nombres tirés (On pourrait aussi parcourir le tableau contenu)
            List<int> numeros = new List<int>();
            for (int numeroLigne = 0; numeroLigne < 3; numeroLigne++)
            {
                // Pour chaque ligne, on ne peut mettre qu'un nombre d'une colonne
                // On va donc garder la liste des colonnes déjà tirées
                List<int> dizaine = new List<int>();
                for (int colonne = 0; colonne < 5; colonne++)
                {
                    // On tire un nombre au hasard 
                    // Intervalle [1,91[
                    int hasard;
                    int colNum;
                    do
                    {
                        do
                        {
                            hasard = alea.Next(1, 91);
                        } while (numeros.Contains(hasard)); // Dans l'ensemble des numeros déjà tirés ?
                        colNum = hasard / 10;
                        if (colNum == 9)
                            colNum = 8;
                    } while (dizaine.Contains(colNum)); // Colonne déjà tirée pour cette ligne
                    // Tout est ok, on garded donc ces infos
                    numeros.Add(hasard);
                    dizaine.Add(colNum);
                    // et on stocke
                    contenu[numeroLigne, colonne] = hasard;
                }
            }
            // C'est avec ça qu'on crée le Carton
            Carton nouveauCarton = new Carton(contenu);
            return nouveauCarton;
        }

        /// <summary>
        /// On construit une Grille de 8 Colonnes
        /// Dans chaque colonne, on met les nombres possibles
        /// On tire une colonne au hasard, puis on tire un nombre au hasard parmi ceux restants
        /// On supprime de la grille les nombres déjà tirés
        /// </summary>
        /// <returns></returns>
        private Carton GenererMethode1()
        {
            // Methode 1
            // On crée une List de List<int>
            // !! ATTENTION !! La List<int> n'a pas encore été crée !!
            List<List<int>> grille = new List<List<int>>();
            //
            for (int dizaine = 0; dizaine < 9; dizaine++)
            {
                // On crée la liste de nombres
                List<int> insideList = new List<int>();
                for (int unite = 0; unite <= 9; unite++)
                {
                    // Cas Particulier N°1
                    if ((unite == 0) && (dizaine == 0))
                        continue;
                    // On met le nombre dans la liste
                    insideList.Add((10 * dizaine) + unite);
                }
                // Cas Particulier N°2
                if (dizaine == 8)
                {
                    // On ajoute 90 dans la liste : 10*8 + 10
                    insideList.Add((10 * dizaine) + 10);
                }
                // Cette liste de nombre est rangée dans la liste principale
                grille.Add(insideList);
            }
            // Ok, donc maintenant, on va générer 3 tableaux de 5 Nombres
            // 1 tableau de 5 nombres pour chaque Ligne du Carton
            int[,] contenu = new int[3, 5];
            for (int numeroLigne = 0; numeroLigne < 3; numeroLigne++)
            {
                // Pour chaque ligne, on ne peut mettre qu'un nombre d'une colonne
                // On va donc garder la liste des colonnes déjà tirées
                List<int> dizaine = new List<int>();
                for (int numero = 0; numero < 5; numero++)
                {
                    // On tire un nombre au hasard pour dire dans quelle colonne on veut un nombre 
                    // Intervalle [0,9[
                    int colonne;
                    do
                    {
                        colonne = alea.Next(0, 9);
                    } while (dizaine.Contains(colonne));
                    dizaine.Add(colonne);
                    // On prend la liste des nombres encore dispo pour cette colonne
                    List<int> insideList = grille[colonne];
                    // Maintenant on tire une position au hasard
                    // Intervalle [0,Taille de cette liste[
                    int position = alea.Next(0, insideList.Count);
                    // Ok, donc le premier nombre sera là
                    contenu[numeroLigne, numero] = insideList[position];
                    // On enlève ce nombre des numeros dispo
                    insideList.RemoveAt(position);
                }
            }
            // C'est avec ça qu'on crée le Carton
            Carton nouveauCarton = new Carton(contenu);
            return nouveauCarton;
        }
    }
}

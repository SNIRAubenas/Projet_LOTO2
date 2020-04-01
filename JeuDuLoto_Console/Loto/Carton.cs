using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loto
{
    /// <summary>
    /// Un carton c'est :
    /// 9 Colonnes : Les Dizaines de 0 à 8
    /// Pour chaque dizaine, on a les unités de 0 à 9
    /// Cas Particuliers : 
    /// 1. Pas de 0 pour la colonne 0
    /// 2. on ajoute 10 dans la colonne 8
    /// </summary>
    public class Carton
    {
        /// <summary>
        /// Un tableau de ligne de taille 3
        /// </summary>
        Ligne[] lignes;

        // Ce constructeur est private, il n'est donc pas visible de l'extérieur
        private Carton()
        {
            // Creation du tableau de ligne
            // !!! Les objects Ligne n'existent pas à ce stade
            lignes = new Ligne[3];
        }

        public Carton(int[,] contenu) : this()
        {
            if (contenu == null)
                throw new NullReferenceException("Le tableau doit exister");
            // Normalement, on a 3 x 5 numeros
            if (contenu.Length != 15)
                throw new Exception("Le tableau doit avoir une taille de 3 x 5");
            if (contenu.Rank != 2)
                throw new Exception("Le tableau doit avoir deux dimensions : 3 x 5");
            if (contenu.GetUpperBound(0) != 2) // Le plus grand Index dans la Dimension 0, c'est 2
                throw new Exception("Le tableau doit avoir deux dimensions, la première de longueur 3");
            if (contenu.GetUpperBound(1) != 4)  // Le plus grand Index dans la Dimension 1, c'est 4
                throw new Exception("Le tableau doit avoir deux dimensions, la deuxième de longueur 5");
            // Pour chaque Ligne
            for (int i = 0; i < 3; i++)
            {
                // On copie dans un tableau
                int[] temp = new int[5];
                for (int j = 0; j < 5; j++)
                {
                    temp[j] = contenu[i, j];
                }
                lignes[i] = new Ligne(temp);
            }
        }

        /// <summary>
        /// Accède aux lignes du Carton.
        /// Retourne une copie de la ligne du Carton demandée
        /// </summary>
        /// <param name="index"> de 0 à 2 </param>
        /// <returns></returns>
        public Ligne this[int index]
        {
            get
            {
                // Est ce que l'index est correct ?
                if ((index >= 0) && (index < this.lignes.Length))
                {
                    // On retourne une copie
                    return new Ligne(this.lignes[index]);
                }
                // Non => Exception
                throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// Vérifie si le nombre existe dans le carton
        /// </summary>
        /// <param name="nombreAVerifier"></param>
        /// <returns></returns>
        public bool Verifier(int nombreAVerifier)
        {
            bool exist = false;
            for (int i = 0; i < lignes.Length; i++)
            {
                exist = exist || this.lignes[i].Verifier(nombreAVerifier);
            }
            return exist;
        }

        /// <summary>
        /// Essaye de marquer un nombre dans le carton
        /// </summary>
        /// <param name="NombreAMarquer"></param>
        /// <returns></returns>
        public bool Marquer(int NombreAMarquer)
        {
            bool exist = false;
            for (int i = 0; i < lignes.Length; i++)
            {
                exist = exist || this.lignes[i].Marquer(NombreAMarquer);
            }
            return exist;
        }

        /// <summary>
        /// Indique si le carton contient au moins une Quine
        /// </summary>
        public bool EstQuine
        {
            get
            {
                bool quine = false;
                for (int i = 0; i < lignes.Length; i++)
                {
                    quine = quine || this.lignes[i].EstQuine;
                }
                return quine;
            }
        }

        /// <summary>
        /// Indique si le carton est plein == Toutes les lignes sont des Quine
        /// </summary>
        public bool EstPlein
        {
            get
            {
                bool plein = true;
                for (int i = 0; i < lignes.Length; i++)
                {
                    plein = plein && this.lignes[i].EstQuine;
                }
                return plein;
            }
        }
    }
}

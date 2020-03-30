using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDuLoto_Console
{
    public class Ligne
    {
        // Les 9 colonnes de la lignes
        int[] lesNumeros;
        // Les Numéros marqués sur la ligne ( 5 au Max )
        List<int> marquage;

        /// <summary>
        /// Constructeur par défaut, la ligne est vide et non marquée
        /// Il est privé, donc inaccessible de l'extérieur
        /// </summary>
        private Ligne()
        {
            lesNumeros = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            Nettoyer();
        }

        /// <summary>
        /// Constructeur par copie.
        /// L'objet retourné comprend les mêmes informations que l'original, mais...C'est une copie !
        /// </summary>
        /// <param name="ligneACopie"></param>
        public Ligne( Ligne ligneACopier ):this()
        {
            // On copie les numéros
            ligneACopier.lesNumeros.CopyTo(this.lesNumeros, 0);
            // et ceux déjà marqués
            this.marquage.AddRange(ligneACopier.marquage);
        }

        /// <summary>
        /// DéMarque completement un ligne :
        /// on efface la ligne mais on garde son contenu
        /// </summary>
        public void Nettoyer()
        {
            marquage = new List<int>();
        }


        /// <summary>
        /// Constructeur à paramètre : Un tableau de 5 valeur pour initialiser la ligne
        /// Les nombres peuvent être dans n'importe quel ordre
        /// Il n'y a pas de doublon
        /// </summary>
        /// <param name="initNumbers"></param>
        // Ici, on appelle le constructeur par défaut, avant d'executer le code
        public Ligne(int[] initNumbers) : this()
        {
            // Une ligne contient 5 nombres, si ce n'est pas bon ... -->> Exception !
            if ((initNumbers == null) || (initNumbers.Length != 5))
            {
                throw new Exception("L'initialisation de la ligne est incorrecte: La taille est incorrecte");
            }
            // On va remplir et vérifier
            foreach (int number in initNumbers)
            {
                if ( (number <= 0) || ( number > 90 ) )
                {
                    throw new Exception("Chaque numéro doit être compris entre 1 et 90.");
                }
                // Quelle dizaine ?
                int dizaine = number / 10;
                // Cas particulier
                if (number == 90)
                    dizaine = 8;
                // La case déjà remplie !?
                if (lesNumeros[dizaine] != 0)
                {
                    throw new Exception("L'initialisation de la ligne est incorrecte: Deux nombres pour la même dizaine.");
                }
                else
                {
                    lesNumeros[dizaine] = number;
                }
            }
        }

        /// <summary>
        /// Indique si une ligne est une Quine
        /// </summary>
        public bool EstQuine
        {
            get
            {
                // C'est le cas si on a marqué les 5 nombres de la Ligne
                return (marquage.Count == 5);
            }
        }

        /// <summary>
        /// Accède à la ligne comme à un tableau
        /// </summary>
        /// <param name="index">La position à lire (entre 0 et 8)</param>
        /// <returns>Le nombre présent dans le carton</returns>
        public int this[int index]
        {
            get
            {
                // Est ce que l'index est correct ?
                if ((index >= 0) && (index < this.lesNumeros.Length))
                {
                    return this.lesNumeros[index];
                }
                // Non => Exception
                throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// Test si un nombre est présent dans la ligne
        /// </summary>
        /// <param name="NombreAVerifier"></param>
        /// <returns></returns>
        public bool Verifier(int NombreAVerifier)
        {
            if ((NombreAVerifier >= 1) && (NombreAVerifier <= 90))
            {
                bool exist = false;
                foreach (int number in lesNumeros)
                {
                    if (number == NombreAVerifier)
                    {
                        exist = true;
                        break;
                    }
                }
                return exist;
            }
            return false;
        }

        /// <summary>
        /// Marque le nombre passé en paramètre sur la ligne.
        /// Il n'est marqué que si présent
        /// </summary>
        /// <param name="NombreAMarquer"></param>
        /// <returns>Indique si le nombre a été marqué</returns>
        public bool Marquer(int NombreAMarquer)
        {
            if (Verifier(NombreAMarquer))
            {
                // Déjà présent dans le marquage ?
                if (!marquage.Contains(NombreAMarquer))
                {
                    marquage.Add(NombreAMarquer);
                }
                return true;
            }
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loto;
using Xunit;

namespace Loto.Tests
{
    public class TestLigne
    {
        [Fact(DisplayName = "Test Verifier ok")]
        public void VerifierTest()
        {
            Ligne ligne1;
            int[] nombres;
            // On crée une ligne à partir d'un tableau Ok
            nombres = new int[] { 1, 10, 20, 30, 40 };
            ligne1 = new Ligne(nombres);
            // On vérifie la présence d'un nombre
            foreach (int nombre in nombres)
                Assert.True(ligne1.Verifier(nombre));
        }

        [Fact(DisplayName = "Test Verifier pas ok")]
        public void VerifierTestFalse()
        {
            Ligne ligne1;
            int[] nombres;
            // On crée une ligne à partir d'un tableau Ok
            nombres = new int[] { 1, 10, 20, 30, 40 };
            ligne1 = new Ligne(nombres);
            // On vérifie l'absence d'un nombre
            Assert.False(ligne1.Verifier(99));
        }

        [Fact(DisplayName = "Constructeur avec null")]
        public void testConstAvecNull()
        {
            Ligne ligne1;
            Action action = () => ligne1 = new Ligne( (int[])null);
            Exception exc = Assert.Throws<Exception>(action);
            //
        }

        [Fact(DisplayName = "Constructeur par copie")]
        public void testConstCopie()
        {
            // Original avec un tableau ok
            Ligne ligne1 = new Ligne(new int[] { 1, 10, 20, 30, 40 });
            // On copie
            Ligne ligne2 = new Ligne(ligne1);
            // Maintenant on prend chaque colonne de l'original et on vérifie dans la copie
            for( int i=0;i<9;i++)
            {
                int nombre = ligne1[i];
                if ( nombre != 0 )
                {
                    Assert.True(ligne2.Verifier(nombre));
                }
            }
        }

        [Fact(DisplayName = "Constructeur avec tableau")]
        public void testConstAvecArray()
        {
            Ligne ligne1;
            int[] nombres;
            // Une taille incorrecte renvoie une Exception
            nombres = new int[] { 1, 10, 20 };
            Action action = () => ligne1 = new Ligne(nombres);
            Exception exc = Assert.Throws<Exception>(action);
            // Un tableau mal construit renvoie une Exception : Deux fois le même
            nombres = new int[] { 1, 10, 20, 30, 30 };
            action = () => ligne1 = new Ligne(nombres);
            exc = Assert.Throws<Exception>(action);
            // Un tableau mal construit renvoie une Exception : nombre impossible
            nombres = new int[] { 0, 92, 20, 30, 30 };
            action = () => ligne1 = new Ligne(nombres);
            exc = Assert.Throws<Exception>(action);
            // Un tableau Ok => Pas d'Exception !
            nombres = new int[] { 1, 10, 20, 30, 40 };
            action = () => ligne1 = new Ligne(nombres);
            exc = Record.Exception(action);
            Assert.Null(exc);
            //                
        }

        [Fact(DisplayName = "Accès aux Numéros")]
        public void LigneEnTableauTest()
        {
            Ligne ligne1;
            // On crée une ligne à partir d'un tableau Ok, pas forcement trié
            ligne1 = new Ligne(new int[] { 20, 30, 10, 40, 50 });
            // Et on les relit
            int nbr;
            for (int i = 1; i < 6; i++)
            {
                nbr = ligne1[i];
                Assert.Equal(nbr, i * 10);
            }
            // Un accès hors tableau déclenche une exception
            Action action = () => nbr = ligne1[10];
            Exception exc = Assert.Throws<IndexOutOfRangeException>(action);
        }

        [Fact(DisplayName = "Test du Marquage et Quine")]
        public void MarquerTest()
        {
            Ligne ligne1;
            // On crée une ligne à partir d'un tableau Ok
            ligne1 = new Ligne(new int[] { 10, 20, 30, 40, 50 });
            // On relit les nombres et on les marque
            int nbr;
            for (int i = 1; i < 6; i++)
            {
                nbr = ligne1[i];
                Assert.True(ligne1.Marquer(nbr));
            }
            // A la sortie, on a une Quine
            Assert.True(ligne1.EstQuine);
            // On nettoie la ligne
            ligne1.Nettoyer();
            // Ce n'est plus une Quine
            Assert.False(ligne1.EstQuine);
            // Marquer un nombre inexistant renvoie False
            Assert.False(ligne1.Marquer(1));
            // On ne peut pas marquer 0
            Assert.False(ligne1.Marquer(0));
        }
    }
}

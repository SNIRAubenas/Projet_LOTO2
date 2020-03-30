using Xunit;
using Loto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loto.Tests
{
    public class CartonTests
    {
        [Fact(DisplayName = "Constructeur de Carton")]
        public void CartonTest()
        {
            Carton leCarton;
            // Le tableau doit exister
            Action action = () => leCarton = new Carton(null);
            Exception exc = Assert.Throws<NullReferenceException>(action);

            // Il faut vérifier la taille du tableau
            action = () => leCarton = new Carton(new int[1, 1]);
            exc = Assert.Throws<Exception>(action);

            // Il faut vérifier la taille du tableau
            action = () => leCarton = new Carton(new int[5, 3]);
            exc = Assert.Throws<Exception>(action);

            // Il faut vérifier la taille du tableau, et son contenu
            action = () => leCarton = new Carton(new int[3, 5]);
            exc = Assert.Throws<Exception>(action);

            // Un tableau Ok => Pas d'Exception !
            int[,] contenu = new int[3, 5] { { 1, 10, 20, 30, 40 }, { 2, 12, 22, 32, 42 }, { 3, 13, 23, 33, 43 } };
            action = () => leCarton = new Carton(contenu);
            exc = Record.Exception(action);
            Assert.Null(exc);
        }

        [Fact(DisplayName = "Test de l'accès par Index")]
        public void CartonTestAcces()
        {
            // Un tableau Ok => Pas d'Exception !
            int[,] contenu = new int[3, 5] { { 1, 10, 20, 30, 40 }, { 2, 12, 22, 32, 42 }, { 3, 13, 23, 33, 43 } };
            Carton leCarton = new Carton(contenu);
            Ligne laLigne;
            // Accès hors tableau
            Action action = () => laLigne = leCarton[3];
            Exception exc = Assert.Throws<IndexOutOfRangeException>(action);
            // Maintenant, on vérifie le contenu
            for (int i = 0; i < 3; i++)
            {
                laLigne = leCarton[i];
                for (int j = 0; j < 5; j++)
                {
                    int nombre = contenu[i, j];
                    Assert.True(laLigne.Verifier(nombre));
                }
            }
        }

        [Fact(DisplayName = "Verification de la présence d'un nombre")]
        public void VerifierTest()
        {
            // Un tableau Ok => Pas d'Exception !
            int[,] contenu = new int[3, 5] { { 1, 10, 20, 30, 40 }, { 2, 12, 22, 32, 42 }, { 3, 13, 23, 33, 43 } };
            Carton leCarton = new Carton(contenu);
            //
            Assert.True(leCarton.Verifier(10));
            Assert.False(leCarton.Verifier(90));
        }

        [Fact(DisplayName = "Marquer un nombre sur le carton")]
        public void MarquerTest()
        {
            // Un tableau Ok => Pas d'Exception !
            int[,] contenu = new int[3, 5] { { 1, 10, 20, 30, 40 }, { 2, 12, 22, 32, 42 }, { 3, 13, 23, 33, 43 } };
            Carton leCarton = new Carton(contenu);
            //
            Assert.True(leCarton.Marquer(10));
            Assert.True(leCarton.Marquer(12));
            Assert.True(leCarton.Marquer(13));
            Assert.False(leCarton.Marquer(90));
        }

        [Fact(DisplayName = "Verifie sur le carton contient une Quine")]
        public void QuineTest()
        {
            // Un tableau Ok => Pas d'Exception !
            int[,] contenu = new int[3, 5] { { 1, 10, 20, 30, 40 }, { 2, 12, 22, 32, 42 }, { 3, 13, 23, 33, 43 } };
            Carton leCarton = new Carton(contenu);
            //
            Assert.False(leCarton.EstQuine);
            Assert.True(leCarton.Marquer(1));
            Assert.True(leCarton.Marquer(10));
            Assert.True(leCarton.Marquer(20));
            Assert.True(leCarton.Marquer(30));
            Assert.True(leCarton.Marquer(40));
            Assert.True(leCarton.EstQuine);

        }

        [Fact(DisplayName = "Verifie que le carton est plein")]
        public void PleinTest()
        {            // Un tableau Ok => Pas d'Exception !
            int[,] contenu = new int[3, 5] { { 1, 10, 20, 30, 40 }, { 2, 12, 22, 32, 42 }, { 3, 13, 23, 33, 43 } };
            Carton leCarton = new Carton(contenu);
            //
            Assert.False(leCarton.EstPlein);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    int nombre = contenu[i, j];
                    Assert.True(leCarton.Marquer(nombre));
                }
            }
            Assert.True(leCarton.EstPlein);
        }

    }
}
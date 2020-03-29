using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeuDuLoto_Console;
using Xunit;

namespace JeuDuLoto_Console.Tests
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
            Assert.False(ligne1.EstVide);
            // On vérifie la présence d'un nombre
            foreach( int nombre in nombres )
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
            Assert.False(ligne1.EstVide);
            // On vérifie l'absence d'un nombre
            Assert.False(ligne1.Verifier(99));
        }


        [Fact(DisplayName = "Constructeur par défaut")]
        public void testConstructeurParDefaut()
        {
            Ligne ligne1 = new Ligne();
            Assert.True(ligne1.EstVide);
        }

        [Fact(DisplayName = "Constructeur avec null")]
        public void testConstAvecNull()
        {
            Ligne ligne1;
            Action action = () => ligne1 = new Ligne(null);
            Exception exc = Assert.Throws<Exception>(action);
            //
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
            // Un tableau mal construit renvoie une Exception
            nombres = new int[] { 1, 10, 20, 30, 30 };
            action = () => ligne1 = new Ligne(nombres);
            exc = Assert.Throws<Exception>(action);
            // Un tableau Ok
            nombres = new int[] { 1, 10, 20, 30, 40 };
            ligne1 = new Ligne(nombres);
            Assert.False(ligne1.EstVide);
            //                
        }

        [Fact(DisplayName = "Accès aux Numéros")]
        public void LigneEnTableauTest()
        {
            Ligne ligne1;
            // On crée une ligne à partir d'un tableau Ok
            ligne1 = new Ligne(new int[] { 10, 20, 30, 40, 50 });
            //
            int nbr;
            for (int i=1; i < 6;i++)
            {
                nbr = ligne1[i];
                Assert.Equal(nbr, i * 10);
            }
            // Un accès hors tableau déclenche une exception
            Action action = () => nbr = ligne1[10] ;
            Exception exc = Assert.Throws<IndexOutOfRangeException>(action);
        }
    }
}

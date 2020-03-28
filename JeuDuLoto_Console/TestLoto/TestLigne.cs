using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeuDuLoto_Console;
using Xunit;

namespace TestLoto
{
    public class TestLigne
    {
        [Fact(), Trait("Ligne", "Constructeur")]
        public void testConstructeurParDefaut()
        {
            Ligne ligne1 = new Ligne();
            Assert.True(ligne1.EstVide);
        }

        [Fact(), Trait("Ligne", "Avec Null")]
        public void testConstAvecNull()
        {
            Ligne ligne1;
            Action action = () => ligne1 = new Ligne(null);
            Exception exc = Assert.Throws<Exception>(action);
            //
        }

        [Fact(), Trait("Ligne", "Avec Un Tableau")]
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
    }
}

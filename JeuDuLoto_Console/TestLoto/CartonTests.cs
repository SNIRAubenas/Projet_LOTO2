using Xunit;
using JeuDuLoto_Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDuLoto_Console.Tests
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
    }
}
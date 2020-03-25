using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDuLot_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Generateur fabrique = new Generateur();

            Carton unCarton = fabrique.Generer();

            Presentateur pres = new Presentateur();
            pres.Afficher(unCarton);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDuLoto_Console
{
    class Generateur
    {
        Random alea;

        public Generateur()
        {
            alea = new Random((int)DateTime.Now.Ticks);
        }

        public Carton Generer()
        {
            return new Carton();
        }
    }
}

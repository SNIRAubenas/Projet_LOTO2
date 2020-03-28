﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDuLoto_Console
{
    class Ligne
    {
        // 
        int[] lesNumeros;

        // Constructeur par défaut
        public Ligne()
        {
            lesNumeros = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        }

        // Ici, on appelle le constructeur par défaut, avant d'executer le code
        public Ligne( int[] initNumbers ):this()
        {
            // Une ligne contient 5 nombres, si ce n'est pas bon ... -->> Exception !
            if ( ( initNumbers != null ) && ( initNumbers.Length != 5 ) )
            {
                throw new Exception("L'initialisation de la ligne est incorrecte: La taille est incorrecte");
            }
            // On va remplir et vérifier
            foreach( int number in initNumbers )
            {
                // Quelle dizaine ?
                int dizaine = number / 10;
                // Cas particulier
                if (number == 90)
                    dizaine = 8;
                // La case déjà remplie !?
                if ( lesNumeros[ dizaine ] != 0 )
                {
                    throw new Exception("L'initialisation de la ligne est incorrecte: Deux nombres pour la même dizaine.");
                }
                else
                {
                    lesNumeros[dizaine] = number;
                }
            }
        }
        Boolean EstQuine( int[] NombresAVerifier )
        {
            return false;
        }
    }
}

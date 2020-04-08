using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JeuDuLoto_Graphique
{
    public partial class MainWindow : Form
    {
        List<Label> ligne1;
        List<Label> ligne2;
        List<Label> ligne3;

        public MainWindow()
        {
            InitializeComponent();
            creerPresentateur();
        }

        void creerPresentateur()
        {
            int nombreLigne = 1;
            ligne1 = new List<Label>();
            ligne2 = new List<Label>();
            ligne3 = new List<Label>();
            
            creerLigne(ligne1,nombreLigne);
            creerLigne(ligne2, nombreLigne+1);
            creerLigne(ligne3, nombreLigne+2);



        }

        /// <summary>
        /// Créer une ligne en type List contenant des Label et chaque ittérations correspond à une case de cette dîte ligne.
        /// </summary>
        /// <param name="ligne"></param>
        /// <param name="nombreLigne"></param>

        void creerLigne(List<Label> ligne,int nombreLigne)
        {
            Label temp;

            int posX = 15;
            int posY = 11;
            if(nombreLigne == 2)
            {
                posY = +101;
            }
            else if(nombreLigne == 3)
            {
                posY = +202;
            }
           
           

                for (int i = 0; i < 9; i++)
                {
                    temp = new Label();
                    temp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    temp.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    temp.Location = new System.Drawing.Point(posX, posY);
                    temp.Name = "label1";
                    temp.Size = new System.Drawing.Size(50, 50);
                    temp.TabIndex = 1;
                    temp.Text = "00";
                    temp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                    this.panel1.Controls.Add(temp);
                    ligne.Add(temp);

                    posX = posX + temp.Size.Width + 6;
                }

               

            
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }
    }
}

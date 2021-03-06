﻿///////////////////////////////////////////////////////////////////////////
/////////////           Labo 02 Math Pour Jonathan Lortie       ///////////
/////////////               Francis Cote                        ///////////                       
/////////////               Mathieu Dumoulin                    ///////////
/////////////               Daren-Ken St-laurent                ///////////
///////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labo2
{
    public partial class FunFunFun : Form
    {
        public FunFunFun()
        {
            InitializeComponent();
        }

        private List<List<float>> tab = new List<List<float>>();
        private string FileName = "FicherSource.csv";
        private const int TABWIDTH = 11;
        private double Centieme;
        private double Centieme2;
        private double nbArrondisDixieme;
        private double nbArrondisDixieme2;
        private double Borne1;
        private double Moyenne;
        private double Borne2;
        private float Gprob1;
        private float Gprob2;

        #region "ReadFrom CSV"

        private void ReadCoordinates(string url)
        {
            try
            {
                tab.Clear();
                string[] lines = System.IO.File.ReadAllLines(url);
                foreach (string line in lines)
                {
                    List<float> temp = new List<float>();
                    string[] tokens = line.Split(';');
                    for (int i = 0; i < TABWIDTH; ++i)
                    {
                        temp.Add(float.Parse(tokens[i]));
                    }
                    tab.Add(temp);
                }
                this.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion


        private void Form1_Load(object sender, EventArgs e)
        {
            ReadCoordinates(FileName); // lecture des donnes du tableau
            CMB_Prob.Items.Add(">"); // ajout des objets dans le combobox(choix de l'usager)
            CMB_Prob.Items.Add("<");
            CMB_Prob.Items.Add("< >");
        }

        private void BTN_Calculer_Click(object sender, EventArgs e) // methode appeler au moment du clique sur le bouton calculer
        {
            bool choix2Bornes = false;

            if (CMB_Prob.SelectedIndex == 2 || CMB_Prob.SelectedIndex == 3)
                choix2Bornes = true;
            else
                choix2Bornes = false;

            if (TB_Borne1.Text == "" || TB_Borne2.Text == "" && choix2Bornes)
            {
                MessageBox.Show("Erreur! Vous devez entrer deux probabilités pour exécuter cette comparaison.");
            }
            else
            {
                try
                {
                    // Premiere borne
                    Borne1 = Convert.ToDouble(TB_Borne1.Text);//convertition valeur du texte en double
                    Moyenne = Convert.ToDouble(TB_Moyenne.Text);//convertition valeur du texte en double
                    double EcartType = Convert.ToDouble(TB_EcartType.Text); //converti la valeur pour avoir des decimal
                    double CoteZ1 = (Borne1 - Moyenne) / EcartType; //calcul de la cote Z
                    float Prob1 = 0.0f;
                    // Deuxieme borne
                    double CoteZ2 = 0;
                    float Prob2 = 0.0f;

                    if (TB_Borne2.Text != "")
                    {
                        Borne2 = Convert.ToDouble(TB_Borne2.Text); //converti  la valeur du texte en double
                        CoteZ2 = (Borne2 - Moyenne) / EcartType; // effectue la cote Z
                    }


                    if (CoteZ1 >= 4 || CoteZ1 <= -4) // Maximum du tableau de la cote Z
                    {
                        MessageBox.Show("Erreur! La cote Z n'est pas calculable avec le tableau donné."); //affiche 
                    }
                    else  // Si c'est une valeur 
                    {
                        isolerPartieNombre(CoteZ1, false);
                        // Si on a une deuxieme probabilité
                        if (Borne2 != 0)
                        {
                            isolerPartieNombre(CoteZ2, true);
                            Prob2 = trouverDansTableau(Centieme2, nbArrondisDixieme2); // affecte le resultat dans le tableau
                        }
                        Prob1 = trouverDansTableau(Centieme, nbArrondisDixieme);
                        CalculerProbabilite(Prob1, Prob2); // calcul les probabilites
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void CalculerProbabilite(float prob1, float prob2)
        {
            float probFinale = 0.0f;
            bool deuxBorne = true;

            if (prob2 == 0)
                deuxBorne = false;

            switch (CMB_Prob.SelectedIndex)
            {
                case 0: // > PROOF
                    {
                        if (!deuxBorne) // si pas 2 borne
                        {
                            if (Borne1 > Moyenne) // Si 
                                probFinale = 1 - prob1;
                            else
                                probFinale = prob1;
                        }
                        else // si 2 bornes
                        {
                            if (Borne1 < Borne2)//on remplace la prob1 par la prob 2 car elle est plus grande
                                prob1 = prob2;
                            if (Borne1 > Moyenne) // 
                                probFinale = 1 - prob1;
                            else
                                probFinale = prob1;
                        }
                        break;
                    }
                case 1: // < PROOF
                    {
                        if (!deuxBorne)
                        {
                            if (Borne1 < Moyenne)
                                probFinale = 1 - prob1;
                            else
                                probFinale = prob1;
                        }
                        else
                        {
                            if (Borne1 > Borne2)
                                prob1 = prob2;
                            if (Borne1 < Moyenne)
                                probFinale = 1 - prob1;
                            else
                                probFinale = prob1;

                        }
                        break;
                    }
                case 2: //< > PROOF
                    {
                        Gprob1 = prob1;
                        Gprob2 = prob2;
                        mettrePositif();
                        if ((Borne1 > Moyenne && Borne2 > Moyenne) || (Borne1 < Moyenne && Borne2 < Moyenne))
                        {
                            if (Borne1 > Borne2)
                                probFinale = Gprob1 - Gprob2;
                            else
                                probFinale = Gprob2 - Gprob1;
                        }
                        else if(Borne1 > Moyenne)
                        {
                            probFinale = Gprob1 - Gprob2;
                        }
                        else
                        {
                            probFinale = (Gprob2 - Gprob1);
                        }
                        
                        break;
                    }
            }
            probFinale = (float)Math.Round(100 * probFinale); // arrondi la probabilite finale
            TB_Resultat.Text = probFinale.ToString() + "%"; // affecte le resultat dans la text box
        }
        private void isolerPartieNombre(double CoteZ, bool deuxiemeProb) // Si cest la deuxieme prob ou non
        {
            if (deuxiemeProb)
            {
                Centieme2 = Math.Abs((Math.Truncate(100 * CoteZ) - (10 * Math.Truncate(10 * CoteZ))) / 100); // Ex: 12.35 - 12.3 = 0.05
                nbArrondisDixieme2 = Math.Abs((Math.Truncate(10 * CoteZ) / 10)); // Ex 3.32 --> 3.3
            }
            else
            {
                Centieme = Math.Abs((Math.Truncate(100 * CoteZ) - (10 * Math.Truncate(10 * CoteZ))) / 100); // Ex: 12.35 - 12.3 = 0.05
                nbArrondisDixieme = Math.Abs((Math.Truncate(10 * CoteZ) / 10)); // Ex 3.32 --> 3.3
            }

        }
        private void mettrePositif()
        {
            if (Borne1 < Moyenne) // verifier si la premiere borne 1 est plus grande que la moyenne
            {
                Gprob1 = 1 - Gprob1; //on affecter l'inverse ( 100% - prob1 )
            }
            if (Borne2 < Moyenne)// verifier si la premiere borne 2 est plus grande que la moyenne
            {
                Gprob2 = 1 - Gprob2; //on affecte l'inverse ( 100% - prob2 )
            }

        }
        private float trouverDansTableau(double centieme, double nbArrondisDixieme)
        {
            int posX = 0;
            int posY = 0;
            // Parcoure le tableau dans la premiere ligne pour trouver la position en X de la valeur
            for (int i = 1; i < TABWIDTH; ++i)
            {
                if (tab[0][i] == (float)centieme)
                {
                    posX = i;
                }
            }
            // Parcoure le tableau dans la colonne pour trouver la position en Y de la valeur
            for (int i = 1; i < tab.Count; ++i)
            {
                if (tab[i][0] == (float)nbArrondisDixieme)
                {
                    posY = i;
                }
            }
            return tab[posY][posX]; // retourne un tablea
        }
    }
}

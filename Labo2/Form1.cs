﻿using System;
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
        private double Borne2;

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
            ReadCoordinates(FileName);
            CMB_Prob.Items.Add(">");
            CMB_Prob.Items.Add("<");
            CMB_Prob.Items.Add("< >");
            CMB_Prob.Items.Add("> <");
        }

        private void BTN_Calculer_Click(object sender, EventArgs e)
        {
            bool choix2Bornes = false;

            if (CMB_Prob.SelectedIndex == 2 || CMB_Prob.SelectedIndex == 3)
                choix2Bornes = true;
            else
                choix2Bornes = false;

            if (TB_Prob.Text == "" || TB_Prob2.Text == "" && choix2Bornes)
            {
                MessageBox.Show("Erreur! Vous devez entrer deux probabilités pour exécuter cette comparaison.");
            }
            else
            {
                try
                {
                    // Premiere borne
                    Borne1 = Convert.ToDouble(TB_Prob.Text);
                    double Moyenne = Convert.ToDouble(TB_Moyenne.Text);
                    double EcartType = Convert.ToDouble(TB_EcartType.Text);
                    double CoteZ1 = (Borne1 - Moyenne) / EcartType;
                    float Prob1 = 0.0f;
                    // Deuxieme borne
                    double CoteZ2 = 0;
                    float Prob2 = 0.0f;

                    if (TB_Prob2.Text != "")
                    {
                        Borne2 = Convert.ToDouble(TB_Prob2.Text);
                        CoteZ2 = (Borne2 - Moyenne) / EcartType;
                    }


                    if (CoteZ1 >= 4 || CoteZ1 <= -4) // Maximum du tableau de la cote Z
                    {
                        MessageBox.Show("Erreur! La cote Z n'est pas calculable avec le tableau donné.");
                    }
                    else  // Si c'est une valeur 
                    {
                        isolerPartieNombre(CoteZ1, false);
                        // Si on a une deuxieme probabilité
                        if (Borne2 != 0)
                        {
                            isolerPartieNombre(CoteZ2, true);
                            Prob2 = trouverDansTableau(Centieme2, nbArrondisDixieme2);
                        }
                        Prob1 = trouverDansTableau(Centieme, nbArrondisDixieme);
                        CalculerProbabilite(Prob1, Prob2);
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
            if (CMB_Prob.SelectedIndex == 0) // >
            {
                if (prob1 < prob2 && prob1 != 0)
                    probFinale = 1 - prob2;
                else
                    probFinale = 1 - prob1;
            }
            else
            {
                if (CMB_Prob.SelectedIndex == 1) // <
                {
                    if (prob1 > prob2 && prob2 != 0)
                        probFinale = prob2;
                    else
                        probFinale = prob1;
                }
                else if (CMB_Prob.SelectedIndex == 2) // < >
                {
                    probFinale = (1 - prob2) + (1 - prob1);
                }
                else if (CMB_Prob.SelectedIndex == 3) // > <
                {
                    probFinale = prob1 - (1 - prob2);
                }
            }
            probFinale = (float)Math.Round(100 * probFinale);
            TB_Resultat.Text = probFinale.ToString() + "%";
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
            return tab[posY][posX];
        }
    }
}
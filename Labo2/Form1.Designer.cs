namespace Labo2
{
    partial class FunFunFun
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_Moyenne = new System.Windows.Forms.TextBox();
            this.TB_EcartType = new System.Windows.Forms.TextBox();
            this.TB_Resultat = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CMB_Prob = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TB_Borne1 = new System.Windows.Forms.TextBox();
            this.BTN_Calculer = new System.Windows.Forms.Button();
            this.TB_Borne2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Moyenne : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Écart type :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Comparaison : ";
            // 
            // TB_Moyenne
            // 
            this.TB_Moyenne.Location = new System.Drawing.Point(167, 10);
            this.TB_Moyenne.Name = "TB_Moyenne";
            this.TB_Moyenne.Size = new System.Drawing.Size(100, 20);
            this.TB_Moyenne.TabIndex = 3;
            // 
            // TB_EcartType
            // 
            this.TB_EcartType.Location = new System.Drawing.Point(167, 36);
            this.TB_EcartType.Name = "TB_EcartType";
            this.TB_EcartType.Size = new System.Drawing.Size(100, 20);
            this.TB_EcartType.TabIndex = 4;
            // 
            // TB_Resultat
            // 
            this.TB_Resultat.Location = new System.Drawing.Point(167, 171);
            this.TB_Resultat.Name = "TB_Resultat";
            this.TB_Resultat.ReadOnly = true;
            this.TB_Resultat.Size = new System.Drawing.Size(100, 20);
            this.TB_Resultat.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(106, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Résultat : ";
            // 
            // CMB_Prob
            // 
            this.CMB_Prob.FormattingEnabled = true;
            this.CMB_Prob.Location = new System.Drawing.Point(167, 62);
            this.CMB_Prob.Name = "CMB_Prob";
            this.CMB_Prob.Size = new System.Drawing.Size(100, 21);
            this.CMB_Prob.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(104, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Borne(s) :";
            // 
            // TB_Borne1
            // 
            this.TB_Borne1.Location = new System.Drawing.Point(63, 107);
            this.TB_Borne1.Name = "TB_Borne1";
            this.TB_Borne1.Size = new System.Drawing.Size(57, 20);
            this.TB_Borne1.TabIndex = 6;
            // 
            // BTN_Calculer
            // 
            this.BTN_Calculer.Location = new System.Drawing.Point(15, 169);
            this.BTN_Calculer.Name = "BTN_Calculer";
            this.BTN_Calculer.Size = new System.Drawing.Size(75, 23);
            this.BTN_Calculer.TabIndex = 8;
            this.BTN_Calculer.Text = "Calculer";
            this.BTN_Calculer.UseVisualStyleBackColor = true;
            this.BTN_Calculer.Click += new System.EventHandler(this.BTN_Calculer_Click);
            // 
            // TB_Borne2
            // 
            this.TB_Borne2.Location = new System.Drawing.Point(182, 107);
            this.TB_Borne2.Name = "TB_Borne2";
            this.TB_Borne2.Size = new System.Drawing.Size(70, 20);
            this.TB_Borne2.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Borne 1 :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(132, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Borne 2 :";
            // 
            // FunFunFun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 203);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TB_Borne2);
            this.Controls.Add(this.BTN_Calculer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TB_Borne1);
            this.Controls.Add(this.CMB_Prob);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TB_Resultat);
            this.Controls.Add(this.TB_EcartType);
            this.Controls.Add(this.TB_Moyenne);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FunFunFun";
            this.Text = "Application du plaisir";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_Moyenne;
        private System.Windows.Forms.TextBox TB_EcartType;
        private System.Windows.Forms.TextBox TB_Resultat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CMB_Prob;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TB_Borne1;
        private System.Windows.Forms.Button BTN_Calculer;
        private System.Windows.Forms.TextBox TB_Borne2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}


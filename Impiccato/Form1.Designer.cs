﻿namespace Impiccato
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonTentativo = new Button();
            listBox1 = new ListBox();
            buttonNuovaParola = new Button();
            textBoxTentativo = new TextBox();
            labelErroriRimasti = new Label();
            labelRisultato = new Label();
            SuspendLayout();
            // 
            // buttonTentativo
            // 
            buttonTentativo.Location = new Point(138, 41);
            buttonTentativo.Name = "buttonTentativo";
            buttonTentativo.Size = new Size(100, 23);
            buttonTentativo.TabIndex = 0;
            buttonTentativo.Text = "Fai un tentativo";
            buttonTentativo.UseVisualStyleBackColor = true;
            buttonTentativo.Click += buttonTentativo_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 12);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(120, 169);
            listBox1.TabIndex = 1;
            // 
            // buttonNuovaParola
            // 
            buttonNuovaParola.Location = new Point(12, 187);
            buttonNuovaParola.Name = "buttonNuovaParola";
            buttonNuovaParola.Size = new Size(120, 23);
            buttonNuovaParola.TabIndex = 2;
            buttonNuovaParola.Text = "Nuova parola";
            buttonNuovaParola.UseVisualStyleBackColor = true;
            buttonNuovaParola.Click += buttonNuovaParola_Click;
            // 
            // textBoxTentativo
            // 
            textBoxTentativo.Location = new Point(138, 12);
            textBoxTentativo.Name = "textBoxTentativo";
            textBoxTentativo.Size = new Size(100, 23);
            textBoxTentativo.TabIndex = 3;
            // 
            // labelErroriRimasti
            // 
            labelErroriRimasti.AutoSize = true;
            labelErroriRimasti.Location = new Point(138, 67);
            labelErroriRimasti.Name = "labelErroriRimasti";
            labelErroriRimasti.Size = new Size(38, 15);
            labelErroriRimasti.TabIndex = 4;
            labelErroriRimasti.Text = "label1";
            // 
            // labelRisultato
            // 
            labelRisultato.AutoSize = true;
            labelRisultato.Location = new Point(138, 82);
            labelRisultato.Name = "labelRisultato";
            labelRisultato.Size = new Size(38, 15);
            labelRisultato.TabIndex = 5;
            labelRisultato.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(571, 450);
            Controls.Add(labelRisultato);
            Controls.Add(labelErroriRimasti);
            Controls.Add(textBoxTentativo);
            Controls.Add(buttonNuovaParola);
            Controls.Add(listBox1);
            Controls.Add(buttonTentativo);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonTentativo;
        private ListBox listBox1;
        private Button buttonNuovaParola;
        private TextBox textBoxTentativo;
        private Label labelErroriRimasti;
        private Label labelRisultato;
    }
}
namespace ArkadiuszCarzynskiLab2Zadanie
{
    partial class FormMenu
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonStartGame = new System.Windows.Forms.Button();
            this.buttonInfo = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.pictureBoxMenuBackground = new System.Windows.Forms.PictureBox();
            this.buttonLoadGame = new System.Windows.Forms.Button();
            this.labelGameTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMenuBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStartGame
            // 
            this.buttonStartGame.BackColor = System.Drawing.Color.OliveDrab;
            this.buttonStartGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStartGame.Location = new System.Drawing.Point(568, 436);
            this.buttonStartGame.Name = "buttonStartGame";
            this.buttonStartGame.Size = new System.Drawing.Size(105, 39);
            this.buttonStartGame.TabIndex = 0;
            this.buttonStartGame.Text = "Nowa gra";
            this.buttonStartGame.UseVisualStyleBackColor = false;
            this.buttonStartGame.Click += new System.EventHandler(this.buttonStartGame_Click);
            // 
            // buttonInfo
            // 
            this.buttonInfo.BackColor = System.Drawing.Color.OliveDrab;
            this.buttonInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInfo.Location = new System.Drawing.Point(568, 530);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Size = new System.Drawing.Size(105, 39);
            this.buttonInfo.TabIndex = 1;
            this.buttonInfo.Text = "Jak grać";
            this.buttonInfo.UseVisualStyleBackColor = false;
            this.buttonInfo.Click += new System.EventHandler(this.buttonInfo_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.OliveDrab;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Location = new System.Drawing.Point(568, 577);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(105, 39);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "Wyjście";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // pictureBoxMenuBackground
            // 
            this.pictureBoxMenuBackground.BackgroundImage = global::ArkadiuszCarzynskiLab2Zadanie.Properties.Resources.background;
            this.pictureBoxMenuBackground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxMenuBackground.Location = new System.Drawing.Point(229, -8);
            this.pictureBoxMenuBackground.Name = "pictureBoxMenuBackground";
            this.pictureBoxMenuBackground.Size = new System.Drawing.Size(782, 530);
            this.pictureBoxMenuBackground.TabIndex = 3;
            this.pictureBoxMenuBackground.TabStop = false;
            // 
            // buttonLoadGame
            // 
            this.buttonLoadGame.BackColor = System.Drawing.Color.OliveDrab;
            this.buttonLoadGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoadGame.Location = new System.Drawing.Point(568, 483);
            this.buttonLoadGame.Name = "buttonLoadGame";
            this.buttonLoadGame.Size = new System.Drawing.Size(105, 39);
            this.buttonLoadGame.TabIndex = 4;
            this.buttonLoadGame.Text = "Wczytaj grę";
            this.buttonLoadGame.UseVisualStyleBackColor = false;
            this.buttonLoadGame.Click += new System.EventHandler(this.buttonLoadGame_Click);
            // 
            // labelGameTitle
            // 
            this.labelGameTitle.AutoSize = true;
            this.labelGameTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelGameTitle.ForeColor = System.Drawing.Color.Brown;
            this.labelGameTitle.Location = new System.Drawing.Point(518, 75);
            this.labelGameTitle.Name = "labelGameTitle";
            this.labelGameTitle.Size = new System.Drawing.Size(215, 39);
            this.labelGameTitle.TabIndex = 5;
            this.labelGameTitle.Text = "Papers, don\'t";
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.labelGameTitle);
            this.Controls.Add(this.buttonLoadGame);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonInfo);
            this.Controls.Add(this.buttonStartGame);
            this.Controls.Add(this.pictureBoxMenuBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Papers, dont";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMenuBackground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStartGame;
        private System.Windows.Forms.Button buttonInfo;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.PictureBox pictureBoxMenuBackground;
        private System.Windows.Forms.Button buttonLoadGame;
        private System.Windows.Forms.Label labelGameTitle;
    }
}


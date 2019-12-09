namespace ArkadiuszCarzynskiLab2Zadanie
{
    partial class FormHowToPlay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonBackToMenu = new System.Windows.Forms.Button();
            this.buttonNextPicture = new System.Windows.Forms.Button();
            this.pictureBoxHow1 = new System.Windows.Forms.PictureBox();
            this.labelGameDestination = new System.Windows.Forms.Label();
            this.labelPensionerInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHow1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBackToMenu
            // 
            this.buttonBackToMenu.BackColor = System.Drawing.Color.OliveDrab;
            this.buttonBackToMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBackToMenu.Location = new System.Drawing.Point(568, 604);
            this.buttonBackToMenu.Name = "buttonBackToMenu";
            this.buttonBackToMenu.Size = new System.Drawing.Size(136, 57);
            this.buttonBackToMenu.TabIndex = 0;
            this.buttonBackToMenu.Text = "Wróc do menu";
            this.buttonBackToMenu.UseVisualStyleBackColor = false;
            this.buttonBackToMenu.Click += new System.EventHandler(this.buttonBackToMenu_Click);
            // 
            // buttonNextPicture
            // 
            this.buttonNextPicture.BackColor = System.Drawing.Color.OliveDrab;
            this.buttonNextPicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNextPicture.Location = new System.Drawing.Point(995, 545);
            this.buttonNextPicture.Name = "buttonNextPicture";
            this.buttonNextPicture.Size = new System.Drawing.Size(84, 31);
            this.buttonNextPicture.TabIndex = 2;
            this.buttonNextPicture.Text = "Następny";
            this.buttonNextPicture.UseVisualStyleBackColor = false;
            this.buttonNextPicture.Click += new System.EventHandler(this.buttonNextPicture_Click);
            // 
            // pictureBoxHow1
            // 
            this.pictureBoxHow1.BackgroundImage = global::ArkadiuszCarzynskiLab2Zadanie.Properties.Resources.howToPlay1;
            this.pictureBoxHow1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxHow1.Location = new System.Drawing.Point(86, 32);
            this.pictureBoxHow1.Name = "pictureBoxHow1";
            this.pictureBoxHow1.Size = new System.Drawing.Size(1100, 566);
            this.pictureBoxHow1.TabIndex = 1;
            this.pictureBoxHow1.TabStop = false;
            // 
            // labelGameDestination
            // 
            this.labelGameDestination.AutoSize = true;
            this.labelGameDestination.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelGameDestination.ForeColor = System.Drawing.Color.White;
            this.labelGameDestination.Location = new System.Drawing.Point(239, 634);
            this.labelGameDestination.Name = "labelGameDestination";
            this.labelGameDestination.Size = new System.Drawing.Size(234, 18);
            this.labelGameDestination.TabIndex = 3;
            this.labelGameDestination.Text = "Celem gry jest zdobycie 10 tysięcy";
            // 
            // labelPensionerInfo
            // 
            this.labelPensionerInfo.AutoSize = true;
            this.labelPensionerInfo.BackColor = System.Drawing.Color.Black;
            this.labelPensionerInfo.ForeColor = System.Drawing.Color.White;
            this.labelPensionerInfo.Location = new System.Drawing.Point(239, 604);
            this.labelPensionerInfo.Name = "labelPensionerInfo";
            this.labelPensionerInfo.Size = new System.Drawing.Size(159, 17);
            this.labelPensionerInfo.TabIndex = 4;
            this.labelPensionerInfo.Text = "Wiek emerytalny >= 65 !";
            // 
            // FormHowToPlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.labelPensionerInfo);
            this.Controls.Add(this.labelGameDestination);
            this.Controls.Add(this.buttonNextPicture);
            this.Controls.Add(this.pictureBoxHow1);
            this.Controls.Add(this.buttonBackToMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormHowToPlay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormHowToPlay";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHow1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBackToMenu;
        private System.Windows.Forms.PictureBox pictureBoxHow1;
        private System.Windows.Forms.Button buttonNextPicture;
        private System.Windows.Forms.Label labelGameDestination;
        private System.Windows.Forms.Label labelPensionerInfo;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArkadiuszCarzynskiLab2Zadanie
{
    public partial class FormHowToPlay : Form
    {
        // zmienna przechowująca ilość obrazków 
        private int amount = 5;
        // zmienna przechowująca index obrazka
        private int index = 1;

        /// <summary>
        /// Konstruktor klasy FormHowToPlay
        /// </summary>
        public FormHowToPlay()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Funkcja obsługująca przycisk odpowiedzialny za pokazanie kolejnego obrazka
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNextPicture_Click(object sender, EventArgs e)
        {
            index = (index++ % amount+1);

            switch (index)
            {
                case 1:
                    {
                        pictureBoxHow1.BackgroundImage = ArkadiuszCarzynskiLab2Zadanie.Properties.Resources.howToPlay1;
                        break;

                    }
                case 2:
                    {
                        pictureBoxHow1.BackgroundImage = ArkadiuszCarzynskiLab2Zadanie.Properties.Resources.howToPlay2;
                        break;
                    }
                case 3:
                    {
                        pictureBoxHow1.BackgroundImage = ArkadiuszCarzynskiLab2Zadanie.Properties.Resources.howToPlay3;
                        break;
                    }
                case 4:
                    {
                        pictureBoxHow1.BackgroundImage = ArkadiuszCarzynskiLab2Zadanie.Properties.Resources.howToPlay4;
                        break;
                    }
                case 5:
                    {
                        pictureBoxHow1.BackgroundImage = ArkadiuszCarzynskiLab2Zadanie.Properties.Resources.howToPlay5;
                        break;
                    }
            }
            
        }

        /// <summary>
        /// Funkcja obsługująca przycisk odpowiedzialny za powrót do menu głownego
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBackToMenu_Click(object sender, EventArgs e)
        {
            FormMenu formMenu = new FormMenu();
            this.Close();
            formMenu.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArkadiuszCarzynskiLab2Zadanie
{
    public partial class FormMenu : Form
    {
        /// <summary>
        /// Konstruktor klasy FormMenu
        /// </summary>
        public FormMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Funkcja obsługująca przycisk odpowiedzialny zryrozpoczęcie gyr
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormGame game = new FormGame(1,300,0,0);
            game.Show();
        }

        /// <summary>
        /// Funkcja obsługująca przycisk odpowiedzialny za wyjście z gry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Funkcja obsługująca przycisk odpowiedzialny za pokazanie informacji o grze
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonInfo_Click(object sender, EventArgs e)
        {
            FormHowToPlay formHowToPlay = new FormHowToPlay();
            this.Hide();
            formHowToPlay.Show();

        }

        /// <summary>
        /// Funkcja obsługująca przycisk odpowiedzialny za wczytanie zapisanej gry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLoadGame_Click(object sender, EventArgs e)
        {
            this.Hide();
            string line;
            double cash;
            int dayCounter, amountOfPills;

            using (StreamReader sr = new StreamReader("savedGame.txt"))
            {
                line = sr.ReadLine();
                dayCounter = Int32.Parse(line);

                line = sr.ReadLine();
                cash = Int32.Parse(line);

                line = sr.ReadLine();
                amountOfPills = Int32.Parse(line);
            }

            FormGame game = new FormGame(dayCounter, cash, amountOfPills, 0);
            game.Show();

        }
    }
}

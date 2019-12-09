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
    public partial class FormHome : Form
    {
        // lista obiektów
        List<Person> people;
        Person person;
        private int dayCounter, amountOfPills;
        private double cash, bonusFromGod;
        // zmienna przechowująca indeks
        private int index = 0;

        /// <summary>
        /// Konstruktor klasy FormHome
        /// </summary>
        /// <param name="people"></param>
        /// <param name="dayCounter"></param>
        /// <param name="cash"></param>
        /// <param name="amountOfPills"></param>
        public FormHome(List<Person>people, int dayCounter, double cash, int amountOfPills)
        {
            InitializeComponent();
            labelAccidentsInfoHome.Visible = labelAccidentsInfoHome.Enabled = false;
            labelDayHomeInfo.Text = "Dzień " + dayCounter.ToString() + " minął...";
            this.people = people;
            this.dayCounter = dayCounter;
            this.cash = cash;
            this.amountOfPills = amountOfPills;
            person = people[index];
            LoadOnScreen();
        }

        /// <summary>
        /// Funkcja obsługująca przycisk odpowiedzialny za zakończenie dnia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEndDay_Click(object sender, EventArgs e)
        {
            people.Clear();
            bonusFromGod = 0;
            dayCounter++;
            FormGame fG = new FormGame(dayCounter, cash, amountOfPills, bonusFromGod);
            this.Close();
            fG.Show();
            
            
        }

        /// <summary>
        /// Funkcja obsługująca załadowanie obywatela na ekran
        /// </summary>
        public void LoadOnScreen()
        {
            labelFirstNameCollection.Text = "Imię: " + person.GetFirstName();
            labelLastNameCollection.Text = "Nazwisko: " + person.GetLastName();
            labelAgeCollection.Text = "Wiek: " + person.GetAge().ToString();
            labelHeightCollection.Text = "Wzrost: " + person.GetHeight().ToString();
            labelWeightCollection.Text = "Waga: " + person.GetWeight().ToString();
            labelTypeCollection.Text = person.GetType().ToString().Substring(30);
            if(dayCounter == 1)
            {
                labelAccidentsInfoHome.Visible = labelAccidentsInfoHome.Enabled = true;
            }
            if(dayCounter == 2)
            {
                labelAccidentsInfoHome.Visible = labelAccidentsInfoHome.Enabled = true;
                labelAccidentsInfoHome.Text = "Choroby i awarie dostępne już od jutra!";
            }
        }

        /// <summary>
        /// Funkcja obsługująca przycisk odpowiedzialny za zapis gry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSaveGame_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("savedGame.txt"))
            {
                sw.WriteLine(dayCounter+1);
                sw.WriteLine(cash);
                sw.WriteLine(amountOfPills);

            }
            MessageBox.Show("Zapisano stan gry!");
        }

        /// <summary>
        /// Funkcja obsługująca przycisk odpowiedzialny za wyjście z gry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExitGameFromHome_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Funkcja obsługująca przycisk odpowiedzialny za pokazanie następnego obywatela
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNext_Click(object sender, EventArgs e)
        {
            person = people[Math.Abs(index++ % people.Count)];
            LoadOnScreen();
        }

        /// <summary>
        /// Funkcja obsługująca przycisk odpowiedzialny za pokazanie poprzedniego klienta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            person = people[Math.Abs(index++ % people.Count)];
            LoadOnScreen();
        }
    }
}

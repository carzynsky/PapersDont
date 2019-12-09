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
    public partial class FormGame : Form
    {
        // zmienne przechowujące informacje o godzinie, minucie i indeksie dnia(potrzebne do tablicy)
        private int hours = 7, minutes = 0, dayIndex = 0;
        // tablica przechowująca nazwy dni tygodnia
        private string[] day = { "Poniedzialek", "Wtorek", "Sroda", "Czwartek", "Piatek", "Sobota", "Niedziela" };
        // lista wczytanych z plikow tekstowych imion i nazwisk
        List<string> firstNames, lastNames;
        Person person;
        Accident accident;
        // lista obietkow
        private List<Person> people = new List<Person>();
        // zmienna przechowująca ilość pieniędzy
        public double cash;
        // zmienna przechowująca bonus od Boga
        public double bonusFromGod;
        // zmienna przechowująca liczbę tabletek
        private int amountOfPills;
        // zmienna przechowująca który dzień
        private int dayCounter;
        // zmienne przechowujące składowe działania matematycznego i rozwiązanie
        private int numberFirst, numberSecond, solutionNumber;

        // tablica przechowująca typy klas
        private string[] oridinanceTypeThisDay = { "Priest", "Worker", "Tourist", "Trader", "Politician" };
        // zmienna przechowująca nazwę typu klasy, do której będzie przypisane rozporządzenie niewpuszczania
        private string ordinanceDecided;

        /// <summary>
        /// Konstruktor klasy FormGame
        /// </summary>
        /// <param name="dayCounter"></param>
        /// <param name="cash"></param>
        /// <param name="amountOfPills"></param>
        /// <param name="bonusFromGod"></param>
        public FormGame(int dayCounter, double cash, int amountOfPills, double bonusFromGod)
        {
            InitializeComponent();
            this.dayCounter = dayCounter;
            this.cash = cash;
            this.amountOfPills = amountOfPills;
            this.bonusFromGod = bonusFromGod;
            people.Clear();
            labelHourInGame.Text = hours.ToString();
            labelDayInGame.Text = day[(dayCounter-1)%7];
            labelDayCounter.Text = "Dzień " + dayCounter.ToString();
            labelNumberOfPills.Text = "Liczba tabletek: " + amountOfPills.ToString();
            LoadNames();
            RandomType();
            RandomOrdinance();
            people.Add(person);
            PutOnScreen(person);
            timerInGame.Interval = 200;
            timerInGame.Start();
            timerPersonTime.Start();
            timerAccident.Start();
        }

        /// <summary>
        /// Funkcja losująca rozporządzenie
        /// </summary>
        public void RandomOrdinance()
        {
            Random random = new Random();
            ordinanceDecided = oridinanceTypeThisDay[random.Next(0, oridinanceTypeThisDay.Length)];
            switch(ordinanceDecided)
            {
                case "Priest":
                default:
                    {
                        labelOrdinance.Text = "Dzisiaj nie wpuszczać: Księży";
                        break;
                    }
                case "Worker":
                    {
                        labelOrdinance.Text = "Dzisiaj nie wpuszczać: Robotników";
                        break;
                    }
                case "Tourist":
                    {
                        labelOrdinance.Text = "Dzisiaj nie wpuszczać: Turystów";
                        break;
                    }
                case "Trader":
                    {
                        labelOrdinance.Text = "Dzisiaj nie wpuszczać: Handlowców";
                        break;
                    }
                case "Politician":
                    {
                        labelOrdinance.Text = "Dzisiaj nie wpuszczać: Polityków";
                        break;
                    }
            }

        }

        /// <summary>
        /// Funkcja losująca typ klasy
        /// </summary>
        public void RandomType()
        {
            Random random = new Random();
            switch(random.Next(0,5))
            {
                case 0:
                    {
                        person = new Priest(RandomFirstName(), RandomLastName(), RandomAge(), RandomWeight(), RandomHeight());
                        labelRole.Text = "Ksiądz";
                        break;
                    }
                case 1:
                    {
                        person = new Worker(RandomFirstName(), RandomLastName(), RandomAge(), RandomWeight(), RandomHeight());
                        labelRole.Text = "Robotnik";
                        break;
                    }
                case 2:
                    {
                        person = new Politician(RandomFirstName(), RandomLastName(), RandomAge(), RandomWeight(), RandomHeight(),RandomPoliticsView());
                        labelRole.Text = "Polityk";
                        break;
                    }
                case 3:
                    {
                        person = new Tourist(RandomFirstName(), RandomLastName(), RandomAge(), RandomWeight(), RandomHeight());
                        labelRole.Text = "Turysta";
                        break;
                    }
                case 4:
                default:
                    {
                        person = new Trader(RandomFirstName(), RandomLastName(), RandomAge(), RandomWeight(), RandomHeight(), RandomWeightOfPackage());
                        labelRole.Text = "Handlarz";
                        break;
                    }


            }
        }

        /// <summary>
        /// Funkcja losująca wagę paczki
        /// </summary>
        /// <returns></returns>
        public double RandomWeightOfPackage()
        {
            Random random = new Random();
            return random.Next(1, 4);
        }

        /// <summary>
        /// Funkcja wczytująca imiona i nazwiska z plików tekstowych
        /// </summary>
        public void LoadNames()
        {
            try
            {
                string line;
                firstNames = new List<string>();
                lastNames = new List<string>();

                using (StreamReader sr = new StreamReader("firstNames.txt"))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        firstNames.Add(line);
                    }
                }
                using(StreamReader sr = new StreamReader("lastNames.txt"))
                {
                    while((line = sr.ReadLine()) != null)
                    {
                        lastNames.Add(line);
                    }
                }
                        
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }
        }

        /// <summary>
        /// Funkcja umieszczająca dane obywatela na ekran
        /// </summary>
        /// <param name="person"></param>
        public void PutOnScreen(Person person)
        {
            labelPersonFirstName.Text = person.GetFirstName();
            labelPersonLastName.Text = person.GetLastName();
            labelAge.Text = person.GetAge().ToString();
            labelHeight.Text = person.GetHeight().ToString();
            labelWeight.Text = person.GetWeight().ToString();          
            textBoxPersonGreeting.Text = person.Greeting();

            if(person is Priest)
            {
                labelPrayForMoney.Enabled = true;
                labelPrayForTime.Enabled = true;
                labelViewsInfo.Visible = false;
            }
            if(person is Politician)
            {
                labelPrayForMoney.Enabled = false;
                labelPrayForTime.Enabled = false;
                labelViewsInfo.Visible = true;
                Politician politician = (Politician)person;
                labelViewsInfo.Text = politician.Views();
            }
            else if(person is Worker)
            {
                labelPrayForMoney.Enabled = false;
                labelPrayForTime.Enabled = false;
                labelViewsInfo.Visible = false;
            }
            else if(person is Trader)
            {
                labelPrayForMoney.Enabled = false;
                labelPrayForTime.Enabled = false;
                labelViewsInfo.Visible = false;
            }
            else if(person is Tourist)
            {
                labelPrayForMoney.Enabled = false;
                labelPrayForTime.Enabled = false; 
                labelViewsInfo.Visible = false;

            }
        }

        /// <summary>
        /// Funkcja losująca poglądy polityczne
        /// </summary>
        /// <returns></returns>
        public bool RandomPoliticsView()
        {
            Random random = new Random();
            if (random.Next(0, 2) == 1) return true;
            else return false;
        }

        /// <summary>
        /// Funkcja losująca imię obywatela
        /// </summary>
        /// <returns></returns>
        public string RandomFirstName()
        {
            Random random = new Random();
            return firstNames.ElementAt(random.Next(0, firstNames.Count));
        }

        /// <summary>
        /// Funkcja losująca nazwisko obywatela
        /// </summary>
        /// <returns></returns>
        public string RandomLastName()
        {
            Random random = new Random();
            return lastNames.ElementAt(random.Next(0, lastNames.Count));
        }

        /// <summary>
        /// Funkcja losująca wiek
        /// </summary>
        /// <returns></returns>
        public int RandomAge()
        {
            Random random = new Random();
            return random.Next(18, 90);
        }

        /// <summary>
        /// Funkcja losująca wzrost
        /// </summary>
        /// <returns></returns>
        public int RandomHeight()
        {
            Random random = new Random();
            return random.Next(150, 200);
        }


        /// <summary>
        /// Funkcja obsługująca wpuszczenie obywatela
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPass_Click(object sender, EventArgs e)
        {
            string sub = person.GetType().ToString().Substring(30);
            bool isPensioner = false;
            if(person.GetAge() >= 65)
            {
                isPensioner = true;
            }

            switch (sub)
            {
                case "Priest" when radioButtonPriest.Checked == true
                            && textBoxFirstName.Text == person.GetFirstName()
                            && textBoxLastName.Text == person.GetLastName()
                            && textBoxAge.Text == person.GetAge().ToString()
                            && textBoxHeight.Text == person.GetHeight().ToString()
                            && textBoxWeight.Text == person.GetWeight().ToString()
                            && (checkBoxIsPensioner.Checked == isPensioner)
                            && ordinanceDecided != sub:
                    {
                            timerInGame.Stop();
                            timerPersonTime.Stop();
                        timerAccident.Stop();
                        MessageBox.Show("Brawo!");
                            cash += person.Pay();
                            timerInGame.Start();
                            timerPersonTime.Start();
                        timerAccident.Start();
                        break;
                    }
                case "Priest" when radioButtonPriest.Checked == false:
                    {
                        timerInGame.Stop();
                        timerPersonTime.Stop();
                        timerAccident.Stop();
                        MessageBox.Show("Dostałeś karę za popełniony błąd");
                        cash -= 100;
                        timerInGame.Start();
                        timerPersonTime.Start();
                        timerAccident.Start();
                        break;
                    }
                case "Worker" when radioButtonWorker.Checked == true
                            && textBoxFirstName.Text == person.GetFirstName()
                            && textBoxLastName.Text == person.GetLastName()
                            && textBoxAge.Text == person.GetAge().ToString()
                            && textBoxHeight.Text == person.GetHeight().ToString()
                            && textBoxWeight.Text == person.GetWeight().ToString()
                            && (checkBoxIsPensioner.Checked == isPensioner)
                            && ordinanceDecided != sub:
                    {
                            timerInGame.Stop();
                            timerPersonTime.Stop();
                        timerAccident.Stop();
                        MessageBox.Show("Brawo!");
                            cash += person.Pay();
                            timerInGame.Start();
                            timerPersonTime.Start();
                        timerAccident.Start();
                        break;
                    }
                case "Worker" when radioButtonWorker.Checked == false:
                    {
                        timerInGame.Stop();
                        timerPersonTime.Stop();
                        timerAccident.Stop();
                        MessageBox.Show("Dostałeś karę za popełniony błąd");
                        cash -= 100;
                        timerInGame.Start();
                        timerAccident.Start();
                        timerPersonTime.Start();
                        break;
                    }
                case "Tourist" when radioButtonTourist.Checked == true
                            && textBoxFirstName.Text == person.GetFirstName()
                            && textBoxLastName.Text == person.GetLastName()
                            && textBoxAge.Text == person.GetAge().ToString()
                            && textBoxHeight.Text == person.GetHeight().ToString()
                            && textBoxWeight.Text == person.GetWeight().ToString()
                            && (checkBoxIsPensioner.Checked == isPensioner)
                            && ordinanceDecided != sub:
                    {
                        timerInGame.Stop();
                        timerPersonTime.Stop();
                        timerAccident.Stop();
                        MessageBox.Show("Brawo");
                        cash += person.Pay();
                        timerInGame.Start();
                        timerPersonTime.Start();
                        timerAccident.Start();
                        break;
                    }
                case "Tourist" when radioButtonTourist.Checked == false:
                    {
                        timerInGame.Stop();
                        timerPersonTime.Stop();
                        timerAccident.Stop();
                        MessageBox.Show("Dostałeś karę za popełniony błąd");
                        cash -= 100;
                        timerInGame.Start();
                        timerPersonTime.Start();
                        timerAccident.Start();
                        break;
                    }
                case "Politician" when radioButtonPolitician.Checked == true
                            && textBoxFirstName.Text == person.GetFirstName()
                            && textBoxLastName.Text == person.GetLastName()
                            && textBoxAge.Text == person.GetAge().ToString()
                            && textBoxHeight.Text == person.GetHeight().ToString()
                            && textBoxWeight.Text == person.GetWeight().ToString()
                            && (checkBoxIsPensioner.Checked == isPensioner)
                            && ordinanceDecided != sub:
                    {
                        timerInGame.Stop();
                        timerPersonTime.Stop();
                        timerAccident.Stop();
                        MessageBox.Show("Brawo!");
                        cash += person.Pay();
                        timerInGame.Start();
                        timerPersonTime.Start();
                        timerAccident.Start();
                        break;
                    
                    }
                case "Politician" when radioButtonTrader.Checked == false:
                    {
                        timerInGame.Stop();
                        timerPersonTime.Stop();
                        timerAccident.Stop();
                        MessageBox.Show("Dostałeś karę za popełniony błąd");
                        cash -= 100;
                        timerInGame.Start();
                        timerPersonTime.Start();
                        timerAccident.Start();
                        break;
                    }
                case "Trader" when radioButtonTrader.Checked == true
                            && textBoxFirstName.Text == person.GetFirstName()
                            && textBoxLastName.Text == person.GetLastName()
                            && textBoxAge.Text == person.GetAge().ToString()
                            && textBoxWeight.Text == person.GetWeight().ToString()
                            && (checkBoxIsPensioner.Checked == isPensioner)
                            && ordinanceDecided != sub:
                    {
                        timerInGame.Stop();
                        timerPersonTime.Stop();
                        timerAccident.Stop();
                        MessageBox.Show("Brawo!");
                        cash += person.Pay();
                        timerInGame.Start();
                        timerPersonTime.Start();
                        timerAccident.Start();
                        break;
                    }
                case "Trader" when radioButtonTrader.Checked == false:
                    {
                        timerInGame.Stop();
                        timerPersonTime.Stop();
                        timerAccident.Stop();
                        MessageBox.Show("Dostałeś karę za popełniony błąd");
                        cash -= 100;
                        timerInGame.Start();
                        timerPersonTime.Start();
                        timerAccident.Start();
                        break;
                    }
                default:
                    {
                        timerInGame.Stop();
                        timerPersonTime.Stop();
                        timerAccident.Stop();
                        MessageBox.Show("Dostałeś karę za popełniony błąd");
                        cash -= 100;
                        timerInGame.Start();
                        timerPersonTime.Start();
                        timerAccident.Start();
                        break;
                    }
            }
            cash += bonusFromGod;
            progressBarPersonTimer.Value = 100;
     
           
        }

        /// <summary>
        /// Funkcja obsługująca niewpuszczenie obywatela
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDontPass_Click(object sender, EventArgs e)
        {
            string sub = person.GetType().ToString().Substring(30);
            bool isPensioner = false;
            if (person.GetAge() >= 65)
            {
                isPensioner = true;
            }

            switch (sub)
            {
                case "Priest" when radioButtonPriest.Checked == true
                            && textBoxFirstName.Text == person.GetLastName()
                            && textBoxAge.Text == person.GetAge().ToString()
                            && textBoxHeight.Text == person.GetHeight().ToString()
                            && textBoxWeight.Text == person.GetWeight().ToString()
                            && (checkBoxIsPensioner.Checked == isPensioner)
                            && ordinanceDecided == sub:
                    {
                        timerInGame.Stop();
                        timerPersonTime.Stop();
                        timerAccident.Stop();
                        MessageBox.Show("Brawo!");
                        cash += person.Pay();
                        timerInGame.Start();
                        timerPersonTime.Start();
                        timerAccident.Start();
                        break;
                    }
                case "Priest" when radioButtonPriest.Checked == false:
                    {
                        timerInGame.Stop();
                        timerPersonTime.Stop();
                        timerAccident.Stop();
                        MessageBox.Show("Dostałeś karę za popełniony błąd");
                        cash -= 100;
                        timerInGame.Start();
                        timerPersonTime.Start();
                        timerAccident.Start();
                        break;
                    }
                case "Worker" when radioButtonWorker.Checked == true
                            && textBoxFirstName.Text == person.GetFirstName()
                            && textBoxLastName.Text == person.GetLastName()
                            && textBoxAge.Text == person.GetAge().ToString()
                            && textBoxHeight.Text == person.GetHeight().ToString()
                            && textBoxWeight.Text == person.GetWeight().ToString()
                            && (checkBoxIsPensioner.Checked == isPensioner)
                            && ordinanceDecided == sub:
                    {
                        timerInGame.Stop();
                        timerPersonTime.Stop();
                        timerAccident.Stop();
                        MessageBox.Show("Brawo!");
                        cash += person.Pay();
                        timerInGame.Start();
                        timerPersonTime.Start();
                        timerAccident.Start();
                        break;
                    }
                case "Worker" when radioButtonWorker.Checked == false:
                    {
                        timerInGame.Stop();
                        timerPersonTime.Stop();
                        timerAccident.Stop();
                        MessageBox.Show("Dostałeś karę za popełniony błąd");
                        cash -= 100;
                        timerInGame.Start();
                        timerAccident.Start();
                        timerPersonTime.Start();
                        break;
                    }
                case "Tourist" when radioButtonTourist.Checked == true
                            && textBoxFirstName.Text == person.GetFirstName()
                            && textBoxLastName.Text == person.GetLastName()
                            && textBoxAge.Text == person.GetAge().ToString()
                            && textBoxHeight.Text == person.GetHeight().ToString()
                            && textBoxWeight.Text == person.GetWeight().ToString()
                            && (checkBoxIsPensioner.Checked == isPensioner)
                            && ordinanceDecided == sub:
                    {
                        timerInGame.Stop();
                        timerPersonTime.Stop();
                        timerAccident.Stop();
                        MessageBox.Show("Brawo");
                        cash += person.Pay();
                        timerInGame.Start();
                        timerPersonTime.Start();
                        timerAccident.Start();
                        break;
                    }
                case "Tourist" when radioButtonTourist.Checked == false:
                    {
                        timerInGame.Stop();
                        timerPersonTime.Stop();
                        timerAccident.Stop();
                        MessageBox.Show("Dostałeś karę za popełniony błąd");
                        cash -= 100;
                        timerInGame.Start();
                        timerPersonTime.Start();
                        timerAccident.Start();
                        break;
                    }
                case "Politician" when radioButtonPolitician.Checked == true
                            && textBoxFirstName.Text == person.GetFirstName()
                            && textBoxLastName.Text == person.GetLastName()
                            && textBoxAge.Text == person.GetAge().ToString()
                            && textBoxHeight.Text == person.GetHeight().ToString()
                            && textBoxWeight.Text == person.GetWeight().ToString()
                            && (checkBoxIsPensioner.Checked == isPensioner)
                            && ordinanceDecided == sub:
                    {
                        timerInGame.Stop();
                        timerPersonTime.Stop();
                        timerAccident.Stop();
                        MessageBox.Show("Brawo!");
                        cash += person.Pay();
                        timerInGame.Start();
                        timerPersonTime.Start();
                        timerAccident.Start();
                        break;

                    }
                case "Politician" when radioButtonTrader.Checked == false:
                    {
                        timerInGame.Stop();
                        timerPersonTime.Stop();
                        timerAccident.Stop();
                        MessageBox.Show("Dostałeś karę za popełniony błąd");
                        cash -= 100;
                        timerInGame.Start();
                        timerPersonTime.Start();
                        timerAccident.Start();
                        break;
                    }
                case "Trader" when radioButtonTrader.Checked == true
                            && textBoxFirstName.Text == person.GetFirstName()
                            && textBoxLastName.Text == person.GetLastName()
                            && textBoxAge.Text == person.GetAge().ToString()
                            && textBoxWeight.Text == person.GetWeight().ToString()
                            && (checkBoxIsPensioner.Checked == isPensioner)
                            && ordinanceDecided == sub:
                    {
                        timerInGame.Stop();
                        timerPersonTime.Stop();
                        timerAccident.Stop();
                        MessageBox.Show("Brawo!");
                        cash += person.Pay();
                        timerInGame.Start();
                        timerPersonTime.Start();
                        timerAccident.Start();
                        break;
                    }
                case "Trader" when radioButtonTrader.Checked == false:
                    {
                        timerInGame.Stop();
                        timerPersonTime.Stop();
                        timerAccident.Stop();
                        MessageBox.Show("Dostałeś karę za popełniony błąd");
                        cash -= 100;
                        timerInGame.Start();
                        timerPersonTime.Start();
                        timerAccident.Start();
                        break;
                    }
                default:
                    {
                        timerInGame.Stop();
                        timerPersonTime.Stop();
                        timerAccident.Stop();
                        MessageBox.Show("Dostałeś karę za popełniony błąd");
                        cash -= 100;
                        timerInGame.Start();
                        timerPersonTime.Start();
                        timerAccident.Start();
                        break;
                    }
            }
            cash += bonusFromGod;
            progressBarPersonTimer.Value = 100;

        }

        /// <summary>
        /// Funkcja obsługująca modlitwę o pieniądze
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelPrayForMoney_Click(object sender, EventArgs e)
        {
            Priest priest = (Priest)person;
            if(priest.PrayForMoreMoney() == true)
            {
                MessageBox.Show("UDALO SIE!");
                bonusFromGod += 300;
            }
            else
            {
                MessageBox.Show("Uraziłeś Boga!");
                bonusFromGod -= 100;
            }
        }

        /// <summary>
        /// Funkcja obsługująca modlitwę o wolniejszy czas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelPrayForTime_Click(object sender, EventArgs e)
        {
            Priest priest = (Priest)person;
            if (priest.PrayForMoreMoney() == true)
            {
                MessageBox.Show("UDALO SIE!");
                timerInGame.Interval -= 20;
            }
            else
            {
                MessageBox.Show("Uraziłeś Boga!");
                timerInGame.Interval += 50;
            }
        }

        /// <summary>
        /// Funkcja obsługująca tick zegara odpowiedzialnego za awarie/choroby
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerAccident_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            int tmp = random.Next(0, 2);
            if(dayCounter > 2)
            {
                if (tmp == 0)
                {
                    accident = new PowerFailure();
                    random = new Random();
                    if (random.Next(1, 101) <= accident.GetPossibility())
                    {
                        timerInGame.Stop();
                        timerPersonTime.Stop();
                        timerAccident.Stop();
                        MessageBox.Show(accident.Description());
                        PowerFailure powerFailure = (PowerFailure)accident;
                        labelNumber1.Visible = labelNumber1.Enabled = true;
                        labelNumber1.Text = powerFailure.GetNumber1().ToString();
                        numberFirst = powerFailure.GetNumber1();

                        labelNumber2.Visible = labelNumber2.Enabled = true;
                        labelNumber2.Text = powerFailure.GetNumber2().ToString();
                        numberSecond = powerFailure.GetNumber2();

                        solutionNumber = powerFailure.GetSolution();

                        labelOperand.Visible = labelOperand.Enabled = true;

                        textBoxAnswer.Enabled = textBoxAnswer.Visible = true;
                        progressBarMath.Enabled = progressBarMath.Visible = true;
                        buttonConfirmAnswer.Enabled = buttonConfirmAnswer.Visible = true;

                        timerMath.Start();

                    }
                }
                else
                {
                    accident = new Illness();
                    random = new Random();
                    if (random.Next(1, 101) <= accident.GetPossibility())
                    {
                        timerInGame.Stop();
                        timerPersonTime.Stop();
                        timerAccident.Stop();
                        MessageBox.Show(accident.Description());
                        if (amountOfPills >= 1)
                        {
                            amountOfPills--;
                            MessageBox.Show("Bierzesz tabletkę! Możesz wracać do pracy");
                        }
                        if (amountOfPills == 0)
                        {
                            cash -= accident.GetPenalty();
                            MessageBox.Show("Musisz wcześniej wyjść z pracy z powodu choroby! Dostajesz karę pieniężną.");
                            FormHome fH = new FormHome(people, dayCounter, cash, amountOfPills);
                            this.Close();
                            fH.Show();

                        }

                    }

                }
            }
            
        }

        /// <summary>
        /// Funkcja obsługująca przycisk pójścia do apteki
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGoToPharmacy_Click(object sender, EventArgs e)
        {
            labelPillsPriceInfo.Enabled = labelPillsPriceInfo.Visible = true;
            labelAmountOfPillsToBuyInfo.Enabled = labelAmountOfPillsToBuyInfo.Visible = true;
            textBoxNumberOfPills.Visible = textBoxNumberOfPills.Enabled = true;
            buttonBuyPills.Visible = buttonBuyPills.Enabled = true;

        }

        /// <summary>
        /// Funkcja obsługująca przycisk zakupu tabletek
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBuyPills_Click(object sender, EventArgs e)
        {
            if(textBoxNumberOfPills.Text == "")
            {
                textBoxNumberOfPills.Text = "0";
            }
            if(Int32.Parse(textBoxNumberOfPills.Text) < 0)
            {
                textBoxNumberOfPills.Text = "0";
            }
            if(cash>=400*Int32.Parse(textBoxNumberOfPills.Text))
            {
                cash -= 400 * Int32.Parse(textBoxNumberOfPills.Text);
                labelCash.Text = cash.ToString();
                amountOfPills += Int32.Parse(textBoxNumberOfPills.Text);
                labelNumberOfPills.Text = "Liczba tabletek: " + amountOfPills.ToString();
                labelAmountOfPillsToBuyInfo.Enabled = labelAmountOfPillsToBuyInfo.Visible = false;
                textBoxNumberOfPills.Enabled = textBoxNumberOfPills.Visible = false;
                buttonBuyPills.Enabled = buttonBuyPills.Visible = false;

            }
        }

        /// <summary>
        /// Funkcja obsługująca tick zegara odpowiedzialnego za działanie matematyczne
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerMath_Tick(object sender, EventArgs e)
        {
            progressBarMath.PerformStep();
            if (progressBarMath.Value >= 100)
            {

                timerMath.Stop();
                progressBarMath.Value = 0;
                MessageBox.Show("Niestety! Nie udało ci się naprawić usterki. Dostajesz karę.");
                cash -= accident.GetPenalty();
                textBoxAnswer.Enabled = textBoxAnswer.Visible = false;
                progressBarMath.Enabled = progressBarMath.Visible = false;
                buttonConfirmAnswer.Enabled = buttonConfirmAnswer.Visible = false;
                labelNumber1.Visible = labelNumber1.Enabled = false;
                labelNumber2.Visible = labelNumber2.Enabled = false;
                labelOperand.Visible = labelOperand.Enabled = false;

                timerInGame.Start();
                timerPersonTime.Start();
                timerAccident.Start();

            }
        }

        /// <summary>
        /// Funkcja obsługująca przycisk odpowiedzialny za wyjście z gry podczas gry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExitGameDuringGame_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Funkcja obsługująca przycisk odpowiedzialny za pójście do domu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGoHome_Click(object sender, EventArgs e)
        {
            FormHome fH = new FormHome(people, dayCounter, cash, amountOfPills);
            this.Close();
            fH.Show();
        }

        /// <summary>
        /// Funkcja obsługująca przycisk potwierdzający wprowadzony przez nas wynik
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonConfirmAnswer_Click(object sender, EventArgs e)
        {
            timerMath.Stop();
            if(textBoxAnswer.Text=="")
            {
                textBoxAnswer.Text = "0";
            }
            if (Int32.Parse(textBoxAnswer.Text) == solutionNumber)
            {
                MessageBox.Show("Brawo! Udało ci się naprawić usterkę.");
            }
            else
            {
                MessageBox.Show("Niestety! Nie udało ci się naprawić usterki. Dostajesz karę.");
                cash -= accident.GetPenalty();
            }

            progressBarMath.Value = 0;
            textBoxAnswer.Enabled = textBoxAnswer.Visible = false;
            progressBarMath.Enabled = progressBarMath.Visible = false;
            buttonConfirmAnswer.Enabled = buttonConfirmAnswer.Visible = false;
            labelNumber1.Visible = labelNumber1.Enabled = false;
            labelNumber2.Visible = labelNumber2.Enabled = false;
            labelOperand.Visible = labelOperand.Enabled = false;

            timerInGame.Start();
            timerPersonTime.Start();
            timerAccident.Start();
        }

        /// <summary>
        /// Funkcja losująca wagę
        /// </summary>
        /// <returns></returns>
        public int RandomWeight()
        {
            Random random = new Random();
            return random.Next(50, 110);
        }

        /// <summary>
        /// Funkcja obsługująca tick zegara odpowiedzialnego za czas oczekiwania obywatela
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerPersonTime_Tick(object sender, EventArgs e)
        {
            
            progressBarPersonTimer.PerformStep();
            if(progressBarPersonTimer.Value >= 100)
            {
                // reset wartosci w textboxach
                textBoxFirstName.Text = textBoxLastName.Text = textBoxAge.Text =
                    textBoxHeight.Text = textBoxWeight.Text = "";
                radioButtonPolitician.Checked = true;

                progressBarPersonTimer.Value = 0;
                RandomType();
                PutOnScreen(person);
                people.Add(person);
            }
        }

        /// <summary>
        /// Funkcja obsługująca tick zegara odpowiedzialnego za czas w grze
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerInGame_Tick(object sender, EventArgs e)
        {
            labelCash.Text = cash.ToString();
            labelCashFromGod.Text = bonusFromGod.ToString();
            if(hours == 17)
            {
                timerInGame.Stop();
                timerAccident.Stop();
                timerPersonTime.Stop();

                groupBoxPersonInfo.Enabled = groupBoxPersonInfo.Visible = false;
                buttonGoToPharmacy.Visible = buttonGoToPharmacy.Enabled = true;
                buttonGoHome.Visible = buttonGoHome.Enabled = true;
                labelIsClosed.Enabled = labelIsClosed.Visible = true;
                if(cash >= 10000)
                {
                    MessageBox.Show("Gratulacje! Udało ci się zdobyć upragnione 10 tysięcy. " +
                        "Teraz możesz rzucić tą pracę i wyjechać na jakieś porządne wakacje.");
                    Application.Exit();
                }

                if(cash < 0)
                {
                    MessageBox.Show("Po dzisiejszym dniu jesteś bankrutem. Nie masz za co żyć. Koniec gry!");
                    Application.Exit();
                }

            }
            minutes++;
            if (minutes == 60)
            {
                hours++;
                minutes = 0;
                if (hours <= 9)
                {
                    labelHourInGame.Text = "0" + hours.ToString();
                }
                else if (hours == 24)
                {
                    hours = 0;
                    dayIndex++;
                    if (dayIndex == 7)
                    {
                        dayIndex = 0;
                    }
                    labelDayInGame.Text = day[dayIndex];
                    labelHourInGame.Text = "0" + hours.ToString();
                }

                else
                {
                    labelHourInGame.Text = hours.ToString();
                }

            }

            if (minutes <= 9)
            {
                labelMinutesInGame.Text = "0" + minutes.ToString();
            }
            else
            {
                labelMinutesInGame.Text = minutes.ToString();
            }
        }
    }
}

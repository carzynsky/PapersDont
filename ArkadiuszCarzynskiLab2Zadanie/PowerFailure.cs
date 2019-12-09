using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkadiuszCarzynskiLab2Zadanie
{
    public class PowerFailure : Accident
    {
        // zmienne przechowujące rozwiązanie działania matematycznego oraz obie składowe działania
        private int solution;
        private int number1, number2;

        /// <summary>
        /// Konstruktor klasy PowerFailure
        /// </summary>
        public PowerFailure()
        {
            penalty = 1000;
            possibility = 1;
            Random random = new Random();
            number1 = random.Next(-500, 500);
            number2 = random.Next(-500, 500);
            solution = number1 + number2;
        }

        /// <summary>
        /// Implementacja metody odziedziczonej po klasie Accident
        /// </summary>
        /// <returns></returns>
        public override string Description()
        {
            return "Awaria zasilania w budynku!. Spróbuj przywrócić je sam albo zadzwoń po pomoc.";
        }

        /// <summary>
        /// Funkcja zwracająca rozwiązanie działania matematycznego
        /// </summary>
        /// <returns></returns>
        public int GetSolution()
        {
            return solution;
        }

        /// <summary>
        /// Funkcja zwracająca pierwszą składową działania matematycznego
        /// </summary>
        /// <returns></returns>
        public int GetNumber1()
        {
            return number1;
        }

        /// <summary>
        /// Funkcja zwracająca drugą składową działania matematycznego
        /// </summary>
        /// <returns></returns>
        public int GetNumber2()
        {
            return number2;
        }
    }
}

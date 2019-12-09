using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkadiuszCarzynskiLab2Zadanie
{
    public abstract class Person
    {
        // pola klasy Person, przechowują informację o imieniu, nazwisku, wieku, wadze i wzroście
        protected string firstName, lastName;
        protected int age, weight, height;

        /// <summary>
        /// Funkcja zwracająca imię
        /// </summary>
        /// <returns></returns>
        public virtual string GetFirstName()
        {
            return firstName;
        }

        /// <summary>
        /// Funkcja zwracająca nazwisko
        /// </summary>
        /// <returns></returns>
        public virtual string GetLastName()
        {
            return lastName;
        }

        /// <summary>
        /// Funkcja zwracająca wiek
        /// </summary>
        /// <returns></returns>
        public virtual int GetAge()
        {
            return age;
        }

        /// <summary>
        /// Funkcja zwracająca wagę
        /// </summary>
        /// <returns></returns>
        public virtual int GetWeight()
        {
            return weight;
        }

        /// <summary>
        /// Funkcja zwracająca wzrost
        /// </summary>
        /// <returns></returns>
        public virtual int GetHeight()
        {
            return height;
        }

        /// <summary>
        /// Niezaimplementowana metoda abstrakcyjna określająca zapłatę
        /// </summary>
        /// <returns></returns>
        public abstract double Pay();

        /// <summary>
        /// Niezaimplementowana metoda abstrakcyjna określająca wiadomość od obywatela
        /// </summary>
        /// <returns></returns>
        public abstract string Greeting();


    }
}

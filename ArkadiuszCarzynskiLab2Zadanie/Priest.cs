using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkadiuszCarzynskiLab2Zadanie
{
    public class Priest : Person, IGod
    {
        /// <summary>
        /// Konstruktor klasy Priest
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="age"></param>
        /// <param name="weight"></param>
        /// <param name="height"></param>
        public Priest(string firstName, string lastName, int age, int weight, int height)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.weight = weight;
            this.height = height;
        }

        /// <summary>
        /// Implementacja funkcji odziedziczonej po klasie Person
        /// </summary>
        /// <returns></returns>
        public override string Greeting()
        {
            return "Szczęść Boże. Czy chcesz coś od Boga?";
        }

        /// <summary>
        /// Implementacja funkcji odziedziczonej po klasie Person
        /// </summary>
        /// <returns></returns>
        public override double Pay()
        {
            return 100;
        }

        /// <summary>
        /// Implementacja funkcji odziedziczonej po interfejsue IGod
        /// </summary>
        /// <returns></returns>
        public bool PrayForLongerTime()
        {
            Random random = new Random();
            if (random.Next(1, 11) > 3) return true;
            else
                return false;
        }

        /// <summary>
        /// Implementacja funkcji odziedziczonej po interfejsie IGod
        /// </summary>
        /// <returns></returns>
        public bool PrayForMoreMoney()
        {
            Random random = new Random();
            if (random.Next(1, 11) > 3) return true;
            else
                return false;
        }

    }
}

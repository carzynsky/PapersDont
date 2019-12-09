using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkadiuszCarzynskiLab2Zadanie
{
    public class Worker : Person
    {
        /// <summary>
        /// Konstruktor klasy Worker
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="age"></param>
        /// <param name="weight"></param>
        /// <param name="height"></param>
        public Worker(string firstName, string lastName, int age, int weight, int height)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.weight = weight;
            this.height = height;
        }

        /// <summary>
        /// Implementacja metody odziedziczonej po klasie Person
        /// </summary>
        /// <returns></returns>
        public override string Greeting()
        {
            return "Kolejny dzień...";
        }

        /// <summary>
        /// Implementacja metody odziedziczonej po klasie Person
        /// </summary>
        /// <returns></returns>
        public override double Pay()
        {
            return 50;
        }
    }
}

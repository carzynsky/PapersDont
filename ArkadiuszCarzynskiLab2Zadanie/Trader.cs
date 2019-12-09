using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkadiuszCarzynskiLab2Zadanie
{
    public class Trader : Person
    {
        // zmienne przechowujące informację o wadze paczki
        private double weightOfPackage;

        /// <summary>
        /// Konstruktor klasy Trader
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="age"></param>
        /// <param name="weight"></param>
        /// <param name="height"></param>
        /// <param name="weightOfPackage"></param>
        public Trader(string firstName, string lastName, int age, int weight, int height, double weightOfPackage)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.weight = weight;
            this.height = height;
            this.weightOfPackage = weightOfPackage;
        }

        /// <summary>
        /// Implementacja funkcji odziedziczonej po klasie Person
        /// </summary>
        /// <returns></returns>
        public override string Greeting()
        {
            return "Przewożę paczkę na targ. Jakieś " + weightOfPackage + " kg";
        }

        /// <summary>
        /// Implementacja funkcji odziedziczonej po klasie Person
        /// </summary>
        /// <returns></returns>
        public override double Pay()
        {
            return 300 + 50*weightOfPackage;
        }
    }
}

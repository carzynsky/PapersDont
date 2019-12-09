using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkadiuszCarzynskiLab2Zadanie
{
    public class Politician : Person, IPolitics
    {
        // zmienna przechowująca informację czy dany polityk ma poglądy lewicowe czy prawicowe
        bool leftView;

        /// <summary>
        /// Konstruktor klasy Politician
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="age"></param>
        /// <param name="weight"></param>
        /// <param name="height"></param>
        /// <param name="leftView"></param>
        public Politician(string firstName, string lastName, int age, int weight, int height, bool leftView)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.weight = weight;
            this.height = height;
            this.leftView = leftView;
        }

        /// <summary>
        /// Implementacja metody odziedziczonej po klasie Person
        /// </summary>
        /// <returns></returns>
        public override string Greeting()
        {
            List<string> greetings = new List<string> { "Proszę mnie wpuścić", 
                "Śpieszę się, proszę to załatwić jak najszybciej!", 
                "Ale dzisiaj ludzi w kolejce..."};
            Random random = new Random();

            return greetings.ElementAt(random.Next(0, greetings.Count));
        }

        /// <summary>
        /// Implementacja metody odziedziczonej po klasie Person
        /// </summary>
        /// <returns></returns>
        public override double Pay()
        {
            return 200;
        }

        /// <summary>
        /// Implementacja metody odziedziczonej po interfejsie IPolitics
        /// </summary>
        /// <returns></returns>
        public string Views()
        {
            if(leftView==true)
            {
                return "Ten Pan jest chyba z lewicy...";
            }
            return "Ten Pan jest chyba z prawicy...";
        }
    }
}

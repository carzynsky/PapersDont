using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkadiuszCarzynskiLab2Zadanie
{
    public class Illness : Accident
    {
        // tablica przechowująca rodzaje choroby
        string[]typesOfIllnes =  { "kaszel", "angina", "ból głowy", "katar"};

        public Illness()
        {
            penalty = 500;
            possibility = 6;
        }
        /// <summary>
        /// Implementacja funkcji odziedziczonej po klasie Accident
        /// </summary>
        /// <returns></returns>
        public override string Description()
        {
            Random random = new Random();
            string typeRandom = typesOfIllnes[random.Next(0, typesOfIllnes.Length)];
            return "Zachorowałeś na " + typeRandom + "! Weź lekarstwo jeśli posiadasz. Jeśli nie, dostajesz karę za wcześniejsze wyjśćie do domu.";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkadiuszCarzynskiLab2Zadanie
{
    public abstract class Accident
    {
        // zmienne przechowujące informację o karze i prawdopodobieństwu wystąpienia awarii/choroby
        protected int penalty;
        protected int possibility;

        /// <summary>
        /// Funkcja zwracająca karę
        /// </summary>
        /// <returns></returns>
        public virtual int GetPenalty()
        {
            return penalty;
        }

        /// <summary>
        /// Funkcja zwracająca prawdopodobieństwo wystąpienia choroby/awarii
        /// </summary>
        /// <returns></returns>
        public virtual int GetPossibility()
        {
            return possibility;
        }

        /// <summary>
        /// Niezaimplementowana metoda abstrakcyjna określająca treść awarii/choroby
        /// </summary>
        /// <returns></returns>
        public abstract string Description();
    }
}

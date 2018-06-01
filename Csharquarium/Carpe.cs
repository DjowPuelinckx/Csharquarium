using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium
{
    public class Carpe : Herbivore
    {
        public Carpe(string race) : base(race)
        {
            
        }

        public Carpe(string nom, string sexe) : base(nom, sexe)
        {
            race = "Carpe";
        }

        public Carpe(string nom, string sexe, int age) : base(nom, sexe, age)
        {
            race = "Carpe";
        }
    }
}

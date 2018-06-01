using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium
{
    public class Herbivore : Poisson
    {
        public Herbivore(string race) : base(race)
        {

        }

        public Herbivore(string nom, string sexe) : base(nom, sexe)
        {

        }

        public Herbivore(string nom, string sexe, int age) : base(nom, sexe, age)
        {

        }
    }
}

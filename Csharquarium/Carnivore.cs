using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium
{
    public class Carnivore : Poisson
    {
        public Carnivore(string race) : base(race)
        {

        }

        public Carnivore(string nom, string sexe) : base(nom, sexe)
        {

        }

        public Carnivore(string nom, string sexe, int age) : base(nom, sexe, age)
        {

        }
    }
}

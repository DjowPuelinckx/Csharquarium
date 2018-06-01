using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium
{
    public class Thon : Carnivore
    {
        public Thon(string race) : base(race)
        {

        }

        public Thon(string nom, string sexe) : base(nom, sexe)
        {
            race = "Thon";
        }

        public Thon(string nom, string sexe, int age) : base(nom, sexe, age)
        {
            race = "Thon";
        }
    }
}

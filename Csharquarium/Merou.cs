using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium
{
    public class Merou : Carnivore
    {
        public Merou(string race) : base(race)
        {
            this.sexe = "Mâle";
        }

        public Merou(string nom, string sexe) : base(nom, sexe)
        {
            race = "Merou";
            this.sexe = "Mâle";
        }

        public Merou(string nom, string sexe, int age) : base(nom, sexe, age)
        {
            race = "Merou";
            if (age < 10)
            {
                this.sexe = "Mâle";
            }
            else
            {
                this.sexe = "Femelle";
            }
        }
    }
}

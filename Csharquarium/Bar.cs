using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium
{
    public class Bar : Herbivore
    {
        public Bar(string race) : base(race)
        {
            this.sexe = "Mâle";
        }

        public Bar(string nom, string sexe) : base(nom, sexe)
        {
            race = "Bar";
            this.sexe = "Mâle";
        }

        public Bar(string nom, string sexe, int age) : base(nom, sexe, age)
        {
            race = "Bar";
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

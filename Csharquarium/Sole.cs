using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium
{
    public class Sole : Herbivore
    {
        public Sole(string race) : base(race)
        {

        }

        public Sole(string nom, string sexe) : base(nom, sexe)
        {
            race = "Sole";
        }

        public Sole(string nom, string sexe, int age) : base(nom, sexe, age)
        {
            race = "Sole";
        }

        public override bool SeReproduire(Poisson poisson)
        {
            if ((sexe == "Mâle" && poisson.sexe == "Femelle") || (sexe == "Femelle" && poisson.sexe == "Mâle"))
            {
                if (!aFaim && !poisson.aFaim && estFecondable && poisson.estFecondable && race == poisson.race)
                {
                    pv -= 1;
                    poisson.pv -= 1;
                    jourDerniereRepro = 0;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if ((sexe == "Mâle" && poisson.sexe == "Mâle") || (sexe == "Femelle" && poisson.sexe == "Femelle"))
            {
                if (!aFaim && !poisson.aFaim && estFecondable && poisson.estFecondable && race == "Sole" && poisson.race == "Sole")
                {
                    if (sexe == "Mâle")
                    {
                        sexe = "Femelle";
                    }
                    else
                    {
                        sexe = "Mâle";
                    }
                    Console.WriteLine($"        - {nom} a changé de sexe.");
                    pv -= 1;
                    poisson.pv -= 1;
                    jourDerniereRepro = 0;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}

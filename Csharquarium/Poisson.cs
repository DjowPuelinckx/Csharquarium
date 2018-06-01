using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium
{
    public class Poisson : EtreVivant
    {
        public string nom;
        public string sexe;
        public string race;
        public int jourDerniereRepro;
        public bool estFecondable
        {
            get
            {
                if (age >= 3 && jourDerniereRepro >= 2 && estVivant)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool aFaim
        {
            get
            {
                if (pv <= 5 && estVivant)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Poisson(string race)
        {
            this.race = race;
            int aleaSexe = GenererAlea.AutreAlea(2);
            if (aleaSexe == 1)
            {
                sexe = "Femelle";
            }
            else
            {
                sexe = "Mâle";
            }
            age = 0;
            jourDerniereRepro = 0;
            estVivant = true;
        }

        public Poisson(string nom, string sexe)
        {
            this.nom = nom;
            this.sexe = sexe;
            estVivant = true;
            jourDerniereRepro = 0;
        }

        //pour achat.
        public Poisson(string nom, string sexe, int age)
        {
            this.nom = nom;
            this.sexe = sexe;
            this.age = age;
            estVivant = true;
            jourDerniereRepro = GenererAlea.AutreAlea(age);
            pv = GenererAlea.AutreAlea(10);
        }

        public void Manger(Poisson poisson)
        {
            int mangerPoissonAlea = GenererAlea.AutreAlea(2);
            if (mangerPoissonAlea == 1)
            {
                Console.WriteLine($"- {nom} a mangé {poisson.nom} !!");
                poisson.SeFaireMordre();
                pv += 5;
            }
            else
            {
                Console.WriteLine($"- {nom} n'a pas réussi à manger {poisson.nom}...");
                pv -= 1;
            }
        }

        public void Manger(Algue algue)
        {
            int mangerAlgueAlea = GenererAlea.AutreAlea(2);
            if (mangerAlgueAlea == 1)
            {
                Console.WriteLine($"- {nom} a mangé une algue.");
                algue.SeFaireManger();
                pv += 3;
            }
            else
            {
                Console.WriteLine($"- {nom} n'a pas réussi à manger d'algue.");
            }
        }

        public void SeFaireMordre()
        {
            pv -= 4;
            Mourir();
        }

        public virtual bool SeReproduire(Poisson poisson)
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
            else
            {
                return false;
            }
        }

        public void NommerPoisson(string nom)
        {
            this.nom = nom;
        }
    }
}

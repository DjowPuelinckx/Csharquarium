using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium
{
    public class Algue : EtreVivant
    {
        public Algue()
        {
            estVivant = true;
        }

        //pour Achat.
        public Algue(int age)
        {
            this.age = age;
            estVivant = true;
            pv = GenererAlea.AutreAlea(10 + (age / 2));
        }

        public void Grandir()
        {
            pv++;
        }

        public void SeFaireManger()
        {
            pv -= 2;
            Mourir();
        }

        public bool SeReproduire()
        {
            if (pv >= 12)
            {
                int aleaRepro = GenererAlea.AutreAlea(4);
                if (aleaRepro == 1)
                {
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

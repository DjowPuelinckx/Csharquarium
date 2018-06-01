using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium
{
    public class EtreVivant
    {
        public int pv = 10;
        public bool estVivant;
        public int age = 0;
        public decimal prix;

        public void Mourir()
        {
            if (pv <= 0 || age == 20)
            {
                estVivant = false;
            }
        }
    }
}

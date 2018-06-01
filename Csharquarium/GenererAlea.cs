using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium
{
    public static class GenererAlea
    {
        static Random alea = new Random();

        public static int AleaCinqA30()
        {
            return alea.Next(5, 31);
        }

        public static int LancerDe()
        {
            return alea.Next(1, 7);
        }

        public static int AutreAlea(int max)
        {
            return alea.Next(1, max + 1);
        }
    }
}

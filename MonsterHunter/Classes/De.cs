using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunter.Classes
{
    public class De
    {
        public int De4()
        {
            Random random = new Random();
            return random.Next(1, 5);
        }
        public int De6()
        {
            Random random = new Random();
            return random.Next(1, 7);
        }

        public int Best3In4De6()
        {
            int[] tab = new int[4];     
            for (int i = 0; i < 4; i++)
            {
                tab[i] = De6();             
            }
            Array.Sort(tab);
            return tab[1] +tab[2] + tab [3];
        }
    }
}

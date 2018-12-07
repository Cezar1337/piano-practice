using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace piano_practice
{
    class Sequence
    {
        public int length;
        int[] arr;
        public Sequence(int l)
        {
            this.length = l;
            arr = new int[l];
            Random rnd = new Random();
            for(int i=0;i < l;i++)
            {
                arr[i] = (int)rnd.Next(0, 12);
            }
        }
        public int[] ReturnSequence()
        {
            return arr;
        }
    }
}

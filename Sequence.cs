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
                arr[i] = rnd.Next(1, 13);
            }
        }
        public int[] ReturnSequence()
        {
            return arr;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace piano_practice
{
    class Sequence
    {
        public int length; //specifies the amount of generated random keys
        private int[] arr; //defines the sequence array
        public Sequence(int l)
        {
            this.length = l;
            arr = new int[l];
            Random rnd = new Random();
            for(int i=0;i < l;i++)
            {
                arr[i] = (int)rnd.Next(0, 12); //fill the array with numbers from 0 to 11
            }
        }

        public int[] ReturnSequence() //return the generated sequence as an array of integers
        {
            return arr;
        }
    }
}

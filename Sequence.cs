using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace piano_practice
{
    /// <summary>
    /// Generates and contains information about a sequence
    /// </summary>
    public class Sequence
    {
        /// <summary>
        /// Specifies the amount of generated random keys
        /// </summary>
        private int length;
        /// <summary>
        /// Holds generated sequence
        /// </summary>
        private int[] arr;
        /// <summary>
        /// Generates a random sequence of length "l"
        /// </summary>
        /// <param name="l">Length of the generated sequence</param>
        public Sequence(int l)
        {
            this.length = l;
            arr = new int[l];
            Random rnd = new Random();
            for(int i = 0; i < l; i++)
            {
                arr[i] = (int)rnd.Next(0, 12); //fill the array with numbers from 0 to 11
            }
        }
        /// <summary>
        /// Return the generated sequence
        /// </summary>
        /// <returns>An array of integers</returns>
        public int[] ReturnSequence()
        {
            return arr;
        }
    }
}

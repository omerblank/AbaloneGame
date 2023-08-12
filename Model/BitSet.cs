using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbaloneGame.Model
{
    internal class BitSet
    {
        private readonly bool[] bits;

        // constructor
        public BitSet()
        {
            this.bits = new bool[Constants.BOARD_SIZE];
        }

        // size property
        public int Size
        {
            get { return this.bits.Length; }
        }

        /// <summary>
        /// funciton that changes the value of the cells in the given indexes range (including "from", not including "to")
        /// </summary>
        /// <param name="from"> the index we run from </param>
        /// <param name="to"> the index we stop run at </param>
        /// <exception cref="IndexOutOfRangeException"> thrown when we are trying to reach an index that's out of the structure's bounds </exception>
        public void Set(int from, int to)
        {
            if (to < 0 || from < 0 || to < from || to > Size || from > Size)
                throw new IndexOutOfRangeException();
            for (int i = from; i < to; i++)
            {
                bits[i] = true;
            }
        }

        /// <summary>
        /// function that changes the value of the element in the given index
        /// </summary>
        /// <param name="bitIndex"> the given index </param>
        /// <exception cref="IndexOutOfRangeException"> thrown when we are trying to reach an index that's out of the structure's bounds </exception>
        public void Set(int bitIndex)
        {
            if (bitIndex < 0 || bitIndex >= Size)
                throw new IndexOutOfRangeException();
            bits[bitIndex] = true;
        }

        /// <summary>
        /// function that gives the value of the element in the given index
        /// </summary>
        /// <param name="bitIndex"> the given index </param>
        /// <returns> the value of the element in the given index </returns>
        /// <exception cref="IndexOutOfRangeException"> thrown when we are trying to reach an index that's out of the structure's bounds </exception>
        public bool Get(int bitIndex)
        {
            if (bitIndex < 0 || bitIndex >= Size)
                throw new IndexOutOfRangeException();
            return bits[bitIndex];
        }

        /// <summary>
        /// function that returns the index of the first bit that is on after the given index (including it)
        /// </summary>
        /// <param name="from"> the index we start to run from </param>
        /// <returns> the index of the first bit that is on after the given index (including it) </returns>
        /// <exception cref="IndexOutOfRangeException"> thrown when we are trying to reach an index that's out of the structure's bounds </exception>
        public int NextSetBit(int from)
        {
            if (from < 0 || from >= Size)
                throw new IndexOutOfRangeException();
            for (int i = from; i < Size; i++)
            {
                if (bits[i])
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// function that changes the value of the cell in the given index to the given value
        /// </summary>
        /// <param name="index"> the index of the bit in the set </param>
        /// <param name="value"> the new value (true/false) </param>
        /// <exception cref="IndexOutOfRangeException"> thrown when we are trying to reach an index that's out of the structure's bounds </exception>
        public void Set(int index, bool value)
        {
            if (index < 0 || index >= Size)
                throw new IndexOutOfRangeException();
            bits[index] = value;
        }

        /// <summary>
        /// function that clones the bit set
        /// </summary>
        /// <returns> a new cloned bit set </returns>
        public BitSet Clone()
        {
            BitSet clonedBitSet = new BitSet();
            for (int i = 0; i < Size; i++)
            {
                if (bits[i])
                    clonedBitSet.Set(i);
            }
            return clonedBitSet;
        }
    }
}

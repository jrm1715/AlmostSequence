using System;
using System.Collections.Generic;
using System.Linq;

namespace Projects
{
    class Program
    {
        // Converts array to list and runs program
        static void Main(string[] args)
        {
            int i = new int();
            int[] initialSequence = { 3, 5, 67, 98, 3 };
            List<int> sequenceList = new List<int>(initialSequence);
            Console.WriteLine(AlmostSequence(ref sequenceList, i));
            Console.ReadLine();
        }
        // Checks if items in list is almost Sequence
        // I feel that this is redundant as IsSequential already
        // checks if the list is sequential. 
        private static bool AlmostSequence(ref List<int> sequence, int i)
        {
            if (IsSequential(ref sequence, out i))
            {
                return true;
            }
            else
            {
                RemoveItem(ref sequence, i);
                IsSequential(ref sequence, out i);

                if (IsSequential(ref sequence, out i) != true)
                {
                    return false;
                }
            }
            return true;
        }

        // Checks if the list given is sequential
        private static bool IsSequential(ref List<int> sequence, out int i)
        {
            for (i = 0; i < sequence.Count - 1; i++)
            {
                if (sequence[i + 1] > sequence[i])
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        // Goes through the list at where IsSequential fails and determins 
        // what item in the list to remove
        // This method is too big and can be broken down. 
        private static List<int> RemoveItem(ref List<int> sequence, int i)
        {
            int itemAtIndex;
            itemAtIndex = i + 1;
            if (sequence[i] >= sequence[i + 1] && i == 0)
            {
                sequence.RemoveAt(i);
            } 
            else if (sequence[i] > sequence[i+1])  //if a > b and b > c, remove b
            {
                if ((sequence.Count - 1) - sequence.IndexOf(sequence[i]) > 1)  
                {
                    if (sequence[i] > sequence[i+1] && sequence[i] < sequence[i+2])
                    {
                        sequence.RemoveAt(itemAtIndex);                        
                    }
                    else
                    {
                        sequence.RemoveAt(i);                        
                    }
                }
                else
                {
                    sequence.RemoveAt(itemAtIndex);
                }
            }
            else
            {
                sequence.RemoveAt(itemAtIndex);
            }
            return sequence;
        }
    }
}
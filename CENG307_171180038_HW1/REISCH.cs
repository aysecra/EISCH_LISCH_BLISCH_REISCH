using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CENG307_171180038_HW1
{
    class REISCH
    {
        static Node[] arr;
        private static int probe = 0;
        public int Probe { get => probe; }
        public REISCH() { arr = new Node[1000]; }
        private int mod(int x) { return x % 1000; }
        private List<int> blankIndexes = new List<int>();

        public void addAllBlankIndexes()
        {
            for (int i = 0; i < 1000; i++)
                blankIndexes.Add(i);

        }
        private int findRandomBlankIndex()
        {
            Random rnd = new Random();
            return rnd.Next(0, blankIndexes.Count + 1);
        }
        public void add(int data)
        {
            Node newData = new Node(data);
            if (arr[mod(data)] == null)
            {
                arr[mod(data)] = newData;
                blankIndexes.Remove(mod(data));
            }
            else
            {
                int rndBlankIndex = findRandomBlankIndex();
                if (arr[mod(data)].Link == -1)
                {
                    arr[mod(data)].Link = rndBlankIndex;
                    arr[rndBlankIndex] = newData;
                    blankIndexes.Remove(rndBlankIndex);
                }

                else if (arr[mod(data)].Link != -1)
                {
                    int i = arr[mod(data)].Link;
                    arr[mod(data)].Link = rndBlankIndex;
                    arr[rndBlankIndex] = newData;
                    arr[rndBlankIndex].Link = i;
                    blankIndexes.Remove(rndBlankIndex);
                }
            }

        }
        public int search(int data)
        {
            probe = 1;
            if (arr[mod(data)].Data == data)
            {
                return mod(data);
            }


            else if (arr[mod(data)].Link != -1)
            {
                int i = arr[mod(data)].Link;
                while (arr[i].Link != -1)
                {
                    probe++;
                    if (arr[i].Data == data)
                        return i;
                    i = arr[i].Link;
                }
                if (arr[i].Data == data)
                {
                    probe++;
                    return i;
                }

            }

            return -1;

        }
        public void print()
        {
            Console.WriteLine("\nREISCH");
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != null && arr[i].Link != -1)
                    Console.WriteLine("Index: {0} Record: {1} Link: {2}", i, arr[i].Data, arr[i].Link);

                else if (arr[i] == null)
                    Console.WriteLine("Index: {0} Record: - Link: -", i);

                else
                    Console.WriteLine("Index: {0} Record: {1} Link: -", i, arr[i].Data);
            }
        }
    }
}

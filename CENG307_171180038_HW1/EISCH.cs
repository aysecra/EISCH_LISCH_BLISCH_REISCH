using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CENG307_171180038_HW1
{
    class EISCH
    {
        private static int probe = 1;
        public int Probe { get => probe; }
        static Node[] arr = new Node[1000];
        private static int last = 999;
        public EISCH() { }
        private int mod(int x) { return x % 1000; }

        public void add(int data)
        {
            Node newData = new Node(data);
            if (arr[mod(data)] == null)
                arr[mod(data)] = newData;

            else if (arr[last] == null && arr[mod(data)].Link == -1)
            {
                arr[mod(data)].Link = last;
                arr[last] = newData;
            }

            else if (arr[last] == null && arr[mod(data)].Link != -1)
            {
                int i = arr[mod(data)].Link;
                arr[mod(data)].Link = last;
                arr[last] = newData;
                arr[last].Link = i;
            }

            else
            {
                last--;
                add(data);
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
            Console.WriteLine("EISCH");
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

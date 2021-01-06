using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CENG307_171180038_HW1
{
    class LICH
    {
        private static int probe = 1;
        public int Probe { get => probe; }
        static Node[] arr = new Node[1000];
        private static int last = 999;
        private static int primaryAreaAmount = 500;
        private Queue<Node> queue = new Queue<Node>();
        public LICH() { }
        private int mod(int x) { return x % primaryAreaAmount; }


        public void add(int data)
        {
            Node newData = new Node(data);

            if (arr[mod(data)] == null)
            {
                arr[mod(data)] = newData;
                queue.Enqueue(newData);
            }
                

            else if (arr[last] == null && arr[mod(data)].Link == -1)
            {

                arr[mod(data)].Link = last;
                arr[last] = newData;
                queue.Enqueue(newData);

                if (last < primaryAreaAmount) exceedTheOverflowArea();
            }

            else if (arr[last] == null && arr[mod(data)].Link != -1)
            {
                int i = arr[mod(data)].Link;
                while (arr[i].Link != -1)
                    i = arr[i].Link;
                arr[i].Link = last;
                arr[last] = newData;
                queue.Enqueue(newData);

                if (last < primaryAreaAmount) exceedTheOverflowArea();
            }

            else
            {
                last--;
                add(data);
            }


        }
        public void exceedTheOverflowArea()
        {
            primaryAreaAmount--;
            last = 999;
            arr = new Node[1000];

            for (int i = 0; i < queue.Count; i++)
                add(queue.Dequeue().Data);

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
            Console.WriteLine("\nLICH:");
            Console.WriteLine("Primary Area:");
            for (int i = 0; i < primaryAreaAmount; i++)
            {
                if (arr[i] != null && arr[i].Link != -1)
                    Console.WriteLine("Index: {0} Record: {1} Link: {2}", i, arr[i].Data, arr[i].Link);

                else if (arr[i] == null)
                    Console.WriteLine("Index: {0} Record: - Link: -", i);

                else
                    Console.WriteLine("Index: {0} Record: {1} Link: -", i, arr[i].Data);
            }

            Console.WriteLine("\nCellar / Overflow Area: ");
            for (int i = primaryAreaAmount; i < arr.Length; i++)
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

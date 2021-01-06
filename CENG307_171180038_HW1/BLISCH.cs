using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CENG307_171180038_HW1
{
    class BLISCH
    {
        private static int probe = 1;
        public int Probe { get => probe; }
        static Node[] arr;
        private static int last = 999;
        private static int head = 0;
        private static int addLastOrHead = 0;
        public BLISCH() { arr = new Node[1000]; }
        private int mod(int x) { return x % 1000; }

        public void add(int data, int lastOrHead = 0)
        {
            Node newData = new Node(data);
            addLastOrHead = lastOrHead;

            if (arr[mod(data)] == null)
                arr[mod(data)] = newData;

            else
            {
                if (addLastOrHead % 2 == 0) addlast(newData);
                else addhead(newData);
            }


        }
        public void addlast(Node newData)
        {
            if (arr[last] != null)
            {
                last--;
                addLastOrHead++;
                add(newData.Data, addLastOrHead);
            }
            else if (arr[last] == null && arr[mod(newData.Data)].Link == -1)
            {

                arr[mod(newData.Data)].Link = last;
                arr[last] = newData;

            }

            else if (arr[last] == null && arr[mod(newData.Data)].Link != -1)
            {
                int i = arr[mod(newData.Data)].Link;
                while (arr[i].Link != -1)
                    i = arr[i].Link;
                arr[i].Link = last;
                arr[last] = newData;

            }

        }
        public void addhead(Node newData)
        {
            if (arr[head] != null)
            {
                head++;
                addLastOrHead++;
                add(newData.Data, addLastOrHead);
            }
            else if (arr[head] == null && arr[mod(newData.Data)].Link == -1)
            {

                arr[mod(newData.Data)].Link = head;
                arr[head] = newData;

            }

            else if (arr[head] == null && arr[mod(newData.Data)].Link != -1)
            {
                int i = arr[mod(newData.Data)].Link;
                while (arr[i].Link != -1)
                    i = arr[i].Link;
                arr[i].Link = head;
                arr[head] = newData;

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
            Console.WriteLine("\nBLISCH");
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

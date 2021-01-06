using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CENG307_171180038_HW1
{
    class MainClass
    {
        static Random rnd = new Random();
        static List<int> Datas = new List<int>();

        static BLISCH blisch = new BLISCH();
        static EISCH eisch = new EISCH();
        static LICH lich = new LICH();
        static REISCH reisch = new REISCH();

        static void Main(string[] args)
        {


            add();

            int controlProcessing = -1;
            bool loopProcessing = true;
            while (loopProcessing)
            {
                Console.Write("\nExit: -1\nPrint: 0 \nSearch data: 1 \nProbes Required: 2 \nClear Screen: 3 \nSelect the processing: ");
                controlProcessing = Convert.ToInt32(Console.ReadLine());
                switch (controlProcessing)
                {
                    case -1:
                        loopProcessing = false;
                        break;
                    case 0:
                        print();
                        break;
                    case 1:
                        search();
                        break;
                    case 2:
                        calculateProbesRequired();
                        break;
                    case 3:
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Invalid entry");
                        break;
                }
            }


            Console.ReadKey();
        }
        static void add()
        {
            reisch.addAllBlankIndexes();

            for (int i = 0; i < 900; i++)
            {
                int data = rnd.Next(0, 1000000);
                Datas.Add(data);
                eisch.add(data);
                lich.add(data);
                blisch.add(data);
                reisch.add(data);
            }
        }
        static void print()
        {
            int controlPrint = -1;
            Console.Write("\n\nEISCH: 0 \nLICH: 1 \nBLISCH: 2 \nREISCH: 3 \nSelect the processing:");
            controlPrint = Convert.ToInt32(Console.ReadLine());
            switch (controlPrint)
            {
                case 0:
                    eisch.print();
                    break;
                case 1:
                    lich.print();
                    break;
                case 2:
                    blisch.print();
                    break;
                case 3:
                    reisch.print();
                    break;
                default:
                    Console.WriteLine("Invalid entry");
                    break;
            }

        }
        static void search()
        {
            int read = 0;
            int controlSearch = -1;

            Console.Write("\n\nEISCH: 0 \nLICH: 1 \nBLISCH: 2 \nREISCH: 3 \nSelect the processing:");
            controlSearch = Convert.ToInt32(Console.ReadLine());
            switch (controlSearch)
            {
                case 0:
                    while (true)
                    {
                        Console.Write("Searched data (exit: -1): ");
                        read = Convert.ToInt32(Console.ReadLine());
                        if (read == -1) break;
                        int index = eisch.search(read);
                        if (index == -1) Console.WriteLine("there isn't this data");
                        else Console.WriteLine("Index: {1} Number of probes: {2} ", read, index, eisch.Probe);
                    }
                    break;
                case 1:
                    while (true)
                    {
                        Console.Write("Searched data (exit: -1): ");
                        read = Convert.ToInt32(Console.ReadLine());
                        if (read == -1) break;
                        int index = lich.search(read);
                        if (index == -1) Console.WriteLine("there isn't this data");
                        else Console.WriteLine("Index: {1} Number of probes: {2} ", read, index, lich.Probe);
                    }
                    break;
                case 2:
                    while (true)
                    {
                        Console.Write("Searched data (exit: -1): ");
                        read = Convert.ToInt32(Console.ReadLine());
                        if (read == -1) break;
                        int index = blisch.search(read);
                        if (index == -1) Console.WriteLine("there isn't this data");
                        else Console.WriteLine("Index: {1} Number of probes: {2} ", read, index, blisch.Probe);
                    }
                    break;
                case 3:
                    while (true)
                    {
                        Console.Write("Searched data (exit: -1): ");
                        read = Convert.ToInt32(Console.ReadLine());
                        if (read == -1) break;
                        int index = reisch.search(read);
                        if (index == -1) Console.WriteLine("there isn't this data");
                        else Console.WriteLine("Index: {1} Number of probes: {2} ", read, index, reisch.Probe);
                    }
                    break;
                default:
                    Console.WriteLine("Invalid entry");
                    break;
            }
            
            
        }

        static void calculateProbesRequired()
        {
            double eischProbesRequired = 0.0;
            double lichProbesRequired = 0.0;
            double blischProbesRequired = 0.0;
            double reischProbesRequired = 0.0;

            for (int i = 0; i < Datas.Count; i++)
            {
                eisch.search(Datas[i]);
                lich.search(Datas[i]);
                blisch.search(Datas[i]);
                reisch.search(Datas[i]);

                eischProbesRequired += eisch.Probe;
                lichProbesRequired += lich.Probe;
                blischProbesRequired += blisch.Probe;
                reischProbesRequired += reisch.Probe;
            }

            eischProbesRequired /= 1000;
            lichProbesRequired /= 1000;
            blischProbesRequired /= 1000;
            reischProbesRequired /= 1000;

            Console.WriteLine("\n\nPROBES REQUIRED: \nEISCH: {0} \nLICH: {1} \nBLISCH: {2} \nREISCH: {3}"
                , eischProbesRequired, lichProbesRequired, blischProbesRequired, reischProbesRequired);
        }


    }
}

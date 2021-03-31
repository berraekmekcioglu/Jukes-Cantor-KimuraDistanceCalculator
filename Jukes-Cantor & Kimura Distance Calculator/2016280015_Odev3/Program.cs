using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2016280015_Odev3
{
    class Program
    {
        static void Main(string[] args)
        {
            float transition = 0;
            float transversion = 0;
            string birincitur = "";
            string ikincitur = "";
            Console.WriteLine("Birinci sekansi giriniz:");
            string birinci = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Ikinci sekansi giriniz:");
            string ikinci = Console.ReadLine();
            char[,] array = new char[(birinci.Length), (ikinci.Length)];
            int sayac = 0;
            char[] birincii = birinci.ToCharArray();
            char[] ikincii = ikinci.ToCharArray();
            for (int i = 0; i < birinci.Length; i++)
            {
                for (int j = 0; j < ikinci.Length; j++)
                {
                    if (birincii[i] == ikincii[j])
                    {
                        array[i, j] = '*';
                        if (i == j)
                        {
                            sayac++;
                        }
                    }
                    else
                    {
                        if (i == j)
                        {
                            if (birincii[i] == 'a' || birincii[i] == 'g')
                            {
                                birincitur = "purine";
                            }
                            else birincitur = "pyrimidine";

                            if (ikincii[i] == 'a' || ikincii[i] == 'g')
                            {
                                ikincitur = "purine";
                            }
                            else ikincitur = "pyrimidine";

                            if ((birincitur == "purine" && ikincitur == "purine") || (birincitur == "pyrimidine" && ikincitur == "pyrimidine"))
                            {
                                transition++;
                            }
                            else transversion++;
                        }
                        array[i, j] = ' ';
                    }
                        

                }
            }
            Console.WriteLine();
            Console.Write("  ");
            for (int k = 0; k < birinci.Length; k++)
            {
                Console.Write(birincii[k]); Console.Write(" ");
            }
            Console.WriteLine();
            for (int k = 0; k < ikinci.Length; k++)
            {
                Console.Write(ikincii[k]);
                for (int m = 0; m < birinci.Length; m++)
                {
                    Console.Write(" " + (array[m, k]));

                }
                Console.Write("\n\n");
            }
            string uzun;
            if (birinci.Length > ikinci.Length)
            {
                uzun = birinci;
            }
            else
            {
                uzun = ikinci;
            }
            float benzerlik = (0.5f * sayac / (0.5f * uzun.Length));
            float farklilik = (1-benzerlik);
            float ln = (float)(Math.Log((float)1 - (((float)4 * farklilik) / (float)3)));
            float kdegeri = ((float)-3 / (float)4)*ln;
            if(kdegeri<0 || kdegeri>0.75)
            {
                Console.WriteLine("Değiştirme oranı limitlerin dışındadır!");
            }
            else
            {
                Console.WriteLine("Jukes-Cantor Genetic Distance: {0}", kdegeri);
            }
            transition = transition / birinci.Length;
            transversion = transversion / birinci.Length;
            float kimura = ((float)(-1) / (float)(2)) * (float)(Math.Log(((float)(1) - ((float)(2) * transition) - transversion) * (float)(Math.Sqrt((float)(1) - ((float)(2) * transversion))))) ;
            if (kimura < 0 || kimura > 0.75)
            {
                Console.WriteLine("Değiştirme oranı limitlerin dışındadır!");
            }
            else
            {
                Console.WriteLine("Kimura Genetic Distance: {0}", kimura);
            }
            Console.ReadKey();
        }
    }
}

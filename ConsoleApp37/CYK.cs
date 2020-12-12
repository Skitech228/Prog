using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://www.xarg.org/tools/cyk-algorithm/
//S -> AB
//A -> CD | CF
//B -> c | EB
//C -> a
//D -> b
//E -> c
//F -> AD

namespace ConsoleApp37
{
    class CYK
    {
        public string[][] CYK_ALG(string Str)
        {
            string[][] table = new string[Str.Length][];
            for (int i = 0; i < Str.Length; i++)
            {
                table[i] = new string[Str.Length - i];
            }
            int count = 0;
            int jj = 0;
            Algoritm(Str, table, ref count, ref jj);
            for (int i = 0; i < Str.Length; i++)
            {
                for (int j = 0; j < table[i].Length; j++)
                {
                    Console.Write(table[i][j] + "\t");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            return table;
        }

        private static void Algoritm(string Str, string[][] table, ref int count, ref int jj)
        {
            for (int i = 0; i < Str.Length; i++)
            {
                for (int j = 0; j < table[i].Length; j++)
                {
                    if (i == 0)
                    {
                        if (Str[j].ToString() == "d")
                            table[i][j] = "B,E";
                        if (Str[j].ToString() == "f")
                            table[i][j] = "C";
                        if (Str[j].ToString() == "g")
                            table[i][j] = "D";
                    }
                    else
                    {
                        count = i - 1;
                        jj = j + 1;
                        for (int t = 0; t < i; t++)
                        {
                            if (table[count][jj] == "C" && table[t][j] == "D" || table[count][jj] == "D" && table[t][j] == "C" || table[count][jj] == "F" && table[t][j] == "C" || table[count][jj] == "C" && table[t][j] == "F")
                                table[i][j] = "A";
                            if (table[count][jj] == "A" && table[t][j] == "D" || table[count][jj] == "D" && table[t][j] == "A")
                                table[i][j] = "F";
                            if (table[count][jj] == "B,E" && table[t][j] == "B,E")
                                table[i][j] = "B";
                            if (table[count][jj] == "B,E" && table[t][j] == "A" || table[count][jj] == "A" && table[t][j] == "B,E" || table[count][jj] == "B" && table[t][j] == "A" || table[count][jj] == "A" && table[t][j] == "B")
                                table[i][j] = "S";
                            count--;
                            jj++;
                        }
                    }
                }
            }
        }
    }
}

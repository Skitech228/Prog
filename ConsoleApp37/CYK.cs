using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            int count=0;
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
                        count = i-1;
                        for (int t = 0; t < i; t++)
                        {
                            if (table[count][t + 1] == "C" && table[t][j] == "D" || table[count][t + 1] == "D" && table[t][j] == "C")
                                table[i][j] = "A";
                            else
                                table[i][j] = "0";
                            count--;
                        }
                    }
                }
            }
            for (int i = 0; i < Str.Length; i++)
            {
                for (int j = 0; j < table[i].Length; j++)
                {
                    Console.Write(table[i][j]+"\t");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            return table;
        }
    }
}

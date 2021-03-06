﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Алгоритм CYK:
//дано строка S из n символов: a1...an.
//дано грамматика, содержащая r нетерминальных символов R1...Rr.
//    Содержит подмножество Rs начальных символов.
//опр массив P[n, n, r] булевских значений, инициализированных значениями Ложь.
//для каждого i = 1 : n
//  для каждой продукции Rj -> ai
//    присвоить P[1, i, j] = Истина
//для каждого i = 2 : n                     -- длина интервала
//  для каждого j = 1 : n-i+1               -- начало интервала
//    для каждого k = 1 : i-1               -- разбиение интервала
//      для каждой продукции RA -> RB RC
//        если P[k, j, B] и P[i-k,j+k,C]
//        то присвоить P[i, j, A] = Истина
//если для некоторого x из множества s P[n,1, x] = Истина, где s все индексы Rs
//то возвратить S принадлежит языку
//иначе возвратить S не принадлежит языку
namespace ConsoleApp37
{
    class Program
    {

        static void Main(string[] args)               
        {
            CYK cyk = new CYK();
            cyk.CYK_ALG("fffgggdd");
        }
    }
}

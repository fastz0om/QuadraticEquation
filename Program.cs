using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите a,b,c: ");
            string[] sArr = Console.ReadLine().Split(' ');
            QuadraticEquation quadraticEquation = new QuadraticEquation(Int32.Parse(sArr[0]), Int32.Parse(sArr[1]), Int32.Parse(sArr[2]));
            quadraticEquation.SolveEquation();
            quadraticEquation.GetExtremum();
            quadraticEquation.GetIntervals();
            quadraticEquation.GetMaxMinRoot();
        }
    }
}

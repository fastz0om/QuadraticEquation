using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquation
{
    public class QuadraticEquation
    {

        private int _a = 0;
        private int _b = 0;
        private int _c = 0;

        private double _d = 0.0;

        private double _x0 = 0.0;
        private double _y0 = 0.0;

        private bool _isMaximum;

        public QuadraticEquation(int a, int b, int c)
        {
            this._a = a;
            this._b = b;
            this._c = c;
        }


        public double getA()
        {
            return _a;
        }


        public double getB()
        {
            return _b;
        }


        public double getC()
        {
            return _c;
        }


        public void SetA(int value)
        {
            _a = value;
        }


        public void SetB(int value)
        {
            _b = value;
        }


        public void SetC(int value)
        {
            _c = value;
        }


        private void CalculateD()
        {
            _d = Math.Pow(_b, 2) - (4 * _a * _c);
        }


        private int NumberOfRoots()
        {
            CalculateD();
            return (_d > 0) ? 2 : (_d == 0) ? 1 : 0;
        }


        private double[] FindRoots()
        {

            double[] roots;

            int r = NumberOfRoots();

            if (r == 2)
            {

                roots = new double[2];

                roots[0] = (-_b + Math.Sqrt(_d)) / (2 * _a);
                roots[1] = (-_b - Math.Sqrt(_d)) / (2 * _a);

                return roots;
            }

            else if (r == 1)
            {

                roots = new double[1];

                roots[0] = (-_b) / (2 * _a);

                return roots;
            }

            return null;
        }


        private void ExtremumFind()
        {
            _isMaximum = false;
            if (_a < 0)
                _isMaximum = true;

            double x0 = -(_b / (double)(2 * _a));
            double y0 = (double)(_a * Math.Pow(x0, 2) + _b * x0 + _c);

            _x0 = x0;
            _y0 = y0;
        }


        public void SolveEquation()
        {
            Console.WriteLine("Уравнение вида: (" + _a + ")*x^2 + (" + _b + ")*x + (" + _c + ")");
            Console.WriteLine("Количество корней уравнения: " + NumberOfRoots());
            double[] roots = FindRoots();

            if (roots == null)
                Console.WriteLine("Так как дискриминант меньше нуля, то уравнение не имеет действительных решений.");
            else
                for (int i = 0; i < roots.Length; i++)
                {
                    Console.WriteLine((i + 1) + "-ый корень уравнения равен: " + roots[i]);
                }
            Console.ReadKey();
        }


        public void GetExtremum()
        {
            ExtremumFind();
            if (_isMaximum)
                Console.WriteLine("Точка максимума имеет следующие координаты: (" + _x0 + ", " + _y0 + ")");
            else
                Console.WriteLine("Точка минимума имеет следующие координаты: (" + _x0 + ", " + _y0 + ")");
            Console.ReadKey();
        }


        public void GetIntervals()
        {
            ExtremumFind();
            if (_isMaximum)
            {
                Console.WriteLine("График функции возрастает на промежутке: (-∞; " + _x0 + "]");
                Console.WriteLine("График функции убывает на промежутке: [" + _x0 + ";+∞)");
            }
            else
            {
                Console.WriteLine("График функции убывает на промежутке: (-∞; " + _x0 + "]");
                Console.WriteLine("График функции возрастает на промежутке: [" + _x0 + ";+∞)");
            }
            Console.ReadKey();
        }


        public void GetMaxMinRoot()
        {
            int numberRoots = NumberOfRoots();
            double[] roots = FindRoots();
            switch (numberRoots)
            {
                case 0:
                    Console.WriteLine("Так как дискриминант меньше нуля, то уравнение не имеет действительных решений.");
                    break;
                case 1:
                    Console.WriteLine("Уравнение имеет один единственный корень: " + roots[0]);
                    break;
                case 2:
                    if (roots[0] > roots[1])
                    {
                        Console.WriteLine("Наибольший по значению корень: " + roots[0]);
                        Console.WriteLine("Наименьший по значению корень: " + roots[1]);
                    }
                    else
                    {
                        Console.WriteLine("Наибольший по значению корень: " + roots[1]);
                        Console.WriteLine("Наименьший по значению корень: " + roots[0]);
                    }
                    break;
            }
            Console.ReadKey();
        }
    }
}

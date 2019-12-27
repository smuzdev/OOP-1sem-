using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] year = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            int n = 8;
            var length = from month in year where month.Length == n select month;
            var alphabeth = from month in year orderby month select month;
            var WinSummer = from month in year
                            where month == year[0] || month == year[1] || month == year[7] || month == year[11] || month == year[5] || month == year[6]
                            select month;
            var u = from month in year where month.Contains('u') && month.Length >= 4 select month;
            Console.WriteLine("По алфавиту");
            foreach (string months in alphabeth)
            {
                Console.WriteLine(months);
            }
            Console.WriteLine("\nПо длине строки,равной 4");
            foreach (string months in length)
            {
                Console.WriteLine(months);
            }
            Console.WriteLine("\nС буквой 'u' ");
            foreach (string months in u)
            {
                Console.WriteLine(months);
            }
            Console.WriteLine("\nЗимние и летние месяцы");
            foreach (string months in WinSummer)
            {
                Console.WriteLine(months);
            }


            Point P1 = new Point(), P2 = new Point(0), P3 = new Point(2, 0), P4 = new Point(2, 3), P5 = new Point(4, 5), P6 = new Point(4, 0);
            Triangle[] Array_Of_Triangles = new Triangle[3];
            Array_Of_Triangles[0] = new Triangle(P1, P2, P6);
            Array_Of_Triangles[1] = new Triangle(P1, P4, P6);
            Array_Of_Triangles[2] = new Triangle(P1, P3, P5);

            List<Triangle> list = new List<Triangle>
            {
                Array_Of_Triangles[0],
                Array_Of_Triangles[1],
                Array_Of_Triangles[2]
            };
            var rbedr = from triangle in list where triangle.Rank == "Равнобедренный" select triangle;
            var rstor = from triangle in list where triangle.Rank == "Равносторонний" select triangle;
            var pryam = from triangle in list where triangle.Rank == "Прямоугольный" select triangle;
            int col = 0;
            double min = 1111111111, max = -1111111111;
            foreach (Triangle tr in rbedr)
            {
                if (min >= tr.perimetr)
                {
                    min = tr.perimetr;
                }
                if (max <= tr.perimetr)
                {
                    max = tr.perimetr;
                }
                col++;
            }
            Console.WriteLine("Равнобедренных " + col + "Макс " + max + " Мин " + min);
            min = 1111111111;
            max = -1111111111;
            col = 0;
            foreach (Triangle tr in rstor)
            {
                if (min >= tr.perimetr)
                {
                    min = tr.perimetr;
                }
                if (max <= tr.perimetr)
                {
                    max = tr.perimetr;
                }
                col++;
            }
            Console.WriteLine("Равносторонних " + col + "Макс " + max + " Мин " + min);
            col = 0;
            min = 1111111111;
            max = -1111111111;
            foreach (Triangle tr in pryam)
            {
                if (min >= tr.perimetr)
                {
                    min = tr.perimetr;
                }
                if (max <= tr.perimetr)
                {
                    max = tr.perimetr;
                }
                col++;
            }
            Console.WriteLine("Прямоугольных " + col + "Макс " + max + " Мин " + min);
            col = 0;

            var minsquartr = from triangle in list select triangle.square;
            min = 1111111111;
            foreach (double i in minsquartr)
            {
                if (i < min)
                {
                    min = i;
                }
            }
            Console.WriteLine("Минимальная площадь " + min);

            var diap = from triangle in list
                       where triangle.length_of_lines[0] < 6 && triangle.length_of_lines[0] > 3 &&
                        triangle.length_of_lines[1] < 6 && triangle.length_of_lines[1] > 3 &&
                        triangle.length_of_lines[2] < 6 && triangle.length_of_lines[2] > 3
                       select triangle;
            foreach (Triangle tr in diap)
            {
                Console.WriteLine(tr.ToString());
            }

            var sorttr = from Triangle in list
                         orderby Triangle.perimetr
                         select Triangle;
            foreach (Triangle tr in sorttr)
            {
                Console.WriteLine(tr.ToString());
            }
        }
    }
}

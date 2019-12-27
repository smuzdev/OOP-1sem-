using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_L2
{
    class Program
    {

        class Example : IDisposable
        {
            private readonly int _state;
            public Example(int state)
            {
                _state = state;
            }
            public int GetState() => _state;
            public void Dispose()
            {

            }
        }
        static int GetResult()
        {
            (int, int) tuple = (2, 10);
            if(IsMoreThan(tuple))
            Console.WriteLine("True");
            else
               Console.WriteLine("False");
            bool IsMoreThan((int,int) k)
            {
                if (k.Item1 == 5 && k.Item2 == 10)
                    return true;
                else return false;
            }

            var tuple1 = (count: 5, sum: 10 , name:"Vladislav");
            Console.WriteLine(tuple1.name);
            Console.WriteLine(tuple1.Item1);

            void WithCheck()
          
            {
                //checked
                //{
                //    int ten = 10;
                //    int temp = 2147483647 + ten;
                //    Console.WriteLine(temp);
                //}
            }
            void WithoutCheck()
            {
                int ten = 10;
                int temp = 2147483647 + ten;
                Console.WriteLine(temp);
            }
            WithCheck();
            WithoutCheck();
            return 1;
        }
        static void Main(string[] args)
        {
            ////The 1st task

            //int a = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Integer: " + a);
            //double b = Convert.ToDouble(Console.ReadLine());
            //Console.WriteLine("Double: " + b);
            //string c = Console.ReadLine();
            //Console.WriteLine("String: " + c);
            //char d = Convert.ToChar(Console.ReadLine());
            //Console.WriteLine("Char: " + d);
            //float e = Convert.ToSingle(Console.ReadLine());
            //Console.WriteLine("Float: " + e);

            //object objectInt = a;
            //object objectChar = d;
            //object objectFloat = e;
            //object objectDouble = b;
            //object objectString = c;

            //Console.WriteLine(string.Format($"{(int)objectInt}, {objectChar}, {objectFloat}, {objectDouble}, {objectString}"));
            ////---------------------------------------------

            //The 2nd task 

            int num = 13;
            string s = Convert.ToString(num);
            float i = num;
            long l = (long)num;
            Console.WriteLine("String = {0}, Float = {1}, Long = {2}", s, i, l);
            Console.ReadLine();

            //------------------------------------------------

            //The 3rd task

            string name = "Vladislav";
            string st = String.Format("My name is {0}.", name);

            Console.WriteLine(st);

            int a1 = 5;
            int b1 = 2;

            Console.WriteLine($"A sum of {a1} and {b1} is {a1 + b1}.");
            Console.ReadLine();

            //---------------------------------------------------

            //The 4th task

            Console.WriteLine(a1.ToString()); // для базовых типов

            Person person = new Person { Name = "Vladislav" }; // для классов
            Console.WriteLine(person.Name);
            Console.WriteLine("Hash for {0} is: {1}", person.Name, person.GetHashCode());

            Console.ReadLine();

            //---------------------------------------------------

            //The 5th task

            string s1 = "Vova";
            string s2 = "Delphi";

            Console.WriteLine(string.Compare(s1, s2)); // сравнивает строки 

            Console.WriteLine(s2.Contains(s1)); // проверяет, содержится ли в строке строка

            Console.WriteLine(s2.Substring(1, 4)); // извлекает символы из строки

            Console.WriteLine(s1.Insert(2, s2)); // вставляет строку 

            Console.WriteLine(s1.Replace('V', 'L'));

            Console.ReadLine();

            //---------------------------------------------

            //The 6th task

            string s3 = "";
            string s4 = null;
            string s5 = "Hello";

            bool isEmt1 = String.IsNullOrEmpty(s3);
            Console.WriteLine(isEmt1);
            bool isEmt2 = String.IsNullOrEmpty(s4);
            Console.WriteLine(isEmt2);
            bool isEmt3 = String.IsNullOrEmpty(s5);
            Console.WriteLine(isEmt3);

            Console.ReadLine();

            //----------------------------------------------

            //The 7th task

            //var value = "Something";
            //value = 5;

            //Console.ReadLine();

            //-----------------------------------------------

            //The 8th task

            Nullable<int> x1 = null;
            int? x2 = 5;
            if (x1 == x2)
                Console.WriteLine("объекты равны");
            else
                Console.WriteLine("объекты не равны");

            Console.ReadLine();
            //The 9th task

            GetResult();

            //The 10th task

            using (Example example = new Example(10))
            {
                Console.WriteLine(example.GetState());
            }
        }
    }
    class Person
    {
        public string Name { get; set; }
    }

}

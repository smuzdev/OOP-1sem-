using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_L8
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Stack<int> myStack1 = new Stack<int>();
                for (int i = 0; i < 15; i++)
                {
                    myStack1.Add(i);
                }
                myStack1.Show();
                Stack<int> myStack2 = new Stack<int>();
                for (int i = 3; i < 8; i++)
                {
                    myStack2.Add(i);
                }

                myStack2.Show();
                myStack1.Add(1);
                myStack1 = myStack1 + (-2);

                Console.WriteLine("myStack1 пуст? {0}\nmyStack2 пуст? {1}\n", myStack1 ? "true" : "false", myStack2 ? "true" : "false");

                myStack2.Remove();
                myStack2 = myStack2 + 5;

                Stack<int> myStack3 = myStack1 > myStack2;

                string testString = "Hello World! Привет Мир!";
                Console.WriteLine(testString + "\n" + string.Format("Количество предложений: {0}\n", testString.WordCount()));

                myStack3 = myStack3 + 7;
                Console.WriteLine("Средний элемент стека = " + Static.MediumElemStack(myStack3) + "\n");
                myStack1 = myStack1 + 1 + 2 + 3;

                Console.WriteLine("Максималный элемент стека = " + Static.GetMaxElement(myStack1) + "\n");

                Console.WriteLine(myStack3.Remove());
                Console.WriteLine(myStack3.Remove());
                myStack3--;
                Console.WriteLine(myStack3.Remove());
                myStack3.Show();
                Stack<int>.Owner owner = new Stack<int>.Owner(2, "", "");
                myStack1.owner.GetInfo();
                Console.WriteLine(myStack1.creationDate.ToString());
            }
            catch
            {
                Console.WriteLine("Ошибка");
            }
            finally
            {
                Console.WriteLine("Finally block");
            }
            Console.ReadKey();
        }
    }
}

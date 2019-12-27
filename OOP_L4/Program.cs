using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_L4
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack myStack1 = new Stack();
            Stack myStack2 = new Stack();

            myStack1.Push(1);
            myStack1 = myStack1 + (-2);

            Console.WriteLine("myStack1 пуст? {0}\nmyStack2 пуст? {1}\n", myStack1 ? "true" : "false", myStack2 ? "true" : "false");

            myStack2.Push(0);
            myStack2 = myStack2 + 5;

            Stack myStack3 = myStack1 > myStack2;

            string testString = "Hello World! Привет Мир!";
            Console.WriteLine(testString + "\n" + string.Format("Количество предложений: {0}\n", testString.WordCount()));

            myStack3 = myStack3 + 7;
            Console.WriteLine("Средний элемент стека = " + Static.MediumElemStack(myStack3) + "\n");
            myStack1 = myStack1 + 1 +2 +3;
            
            Console.WriteLine("Максималный элемент стека = " + Static.GetMaxElement(myStack1) + "\n");

            Console.WriteLine(myStack3.Pop());
            Console.WriteLine(myStack3.Pop());
            myStack3--;
            Console.WriteLine(myStack3.Pop());

            Stack.Owner owner = new Stack.Owner(2, "","");
            myStack1.creationDate.day = 1;


            Console.ReadKey();

        }
    }
 }





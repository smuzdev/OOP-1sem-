using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_L3
{
    public partial class Customer
    {
        public string country { get; set; }
        public readonly string company;
        public int deadline;
        static private int num;

        //Конструктор по умолчанию (а)
        public Customer()
        {
            country = "Belarus";
            company = "BuildIt";
            deadline = 3;
            Customer.Number();
        }

        //Конструктор с параметрами (b)
        public Customer(string n, string c, int d)
        {
            company = n;
            country = c;
            deadline = d;
            Customer.Number();
        }

        //Статический конструктор (c)
        static Customer()
        {
            Console.WriteLine("Ваши заказы:");
        }

        static class OutStatic
        {
            static public void OutStatic1(Customer cst)
            {
                Console.WriteLine(cst.ToString());
            }
        }

        //Конструктор копирования (d)
        public Customer(Customer previousCustomer)
        {
            company = previousCustomer.company;
            country = previousCustomer.country;
            deadline = previousCustomer.deadline;
            Customer.Number();
        }

        //Деструктор (f)
        ~Customer()
        {
            Console.WriteLine("Деструктор");
        }

        //Статический метод (g) 
        static public int Number()
        {
            return ++num;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer();
            Console.WriteLine(customer1.ToString());

            Customer customer2 = new Customer("BelGaz", "Belarus", 2);
            if (customer2.deadline <= 0 || customer2.company == "" || customer2.company == null)
            {
                Console.WriteLine("Некорректные данные");
            }
            else
            {
                Console.WriteLine(customer2.ToString());
            }

            Customer customer3 = new Customer("ALMI", "Russia", 6);
            Console.WriteLine(customer3.ToString());

            Customer customer4 = new Customer(customer2);
            Console.WriteLine(customer4.ToString());
            Console.ReadLine();

            if (customer1.Equals(customer2))
            {
                Console.WriteLine("Заказы равны");
            }
            else
            {
                Console.WriteLine("Заказы не равны");
            }
            Console.ReadLine();

            Console.WriteLine($"Hashcode for customer1: {customer1.GetHashCode()}");
            Console.WriteLine($"Hashcode for customer2: {customer2.GetHashCode()}");
            Console.WriteLine($"Hashcode for customer3: {customer3.GetHashCode()}");
            Console.ReadLine();

            int x = 10;
            int y = 15;
            int z = 0;
            Addition(ref x, y);
            Console.WriteLine("Сумма x и y: " + x);

            Sum(20, 40, out z);
            Console.WriteLine("Разность x и y: " + z);
            Console.ReadLine();

            // Анонимный тип
            var customer = new { company = "FITA", country = "Belgium", deadline = 10 };
            Console.WriteLine(customer.ToString());
            Console.WriteLine(customer.GetType());
            Console.ReadLine();

            MyCollection<Customer> customer5 = new MyCollection<Customer>();
            customer5.addItem(customer1);
            customer5.addItem(customer3);
            customer5.printAll();
            Customer customer6 = new Customer("Tweebykvai", "Belarus", 5);
            if (customer5.attend(customer6))
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
            MyCollection<Customer> customer10 = new MyCollection<Customer>();
            customer10.addItem(customer1);
            customer10.addItem(customer6);
            MyCollection<Customer> customer7 = customer5.Merge(customer10);
            Console.WriteLine("customer7: ");
            customer7.printAll();

            Singleton<int> singleton = new Singleton<int>();
            singleton.addItem(25);
            singleton.addItem(15);

            Console.WriteLine("\nSingleton : ");
            singleton.printAll();
            Singleton<int> singleton2 = new Singleton<int>();
            Console.WriteLine("\nSingleton2 : ");
            singleton2.printAll();
            singleton.addItem(100);
            Console.WriteLine("\nAfter add to first. The second: ");
            singleton2.printAll();
            Console.ReadLine();
            Console.ReadLine();
        }
        // параметр x передается по ссылке
        static void Addition(ref int x, int y)
        {
            x += y;
        }

        // выходной параметр z 
        static void Sum(int x, int y, out int z)
        {
            z = x - y;
        }
    }

    public class MyCollection<T>
    {
        private T[] items = new T[0];
        public int Count = 0;
        public void addItem(T item)
        {
            Array.Resize(ref items, items.Count() + 1);
            items[items.Count() - 1] = item;
            Count++;
        }
        public void removeItem(T item)
        {
            items[Array.IndexOf(items, item)] = items[items.Count() - 1];
            Array.Resize(ref items, items.Count() - 1);
            Count--;
        }
        public IEnumerable<T> getItems()
        {
            return items;
        }
        public void printAll()
        {
            Console.WriteLine();
            foreach (var oneitem in getItems())
            {
                Console.WriteLine(oneitem.ToString());
            }
            Console.WriteLine();
        }
        public bool attend(T item)
        {
            bool rc = false;
            foreach (var oneitem in getItems())
            {
                if (item.ToString() == oneitem.ToString())
                    rc = true;
            }
            return rc;
        }
        public MyCollection<T> Merge(MyCollection<T> second)
        {
            MyCollection<T> customer = new MyCollection<T>();
            foreach (var oneitem in second.getItems())
            {
                if (!(this.attend(oneitem)))
                    customer.addItem(oneitem);
            }
            foreach (var oneitem in this.getItems())
            {
                if (!(second.attend(oneitem)))
                    customer.addItem(oneitem);
            }
            return customer;
        }
    }
        class Singleton<T> : IDisposable
        {

            private static Singleton<T> instance;

            private static T[] items = new T[0];
            public void addItem(T item)
            {
                Array.Resize(ref items, items.Count() + 1);
                items[items.Count() - 1] = item;
            }
            public void removeItem(T item)
            {
                items[Array.IndexOf(items, item)] = items[items.Count() - 1];
                Array.Resize(ref items, items.Count() - 1);
            }
            public IEnumerable<T> getItems()
            {
                return items;
            }
            public Singleton()
            {
            }
            public static Singleton<T> getInstance()
            {
                if (instance == null)
                    instance = new Singleton<T>();
                return instance;
            }
            public void printAll()
            {
                Console.WriteLine();
                foreach (var oneitem in getItems())
                {
                    Console.WriteLine(oneitem);
                }
                Console.WriteLine();
            }
            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }
        }
    }


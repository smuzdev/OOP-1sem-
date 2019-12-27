using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace OOP_L8
{
    [Serializable]
    class Stack<T> : ICollectionType<T> where T : new()
    {
        private List<T> storage;
        public Owner owner;
        public Date creationDate;

        public class Owner
        {
            public int id;
            public string name;
            public string organisation;

            public Owner(int id, string name, string organisation)
            {
                this.id = id;
                this.name = name;
                this.organisation = organisation;
            }

            public void GetInfo()
            {
                Console.WriteLine($"ID: {id} Name: {name} Organization: {organisation}");
            }
        }
        public Stack()
        {
            this.storage = new List<T>();
            this.owner = new Owner(1, "Vladislav Taraikovich", "TBK");
            this.creationDate = new Date();
        }

        //Только для чтения
        public List<T> Storage
        {
            get
            {
                return this.storage;
            }
        }

        //Свойсто подсчета
        public int Count
        {
            get
            {
                return this.storage.Count;
            }
        }

        //Добавление элемента в стек
        public void Add(T element)
        {
            this.storage.Add(element);
        }

        //Удаление элемена из стека
        public T Remove()
        {
            int lastElementIndex = this.storage.Count - 1;
            T lastElement = this.storage[lastElementIndex];
            this.storage.RemoveAt(lastElementIndex);
            return lastElement;
        }
        public void Show()
        {
            foreach (T str in Storage)
            {
                Console.Write(str + " ");
            }
            Console.WriteLine();
        }

        //Индексатор
        public T this[int index]
        {
            get
            {
                return this.storage[index];
            }

            set
            {
                this.storage[index] = value;
            }
        }

        // + - добавить элемент в стек
        public static Stack<T> operator +(Stack<T> stack, T element)
        {
            stack.Add(element);
            return stack;
        }

        // -- - извлечь элемент из стека
        public static Stack<T> operator --(Stack<T> stack)
        {
            stack.Remove();
            return stack;
        }
        public static Stack<T> operator ++(Stack<T> stack)
        {
            Stack<int> stack1 = new Stack<int>();
            if (stack is Stack<int>)
            {
                stack1 = stack as Stack<int>;
                stack1.Add(8);
                stack = stack1 as Stack<T>;
                return stack;
            }
            else
            {
                Console.WriteLine("Error");
                return null;
            }
        }
        public bool ContainsNegatives()
        {
            bool containsNegatives = false;
            List<int> storage1 = new List<int>();
            if (storage is List<int>)
            {
                storage1 = storage as List<int>;
            }
            foreach (int n in storage1)
            {
                if (n < 0)
                {
                    containsNegatives = true;
                    break;
                }
            }
            return containsNegatives;
        }
        // true  - проверка, пустой ли стек
        public static bool operator true(Stack<T> stack)
        {
            return (stack.Count == 0);
        }
        public static bool operator false(Stack<T> stack)
        {
            return stack.ContainsNegatives();
        }

        // > - копирование одного стека в другой с сортировкой в возрастающем порядке
        public static Stack<T> operator >(Stack<T> stack1, Stack<T> stack2)
        {
            Stack<T> result = new Stack<T>();
            while (stack1.Count != 0)
            {
                result = result + stack1.Remove();
            }
            while (stack2.Count != 0)
            {
                result = result + stack2.Remove();
            }
            result.storage.Sort();
            return result;
        }
        public static Stack<T> operator <(Stack<T> a, Stack<T> b)
        {
            if (a.Count < b.Count)
            {
                return a;
            }
            else
            {
                return b;
            }
        }
        public void Save(string CurrentFile)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(CurrentFile, FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, storage);
                fs.Close();
            }
        }

        public void Upload(string CurrentFile)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(CurrentFile, FileMode.OpenOrCreate))
            {
                List<T> deser = (List<T>)bf.Deserialize(fs);
                foreach (T p in deser)
                {
                    if (p == null)
                        continue;
                    this.Add(p);
                }
                fs.Close();
            }
        }
    }
    public class Date
    {
        DateTime dateTime = DateTime.Now;
        public int day;

        public override String ToString()
        {
            return dateTime.ToShortDateString();
        }
        
    }
   
}


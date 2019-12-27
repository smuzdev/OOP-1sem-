using System;
using System.Collections.Generic;

namespace OOP_L8
{
    class Stack<T> : ICollectionType<T> where T: new()
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
        }
        public Stack()
        {
            this.storage = new List<T>();
            this.owner = new Owner(1, "Vladislav Taraikovich", "TBK");
            this.creationDate = new Date();
        }

        //Только для чтенияfd
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
                stack1.Add(1);
                stack = stack1 as Stack<T>;
                return stack;
            }
            else {
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
        }
}

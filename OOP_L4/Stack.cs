using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_L4
{
    class Stack
    {
        private List<int> storage;
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
            this.storage = new List<int>();
            this.owner = new Owner(1, "Vladislav Taraikovich", "TBK");
            this.creationDate = new Date();
        }

        //Только для чтенияfd
        public List<int> Storage
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
        public void Push(int element)
        {
            this.storage.Add(element);
        }

        //Удаление элемена из стека
        public int Pop()
        {
            int lastElementIndex = this.storage.Count-1;
            int lastElement = this.storage[lastElementIndex];
            this.storage.RemoveAt(lastElementIndex);
            return lastElement;
        }

        //Индексатор
        public int this[int index]
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
        public static Stack operator +(Stack stack, int element)
        {
            stack.Push(element);
            return stack;
        }

        // -- - извлечь элемент из стека
        public static Stack operator --(Stack stack)
        {
            stack.Pop();
            return stack;
        }
        public static Stack operator ++(Stack stack)
        {
            stack.Push(1);
            return stack;
        }
        public bool ContainsNegatives()
        {
            bool containsNegatives = false;
            foreach (int n in storage)
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
        public static bool operator true(Stack stack)
        {
            return (stack.Count == 0);
        }
        public static bool operator false(Stack stack)
        {
            return stack.ContainsNegatives();
        }

        // > - копирование одного стека в другой с сортировкой в возрастающем порядке
        public static Stack operator >(Stack stack1, Stack stack2)
        {
            Stack result = new Stack();
            while (stack1.Count != 0)
            {
                result = result + stack1.Pop();
            }
            while (stack2.Count != 0)
            {
                result = result + stack2.Pop();
            }
            result.storage.Sort();
            return result;
        }
        public static Stack operator <(Stack a, Stack b)
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

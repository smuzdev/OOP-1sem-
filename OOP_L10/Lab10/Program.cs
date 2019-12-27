using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab10
{
    public class Island : IComparable<Island>, IComparer<Island>
    {
        public string Name { get; set; }
        public Island(string nm)
        {
            this.Name = nm;
        }
        public int CompareTo(Island island)
        {
            return this.Name.CompareTo(island.Name);
        }

        public int Compare(Island i1, Island i2)
        {
            if (i1.Name.Length > i2.Name.Length)
            {
                return 1;
            }
            else if (i1.Name.Length < i2.Name.Length)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arrayList = new ArrayList
            {
                1, 2, 3, 4, 5,
                "Lex"
            };
            arrayList.RemoveAt(2);
            foreach (var a in arrayList)
            {
                Console.Write(a + " ");
            }

            Console.WriteLine("\nКоличество элементов:" + arrayList.Count);
            Console.WriteLine("Поиск элемента " + arrayList.Contains("Lex"));


            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(3);
            queue.Enqueue(42);
            queue.Enqueue(2);
            queue.Enqueue(5);

            queue.Dequeue();

            SortedDictionary<int, string> SDict = new SortedDictionary<int, string>
            {
                { queue.Dequeue(), "p" },
                { queue.Dequeue(), "o" },
                { queue.Dequeue(), "i" },
                { queue.Dequeue(), "t" },
            };
            foreach (var z in SDict)
            {
                Console.WriteLine(z);
            }

            Console.WriteLine(SDict.ContainsKey(5));
            Console.WriteLine(SDict.ContainsValue("o"));

            Queue<Island> island = new Queue<Island>();
            Island island1 = new Island("Sumatra");
            Island island2 = new Island("Schpicbergen");
            Island island3 = new Island("Corsika");
            island.Enqueue(island1);
            island.Enqueue(island2);
            island.Enqueue(island3);

            ObservableCollection<Island> p = new ObservableCollection<Island>();

            void p_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        Island newIsland = e.NewItems[0] as Island;
                        Console.WriteLine("Добавлен новый объект: " + newIsland.Name);
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        Island oldIsland = e.OldItems[0] as Island;
                        Console.WriteLine("Удален объект: " + oldIsland.Name);
                        break;
                }
            }

            p.CollectionChanged += p_CollectionChanged;

            p.Add(island1);
            p.Add(island2);
            p.Add(island3);
            p.RemoveAt(2);

            foreach (Island i in p)
            {
                Console.WriteLine(i.ToString());
            }
        }
    }
}
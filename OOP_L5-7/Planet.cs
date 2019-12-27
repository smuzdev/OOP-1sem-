using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_L5
{
    public class Planet
    {
        private List<Planet> List = new List<Planet>();
        public void Add(Planet item)
        {
            List.Add(item);
        }
        public void Remove(Planet item)
        {
            List.Remove(item);
        }
        public List<Planet> getList()
        {
            return List;
        }
        public virtual void Show()
        {
            foreach (var item in List)
                Console.WriteLine(item);
        }
        public Planet(string _name = null)
        {
            if (_name != null)
            {
                name = _name;
            }
            else
            {
                throw new EmptyException("Не задано имя планеты.");
            }
        }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        
        public virtual void Presipitation()
        {
            Console.WriteLine("Выпадение осадков");
        }
        

        public override string ToString()
        {
            return "Планета: " + Name;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}

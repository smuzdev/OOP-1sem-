using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_L5
{
     public class Continent : Land
    {
        private List<Continent> List = new List<Continent>();
        public void Add(Continent item)
        {
            List.Add(item);
        }
        public void Remove(Continent item)
        {
            List.Remove(item);
        }
        public override void Show()
        {
            foreach (var item in List)
                Console.WriteLine(item);
        }
        public Continent(string _name = "", string _coverness = "", int _area = -1) : base(_name,_coverness,_area)
        {
            Coverness = _coverness;
        }
        public override string Coverness { get; set; }
        public override void Presipitation()
        {
            Console.WriteLine("Дождь");
        }
        public override void Disasters()
        {
            Console.WriteLine("На континенте землетрясение");
        }
        public override string ToString()
        {
            return "Континент:\n" +
                   "\tНазвание: "+ Name.ToString() + 
                   "\n\tПлощадь: " + Area.ToString() + " млн.кв.км" +
                   "\n\tПоверхность: " + Coverness.ToString();

        }
    }
}

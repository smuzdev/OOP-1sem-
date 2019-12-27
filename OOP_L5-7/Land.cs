using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_L5
{

    public abstract class Land : Planet
    {
        static void AAA()
        {

        }
        public Land(string _name = "", string _coverness = "", int _area = -1) : base(_name)
        {
            Coverness = _coverness;
            area = _area;

        }
        public abstract string Coverness { get; set; }
        private int area;
        public int Area
        {
            get
            {
                return area;
            }
            set
            {
                area = value;
            }
        }
        public abstract void Disasters();
        public override string ToString()
        {
            return "Суша:\n" +
                   "\tПлощадь: " + Area.ToString() + " млн.кв.км" +
                   "\n\tПоверхность: " + Coverness.ToString();
        }
    }
}

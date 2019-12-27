using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_L5
{
    class Sea : Planet, IWater, IMethod
    {
        public Sea(string _name = "", double _temperature = -1, int _deepness = -1) : base(_name)
        {
            temperature = _temperature;
            deepness = _deepness;
        }
        private double temperature;
        private int deepness;

        public double Temperature
        {
            get
            {
                return temperature;
            }
            set
            {
                temperature = value;
            }
        }
        public int Deepness
        {
            get
            {
                return deepness;
            }
            set
            {
                deepness = value;
            }
        }

        public override void Presipitation()
        {
            Console.WriteLine("Дождь");
        }
        void IWater.Method()
        {
            Console.WriteLine("Вызван метод интерфейса IWater");
        }
        void IMethod.Method()
        {
            Console.WriteLine("Вызван метод интерфейса IMethod");
        }
        public override string ToString()
        {
            return "Море:\n" +
                   "\tНазвание: " + Name.ToString() +
                   "\n\tГлубина: " + deepness.ToString() + " м" +
                   "\n\tТемпература: " + temperature.ToString() + " градусов";
        }
    }
}

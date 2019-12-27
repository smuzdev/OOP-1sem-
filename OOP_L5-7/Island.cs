using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_L5
{
    sealed class Island: Land, IWater
    {
        enum Habitebility
        {
            uninhabited,
            habitable
        }
        private Habitebility habitebility;

        public Island(string _name = "", string _coverness = "", int _area = -1, int _habitebility = -1,double _temperature = -1) : base(_name, _coverness, _area)
        {
           
            switch (_habitebility)
            {
                case 0:
                    habitebility = Habitebility.uninhabited;
                    break;
                case 1:
                    habitebility = Habitebility.habitable;
                    break;
                default:
                    throw new ConstructorException("Ошибка в конструкторе Остров");
                   
            }
            temperature = _temperature;
        }
        public override string Coverness { get; set; }

        private double temperature;
        public double Temperature { get => temperature; set => temperature = value; }
        void IWater.Method()
        {
            Console.WriteLine("Вызван метод интерфейса IWater");
        }

        public override void Disasters()
        {
            Console.WriteLine("На острове потоп");
        }
        public override string ToString()
        {
            return "Остров:\n" +
                   "\tНазвание: " + Name.ToString() +
                   "\n\tПлощадь: " + Area.ToString() + " тыс.кв.км" +
                   "\n\tОбитаемось: " + habitebility.ToString() +
                   "\n\tПоверхность: " + Coverness.ToString()+
                   "\n\tТемпература: " + temperature.ToString();

        }
    }
}

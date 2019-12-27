using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;
namespace lab14
{
    [Serializable]
    [XmlRoot("Human")]
    public partial class Human:IIntelligentCreature
    {
        private string sex;
        private int age;
        private int iq;
        private string name;
        private int lifelength;
        public int LifeLength
        {
            get => lifelength;
            set => lifelength = value;
        }
        public Human()
        {
            LifeLength = 100;
            sex = "";
            age = -1;
            iq = -1;
            name = "";
        }
        public Human(string _sex, int _age, int _iq, string _name)
        {
            LifeLength = 100;
            sex = _sex;
            age = _age;
            iq = _iq;
            name = _name;
        }
        public string Name
        {
            get => name;
            set => name = value;
        }
        public string Sex
        {
            get => sex;
            set => sex = value;
        }
        public int Age
        {
            get => age;
            set => age = value;
        }
        public int IQ
        {
            get => iq;
            set => iq = value;
        }
        public void Think()
        {
            Console.WriteLine("think");
        }
        public override string ToString()
        {
            return "Человек:\n" +
                   "Продолжительность жизни: " + "~" + LifeLength + " лет" +
                   "\nИмя: " + name.ToString() +
                   "\nПол: " + sex.ToString() +
                   "\nВозвраст: " + age.ToString() + " лет" +
                   "\nIQ: " + iq.ToString();
        }
    }
}
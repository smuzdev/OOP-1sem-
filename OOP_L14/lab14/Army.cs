using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Xml;
using System.Xml.XPath;
using System.IO;
namespace lab14
{
    [Serializable]
    [XmlRoot("Human")]
    
    public class Army
    {
        private List<Human> units = new List<Human>();
        public Army()
        {

        }
        [XmlAttribute]
        public int Count => units.Count;
        [XmlArray("ListofUnits")]
        [XmlArrayItem("Human")]
        [XmlIgnore]
        public List<Human> ListofUnits
        {
            get => units;
            set => units = value;
        }
        public void Add(Human human)
        {
            Human x = human;
            units.Add(x);
        }
        public void Remove(Human human)
        {
            Human x = human;
            units.Remove(x);
        }
        public void ToConsole()
        {
            Human[] arr = units.ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine((i + 1).ToString() + ' ' + arr[i].ToString() + '\n');
            }
           }
    }
}

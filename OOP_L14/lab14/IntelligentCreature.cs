using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab14
{

    public interface IIntelligentCreature
    {
        int LifeLength { get;  }
        int IQ { get; }
        string Name { get; }
        void Think();
    }
}

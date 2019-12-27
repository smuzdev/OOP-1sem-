using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_L3
{
    public partial class Customer
    {
        public override string ToString()
        {
            string str = String.Format("Компания: {0}  Страна: {1} Срок выполнения: {2} Заказ № {3}", company, country, deadline, num);
            return str;
        }

        public bool Equals(Customer customer1)
        {
            if (customer1.company == company && customer1.country == country && customer1.deadline == deadline)
                return true;
            else return false;
        }
        public override int GetHashCode()
        {
            int hash = company.GetHashCode() + country.GetHashCode() + deadline.GetHashCode();
            return hash;
        }

    }
}


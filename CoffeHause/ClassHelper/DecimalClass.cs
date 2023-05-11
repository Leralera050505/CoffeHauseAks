using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeHause.ClassHelper
{
    public class DecimalClass
    {
        public static decimal Discount(decimal price, decimal discount)
        {
            return price - (price * discount);
        }
    }
}

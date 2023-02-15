using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CoffeHause.DB;

namespace CoffeHause.ClassHelper
{
    public class EFclass
    {
        public static Entities Contex { get; } = new Entities();
    }
}

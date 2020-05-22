using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19052020
{
    public class Tovar
    {
        public string Name { get; set; }
        public string MadeIn { get; set; }
        double price;
        public double Price { 
            get=>price;
            set {
                if (value >= 0)
                    price = value;
            }
        }
        public override string ToString()
        {
            return $"{Name} {MadeIn} {Price,5:f2}";
        }
    }
}

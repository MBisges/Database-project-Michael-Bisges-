using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        public string Manufacturer { get; set; }

        public int Price { get; set; }

        public string fullDetails
        {
            get
            {
                return ProductID.ToString() + " " + ProductName + " " + Manufacturer + " " + Price.ToString();
            }
        }
    }
}

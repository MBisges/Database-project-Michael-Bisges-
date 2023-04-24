using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4
{
    public class Order
    {
        public int OrderID { get; set; }
        public int TotalCost { get; set; }

        public int ProductID { get; set; }

        public int CustomerID { get; set; }

        public int TypeID { get; set; }

        public string fullDetails
        {
            get
            {
                return OrderID.ToString() + " " + TotalCost.ToString() + " " + ProductID.ToString() + " " + CustomerID.ToString() + " " + TypeID.ToString();
            }
        }
    }
}

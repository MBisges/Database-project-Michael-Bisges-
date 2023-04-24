using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4
{
    public class Customers
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }

        public string Address { get; set; }

        public int TotalOrders { get; set;}


        public string fullDetails
        {
            get
            {
                return CustomerID.ToString() + " " + CustomerName + " " + Address + " " + TotalOrders.ToString();
            }
        }
    }
}
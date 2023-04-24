using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4
{
    public class DeliveryType
    {
        public int TypeID { get; set; }
        public string title { get; set; }

        public int DaysToDeliver { get; set; }

        public int AdditionalCost { get; set; }

        public string fullDetails
        {
            get
            {
                return TypeID.ToString() + " " + title + " " + DaysToDeliver.ToString() + " " + AdditionalCost.ToString();
            }
        }
    }
}

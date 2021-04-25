using System;
using System.Collections.Generic;
using System.Text;

namespace DBFirstBack_End.Models
{
    public class OrderDetailsModel
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPri { get; set; }
        public short Quantity { get; set; }
    }
}

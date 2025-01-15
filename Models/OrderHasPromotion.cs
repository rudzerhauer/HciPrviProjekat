using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class OrderHasPromotion
    {
        public int OrderID { get; set; }
        public int PromotionID { get; set; }

        // Navigation properties
        public Order Order { get; set; }
        public Promotion Promotion { get; set; }
    }

}

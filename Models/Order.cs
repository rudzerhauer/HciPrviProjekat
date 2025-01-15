using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;


namespace WpfApp1.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public int TableID { get; set; }
        public int EmployeeID { get; set; }
        public bool IsClosed { get; set; }
        public decimal TotalPrice { get; set; }

        // Navigation properties
        public CafeTable Table { get; set; }
        public Employee Employee { get; set; }
        public List<OrderHasProduct> OrderHasProducts { get; set; }
        public List<OrderHasPromotion> OrderHasPromotions { get; set; }
    }
    
}

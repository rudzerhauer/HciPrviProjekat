using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class CafeTable
    {
        public int TableID { get; set; }
        public int Capacity { get; set; }
        public bool IsOccupied { get; set; }
        public int? AssignedEmployeeID { get; set; } // The employee managing the table, nullable in case no employee is assigned
        public int? OrderID { get; set; } // The order associated with this table

        // Navigation properties (Optional)
        public Employee AssignedEmployee { get; set; }
        public Order Order { get; set; }
        public override string ToString()
        {
            return $"Table ID: {TableID}, Capacity: {Capacity}, Occupied: {IsOccupied}";
        }
    }
   

}

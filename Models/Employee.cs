using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class Employee
    {
        public int EmployeeId
        {
            get; set;
        }
        public string FullName{
            get;set;
        }
        public string Username {
            get;set;
        }
        public string PasswordHash {
            get;set;
        }
        public string Role {
            get;set;
        }
        public string Email {
            get;set;
        }
        public string PhoneNumber {
            get;set;
        }
    }
}

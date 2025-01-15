﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class Product
    {
        public int ProductID {
            get; set;
        }
        public string Name {
            get; set;
        }
        public double Price {
            get;set;
        }
        public string Description
        {
            get;set;
        }
        public int QuantityInStock {
            get;set;
        }

    }
}

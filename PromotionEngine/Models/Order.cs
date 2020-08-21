﻿using PromotionEngine.PromotionRuleEngine.Managers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public List<Product> Products { get; set; }
        public Order(int _oid, List<Product> _prods)
        {
            this.OrderID = _oid;
            this.Products = _prods;
        } 
    }
}

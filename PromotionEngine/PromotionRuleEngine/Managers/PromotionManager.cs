using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.PromotionRuleEngine.Managers
{
  public  class PromotionManager : IPromotionManager
    {
        //returns PromotionID and count of promotions
        private decimal GetTotalPrice(Order ord, Promotion prom)
        {
            decimal d = 0M;
            //get count of promoted products in order
            var copp = ord.Products
                .GroupBy(x => x.Id)
                .Where(grp => prom.ProductInfo.Any(y => grp.Key == y.Key && grp.Count() >= y.Value))
                .Select(grp => grp.Count())
                .Sum();
            //get count of promoted products from promotion
            int ppc = prom.ProductInfo.Sum(kvp => kvp.Value);
            while (copp >= ppc)
            {
                d += prom.PromoPrice;
                copp -= ppc;
            }
            return d;
        }

        public void CreateOrder(List<Promotion> promotions)
        {
            List<Order> orders = new List<Order>();
            Order order1 = new Order(1, new List<Product>() { new Product("A"), new Product("A"), new Product("B"), new Product("B"), new Product("C"), new Product("D") });
            Order order2 = new Order(2, new List<Product>() { new Product("A"), new Product("A"), new Product("A"), new Product("A"), new Product("A"), new Product("A"), new Product("B") });
            Order order3 = new Order(3, new List<Product>() { new Product("A"), new Product("A"), new Product("D"), new Product("B"), new Product("B") });
            orders.AddRange(new Order[] { order1, order2, order3 });
            //check if order meets promotion
            foreach (Order ord in orders)
            {
                List<decimal> promoprices = promotions
                    .Select(promo => GetTotalPrice(ord, promo))
                    .ToList();
                decimal origprice = ord.Products.Sum(x => x.Price);
                decimal promoprice = promoprices.Sum();
                Console.WriteLine($"OrderID: {ord.OrderID} => Original price: {origprice.ToString("0.00")} | Rebate: {promoprice.ToString("0.00")} | Final price: {(origprice - promoprice).ToString("0.00")}");
            }
        }
    }
}

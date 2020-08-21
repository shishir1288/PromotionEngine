using PromotionEngine.Models;
using PromotionEngine.PromotionRuleEngine.Factory;
using PromotionEngine.PromotionRuleEngine.Managers;
using System;
using System.Collections.Generic; 

namespace PromotionEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            //we need to add information about Product's count
            Dictionary<String, int> d1 = new Dictionary<String, int>();
            d1.Add("A", 3);
            Dictionary<String, int> d2 = new Dictionary<String, int>();
            d2.Add("B", 2);
            Dictionary<String, int> d3 = new Dictionary<String, int>();
            d3.Add("C", 1);
            d3.Add("D", 1);


            //create list of promotions
            List<Promotion> promotions = new List<Promotion>()
            {
                new Promotion(1, d1, 130),
                new Promotion(2, d2, 45),
                new Promotion(3, d3, 30)
            };

            //Factroy pattern used because in fetaure more pormotion needs to implement we can arrange it without impacting the actual implementation
            ApplyPromotionForOrderFactory promotionManagerFactory = new ApplyPromotionForOrderFactory();
            IPromotionManager promotionManager = promotionManagerFactory.ApplyPromotionOnOrder(promotions, 1);
            promotionManager.CreateOrder(promotions);
            Console.ReadLine();
        }
    
       
    }
}

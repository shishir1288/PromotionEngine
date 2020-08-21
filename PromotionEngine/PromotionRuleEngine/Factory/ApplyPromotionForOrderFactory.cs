using PromotionEngine.Models;
using PromotionEngine.PromotionRuleEngine.Managers;
using System.Collections.Generic;

namespace PromotionEngine.PromotionRuleEngine.Factory
{
    public class ApplyPromotionForOrderFactory
    {
        public IPromotionManager ApplyPromotionOnOrder(List<Promotion> promotions, int promoID)
        {
            IPromotionManager promotionManager = null;
            //create orders

            switch (promoID) // if in future need to more promotions than just create class and the instance based upon called promoID
            {
                case 1:
                    promotionManager = new PromotionManager();
                    break;
                default:
                    break;
            }

            return promotionManager;
        }

    }
}

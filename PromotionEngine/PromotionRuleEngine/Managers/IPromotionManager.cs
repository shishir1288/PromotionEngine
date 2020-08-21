using PromotionEngine.Models;
using System.Collections.Generic;

namespace PromotionEngine.PromotionRuleEngine.Managers
{
    public interface IPromotionManager
    {
        void CreateOrder(List<Promotion> promotions);
    }
}

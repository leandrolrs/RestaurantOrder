using RestaurantOrder.Enumerations;
using RestaurantOrder.Domain;
using System.Collections.Generic;
using System.Linq;


namespace RestaurantOrder.Rules
{
    public class MorningEntreeRule : IOrderTypeRule
    {
        public void GetOrder(OrderDomain order)
        {
            List<string> entreeItems = new List<string>() { FoodItems.Eggs.ToString() };

            foreach (var dType in order.DishTypes.Where(x=>x == DishType.Entree))
            {
                var existingOrder = order.ReturnOrders.Where(x => x.Key == DishType.Entree).Select(x=>x.Value);

                if (existingOrder.Count() > 0)
                {
                     order.ErrorMessage = "Can not order more than one Entree.";
                }
                else
                {                   
                    order.ReturnOrders.Add(dType, entreeItems);
                }
            }
            
        }
    }
}

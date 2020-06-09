using RestaurantOrder.Enumerations;
using RestaurantOrder.Domain;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantOrder.Rules
{
    public class NightSideRule : IOrderTypeRule
    {
        public void GetOrder(OrderDomain order)
        {
            var sidesQuery = order.DishTypes.Where(x => x == DishType.Side);

            if (sidesQuery.Count() > 0)
            {
                List<string> sideItems = new List<string>();

                foreach (var dType in sidesQuery)
                {
                    sideItems.Add(FoodItems.Potato.ToString());
                }

                order.ReturnOrders.Add(DishType.Side, sideItems);
            }

        }
    }
}

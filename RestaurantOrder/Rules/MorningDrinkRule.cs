using RestaurantOrder.Enumerations;
using RestaurantOrder.Domain;
using System.Collections.Generic;
using System.Linq;


namespace RestaurantOrder.Rules
{
    class MorningDrinkRule : IOrderTypeRule
    {
        public void GetOrder(Order order)
        {
            var drinkQuery = order.DishTypes.Where(x => x == DishType.Drink);

            if(drinkQuery.Count() > 0)
            {
                List<string> drinkItems = new List<string>();

                foreach (var dType in drinkQuery)
                {
                    drinkItems.Add(FoodItems.Coffee.ToString());
                }

                order.ReturnOrders.Add(DishType.Drink, drinkItems);
            }            
        }
    }
}

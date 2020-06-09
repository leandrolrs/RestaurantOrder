using RestaurantOrder.Enumerations;
using RestaurantOrder.Domain;
using System.Collections.Generic;
using System.Linq;


namespace RestaurantOrder.Rules
{
    public class NightDrinkRule : IOrderTypeRule
    {
        public void GetOrder(OrderDomain order)
        {
            List<string> drinkItems = new List<string>() { FoodItems.Wine.ToString() };

            foreach (var dType in order.DishTypes.Where(x => x == DishType.Drink))
            {
                var existingOrder = order.ReturnOrders.Where(x => x.Key == DishType.Drink);

                if (existingOrder.Count() > 1)
                {
                    order.ErrorMessage = "Can not order more than one Drink.";
                }
                else
                {
                    order.ReturnOrders.Add(dType, drinkItems);
                }
            }
        }
    }
}

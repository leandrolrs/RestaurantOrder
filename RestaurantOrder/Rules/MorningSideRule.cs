using RestaurantOrder.Enumerations;
using RestaurantOrder.Domain;
using System.Collections.Generic;
using System.Linq;


namespace RestaurantOrder.Rules
{
    public class MorningSideRule : IOrderTypeRule
    {
        public void GetOrder(OrderDomain order)
        {
            List<string> sideItems = new List<string>() { FoodItems.Toast.ToString() };

            foreach (var dType in order.DishTypes.Where(x => x == DishType.Side))
            {
                var existingOrder = order.ReturnOrders.Where(x => x.Key == DishType.Side);

                if (existingOrder.Count() > 1)
                {
                    order.ErrorMessage = "Can not order more than one Side.";
                }
                else
                {
                    order.ReturnOrders.Add(dType, sideItems);
                }
            }
        }
    }
}

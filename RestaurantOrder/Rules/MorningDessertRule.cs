using RestaurantOrder.Domain;
using RestaurantOrder.Enumerations;
using System.Linq;


namespace RestaurantOrder.Rules
{
    public class MorningDessertRule : IOrderTypeRule
    {
        public void GetOrder(OrderDomain order)
        {
            if(order.DishTypes.Where(x => x == DishType.Dessert).Count() > 0)
            {
                order.ErrorMessage = "Invalid Order.";   
            }
        }
    }
}
 
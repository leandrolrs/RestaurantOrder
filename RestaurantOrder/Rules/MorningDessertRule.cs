using RestaurantOrder.Domain;
using RestaurantOrder.Enumerations;
using System.Linq;


namespace RestaurantOrder.Rules
{
    class MorningDessertRule : IOrderTypeRule
    {
        public void GetOrder(Order order)
        {
            if(order.DishTypes.Where(x => x == DishType.Dessert).Count() > 0)
            {
                order.ErrorMessage = "Invalid Order.";   
            }
        }
    }
}

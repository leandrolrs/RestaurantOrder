using RestaurantOrder.Enumerations;
using RestaurantOrder.Domain;
using System.Linq;

namespace RestaurantOrder.Rules
{
    class InvalidSelectionRule : IOrderTypeRule
    {
        public void GetOrder(Order order)
        {
            if (order.DishTypes.Where(x => x == DishType.Invalid).Count() > 0)
            {
                order.ErrorMessage = "Invalid Selection";
            }
            
        }
    }
}

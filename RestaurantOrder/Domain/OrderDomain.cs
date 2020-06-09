using RestaurantOrder.Enumerations;
using System.Collections.Generic;

namespace RestaurantOrder.Domain
{
    public class OrderDomain
    {
        public List<DishType> DishTypes { get; set; }

        public TimeOfDay TimeOfDay { get; set; }

        public Dictionary<DishType, List<string>> ReturnOrders = new Dictionary<DishType, List<string>>();

        public string ErrorMessage { get; set; }
    }
}

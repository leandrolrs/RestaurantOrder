using RestaurantOrder.Enumerations;

namespace RestaurantOrder.Domain
{
    public class OrderItemDomain
    {
        public DishType DishType { get; set; }
        public TimeOfDay TimeOfDay { get; set; }

    }
}

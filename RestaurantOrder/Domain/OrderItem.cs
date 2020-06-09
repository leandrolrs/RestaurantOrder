using RestaurantOrder.Enumerations;

namespace RestaurantOrder.Domain
{
    public class OrderItem
    {
        public DishType DishType { get; set; }
        public TimeOfDay TimeOfDay { get; set; }

    }
}

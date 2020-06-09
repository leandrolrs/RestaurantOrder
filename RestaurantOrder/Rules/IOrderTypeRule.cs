using RestaurantOrder.Domain;

namespace RestaurantOrder.Rules
{
    public interface IOrderTypeRule
    {
        void GetOrder(Order order);
    }
}

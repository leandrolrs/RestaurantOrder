using RestaurantOrder.Domain;

namespace RestaurantOrder.Rules
{
    interface IOrderTypeRule
    {
        void GetOrder(Order order);
    }
}

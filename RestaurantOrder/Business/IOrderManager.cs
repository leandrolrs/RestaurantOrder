namespace RestaurantOrder.Business
{
    public interface IOrderManager
    {
        string GetOrder(string[] orderParams);
    }
}

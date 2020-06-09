namespace RestaurantOrder.Business
{
    interface IOrderFood
    {
        string GetOrder(string[] orderParams);
    }
}

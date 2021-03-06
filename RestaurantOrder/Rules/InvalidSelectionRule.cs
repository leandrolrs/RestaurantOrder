﻿using RestaurantOrder.Enumerations;
using RestaurantOrder.Domain;
using System.Linq;

namespace RestaurantOrder.Rules
{
    public class InvalidSelectionRule : IOrderTypeRule
    {
        public void GetOrder(OrderDomain order)
        {
            if (order.DishTypes.Where(x => x == DishType.Invalid).Count() > 0)
            {
                order.ErrorMessage = "Invalid Selection";
            }
            
        }
    }
}

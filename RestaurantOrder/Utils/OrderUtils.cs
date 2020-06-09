using RestaurantOrder.Domain;
using RestaurantOrder.Enumerations;
using RestaurantOrder.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestaurantOrder.Utils
{
    public class OrderUtils
    {

        List<IOrderTypeRule> _rules = new List<IOrderTypeRule>();
        public string GetOrderOutput(string[] orderParams)
        {

            OrderDomain order = BuildOrder(orderParams);

            _rules = RulesEngine.GetRules(order);

            foreach (var rule in _rules)
            {
                rule.GetOrder(order);

                if (!string.IsNullOrWhiteSpace(order.ErrorMessage))
                {
                    break;
                }
            }

            var orderOutput = GenerateFormattedOutput(order);

            return orderOutput;
        }

        public string GenerateFormattedOutput(OrderDomain order)
        {
            StringBuilder formattedStringOutput = new StringBuilder();

            string prefix = "";
            foreach (var item in order.ReturnOrders)
            {
                formattedStringOutput.Append(prefix);
                prefix = ",";

                formattedStringOutput.Append(item.Value[0].ToLower());
                if (item.Value.Count() > 1)
                {
                    formattedStringOutput.Append(string.Format("(x{0})", item.Value.Count()));
                }
            }

            if (!string.IsNullOrWhiteSpace(order.ErrorMessage))
            {
                formattedStringOutput.Append(prefix);
                formattedStringOutput.Append("error");
            }

            return formattedStringOutput.ToString();
        }

        private OrderDomain BuildOrder(string[] orderParams)
        {
            List<string> lstOrdParams = orderParams.ToList();

            OrderDomain inputOrder = new OrderDomain();

            TimeOfDay timeOfDay = (TimeOfDay)Enum.Parse(typeof(TimeOfDay), lstOrdParams[0].ToUpper());

            inputOrder.TimeOfDay = timeOfDay;
            inputOrder.DishTypes = new List<DishType>();

            if (string.IsNullOrWhiteSpace(lstOrdParams.Skip(1).Last().ToString()))
            {
                lstOrdParams.RemoveAt(lstOrdParams.Count() - 1);
            }

            foreach (var itemId in lstOrdParams.Skip(1))
            {
                DishType _dtype;
                int intEnumValue;
                if (int.TryParse(itemId, out intEnumValue))
                {
                    if (Enum.IsDefined(typeof(DishType), intEnumValue))
                    {
                        _dtype = (DishType)(object)intEnumValue;
                    }
                    else
                    {
                        _dtype = DishType.Invalid;
                    }
                }
                else
                {
                    throw new InvalidCastException("Invalid selection.");
                }

                inputOrder.DishTypes.Add(_dtype);

            }

            return inputOrder;
        }
    }
}

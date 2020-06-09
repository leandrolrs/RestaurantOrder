﻿using RestaurantOrder.Enumerations;
using RestaurantOrder.Domain;
using System.Collections.Generic;


namespace RestaurantOrder.Rules
{
    public class RulesEngine
    {
        public static List<IOrderTypeRule> GetRules(Order order)
        {
            List<IOrderTypeRule> _rules = new List<IOrderTypeRule>();            

            if (order.TimeOfDay == TimeOfDay.MORNING)
            {
                _rules.Add(new MorningEntreeRule());
                _rules.Add(new MorningSideRule());
                _rules.Add(new MorningDrinkRule());
                _rules.Add(new MorningDessertRule());
            }
            else
            {
                _rules.Add(new NightEntreeRule());
                _rules.Add(new NightSideRule());
                _rules.Add(new NightDrinkRule());
                _rules.Add(new NightDessertRule());
            }

            _rules.Add(new InvalidSelectionRule());

            return _rules;
        }
    }
}

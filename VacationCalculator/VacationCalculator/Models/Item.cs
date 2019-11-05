using SQLite;
using System;

namespace VacationCalculator.Models
{
    public class Item
    {
        [PrimaryKey]
        public string Date { get; set; }
        public string Description { get; set; }
    }

    public class SettingItem
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string Value { get; set; }

        public SettingItem()
        {
        }

        public SettingItem(string id, string value)
        {
            Id = id;
            Value = value;
        }
    }

    enum SettingItems
    {
        BeginningDate,
        InitialDays,
        PercentOfPay
    }
}
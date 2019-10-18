using SQLite;
using System;

namespace VacationCalculator.Models
{
    public class Item
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
    }
}
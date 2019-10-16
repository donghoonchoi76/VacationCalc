using System;

using VacationCalculator.Models;

namespace VacationCalculator.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Date;
            Item = item;
        }
    }
}

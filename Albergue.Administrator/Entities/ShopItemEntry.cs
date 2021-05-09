
using Albergue.Administrator.Model;
using System.Collections.Generic;

namespace Albergue.Administrator.Entities
{
    public class ShopItemEntry
    {
        public string Id { get; set; }
        public double Price { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        //WIP
        //public List<string> ImageUrls { get; set; }

        public string CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

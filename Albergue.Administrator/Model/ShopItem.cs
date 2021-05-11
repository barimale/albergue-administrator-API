using System.Collections.Generic;

namespace Albergue.Administrator.Model
{
    public class ShopItem
    {
        public string Id { get; set; }
        public double Price { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
    }
}

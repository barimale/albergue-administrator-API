using System.Collections.Generic;

namespace Albergue.Administrator.Model
{
    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<ShopItem> ShopItems { get; } = new List<ShopItem>();
    }
}

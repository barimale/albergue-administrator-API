
using System.Collections.Generic;

namespace Albergue.Administrator.Entities
{
    public class CategoryEntry
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<ShopItemEntry> ShopItems { get; } = new List<ShopItemEntry>();
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Albergue.Administrator.Entities
{
    public class CategoryEntry
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public List<ShopItemEntry> ShopItems { get; } = new List<ShopItemEntry>();
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Albergue.Administrator.Entities
{
    public class CategoryEntry
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public List<CategoryTranslatableDetailsEntry> TranslatableDetails { get; set; }
        public List<ShopItemEntry> ShopItems { get; set; }
    }
}

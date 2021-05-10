
using Albergue.Administrator.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Albergue.Administrator.Entities
{
    public class ShopItemEntry
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

using System.ComponentModel.DataAnnotations.Schema;

namespace Albergue.Administrator.Entities
{
    public class CategoryTranslatableDetailsEntry
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }

        public LanguageCategoryEntry Language { get; set; }

        public string CategoryId { get; set; }
        public CategoryEntry Category { get; set; }
    }
}

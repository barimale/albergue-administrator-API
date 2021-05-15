using System.Collections.Generic;

namespace Albergue.Administrator.Model
{
    public class Category
    {
        public Category()
        {
            TranslatableDetails = new List<CategoryTranslatableDetails>();
        }

        public string Id { get; set; }
        public List<CategoryTranslatableDetails> TranslatableDetails { get; set; }
    }
}

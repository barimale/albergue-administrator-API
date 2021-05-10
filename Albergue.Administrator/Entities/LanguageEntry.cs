using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Albergue.Administrator.Entities
{
    public class LanguageEntry
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Alpha2Code { get; set; }
    }
}
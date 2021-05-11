using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Albergue.Administrator.Entities
{
    public class LanguageEntry
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; private set; } = Guid.NewGuid().ToString();
        public string Alpha2Code { get; set; }
    }
}
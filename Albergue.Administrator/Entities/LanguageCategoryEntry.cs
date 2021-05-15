namespace Albergue.Administrator.Entities
{
    public class LanguageCategoryEntry: LanguageBaseEntry
    {
        public string CategoryTranslatableDetailsEntryId { get; set; }
        public CategoryTranslatableDetailsEntry CategoryTranslatableDetailsEntry { get; set; }
    }
}
namespace Albergue.Administrator.Entities
{
    public class LanguageShopItemEntry: LanguageBaseEntry
    {
        public string ShopItemTranslatableDetailsEntryId { get; set; }
        public ShopItemTranslatableDetailsEntry ShopItemTranslatableDetailsEntry { get; set; }
    }
}
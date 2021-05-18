using Albergue.Administrator.Entities;
using Albergue.Administrator.Model;
using AutoMapper;

namespace Albergue.Administrator.Mappings
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            //WIP put Id generating here
            CreateMap<Category, CategoryEntry>().ReverseMap();
            CreateMap<ShopItem, ShopItemEntry>().ReverseMap();
            CreateMap<Language, LanguageBaseEntry>().ReverseMap();
            CreateMap<Image, ImageEntry>().ReverseMap();
            //CreateMap<LanguageMap, LanguageMapEntry>().ReverseMap();
            CreateMap<CategoryTranslatableDetails, CategoryTranslatableDetailsEntry>().ReverseMap();
            CreateMap<ShopItemTranslatableDetails, ShopItemTranslatableDetailsEntry>().ReverseMap();

            //WIP check if blowed mappings are needed at all
            CreateMap<LanguageMapEntry, LanguageMapEntry>();
            CreateMap<ShopItemTranslatableDetails, ShopItemTranslatableDetails>();
            CreateMap<ShopItemTranslatableDetailsEntry, ShopItemTranslatableDetailsEntry>();
            CreateMap<ShopItemEntry, ShopItemEntry>();
            CreateMap<Category, Category>();
            CreateMap<CategoryTranslatableDetails, CategoryTranslatableDetails>();
            CreateMap<ShopItem, ShopItem>();
            CreateMap<Image, Image>();
        }
    }
}

using Albergue.Administrator.Entities;
using Albergue.Administrator.Model;
using AutoMapper;

namespace Albergue.Administrator.Mappings
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Category, CategoryEntry>().ReverseMap();
            CreateMap<ShopItem, ShopItemEntry>().ReverseMap();
            CreateMap<Language, LanguageEntry>().ReverseMap();

            CreateMap<ShopItemEntry, ShopItemEntry>();
            CreateMap<ShopItem, ShopItem>();
        }
    }
}

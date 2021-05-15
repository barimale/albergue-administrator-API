﻿using System.Collections.Generic;

namespace Albergue.Administrator.Model
{
    public class ShopItem
    {
        public ShopItem()
        {
            TranslatableDetails = new List<ShopItemTranslatableDetails>();
        }

        public string Id { get; set; }
        public double Price { get; set; }
        public bool Active { get; set; }
        public string CategoryId { get; set; }

        public List<ShopItemTranslatableDetails> TranslatableDetails { get; set; }
    }
}

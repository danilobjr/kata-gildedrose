using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Builders
{
    internal class ItemBuilder
    {
        private string name;
        private int sellIn;
        private int quality;

        internal static ItemBuilder AnItem()
        {
            return new ItemBuilder();
        }

        internal ItemBuilder AnyName()
        {
            this.name = "Any name";
            return this;
        }

        internal ItemBuilder Quality(int quality)
        {
            this.quality = quality;
            return this;
        }

        internal ItemBuilder SellIn(int sellIn)
        {
            this.sellIn = sellIn;
            return this;
        }

        internal Item Build()
        {
            return new Item
            {
                Name = this.name,
                SellIn = this.sellIn,
                Quality = this.quality
            };
        }
    }
}

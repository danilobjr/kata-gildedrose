using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Builders
{
    internal class GildedRoseBuilder
    {
        private IList<Item> items;

        public GildedRoseBuilder()
        {
            this.items = new List<Item>();
        }

        internal static GildedRoseBuilder AnGildedRose()
        {
            return new GildedRoseBuilder();
        }

        internal GildedRoseBuilder AddItem(Item item)
        {
            this.items.Add(item);
            return this;
        }

        internal GildedRose Build()
        {
            return new GildedRose(this.items);
        }
    }
}

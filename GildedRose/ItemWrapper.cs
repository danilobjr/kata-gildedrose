using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class ItemWrapper
    {
        private Item item;
        private readonly IUpdateQualityStrategy updateQualityStrategy;

        public ItemWrapper(Item item)
        {
            this.item = item;

            if (item.Name == "Aged Brie")
            {
                this.updateQualityStrategy = new UpdateQualityAgedBrie();
            }
            else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                this.updateQualityStrategy = new UpdateQualityBackstage();
            }
            else if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                this.updateQualityStrategy = new UpdateQualitySulfuras();
            }
            else if (item.Name == "Conjured")
            {
                this.updateQualityStrategy = new UpdateQualityConjured();
            }
            else
            {
                this.updateQualityStrategy = new UpdateQualityAnyItem();
            }
        }

        public string Name
        {
            get { return this.item.Name; }
            set { this.item.Name = value; }
        }

        public int SellIn
        {
            get { return this.item.SellIn; }
            set { this.item.SellIn = value; }
        }

        public int Quality
        {
            get { return this.item.Quality; }
            set { this.item.Quality = value; }
        }

        public void UpdateQuality()
        {
            this.updateQualityStrategy.UpdateItemQuality(item);
        }
    }
}

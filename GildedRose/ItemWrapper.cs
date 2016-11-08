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
            this.updateQualityStrategy = UpdateQualityFactory.Create(item);
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
            set
            {
                if (value >= 0 && value <= 50)
                {
                    this.item.Quality = value;
                }
            }
        }

        public void UpdateQuality()
        {
            this.updateQualityStrategy.UpdateItemQuality(this);
        }
    }
}

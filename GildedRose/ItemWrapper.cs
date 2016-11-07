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

        public ItemWrapper(Item item)
        {
            this.item = item;
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
            if (this.Name == "Aged Brie" || this.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                if (this.Quality < 50)
                {
                    this.Quality = this.Quality + 1;

                    if (this.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (this.Quality < 50)
                        {
                            if (this.SellIn < 11)
                            {
                                this.Quality = this.Quality + 1;
                            }

                            if (this.SellIn < 6)
                            {
                                this.Quality = this.Quality + 1;
                            }
                        }
                    }
                }
            }
            else
            {
                if (this.Quality > 0)
                {
                    if (this.Name != "Sulfuras, Hand of Ragnaros")
                    {
                        this.Quality = this.Quality - 1;
                    }
                }
            }

            if (this.Name != "Sulfuras, Hand of Ragnaros")
            {
                this.SellIn = this.SellIn - 1;
            }

            if (this.SellIn < 0)
            {
                if (this.Name == "Aged Brie")
                {
                    if (this.Quality < 50)
                    {
                        this.Quality = this.Quality + 1;
                    }
                }
                else
                {
                    if (this.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        this.Quality = this.Quality - this.Quality;
                    }
                    else
                    {
                        if (this.Quality > 0)
                        {
                            if (this.Name != "Sulfuras, Hand of Ragnaros")
                            {
                                this.Quality = this.Quality - 1;
                            }
                        }
                    }
                }
            }
        }
    }
}

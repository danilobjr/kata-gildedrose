using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    class UpdateQualityFactory
    {
        public static IUpdateQualityStrategy Create(Item item)
        {
            if (item.Name == "Aged Brie")
            {
                return new UpdateQualityAgedBrie();
            }
            else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                return new UpdateQualityBackstage();
            }
            else if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                return new UpdateQualitySulfuras();
            }
            else if (item.Name == "Conjured")
            {
                return new UpdateQualityConjured();
            }
            else
            {
                return new UpdateQualityAnyItem();
            }
        }
    }
}

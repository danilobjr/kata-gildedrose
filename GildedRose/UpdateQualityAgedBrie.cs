using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    class UpdateQualityAgedBrie : IUpdateQualityStrategy
    {
        public void UpdateItemQuality(ItemWrapper item)
        {
            item.Quality++;
            item.SellIn--;

            if (item.SellIn < 0)
            {
                item.Quality++;
            }
        }
    }
}

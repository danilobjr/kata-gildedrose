using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    class UpdateQualityBackstage : IUpdateQualityStrategy
    {
        public void UpdateQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;

                if (item.Quality < 50)
                {
                    if (item.SellIn < 11)
                    {
                        item.Quality++;
                    }

                    if (item.SellIn < 6)
                    {
                        item.Quality++;
                    }
                }
            }

            item.SellIn--;

            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
        }
    }
}

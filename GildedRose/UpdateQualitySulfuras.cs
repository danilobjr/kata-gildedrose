using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    class UpdateQualitySulfuras : IUpdateQualityStrategy
    {
        public void UpdateItemQuality(ItemWrapper item)
        {
            this.NeverHasToBeSoldOrDecreasesInQualitySoNoUpdateNeeded();
        }

        private void NeverHasToBeSoldOrDecreasesInQualitySoNoUpdateNeeded()
        {
        }
    }
}

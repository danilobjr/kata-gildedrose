using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class QualityService
    {
        public IList<Item> Items;

        public QualityService(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                var itemWrapper = new ItemWrapper(item);
                itemWrapper.UpdateQuality();
            }
        }
    }
}

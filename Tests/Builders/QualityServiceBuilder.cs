using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Builders
{
    internal class QualityServiceBuilder
    {
        private IList<Item> items;

        public QualityServiceBuilder()
        {
            this.items = new List<Item>();
        }

        internal static QualityServiceBuilder AnQualityService()
        {
            return new QualityServiceBuilder();
        }

        internal QualityServiceBuilder AddItem(Item item)
        {
            this.items.Add(item);
            return this;
        }

        internal QualityService Build()
        {
            return new QualityService(this.items);
        }
    }
}

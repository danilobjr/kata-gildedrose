using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public override bool Equals(object obj)
        {
            var anotherItem = obj as Item;

            return this.Name == anotherItem.Name &&
                this.Quality == anotherItem.Quality &&
                this.SellIn == anotherItem.SellIn;
        }
    }
}

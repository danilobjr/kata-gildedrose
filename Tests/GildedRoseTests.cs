using Application;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Builders;

namespace Tests
{
    [TestFixture]
    public class GildedRoseTests
    {
        private readonly Item EMPTY_ITEM = ItemBuilder.AnItem().Build();
        private readonly Item ITEM_WITH_ANY_NAME = ItemBuilder.AnItem().AnyName().Build();

        [Test]
        public void UpdateQuality_EmptyItem_SellInDecreasesBy1()
        {
            var gildedRose = AnGildedRose()
                .AddItem(EMPTY_ITEM)
                .Build();

            gildedRose.UpdateQuality();

            Assert.That(gildedRose.Items.First().SellIn, Is.EqualTo(-1));
        }

        [Test]
        public void UpdateQuality_ItemWithAnyName_SellInDecreasesBy1()
        {
            var gildedRose = AnGildedRose()
                .AddItem(ITEM_WITH_ANY_NAME)
                .Build();

            gildedRose.UpdateQuality();

            Assert.That(gildedRose.Items.First().SellIn, Is.EqualTo(-1));
        }

        private GildedRoseBuilder AnGildedRose()
        {
            return GildedRoseBuilder.AnGildedRose();
        }

        private ItemBuilder AnItem()
        {
            return ItemBuilder.AnItem();
        }
    }
}

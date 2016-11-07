using Application;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Builders;

namespace Tests
{
    [TestFixture]
    public class QualityServiceTests
    {
        private readonly ItemBuilder SULFURAS_ITEM = ItemBuilder.AnItem().NamedSulfuras();
        private readonly ItemBuilder AGED_BRIE_ITEM = ItemBuilder.AnItem().NamedAgedBrie();
        private readonly ItemBuilder BACKSTAGE_ITEM = ItemBuilder.AnItem().NamedBackstage();
        private readonly ItemBuilder NORMAL_ITEM = ItemBuilder.AnItem().AnyName();
        private readonly int DEFAULT_INITIAL_QUALITY = 10;
        private readonly int DEFAULT_INITIAL_SELLIN = 10;
        private readonly int MIN_QUALITY = 0;
        private readonly int MAX_QUALITY = 50;

        [Test]
        public void UpdateQuality_SellInHasPassed_QualityDropsBy2()
        {
            var passedSellIn = -1;

            var qualityService = AnQualityService()
                .AddItem(NORMAL_ITEM
                    .SellIn(passedSellIn)
                    .Quality(DEFAULT_INITIAL_QUALITY)
                    .Build())
                .Build();

            qualityService.UpdateQuality();

            Assert.That(qualityService.Items.First().Quality, Is.EqualTo(DEFAULT_INITIAL_QUALITY - 2));
        }

        [Test]
        public void UpdateQuality_ItemHasMinQuality_QualityDoesntBecomeNegative()
        {
            var qualityService = AnQualityService()
                .AddItem(NORMAL_ITEM.Quality(MIN_QUALITY).Build())
                .Build();

            qualityService.UpdateQuality();

            Assert.That(qualityService.Items.First().Quality, Is.EqualTo(MIN_QUALITY));
        }

        [Test]
        public void UpdateQuality_AgedBrieItem_IncreasesInQualityTheOlderItGets()
        {
            var qualityService = AnQualityService()
                .AddItem(AGED_BRIE_ITEM
                    .SellIn(DEFAULT_INITIAL_SELLIN)
                    .Quality(DEFAULT_INITIAL_QUALITY)
                    .Build())
                .Build();

            qualityService.UpdateQuality();

            Assert.That(qualityService.Items.First().Quality, Is.EqualTo(DEFAULT_INITIAL_QUALITY + 1));
        }

        [Test]
        public void UpdateQuality_ItemHasMaxQuality_QualityDoesntIncreasesAnymore()
        {
            var qualityService = AnQualityService()
                .AddItem(AGED_BRIE_ITEM
                    .SellIn(DEFAULT_INITIAL_SELLIN)
                    .Quality(MAX_QUALITY)
                    .Build())
                .Build();

            qualityService.UpdateQuality();

            Assert.That(qualityService.Items.First().Quality, Is.EqualTo(MAX_QUALITY));
        }

        [Test]
        public void UpdateQuality_SulfurasItem_NeverDecreasesSellIn()
        {
            var qualityService = AnQualityService()
                .AddItem(SULFURAS_ITEM
                    .SellIn(DEFAULT_INITIAL_SELLIN)
                    .Quality(DEFAULT_INITIAL_QUALITY)
                    .Build())
                .Build();

            qualityService.UpdateQuality();

            Assert.That(qualityService.Items.First().SellIn, Is.EqualTo(DEFAULT_INITIAL_SELLIN));
        }

        [Test]
        public void UpdateQuality_SulfurasItem_NeverDecreasesInQuality()
        {
            var qualityService = AnQualityService()
                .AddItem(SULFURAS_ITEM
                    .SellIn(DEFAULT_INITIAL_SELLIN)
                    .Quality(DEFAULT_INITIAL_QUALITY)
                    .Build())
                .Build();

            qualityService.UpdateQuality();

            Assert.That(qualityService.Items.First().Quality, Is.EqualTo(DEFAULT_INITIAL_QUALITY));
        }

        [Test]
        public void UpdateQuality_WhenBackstageItemHasSellInLessThanOrEquals10_IncreasesInQualityBy2()
        {
            var initialSellIn = 10;

            var qualityService = AnQualityService()
                .AddItem(BACKSTAGE_ITEM
                    .SellIn(initialSellIn)
                    .Quality(DEFAULT_INITIAL_QUALITY)
                    .Build())
                .Build();

            qualityService.UpdateQuality();

            Assert.That(qualityService.Items.First().Quality, Is.EqualTo(DEFAULT_INITIAL_QUALITY + 2));
        }

        [Test]
        public void UpdateQuality_WhenBackstageItemHasSellInLessThanOrEquals5_IncreasesInQualityBy3()
        {
            var initialSellIn = 5;

            var qualityService = AnQualityService()
                .AddItem(BACKSTAGE_ITEM
                    .SellIn(initialSellIn)
                    .Quality(DEFAULT_INITIAL_QUALITY)
                    .Build())
                .Build();

            qualityService.UpdateQuality();

            Assert.That(qualityService.Items.First().Quality, Is.EqualTo(DEFAULT_INITIAL_QUALITY + 3));
        }

        [Test]
        public void UpdateQuality_WhenBackstageItemHasSellInLessThan0_QualityDropsTo0()
        {
            var initialSellIn = -1;

            var qualityService = AnQualityService()
                .AddItem(BACKSTAGE_ITEM
                    .SellIn(initialSellIn)
                    .Quality(DEFAULT_INITIAL_QUALITY)
                    .Build())
                .Build();

            qualityService.UpdateQuality();

            var noQuality = 0;

            Assert.That(qualityService.Items.First().Quality, Is.EqualTo(noQuality));
        }

        [Test]
        public void UpdateQuality_SulfurasItemHasQualityOf80_QualityDoesntAlters()
        {
            var initialQuality = 80;

            var qualityService = AnQualityService()
                .AddItem(SULFURAS_ITEM
                    .SellIn(DEFAULT_INITIAL_SELLIN)
                    .Quality(initialQuality)
                    .Build())
                .Build();

            qualityService.UpdateQuality();

            Assert.That(qualityService.Items.First().Quality, Is.EqualTo(initialQuality));
        }

        private QualityServiceBuilder AnQualityService()
        {
            return QualityServiceBuilder.AnQualityService();
        }

        private ItemBuilder AnItem()
        {
            return ItemBuilder.AnItem();
        }
    }
}

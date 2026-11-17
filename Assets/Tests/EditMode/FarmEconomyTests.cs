using System;
using NUnit.Framework;
using GameStudio.FarmEmpire;

namespace GameStudio.FarmEmpire.Tests
{
    public sealed class FarmEconomyTests
    {
        [Test]
        public void PlantHarvestAndSellProducesExpectedBalances()
        {
            var farm = new FarmEconomy();
            Assert.IsTrue(farm.Plant(2));
            Assert.IsTrue(farm.AdvanceDay());
            Assert.IsTrue(farm.SellGrain(2));
            var s = farm.Snapshot();
            Assert.AreEqual(2, s.Day);
            Assert.AreEqual(60, s.Coins);
            Assert.AreEqual(3, s.Seeds);
            Assert.AreEqual(0, s.Grain);
        }

        [Test]
        public void FailedTransactionsNeverMutateState()
        {
            var farm = new FarmEconomy();
            var before = farm.Snapshot();
            Assert.IsFalse(farm.Plant(3));
            Assert.IsFalse(farm.BuySeeds(-1));
            Assert.IsFalse(farm.SellGrain(1));
            Assert.AreEqual(before.Coins, farm.Snapshot().Coins);
            Assert.AreEqual(before.Seeds, farm.Snapshot().Seeds);
        }

        [Test]
        public void CannotPlantMoreThanFreeFields()
        {
            var farm = new FarmEconomy();
            Assert.IsTrue(farm.Plant(2));
            Assert.IsFalse(farm.Plant(1));
            Assert.AreEqual(2, farm.Snapshot().Growing);
        }

        [Test]
        public void SaveSnapshotIsDefensivelyCopied()
        {
            var farm = new FarmEconomy();
            var snapshot = farm.Snapshot();
            snapshot.Coins = 999999;
            Assert.AreEqual(50, farm.Snapshot().Coins);
            var restored = new FarmEconomy(farm.Snapshot());
            Assert.AreEqual(50, restored.Snapshot().Coins);
        }

        [Test]
        public void InvalidSaveIsRejected()
        {
            Assert.Throws<ArgumentException>(() =>
                new FarmEconomy(new FarmSnapshot { Day = 1, Fields = 1, Growing = 2 }));
        }

        [Test]
        public void OverflowCannotGenerateCurrency()
        {
            var farm = new FarmEconomy(new FarmSnapshot
            {
                Day = 1, Fields = 1, Grain = 1, Coins = int.MaxValue
            });
            Assert.IsFalse(farm.SellGrain(1));
            Assert.AreEqual(int.MaxValue, farm.Snapshot().Coins);
        }
    }
}

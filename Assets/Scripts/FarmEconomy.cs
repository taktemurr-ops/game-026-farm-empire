using System;
using System.Collections.Generic;

namespace GameStudio.FarmEmpire
{
    // Pure deterministic domain model. No ads, payments or Unity runtime dependencies.
    [Serializable]
    public sealed class FarmSnapshot
    {
        public int Day;
        public int Coins;
        public int Seeds;
        public int Grain;
        public int Fields;
        public int Growing;
    }

    public sealed class FarmEconomy
    {
        private const int FieldCost = 20;
        private const int SeedCost = 3;
        private const int GrainSalePrice = 5;
        private const int MaxFields = 1000;
        private readonly FarmSnapshot state;

        public FarmEconomy() : this(new FarmSnapshot { Day = 1, Coins = 50, Seeds = 5, Fields = 2 }) { }

        public FarmEconomy(FarmSnapshot saved)
        {
            if (saved == null || saved.Day < 1 || saved.Coins < 0 || saved.Seeds < 0 ||
                saved.Grain < 0 || saved.Fields < 1 || saved.Fields > MaxFields ||
                saved.Growing < 0 || saved.Growing > saved.Fields)
                throw new ArgumentException("Invalid farm save", nameof(saved));
            state = Copy(saved);
        }

        public FarmSnapshot Snapshot() { return Copy(state); }

        public bool BuyField()
        {
            if (state.Coins < FieldCost || state.Fields >= MaxFields) return false;
            state.Coins -= FieldCost;
            state.Fields++;
            return true;
        }

        public bool BuySeeds(int count)
        {
            if (count <= 0 || count > int.MaxValue / SeedCost) return false;
            int cost = count * SeedCost;
            if (cost > state.Coins || count > int.MaxValue - state.Seeds) return false;
            state.Coins -= cost;
            state.Seeds += count;
            return true;
        }

        public bool Plant(int count)
        {
            if (count <= 0 || count > state.Seeds || count > state.Fields - state.Growing) return false;
            state.Seeds -= count;
            state.Growing += count;
            return true;
        }

        public bool AdvanceDay()
        {
            if (state.Day == int.MaxValue || state.Growing > int.MaxValue - state.Grain) return false;
            state.Day++;
            state.Grain += state.Growing;
            state.Growing = 0;
            return true;
        }

        public bool SellGrain(int count)
        {
            if (count <= 0 || count > state.Grain || count > (int.MaxValue - state.Coins) / GrainSalePrice)
                return false;
            state.Grain -= count;
            state.Coins += count * GrainSalePrice;
            return true;
        }

        private static FarmSnapshot Copy(FarmSnapshot s)
        {
            return new FarmSnapshot
            {
                Day = s.Day, Coins = s.Coins, Seeds = s.Seeds,
                Grain = s.Grain, Fields = s.Fields, Growing = s.Growing
            };
        }
    }
}

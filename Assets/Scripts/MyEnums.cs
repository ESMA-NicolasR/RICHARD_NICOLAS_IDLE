public enum ResourceTypeEnum
{
    Seed,
    Cereal,
    Fruit,
    Vegetable,
}

public enum UpgradeEnum
{
    // One time upgrades (main tasks)
    UnlockFieldPlot,
    UnlockShop,
    UnlockAutoGather,
    UnlockCereal,
    UnlockFruit,
    UnlockVegetable,
    // Multiple buy upgrades (shop)
    AddFieldPlot,
    GatherPowerOne,
    GatherPowerTen,
    AutoGatherSpeed,
    AddCerealYield,
    ScaleGlobalYield,
    AddFruitGrowSpeed,
    ScaleGlobalGrowSpeed,
    AutomateHarvest,
    ScaleWorldHungerReward,
}

public enum UpgradeScalingEnum
{
    AddCerealYield,
    AddFruitGrowSpeed,
    ExpGlobalYield,
    ExpGlobalGrowSpeed,
    MultWorldHungerReward,
}
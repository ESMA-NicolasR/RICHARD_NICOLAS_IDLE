public enum ResourceTypeEnum
{
    Seed,
    Cereal,
    Fruit,
    Vegetable,
    // Add new resources here
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
    UnlockCerealUpgrades,
    UnlockFruitUpgrades,
    UnlockVegetableUpgrades,
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
    // Add new upgrades here
}

public enum UpgradeScalingEnum
{
    AddCerealYield,
    AddFruitGrowSpeed,
    MultGlobalYield,
    ExpGlobalGrowSpeed,
    MultWorldHungerReward,
    // Add new scalings here
}
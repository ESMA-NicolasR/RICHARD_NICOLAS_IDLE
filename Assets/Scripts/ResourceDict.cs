using System;

[Serializable]
public class ResourceDict : MyDictionary<ResourceTypeEnum, int>
{
    public string GetStringWithSprites()
    {
        string result = "";
        foreach (ResourceTypeEnum resourceType in GetKeys())
        {
            switch (resourceType)
            {
                case ResourceTypeEnum.Seed:
                    result += $"<sprite name=seed>{GetValue(resourceType)}";
                    break;
                case ResourceTypeEnum.Cereal:
                    result += $"<sprite name=cereal>{GetValue(resourceType)}";
                    break;
                case ResourceTypeEnum.Fruit:
                    result += $"<sprite name=fruit>{GetValue(resourceType)}";
                    break;
                case ResourceTypeEnum.Vegetable:
                    result += $"<sprite name=vegetable>{GetValue(resourceType)}";
                    break;
            }
        }

        return result;
    }
}
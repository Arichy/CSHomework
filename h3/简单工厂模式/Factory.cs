using System;
using Food;

public class Factory
{
    public static Food.Food produceFood(string foodName)
    {
        switch (foodName)
        {
            case "米饭": return new Rice();
            case "鸡肉": return new Chicken();
            case "面包": return new Bread();
            default: return null;
        }
    }
}
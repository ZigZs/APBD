namespace APBD3;

public class RefrigeratedContainer : Container
{
    public string ProductType { get; set; }
    public double Temperature { get; set; }

    private readonly Dictionary<string, double> ProductTemperatures = new Dictionary<string, double>
    {
        { "Bananas", 13.3 },
        { "Chocolate", 18 },
        { "Fish", 2 },
        { "Meat", -15 },
        { "Ice cream", -18 },
        { "Frozen pizza", -30 },
        { "Cheese", 7.2 },
        { "Sausages", 5 },
        { "Butter", 20.5 },
        { "Eggs", 19 }
    };

    public RefrigeratedContainer(double height, double deadweightLoad, double depth, double maxLoad, string productType, double temperature) :
        base(height, deadweightLoad, depth, "C", maxLoad)
    {
        if (!ProductTemperatures.ContainsKey(productType))
        {
            throw new ArgumentException($"Nieznany typ produktu: {productType}");
        }

        double requiredTemp = ProductTemperatures[productType];
        if (temperature < requiredTemp)
        {
            throw new AggregateException($"Temperatura {temperature}°C jest niższa niż wymagana {requiredTemp}°C dla {productType}");
        }
        
        ProductType = productType;
        Temperature = temperature;
    }
    public override string ToString()
    {
        return base.ToString() + $", Produkt: {ProductType}, Temperatura: {Temperature}°C";
    }
}
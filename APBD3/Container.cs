namespace APBD3;

public class Container
{
    public double weightLoad { get; set; }
    public double height { get; set; }
    public double deadweightLoad { get; set; }
    public double depth { get; set; }
    public string serialNumber { get; set; }
    public double maxLoad { get; set; }

    protected Container(double height, double deadweightLoad, double depth, string containerType, double maxLoad)
    {
        this.height = height;
        this.deadweightLoad = deadweightLoad;
        this.depth = depth;
        serialNumber = GenerateSerialnumber(containerType);
        this.maxLoad = maxLoad;
    }

    private static int id = 1;
    private string GenerateSerialnumber(string containerType)
    {
        return $"KON-{containerType}-{id++}";
    }

    public virtual void EmptyLoad()
    {
        weightLoad = 0;
    }

    public virtual void Load(double weight)
    {
        if (weight > maxLoad)
        {
            throw new OverfillException($"Proba zaladowania {weight}kg gdy maksymalna ladownosc to {maxLoad}kg");
        }
        weightLoad = weight;
    }
    public override string ToString()
    {
        return $"{serialNumber} - Wysokość: {height}cm, Głębokość: {depth}cm, Waga własna: {deadweightLoad}kg, Masa ładunku: {weightLoad}kg, Maks. ładowność: {maxLoad}kg";
    }
}
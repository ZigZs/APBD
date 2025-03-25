namespace APBD3;

public class GasContainer : Container
{
    public double Pressure { get; set; }
    //int height, int deadweightLoad, int depth, string containerType, int maxLoad
    public GasContainer(double height, double deadweightLoad, double depth, double maxLoad, double pressure) : base(height,
        deadweightLoad, depth, "G", maxLoad)
    {
        Pressure = pressure;
    }

    public override void EmptyLoad()
    {
        weightLoad *= 0.05;
    }
    
    
    public void NotifyHazard(string containerNumber)
    {
        Console.WriteLine($"UWAGA: Niebezpieczna operacja na kontenerze {containerNumber}");

    }
}
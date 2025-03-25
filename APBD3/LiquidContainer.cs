namespace APBD3;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; set; }

    public LiquidContainer(double height, double deadweightLoad, double depth, double maxLoad, bool isHazardous) : base(height,deadweightLoad,depth,"L",maxLoad)
    {
        IsHazardous = isHazardous;
    }

    public override void Load(double weight)
    {
        double maxAllowed = (IsHazardous ? maxLoad * 0.5 : maxLoad * 0.9);
        if (weight > maxAllowed)
        {
            NotifyHazard(serialNumber);
            throw new OverfillException($"Niebezpieczna operacja: próba załadowania {weight} kg, gdy maksymalna dozwolona to {maxAllowed} kg");
        }
        base.Load(weight);
    }
    
    public void NotifyHazard(string containerNumber)
    {
        Console.WriteLine($"UWAGA: Niebezpieczna operacja na kontenerze {containerNumber} - przekroczono dozwoloną pojemność dla {(IsHazardous ? "materiału niebezpiecznego" : "materiału zwykłego")}");
    }
}
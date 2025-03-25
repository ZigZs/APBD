using System.Collections;

namespace APBD3;

public class Ship
{
    public List<Container> Containers { get; set; } = new List<Container>();
    public double MaxSpeed { get; set; }
    public int MaxNumberOfContainers { get; set; }
    public double MaxLoad { get; set; }

    public Ship(double maxSpeed, int maxNumberOfContainers, double maxLoad)
    {
        MaxSpeed = maxSpeed;
        MaxNumberOfContainers = maxNumberOfContainers;
        MaxLoad = maxLoad;
    }

    public void LoadContainer(Container container)
    {
        if (Containers.Count >= MaxNumberOfContainers ){
            throw new OverflowException($"Kontener: {container.serialNumber} nie zmiesci sie na statku");
        }

        double totalWeight = Containers.Sum(c => c.weightLoad + c.deadweightLoad) + container.deadweightLoad +
                             container.weightLoad;
        if (totalWeight / 1000 > MaxLoad)
        {
            throw new InvalidOperationException($"Przekoczono wage maksymalna {MaxLoad}t");
        }
        Containers.Add(container);
    }

    public void LoadContainers(List<Container> containers)
    {
        foreach (Container cont in containers)
        {
            LoadContainer(cont);
        }
    }

    public void TakeOfContainer(Container container)
    {
        if (Containers.Contains(container))
        { 
            Containers.Remove(container);
        }
        else
        {
            Console.WriteLine($"Nie znaleziono kontenera {container.serialNumber}");
        }
    }

    public void SwitchContainers(string serialNumber, Container toAdd)
    {
        Container? toSwitch = Containers.FirstOrDefault(c => c.serialNumber == serialNumber);
        if (toSwitch != null)
        {
            throw new Exception($"Nie znaleziono kontenera {serialNumber}");
        }
        double totalWeight = Containers.Sum(c => c.weightLoad + c.deadweightLoad) - toSwitch.deadweightLoad - toSwitch.weightLoad + toAdd.deadweightLoad + toAdd.weightLoad;
        if (totalWeight / 1000 > MaxLoad)
        {
            throw new OverfillException(
                $"Nie mozna podmienic konteneroa {toSwitch.serialNumber} bo {toAdd.serialNumber} jest za ciezki");
        }
        TakeOfContainer(toSwitch);
        LoadContainer(toAdd);
    }

    public void SwitchToDifrentShip(Container container, Ship secondShip)
    {
        if (Containers.Contains(container))
        {
            secondShip.LoadContainer(container);
            TakeOfContainer(container);
        }
        else
        {
            Console.WriteLine($"Nie znaleziono kontenera {container.serialNumber}");
        }
    }

    public override string ToString()
    {
        string output = "Lista kontenerow: ";
        foreach (Container cont in Containers)
        {
            output += cont + "\n";
        }
        return output + $"Max speed: {MaxSpeed}w \nMax load: {MaxLoad}t \nMax number of containers: {MaxNumberOfContainers}";
    }
}

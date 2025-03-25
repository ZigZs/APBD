namespace APBD3;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            Ship arka = new Ship(15, 5, 10);
            Ship gdynia = new Ship(20, 10, 15);


            LiquidContainer milker = new LiquidContainer(12, 3, 30, 1230, false);
            LiquidContainer napalm = new LiquidContainer(200, 60, 0, 1000, true);
            GasContainer gazprom = new GasContainer(150, 400, 120, 1500, 2.5);
            RefrigeratedContainer bananiak = new RefrigeratedContainer(250, 700, 150, 2500, "Bananas", 13.5);

            milker.Load(1000);
            napalm.Load(500);
            gazprom.Load(200);
            bananiak.Load(1500);

            arka.LoadContainer(milker);
            arka.LoadContainer(napalm);
            gdynia.LoadContainer(gazprom);
            gdynia.LoadContainer(bananiak);

            gdynia.SwitchToDifrentShip(bananiak, arka);
            arka.TakeOfContainer(milker);

            Console.WriteLine(arka);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
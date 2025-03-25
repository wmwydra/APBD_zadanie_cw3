using APBD_cw3;

public class Program
{
    public static void Main(string[] args)
    {
        Container testingContainer = new ContainerL(12, 0.0f, 0.0f, 0.0f, 30.4f);
        Container testingContainer1 = new ContainerL(12, 0.0f, 0.0f, 0.0f, 30.4f);
        Console.WriteLine(testingContainer.SeriesNumber);
        
        Container testingContainer2 = new ContainerG(12.0, 0.0f, 11.0f, 0.0f, 0.0f, 30.4f);
        
        Load bananki = new Load("Bananki", LoadType.COOL, 12.6f, false, null);
        Console.WriteLine(bananki.Type);
        
        Load woda = new Load("Woda", LoadType.LIQUID, 0.6f, false, null);
        Load paliwo = new Load("Paliwo", LoadType.LIQUID, 60.2f, true, null);

        try
        {
            testingContainer.LoadContainer(woda);
            testingContainer1.LoadContainer(paliwo);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        Ship myShip = new Ship("IMO2348675", 350.3f, 10, 30.4f );
        Ship secondShip = new Ship("IMO3348671", 350.3f, 0, 30.4f );
        myShip.LoadShip(testingContainer);
        myShip.LoadShip(testingContainer2);
        
        myShip.DisplayContainers();
        Console.WriteLine();
        Console.WriteLine(myShip.ToString());

        try
        {
            myShip.MoveContainer(testingContainer, secondShip);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        Console.WriteLine(secondShip.ToString());
        
        
        myShip.EmptyShip();
        Console.WriteLine(myShip.ToString());


    }
}
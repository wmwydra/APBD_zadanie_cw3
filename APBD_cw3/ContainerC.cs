namespace APBD_cw3;

public class ContainerC : Container
{
    private string ProductType { get; set; }
    private float Temperature { get; set; }

    public ContainerC(string pT, float temp, float lM, float cM, float h, float d, float mC)
        : base(lM, cM, h, d, mC)
    {
        SeriesNumber = GenerateSeriesNumber("C");
        AcceptableLoadType = LoadType.COOL;
        ProductType = pT;
        Temperature = temp;

    }

    public override void LoadContainer(Load load)
    {   
        if (CurrentLoad != null && !CurrentLoad.name.Equals(load.name))
        {
            throw new LoadContradictionException();
        }
        if (load.Type != AcceptableLoadType)
            throw new WrongLoadTypeException();
        else if (load.requiredTemperature > Temperature)
            throw new LowTemperatureException();
        else
        {
            if (load.mass + LoadMass > MaxCapacity)
            {
                throw new OverfillException();
            }
            else
            {
                CurrentLoad = load;
                LoadMass = load.mass + LoadMass;
                Console.WriteLine($"The container {SeriesNumber} was successfully loaded with {load.name}\n");
            }
        }
    }

}
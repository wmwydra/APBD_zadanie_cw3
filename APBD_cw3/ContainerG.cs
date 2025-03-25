namespace APBD_cw3;

public class ContainerG : Container, IHazardNotifier
{
    private double Pressure { get; set; }
    public ContainerG(double p, float lM, float cM, float h, float d, float mC)
        : base(lM, cM, h, d, mC)
    {
        SeriesNumber = GenerateSeriesNumber("G");
        AcceptableLoadType = LoadType.GAS;
        Pressure = p;
    }

    public override void LoadContainer(Load load)
    {
        base.LoadContainer(load);
        Notify();
    }

    public override void EmptyLoad()
    {
        LoadMass = (float)(0.05 * LoadMass);
        CurrentLoad = null;
    }
    
    public void Notify()
    {
        Console.WriteLine($"WARNING: Dangerous load\n" +
                          $"The container number {SeriesNumber} is carrying load that may pose risks to health, safety, and the environment. \n" +
                          $"Proper handling, storage, and safety precautions must be followed at all times. \n" +
                          $"Unauthorized access is strictly prohibited.\n" +
                          $"In case of emergency, contact the designated safety officer immediately.\n");
    }

}
namespace APBD_cw3;

public class ContainerL : Container, IHazardNotifier
{ 
    public ContainerL(float lM, float cM, float h, float d, float mC)
        : base(lM, cM, h, d, mC)
    {
        SeriesNumber = GenerateSeriesNumber("L");
        AcceptableLoadType = LoadType.LIQUID;
    }

    public override void LoadContainer(Load load)
    {
        if (CurrentLoad != null && !CurrentLoad.name.Equals(load.name))
        {
            throw new LoadContradictionException();
        }
        if (load.Dangerous)
            MaxCapacity = (MaxCapacity / 2);
        else
            MaxCapacity = (float)(MaxCapacity * 0.9);
        if (load.Type != AcceptableLoadType)
            throw new WrongLoadTypeException();
        else
        {
            if (load.mass + LoadMass > MaxCapacity)
            {
                throw new DangerException();
            }
            else
            {
                CurrentLoad = load;
                LoadMass = load.mass + LoadMass;
                Console.WriteLine($"The container {SeriesNumber} was successfully loaded with {load.name}\n");
                Notify();
            }
        }
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
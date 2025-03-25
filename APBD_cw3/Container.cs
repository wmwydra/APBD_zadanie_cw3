namespace APBD_cw3;

public abstract class Container(float lM, float cM, float h, float d, float mC)
{
    private static int _serialCounter = 1; // Unikalny licznik numerów
    private static HashSet<int> _usedNumbers = new HashSet<int>();
    public LoadType AcceptableLoadType { get; set; }
    public float LoadMass { get; set; } = lM ; 
    public float ContainerMass { get; set; } = cM; 
    
    public float Height { get; set; } = h; 
    public float Deptht { get; set; } = d;
    public string SeriesNumber { get; set; }
    public float MaxCapacity { get; set; } = mC;
    public Load? CurrentLoad { get; set; }  
    public float TotalWeight => LoadMass + ContainerMass; //wartość dynamiczna
    public bool IsEmpty => LoadMass == 0;

    public string GenerateSeriesNumber(string type)
    {
        int number = _serialCounter++;
        _usedNumbers.Add(number);
        
        return $"KON-{type}-{number}";
    }
    
    public virtual void EmptyLoad()
    {
        LoadMass = 0.0f ;
        CurrentLoad = null;
    }

    public virtual void LoadContainer(Load load)
    {
        if (CurrentLoad != null && !CurrentLoad.name.Equals(load.name))
        {
            throw new LoadContradictionException();
        }
        if (load.Type != AcceptableLoadType)
            throw new WrongLoadTypeException();
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

    public override string ToString()
    {
        string LoadedInfo = "";
        if (IsEmpty)
        {
            LoadedInfo = "Load: EMPTY";
        }
        else
        {
            LoadedInfo = $"Load: {CurrentLoad.name}, mass: {LoadMass}, dangerous load: {CurrentLoad.Dangerous}";
        }
        string info = $"-------------------------------- \n " +
                      $"CONTAINER number: {SeriesNumber} \n" +
                      $"Acceptable load type : {AcceptableLoadType} \n" +
                      $"Maximum capacity: {MaxCapacity} \n" +
                      $"{LoadedInfo} \n" +
                      $"Total weight: {TotalWeight} \n" +
                      $"--------------------------------\n";
        return info;
    }
}

namespace APBD_cw3;

public class Load(string name, LoadType type, float mass, bool danger,  float? rTemp)
{
    public string name { get; set; } = name;
    public LoadType Type { get; set; } = type;
    public float mass { get; set; } = mass;
    public bool Dangerous { get; set; } = danger;
    public float? requiredTemperature { get; set; } = rTemp;
}
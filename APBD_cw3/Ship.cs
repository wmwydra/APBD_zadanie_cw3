using Microsoft.VisualBasic;

namespace APBD_cw3;

public class Ship(string imoNumber, float maxSpeed, int capacity, float maxWeight)
{
    public HashSet<Container> Containers = new HashSet<Container>();
    private string IMONumber = imoNumber;
    private float MaxSpeed { get; set; } = maxSpeed;
    private int Capacity { get; set; } = capacity;
    private float CurrentWeight { get; set; } = 0;
    private float MaxWeightTons { get; set; } = maxWeight;
    
    public void LoadShip(Container container)
    {
        if (Containers.Count != Capacity && (CurrentWeight + container.TotalWeight) != MaxWeightTons)
        {
            Containers.Add(container);
            CurrentWeight += container.TotalWeight;
        }
        else
        {
            throw new OverfillException("You cannot put this container on the ship because it will be overloaded");
        }
    }
    
    public void LoadShip(ICollection<Container> containers)
    {
        foreach (Container c in containers)
        {
            LoadShip(c);
        }
    }
    
    public void RemoveContainer(Container container)
    {
        Containers.Remove(container);
        CurrentWeight -= container.TotalWeight;
    }

    public void ReplaceContainer(Container container, Container replacement)
    {
        RemoveContainer(container);
        LoadShip(replacement);
    }

    public void MoveContainer(Container container, Ship ship)
    {
            ship.LoadShip(container);
            RemoveContainer(container);
    }

    public void EmptyShip()
    {
        foreach (Container c in Containers)
        {
            RemoveContainer(c);
        }
    }

    public void DisplayContainers()
    {
        Console.WriteLine("List of Containers:");
        foreach (Container container in Containers)
        {
            Console.WriteLine(container.ToString());
        }
    }

    public override string ToString()
    {
        if (Containers.Count == 0)
            return "-------------------------------- \n" +
                   $"Ship number {IMONumber} \n" +
                   "This ship is currently empty and ready for loading. \n" +
                   $"There are {Capacity} slots available for containers. \n" +
                   $"This ship can hold maximum load weight of {MaxWeightTons} tons. \n" +
                   $"--------------------------------\n";
        else
            return "-------------------------------- \n" +
                   $"Ship number {IMONumber} \n" +
                   $"This ship is currently transporting {Containers.Count} containers. \n" +
                   $"There are {Capacity - Containers.Count} slots available for containers. \n" +
                   $"This ship can hold maximum load weight of {MaxWeightTons} tons. \n" +
                   $"Maximum speed: {MaxSpeed} m/s. \n" +
                   "--------------------------------\n";
    }
    
}
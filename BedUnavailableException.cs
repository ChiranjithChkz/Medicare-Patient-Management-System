using Medicare;

public class BedUnavailableException : MediCareException
{
    public string Department { get; }
    public int CurrentOccupancy { get; }

    public int Capacity { get; }

    //public BedUnavailableException() { }
    public BedUnavailableException(string department, int occupancy, int capacity) : 
    base($"No bed in {department}: {occupancy}/{capacity} occupied")
    {
        Department = department;
        CurrentOccupancy = occupancy;
        Capacity = capacity;
    }

       public BedUnavailableException(string message, Exception inner)
        : base(message, inner)
        {
            Department = "Unknown";
            CurrentOccupancy = 0;
            Capacity = 0;
        }

}
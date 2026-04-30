 
class EmergencyPatient : Patient, ITransferable
{
    private string _emergencyType = "";
    public string EmergencyType
    {
        get { return _emergencyType; }
        private set
        {
            if (value == null)
            {
                throw new InvalidPatientDataException("EmergencyType", "null");
            }
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("EmergencyType cannot be empty.", nameof(EmergencyType));
            }
            // FIXED: was missing this line — value was validated but never stored!
            _emergencyType = value;
        }
    }

    public void TransferTo(string department)
    {
        Random rng = new Random();
        if (rng.Next(0, 3) == 0)
            throw new BedUnavailableException(department, 20, 20);
        Console.WriteLine($"[Transfer] URGENT: Moving {PatientName} from ER to {department}");
    }

    public EmergencyPatient(string name, int id, string bloodGroup, string type)
        : base(name, id, bloodGroup)
    {
    
        EmergencyType = type;
    }

    public void ProcessInsuranceClaim()
    {
        Console.WriteLine($"[Insurance] Processing claim for {PatientName}");
        Console.WriteLine($"Insurance ID: {PatientId}     |        Claim Amount: BDT {BillAmount}");
    }

    public override void Diagnose()
    {
        Console.WriteLine("-----------------Emergency Patient---------------");
        Console.WriteLine();
        Console.WriteLine($"[Diagnose] Patient #{PatientId} {PatientName}: URGENT TRIAGE | Emergency : {EmergencyType}");
    }

    public override void Treat()
    {
        Console.WriteLine($"[Treat] Rushing to ER -> IV drip -> Calling cardiologist");
        SetBillAmount(5000);
    }
}
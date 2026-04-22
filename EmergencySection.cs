class EmergencyPatient : Patient , ITransferable
{
     private string _emergencyType;
     public string EmergencyType
    {
        get {return _emergencyType;}
        private set
        {
            if(value == null)
            {
                throw new ArgumentNullException(nameof(EmergencyType));

            }
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Symptoms cannot be empty.", nameof(EmergencyType));
            }
        }
    }

     public void TransferTo(string department)
    {
        Console.WriteLine($"[Transfer] URGENT: Moving {PatientName} from ER to {department}");
    }

    public EmergencyPatient(string name , int id, string bloodGroup,string type) : base(name, id, bloodGroup)
    {
        _emergencyType= type;
    }
    public void ProcessInsuranceClaim()
    {
        Console.WriteLine($"[Insurance] Processing claim for {PatientName}");
        Console.WriteLine($"Insurance ID: {PatientId}     |        Claim Amount: BDT {BillAmount}");
    }

    public override void Diagnose()
    {
        //base.Diagnose();
        Console.WriteLine("-----------------Emergency Patient---------------");
        Console.WriteLine();
        Console.WriteLine($"[Diagnose] Patient #{PatientId} {PatientName}: URGENT TRIAGE | Emergency : {EmergencyType}");
    }  

    public override void Treat()
    {
       // base.Treat();
        Console.WriteLine($"[Treat] Rushing to ER -> IV drip -> Calling cardiologist");
       // BillAmount = 5000;
       SetBillAmount(5000);
    }
}
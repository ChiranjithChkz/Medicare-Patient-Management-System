public class SurgeryPatient : Patient, IInsurable, ITransferable, IBillable
{
    private string _surgery;
    public string Surgery
    {
        get {return _surgery;}
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Srugery cannot null or empty");
                _surgery = value;
            }
        }
    }
    private string _surgeon;
    public string Surgeon
    {
        get {return _surgeon;}
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Surgeon name cannot null or whitespace");
                _surgeon = value;
            }
        }
    }
    private string _insurance;
        public string Insurance
    {
        get {return _insurance;}
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Insurance name cannot null or whitespace");
                _insurance = value;
            }
        }
    }

    public SurgeryPatient(string PatientName, int id, string surgery, string surgeon, string insurance) 
        : base(PatientName, id)
    {
        _surgeon = surgeon;
        _surgery = surgery;
        _insurance = insurance;
    }

 

    public string GetInsuranceDetails()
    {
        return $"Patient: {PatientName}, Surgery: {Surgery}, Insurance: {Insurance}";
    }

 
    void ITransferable.TransferTo(string department)
    {
        Console.WriteLine($"Transferred patient {PatientName} to another department/hospital.");
    }

     public void ProcessInsuranceClaim()
    {
        Console.WriteLine($"[Insurance] Processing claim for {PatientName}");
        Console.WriteLine($"Insurance ID: {PatientId}     |        Claim Amount: BDT {BillAmount}");
    }

   
    public override void Diagnose()
    {
        Console.WriteLine("-----------------Surgery Patient-----------------");
        Console.WriteLine();
        Console.WriteLine($"[Diagnose] Patient #{PatientId} {PatientName}: Pre-surgical assessment for {Surgery}");
    }

    public override void Treat()
    {
        Console.WriteLine($"[Treat] Preparing OT -> Anesthesia -> {Surgeon} performing {Surgery}");
        SetBillAmount(25000);
    }
    public double CalculateBill()
    {
        return BillAmount;
    }
     public void ApplyDiscount(double percentage)
    {
        BillAmount -= BillAmount * (percentage/ 100 );
    }
}
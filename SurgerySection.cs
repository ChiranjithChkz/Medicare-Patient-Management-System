public class SurgeryPatient : Patient, IInsurable, ITransferable, IBillable
{
    private string _surgery;
    public string Surgery
    {
        get {return _surgery;}
        private set
        {
            if(value == null)
            {
                throw new ArgumentNullException(nameof(Surgery));

            }
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("SurgeryType cannot be empty.", nameof(Surgery));
            }
        }
    }
    private string _surgeon;
    public string Surgeon
    {
        get {return _surgeon;}
        private set
        {
             if(value == null)
            {
                throw new ArgumentNullException(nameof(Surgeon));

            }
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Surgeon cannot be empty.", nameof(Surgeon));
            }
        }
    }
    // private string _insurance;
    //     public string Insurance
    // {
    //     get {return _insurance;}
    //     private set
    //     {
    //         if (string.IsNullOrWhiteSpace(value))
    //         {
    //             throw new ArgumentException("Insurance name cannot null or whitespace");
    //             _insurance = value;
    //         }
    //     }
    // }

    public string InsuranceId {get;}

    public SurgeryPatient(string PatientName, int id,string bloodGroup, string insuranceId,string surgery, string surgeon ) 
        : base(PatientName, id, bloodGroup)
    {
        _surgeon = surgeon;
        _surgery = surgery;
      

         if (string.IsNullOrWhiteSpace(insuranceId))
            throw new ArgumentException("InsuranceId cannot be empty.");

        InsuranceId = insuranceId;
    }

 

    public string GetInsuranceDetails()
    {
        return $"Patient: {PatientName}  | Surgery: {Surgery} | ID: {InsuranceId} | Status: Active";
        
    }

 
    void ITransferable.TransferTo(string department)
    {
        Console.WriteLine($"Transferred patient {PatientName} to another department/hospital.");
    }

     public void ProcessInsuranceClaim()
    {

        if(BillAmount <= 0)
        {
            throw new InvalidOperationException($"Cannot process insurance for {PatientName}: Treatment has not been completed yet.");
        }
        Console.WriteLine($"[Insurance] Processing claim for {PatientName}");
        Console.WriteLine($"Insurance ID: {PatientId}|Claim Amount: BDT {BillAmount}");
    }

   
    public override void Diagnose()
    {
        Console.WriteLine("-----------------Surgery Patient-----------------");
        Console.WriteLine();
        Console.WriteLine($"[Diagnose] Patient #{PatientId} {PatientName}: Pre-surgical assessment for {Surgery}");
    }

    public override void Treat()
    {
        Console.WriteLine($"[Treat] Preparing OT -> Anesthesia -> {Surgeon} performing {Surgery} on {PatientName}");
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
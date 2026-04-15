public class PediatricPatient : Patient, IInsurable
{
    private string _guardianName;
        public string GuardianName
    {
        get {return _guardianName;}
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Gurdiam name cannot null or whitespace");
                _guardianName = value;
            }
        }
    }
    private string _insuranceId;
        public string  InsuranceId
    {
        get {return _insuranceId;}
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(" Insurance name cannot null or whitespace");
                _insuranceId = value;
            }
        }
    }

    public PediatricPatient(string name, int id, string guardian, string insuranceId) : base(name, id)
    {
        _guardianName = guardian;
        _insuranceId = insuranceId;
    }

    
    public void ProcessInsuranceClaim()
    {
        Console.WriteLine($"[Insurance] Processing insurance claim for {PatientName}");
        Console.WriteLine($"   Insurace ID : {InsuranceId} |  Claim Amount : BDT {BillAmount}");
    }

    
    string IInsurable.GetInsuranceDetails()
    {
        return $"Guardian: {GuardianName}, Insurance ID: {InsuranceId}";
    }

   
    public override void Diagnose()
    {
        Console.WriteLine($"[Pediatric] Guardian: {GuardianName}");
    }

    public override void Treat()
    {
        Console.WriteLine("[Treatment] Pediatric care applied");
        SetBillAmount(1200);
    }
}
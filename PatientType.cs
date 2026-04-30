 
public class PediatricPatient : Patient, IInsurable
{
    private string _guardianName="";

    public string GuardianName
    {
        get { return _guardianName; }
        private set
        {
            if (value == null)
            {
                throw new InvalidPatientDataException("GuardianName", "null");
            }
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("GuardianName cannot be empty.", nameof(GuardianName));
            }
            // FIXED: was missing this line
            _guardianName = value;
        }
    }

    public string InsuranceId { get; }

    public PediatricPatient(string name, int id, string bloodGroup, string guardian, string insuranceId)
        : base(name, id, bloodGroup)
    {
        GuardianName = guardian;

        if (string.IsNullOrWhiteSpace(insuranceId))
            throw new ArgumentException("InsuranceId cannot be empty.");

        InsuranceId = insuranceId;
    }

    public void ProcessInsuranceClaim()
    {
        Console.WriteLine($"[Insurance] Processing insurance claim for {PatientName}");
        Console.WriteLine($"   Insurance ID: {InsuranceId} | Claim Amount: BDT {BillAmount}");
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
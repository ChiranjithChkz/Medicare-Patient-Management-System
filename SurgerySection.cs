 
public class SurgeryPatient : Patient, IInsurable, ITransferable, IBillable
{
    private string _surgery ="";
    public string Surgery
    {
        get { return _surgery; }
        private set
        {
            if (value == null)
            {
                throw new InvalidPatientDataException("Surgery", "null");
            }
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("SurgeryType cannot be empty.", nameof(Surgery));
            }
            // FIXED: was missing this line
            _surgery = value;
        }
    }

    private string _surgeon ="";
    public string Surgeon
    {
        get { return _surgeon; }
        private set
        {
            if (value == null)
            {
                throw new InvalidPatientDataException("Surgeon", "null");
            }
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Surgeon cannot be empty.", nameof(Surgeon));
            }
            // FIXED: was missing this line
            _surgeon = value;
        }
    }

    public string InsuranceId { get; }

    public SurgeryPatient(string patientName, int id, string bloodGroup, string insuranceId, string surgery, string surgeon)
        : base(patientName, id, bloodGroup)
    { 
        Surgery = surgery;
        Surgeon = surgeon;

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
        if (BillAmount <= 0)
            throw new InvalidOperationException(
                $"Cannot process insurance for {PatientName}: Treatment has not been completed yet.");

        if (BillAmount > 20000)
            throw new InsuranceClaimRejectedException(
                InsuranceId, BillAmount, "Pre-authorization required for claims above BDT 20,000");

        Console.WriteLine($"[Insurance] Processing claim for {PatientName}");
        Console.WriteLine($"Insurance ID: {InsuranceId} | Claim Amount: BDT {BillAmount}");
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
        BillAmount -= BillAmount * (percentage / 100);
    }
}
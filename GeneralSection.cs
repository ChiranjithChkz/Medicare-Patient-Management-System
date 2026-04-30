 
public class GeneralPatient : Patient, IInsurable
{
    private string _symptoms = " ";
    public string Symptoms
    {
        get { return _symptoms; }
        private set
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(Symptoms));
            }
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidPatientDataException("Symptoms", value);
            }
            // FIXED: was missing this line — value was validated but never stored!
            _symptoms = value;
        }
    }

    public void ProcessInsuranceClaim()
    {
        try
        {
            if (new Random().Next(0, 4) == 0)
                throw new Exception("Database connection timeout");

            Console.WriteLine($"[Insurance] Processing claim for {PatientName}");
        }
        catch (Exception ex)
        {
            throw new InsuranceClaimRejectedException(
                $"Claim failed for {PatientName} due to system error", ex);
        }
    }

    string IInsurable.GetInsuranceDetails()
    {
        return $"Provider: National Health | ID : {InsuranceId} | Status: Active";
    }

    public string InsuranceId { get; }

    public GeneralPatient(string name, int id, string bloodGroup, string insuranceId, string sym)
        : base(name, id, bloodGroup)
    {
        Symptoms = sym;
        if (string.IsNullOrWhiteSpace(insuranceId))
            throw new ArgumentException("InsuranceId cannot be empty.");

        InsuranceId = insuranceId;
    }

    public override void Diagnose()
    {
        Console.WriteLine("------------------General Patient------------------");
        Console.WriteLine();
        Console.WriteLine($"[Diagnose] Patient #{PatientId} {PatientName} : General Checkup | Symptoms: {Symptoms}");
    }

    public override void Treat()
    {
        Console.WriteLine($"[Treat] Prescribing medication and rest for {PatientName}");
        SetBillAmount(800);
    }
}
public class GeneralPatient : Patient, IInsurable
{

    private string _insurable;
    private string _symptoms;
    public string Symptoms
    {
        get {return _symptoms; }
        private set
        {
             if(value == null)
            {
                throw new ArgumentNullException(nameof(Symptoms));
            }
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Symptoms cannot be empty.", nameof(Symptoms));
            }
            
            
        }
    }

    public void ProcessInsuranceClaim()
    {
        Console.WriteLine($"[Insurance] Processing claim for {PatientName}");
        Console.WriteLine($"Insurance ID: {InsuranceId}     |        Claim Amount: BDT {BillAmount}");
    }

    string IInsurable.GetInsuranceDetails()
    {
        return $"Provider: National Health | ID : {InsuranceId} | Status: Active";
    }


     public string InsuranceId {get; }
    public GeneralPatient(string name, int id,string bloodGroup,string  insuranceId, string sym ) : base(name, id, bloodGroup)
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
        Console.WriteLine($"[Diagnose] Patient #{PatientId} {PatientName} : General Checkup | Symptoms: {Symptoms} ");

    }
 
    public override void Treat()
    {

        Console.WriteLine($"[Treat] Prescribing medication and rest for {PatientName}");
        SetBillAmount(800);
    }
}
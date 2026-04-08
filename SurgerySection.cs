public class SurgeryPatient : Patient, IInsurable, ITransferable
{
    public string Surgery;
    public string Surgeon;
    public string Insurance;

    public SurgeryPatient(string patientName, int id, string surgery, string surgeon, string insurance) 
        : base(patientName, id)
    {
        Surgeon = surgeon;
        Surgery = surgery;
        Insurance = insurance;
    }

    // IInsurable implementation
    public void ProcessInsuranceClaim()
    {
        Console.WriteLine($"Processing insurance claim for {patientName}");
    }

    public string GetInsuranceDetails()
    {
        return $"Patient: {patientName}, Surgery: {Surgery}, Insurance: {Insurance}";
    }

 
    void ITransferable.TransferTo(string department)
    {
        Console.WriteLine($"Transferred patient {patientName} to another department/hospital.");
    }

   
    public override void Diagnose()
    {
        Console.WriteLine("------Surgery Patient--------");
        Console.WriteLine($"[Diagnose] Patient #{PatientId} {patientName}: Pre-surgical assessment for {Surgery}");
    }

    public override void Treat()
    {
        Console.WriteLine($"[Treat] Preparing OT -> Anesthesia -> {Surgeon} performing {Surgery}");
        BillAmount = 25000;
    }
}
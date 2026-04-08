public class PediatricPatient : Patient, IInsurable
{
    string GuardianName;
    string InsuranceId;

    public PediatricPatient(string name, int id, string guardian, string insuranceId) : base(name, id)
    {
        GuardianName = guardian;
        InsuranceId = insuranceId;
    }

    
    public void ProcessInsuranceClaim()
    {
        Console.WriteLine($"Processing insurance claim for {GuardianName}");
    }

    
    string IInsurable.GetInsuranceDetails()
    {
        return $"Guardian: {GuardianName}, Insurance ID: {InsuranceId}";
    }

   
    public override void Diagnose()
    {
        Console.WriteLine($"[Pediatric Check] Guardian: {GuardianName}");
    }

    public override void Treat()
    {
        Console.WriteLine("[Treatment] Pediatric care applied");
    }
}
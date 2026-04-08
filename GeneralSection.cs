public class GeneralPatient : Patient, IInsurable
{

    private string Insurable;
    string Symptoms;

    public void ProcessInsuranceClaim()
    {
        Console.WriteLine($"[Insurance] Processing claim for {patientName}");
        Console.WriteLine($"Insurance ID: {PatientId}     |        Claim Amount: BDT {BillAmount}");
    }

    string IInsurable.GetInsuranceDetails()
    {
        return $"Provider: National Health | ID : {PatientId} | Status: Active";
    }



    public GeneralPatient(string name, int id, string sym, string insurable) : base(name, id)
    {
        Symptoms = sym;
        Insurable = insurable;
    }

    public override void Diagnose()
    {

        Console.WriteLine("------------------General Patient------------------");
        Console.WriteLine();
        Console.WriteLine($"[Diagnose] Patient #{PatientId} {patientName} : General Checkup | Symptoms: {Symptoms} ");

    }
    // public void Diagnose()
    // {

    //    Console.WriteLine("--------General Patient-----------");
    //     Console.WriteLine($"[Diagnose] Patient #{PatientId} {patientName} : General Checkup | Symptoms: {Symptoms} ");

    // }



    public override void Treat()
    {

        Console.WriteLine($"[Treat] Prescribing medication and rest for {patientName}");
        BillAmount = 800;
    }
}
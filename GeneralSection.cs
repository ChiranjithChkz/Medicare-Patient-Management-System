class GeneralPatient : Patient
{
     string Symptoms;

 
     public GeneralPatient(string name, int id, string sym) : base(name, id)
    {
        Symptoms = sym;
    }

    public override void Diagnose()
    {
       
       Console.WriteLine("--------General Patient-----------");
        Console.WriteLine($"[Diagnose] Patient #{PatientId} {patientName} : General Checkup | Symptoms: {Symptoms} ");

    }

    public override void Treat()
    {
        
        Console.WriteLine($"[Treat] Prescribing medication and rest for {patientName}");
        BillAmount = 800;
    }
}
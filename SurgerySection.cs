class SurgeryPatient : Patient
{
    public string Surgery;
    public string Surgeon;

    public SurgeryPatient(string name, int id, string surgery ,string surgeon) : base(name, id)
    {
        Surgeon = surgeon;
        Surgery = surgery;

    }

    public override void Diagnose()
    {
        Console.WriteLine("------Surgery Patient--------");
        Console.WriteLine($"[Diagnose] Patient #{PatientId} {patientName}: Pre-surgecal assesment for {Surgery}");

    }

    public override void Treat()
    {
       // base.Treat();
        Console.WriteLine($"[Treat] Preparring OT -> Anesthesia -> {Surgeon} performing {Surgery}");
        BillAmount = 25000;
    }
}
class EmergencyPatient : Patient
{
     string EmergencyType;

    public EmergencyPatient(string name , int id, string type) : base(name, id)
    {
        EmergencyType= type;
    }

    public override void Diagnose()
    {
        //base.Diagnose();
        Console.WriteLine("---------Emergency Patient---------");
        Console.WriteLine($"[Diagnose] Patient #{PatientId} {patientName}: URGENT TRIAGE | Emergency : {EmergencyType}");
    }  

    public override void Treat()
    {
       // base.Treat();
        Console.WriteLine($"[Treat] Rushing to ER -> IV drip -> Calling cardiologist");
        BillAmount = 5000;
    }
}
using System.Globalization;

class Patient
{
    protected string patientName;
    protected int PatientId;
    protected double BillAmount;

    public Patient(string name, int id)
    {
        patientName = name;
        PatientId = id;
    }

    public virtual void Diagnose()
    {
        Console.WriteLine($"[Treat] Providing general treatment for {patientName}");
    }
    public virtual void Treat()
    {
        BillAmount = 500;
        Console.WriteLine($"[Treat] Providing general treatment for {patientName}");

    }

    public void GeneralReport()
    {
        Diagnose();
        Treat();
        Console.WriteLine($"[Bill] Patient: {patientName} | Total BDT  {BillAmount}");
    }
}
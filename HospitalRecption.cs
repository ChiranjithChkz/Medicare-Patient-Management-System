using System.Reflection;

class HospitalReception
{
    public void AdmitPatient(string patientName)
    {
        Console.WriteLine($"[Admitted] {patientName} -> Dept: General OPD | Insurence: Self-pay");
    }
    public void AdmitPatient(string patientName, string department)
    {
        Console.WriteLine($"[Admitted] {patientName} -> Dept: {department} | Insurence: self-pay");
    }
    public void AdmitPatient(string patientName, string department, string insurenceId)
    {
        Console.WriteLine($"[Admitted] {patientName} -> Dept: {department} | Insurence : {insurenceId}");
    }

 

}
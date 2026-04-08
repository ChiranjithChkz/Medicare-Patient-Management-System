using System.Reflection;

class HospitalReception
{
    public void AdmitPatient(string patientName)
    {
        Console.WriteLine($"[admited] {patientName} -> Dept: General OPD | Insurence: Self-pay");
    }
    public void AdmitPatient(string patientName, string department)
    {
        Console.WriteLine($"[Admitted] {patientName} -> Dept: {department} | Insurence: self-pay");
    }
    public void AdmitPatient(string patientName, string department, string insurenceId)
    {
        Console.WriteLine($"[Admitted] {patientName} -> Dept: {department} | Insurence : {insurenceId}");
    }


    // public static void Main(string[] args)
    // {
    //     while (true)
    //     {
    //         HospitalReception reception = new HospitalReception();

    //         Console.Write("Enter Patient name: ");
    //         string name = Console.ReadLine();

    //         Console.Write("Enter department Name: ");
    //         string dept = Console.ReadLine();

    //         Console.Write("Enter Insurence Id: ");
    //         string id = Console.ReadLine();

    //        Console.WriteLine("=================Medicare+ patient Amission===============");
           
    //         if (string.IsNullOrEmpty(dept) && string.IsNullOrEmpty(id))
    //         {
    //             reception.AdmitPatient(name);
    //         }
    //         else if (!string.IsNullOrEmpty(dept) && string.IsNullOrEmpty(id))
    //         {
    //             reception.AdmitPatient(name, dept);
    //         }
    //         else
    //         {
    //             reception.AdmitPatient(name, dept, id);
    //         }
    //     }
    // }

}
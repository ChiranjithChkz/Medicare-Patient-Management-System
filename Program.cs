using System;

class Program
{
    public static void Main(string[] args)
    {
        Patient[] patients = new Patient[]
        {
            new GeneralPatient("Chiji", 101, "Fever, cough", "INs-23"),
            new EmergencyPatient("Karim", 102, "Cardiac Arrest"),
            new SurgeryPatient("Fatema", 103, "Appendectomy", "Dr. Khan", "INS-123"),
            new PediatricPatient("Ali", 104, "Mr. Korim", "INS-456")
        };

        Console.WriteLine("===============Patient Reports===============");
        foreach(Patient p in patients)
        {
            p.GeneralReport();
            Console.WriteLine();
        }

        Console.WriteLine("==================Insurance Processing===============");
        foreach(Patient p in patients)
        {
            if(p is IInsurable insuredPatient)
            {
                Console.WriteLine(insuredPatient.GetInsuranceDetails());
                insuredPatient.ProcessInsuranceClaim();
                Console.WriteLine();
            }
        }

        Console.WriteLine("==================Patient Transfers===============");
        foreach(Patient p in patients)
        {
            if(p is ITransferable transferable)
            {
                transferable.TransferTo("ICU");
            }
        }
    }
}
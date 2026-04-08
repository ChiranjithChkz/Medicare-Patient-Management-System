using System;

class Program
{
    public static void Main(string[] args)
    {
        
        HospitalReception h = new HospitalReception();
        Console.WriteLine("===================Hospital Reception==================");
        Console.WriteLine();
        h.AdmitPatient("Chiranjith Chakma");
        h.AdmitPatient("Chiranjith Chakma", "Emergency");
        h.AdmitPatient("Chiranjith Chakma", "Surgery", "INS-1234#");
        Console.WriteLine();

        Patient[] patients = new Patient[]
        {
            new GeneralPatient("Chiranjith Chakma", 101, "Fever, cough", "INs-2312"),
            new EmergencyPatient("Karim Rahman", 102, "Cardiac Arrest"),
            new SurgeryPatient("Fatema Begum", 103, "Appendectomy", "Dr. Khan", "INS-123"),
            new PediatricPatient("Ali Uddin", 104, "Mr. Korim", "INS-456")
        };

        Console.WriteLine("===============Patient Reports===============");
        Console.WriteLine();
        foreach(Patient p in patients)
        {
            p.GeneralReport();
            Console.WriteLine();
        }

        Console.WriteLine("===============Insurance Processing=============");
        Console.WriteLine();
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
        Console.WriteLine();
        foreach(Patient p in patients)
        {
            if(p is ITransferable transferable)
            {
                transferable.TransferTo("ICU");
            }
        }
    }
}
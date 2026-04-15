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

        Console.WriteLine("================Applying Discount================");

        string [] patientType = {"General", "Emergency", "Surgery", "Pediatric"};
        Console.WriteLine();
        for(int i=0; i<patients.Length; i++)
        {
            ApplyDiscount.AddDiscount(patients[i], patientType[i]);
        }
        Console.WriteLine();



        Console.WriteLine("===============Patient Reports===============");
        Console.WriteLine();
        foreach (Patient p in patients)
        {
            p.GeneralReport();
            Console.WriteLine();
        }

        Console.WriteLine("===============Insurance Processing=============");
        Console.WriteLine();
        foreach (Patient p in patients)
        {
            if (p is IInsurable insuredPatient)
            {
                Console.WriteLine(insuredPatient.GetInsuranceDetails());
                insuredPatient.ProcessInsuranceClaim();
              // ProcessAllInsurance(patients);
                Console.WriteLine();
            }
        }

        Console.WriteLine("==================Patient Transfers===============");
        Console.WriteLine();
        foreach (Patient p in patients)
        {
            if (p is ITransferable transferable)
            {
                transferable.TransferTo("ICU");
            }
        }

       
    Console.WriteLine("==============Encapsulation Test============");
     Console.WriteLine();
     try
     {
        var bad1 = new GeneralPatient("", 201, "Fever", "INS-001");
     }
     catch (ArgumentException ex)
     {
        
        Console.WriteLine($"[Validation] Rejected:  {ex.Message}");
     }

     try
     {
        var bad2 = new GeneralPatient("Test", -5 , "Fever", "INS-100");
     }
     catch (ArgumentException ex)
     {
        
        Console.WriteLine($"[Validation] Rejected:  {ex.Message}");
     }
     try
     {
        var bad3 = new GeneralPatient("Test", 201, "", "INS-100");
     }
     catch (ArgumentException ex)
     {
        
         Console.WriteLine($"[Validation] Rejected:  {ex.Message}");
     }

            Console.WriteLine("==============Encapsulation Test============");
        Console.WriteLine();

        foreach (Patient p in patients)
        {
            if (p is GeneralPatient gp)
            {
                Console.WriteLine($"Patient: {gp.PatientName}, ID: {gp.PatientId}, Symptoms: {gp.Symptoms}");
            }
        }


    }

}
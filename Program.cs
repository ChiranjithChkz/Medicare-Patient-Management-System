using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;

class Program
{
    public static void Main(string[] args)
    {
        HospitalReception h = new HospitalReception();

        Console.WriteLine("===================Admitting  Patinets==================\n");
        Console.WriteLine();

        SafePatientList admitted = new SafePatientList();

        // for patient 1
        try
        {  
            var p1 = new GeneralPatient("Rohim", 101, "A+", "INS-G-001", "Fever, cough");
            admitted.Add(p1);
            Console.WriteLine($"[ok] Admitted: {p1.PatientName} (ID: {p1.PatientId})");
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"[REJECTED] Missing required field: {ex.Message}");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"[REJECTED] Out of range: {ex.ParamName} = {ex.ActualValue}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"[REJECTED] Invalid data: {ex.Message}");
        }

        // for patient 2; INVALID - empty name
        try
        {
            var p2 = new EmergencyPatient("", 102, "B+", "Cardiac Arrest");
            admitted.Add(p2);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"[REJECTED] Missing required field: {ex.ParamName}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"[REJECTED] {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Rejected]: {ex.Message}");
        }

        // for patient 3; VALID
        try
        {
            var p3 = new SurgeryPatient("Fatema", 102, "B+", "INS-001", "Appendectomy", "Dr. Khan");
            admitted.Add(p3);
            Console.WriteLine($"[OK] Admitted: {p3.PatientName} (ID: {p3.PatientId})");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"[REJECTED] {ex.Message}");
        }
         catch (Exception ex)
        {
            Console.WriteLine($"[Rejected]: {ex.Message}");
        }

        // for patient 4: negative ID
        try
        {
            var p4 = new PediatricPatient("Chiranjith", -101, "A+", "Ms.Pushpa Mala", "INS-G-001");
            admitted.Add(p4);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"[REJECTED] Out of range: {ex.ParamName} = {ex.ActualValue}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"[REJECTED] {ex.Message}");
        }
         catch (Exception ex)
        {
            Console.WriteLine($"[Rejected]: {ex.Message}");
        }

        Console.WriteLine($"\nTotal admitted: {admitted.Count} out of 4 attempted");
        Console.WriteLine();

        Patient[] patients = new Patient[]
        {
            new GeneralPatient("Chiranjith Chakma", 101, "A+", "INshel","Fever, cough" ),
            new EmergencyPatient("Karim Rahman", 102, "A+", "Cardiac Arrest"),
            new SurgeryPatient("Fatema Begum", 103, "A+", "Insheew", "Appendectomy", "Dr. Khan" ),
            new PediatricPatient("Ali Uddin", 104, "O+", "Mr. Korim", "INS-456")
        };

        Console.WriteLine("================Applying Discount================\n");

        string[] patientType = { "General", "Emergency", "Surgery", "Pediatric" };

        foreach (Patient p in admitted)
        {
            if (p == null) continue;

            if (p is GeneralPatient)
                ApplyDiscount.AddDiscount(p, "General");
            else if (p is EmergencyPatient)
                ApplyDiscount.AddDiscount(p, "Emergency");
            else if (p is SurgeryPatient)
                ApplyDiscount.AddDiscount(p, "Surgery");
            else if (p is PediatricPatient)
                ApplyDiscount.AddDiscount(p, "Pediatric");
        }

        Console.WriteLine("\n===============Treatment Reports===============\n");
        Console.WriteLine();

        foreach (Patient p in admitted)
        {
            try
            {
                p.GeneralReport();
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Null patient found");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Failed to generate report for patient: {ex.Message}");
            }
            Console.WriteLine();
        }

        Console.WriteLine("===============Insurance Processing=============\n");

        foreach (Patient p in admitted)
        {
            if (p is IInsurable insured)
            {
                bool started = false;
                try
                {
                    Console.WriteLine($"[CLAIM] Starting claim for {p.PatientName}....");
                    started = true;

                    Console.WriteLine(insured.GetInsuranceDetails());
                    insured.ProcessInsuranceClaim();

                    Console.WriteLine("[CLAIM] Completed successfully.");
                }
                catch (InsuranceClaimRejectedException ex)
                {
                    Console.WriteLine($"[CLAIM DENIED] {ex.Message}");
                    Console.WriteLine($"  Insurance: {ex.InsuranceId} | Amount: BDT {ex.ClaimAmount:N0}");
                    Console.WriteLine($"  Reason: {ex.Reason}");

                    if (ex.InnerException != null)
                        Console.WriteLine($"  Root cause: {ex.InnerException.Message}");
                }
                catch (InvalidCastException ex)
                {
                    Console.WriteLine($"[CLAIM FAILED] {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[CLAIM ERROR] Unexpected: {ex.Message}");
                }
                finally
                {
                    if (started)
                    {
                        Console.WriteLine($"[LOG] Claim attempt for {p.PatientName}");
                    }
                    Console.WriteLine();
                }
            }
        }

        Console.WriteLine("==================Patient Transfers===============\n");
        Console.WriteLine();

        foreach (Patient p in admitted)
        {
            if (p is ITransferable transferable)
            {
                try
                {
                    transferable.TransferTo("ICU");
                }
                catch (BedUnavailableException ex)
                {
                    Console.WriteLine($"[TRANSFER DENIED] {ex.Message}");
                    Console.WriteLine($" Department: {ex.Department}");
                    Console.WriteLine($" Occupancy: {ex.CurrentOccupancy}/{ex.Capacity}");
                    Console.WriteLine($" Action: {p.PatientName} placed on waiting list.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[TRANSFER ERROR] {ex.Message}");
                }
            }
        }

        Console.WriteLine("\n==============Encapsulation Test============\n");

        try
        {
            var bad1 = new GeneralPatient("", 201, "A+", " ", "Fever");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"[Validation] Rejected: {ex.Message}");
        }
         catch (Exception ex)
        {
            Console.WriteLine($"[Validation] Rejected: {ex.Message}");
        }

        try
        {
            var bad2 = new GeneralPatient("Test", -5, "A+", " ", "Fever");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"[Validation] Rejected: {ex.Message}");
        }
         catch (Exception ex)
        {
            Console.WriteLine($"[Validation] Rejected: {ex.Message}");
        }

        try
        {
            var bad3 = new GeneralPatient("Test", 201, "A+", " ", "");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"[Validation] Rejected: {ex.Message}");
        }
         catch (Exception ex)
        {
            Console.WriteLine($"[Validation] Rejected: {ex.Message}");
        }

        Console.WriteLine("\n==============Encapsulation Check============\n");

        foreach (Patient p in patients)
        {
            if (p is GeneralPatient gp)
            {
                Console.WriteLine($"Patient: {gp.PatientName}, ID: {gp.PatientId}, Symptoms: {gp.Symptoms}");
            }
        }
    }
}
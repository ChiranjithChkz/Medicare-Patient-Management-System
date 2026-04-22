public class ApplyDiscount
{
    public static double GetDiscountPercentage(string patientType)
    {
        if (string.IsNullOrWhiteSpace(patientType))
            throw new ArgumentException("Patient type cannot be empty");

        patientType = patientType.Trim();

        switch (patientType)
        {
            case "General": return 10;
            case "Emergency": return 0;
            case "Surgery": return 15;
            case "Pediatric": return 20;
            default:
                throw new ArgumentException($"Invalid patient type: {patientType}");
        }
    }

    public static void AddDiscount(Patient patient, string patientType)
    {
        if (patient == null)
            throw new ArgumentNullException(nameof(patient));

        
        double percent = GetDiscountPercentage(patientType);

        patient.SetDiscount(percent);

        Console.WriteLine(
            $"[Discount Applied] {patient.PatientName} ({patientType}) → {percent}%"
        );
    }
}
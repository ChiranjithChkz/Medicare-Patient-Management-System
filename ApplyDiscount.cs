public class ApplyDiscount
{
    public static double GetDiscountPercentage(string patientType)
    {
        switch (patientType)
        {
            case "General": return 10;
            case "Emergency": return 0;
            case "Surgery": return 15;
            case "Pediatric": return 20;
            default: return 0;
        }
    }
    public static void AddDiscount(Patient patient,string patientType)
    {
        double percent = GetDiscountPercentage(patientType);
        patient.SetDiscount(percent);
        Console.WriteLine($"[Discount] {patientType} patient gets {percent}% discount");

    }
}
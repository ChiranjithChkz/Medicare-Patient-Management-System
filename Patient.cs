 
public abstract class Patient
{
    private string _PatientName="";
    private int _patientId ;

    public double BillAmount { get; protected set; }

    protected double DiscountPercent = 0;
    public DateTime AdmissionDate { get; }

    public string PatientName
    {
        get { return _PatientName; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidPatientDataException("PatientName", value ?? "Null");
            }
            _PatientName = value.Trim();
        }
    }

    public int PatientId
    {
        get { return _patientId; }
    }

    protected void SetBillAmount(double amount)
    {
        if (amount < 0)
        {
            throw new InvalidPatientDataException("BillAmount", amount);
        }
        BillAmount = amount;
    }

    public string BloodGroup { get; }

    public Patient(string patientName, int patientId, string bloodGroup)
    {
        var validGroups = new HashSet<string>
        {
            "A+", "A-", "B+", "B-",
            "AB+", "AB-", "O+", "O-"
        };
        if (!validGroups.Contains(bloodGroup))
        {
            throw new ArgumentException("Invalid blood group");
        }
        BloodGroup = bloodGroup;

        PatientName = patientName;
        if (patientId <= 0)
        {
            throw new InvalidPatientDataException("PatientId", patientId);
        }
        _patientId = patientId;
        AdmissionDate = DateTime.Now;
    }

    public abstract void Diagnose();
    public abstract void Treat();

    public void SetDiscount(double percent)
    {
        if (percent < 0 || percent > 100)
        {
            throw new ArgumentException("Discount must be between 0 to 100");
        }
        DiscountPercent = percent;
    }

    public void GeneralReport()
    {
        Diagnose();
        Treat();
        double discountAmount = BillAmount * (DiscountPercent / 100.0);
        double finalAmount = BillAmount - discountAmount;
        Console.WriteLine($"[Bill] Patient: {PatientName} | Blood Group: {BloodGroup} | Total BDT {BillAmount} TK");
        Console.WriteLine($" Admitted Time: {AdmissionDate:yyyy-MM-dd HH:mm}");
        Console.WriteLine($"[Discount]: {DiscountPercent}% | After discount: BDT {finalAmount}");
    }
}
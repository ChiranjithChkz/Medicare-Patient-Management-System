using System.Globalization;
using System.Reflection.Metadata;

public abstract class Patient
{
    //protected string patientName;
    //change;
    private string _PatientName;

    //protected int PatientId;
    private int _patientId;
   // protected double BillAmount;
 
   public double BillAmount { get; protected set; }


    private string _symptoms;
    public string Symptoms
    {
        get {return _symptoms;}
        private set
        {
            
        if(string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Systoms cannot be Null or Empty");
        }
            _symptoms = value;
        }
        
    }
    protected double DiscountPercent = 0;
    public DateTime AdmissionDate { get ;}


    public string PatientName
    {
        get {return _PatientName ;}
        set
        {
            if(string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Patinet name cannot be empty or whitespace.");
            _PatientName = value.Trim(); // also trim whitespace
        }
        
    }

    public int PatientId
    {
        get{ return _patientId; }  // only read
    }

    protected void SetBillAmount(double amount)
    {
        if(amount < 0)
        { 
            throw new ArgumentOutOfRangeException(
                nameof(amount),
                amount,
                "Bill amount cannot be negative."
            );

        }
        BillAmount = amount;
      
    }

    public string BloodGroup{ get; }
 
    public Patient(string patientName, int patientId, string bloodGroup)
    {
        //bloodGroup implemented---->
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
        if(patientId <= 0)
        {
             throw new ArgumentOutOfRangeException(
                nameof(patientId),
                patientId,
                "Patient ID must be a positive number."
             );

        }
         _patientId = patientId; 
         AdmissionDate = DateTime.Now;


    }
    
 
    public abstract void Diagnose();
    public abstract void Treat();

    public void SetDiscount(double percent)
    {
        if( percent < 0 || percent > 100)
        {
            throw new ArgumentException("Discount must be between  0 to  100");
        }
        DiscountPercent = percent;
    }

    public  void GeneralReport()
    {
        Diagnose();
        Treat();
        double discountAmount = BillAmount * (DiscountPercent / 100.0);
        double finalAmount = BillAmount - discountAmount;
        Console.WriteLine($"[Bill] Patient: {PatientName} | Blood Group: {BloodGroup} |   Total BDT  {BillAmount} TK ");
        Console.WriteLine($" Admitted Time: {AdmissionDate: yyyy-MM-dd HH:mm}");
        Console.WriteLine($"[Discount]:  {DiscountPercent}%  | After discount: BDT {finalAmount}");
    }
}
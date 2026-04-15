using System.Globalization;

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
            _symptoms = value;
        }
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
            throw new ArgumentException("Bill amount cannot be negative.");

        }
        BillAmount = amount;
    }
    

    public Patient(string patientName, int patientId)
    {
        PatientName = patientName;
       

        if(patientId <= 0)
        {
            throw new ArgumentException("Patient ID must be a positive number.");
        }
         _patientId = patientId; 
         AdmissionDate = DateTime.Now;

    }
    
 
    public abstract void Diagnose();
    public abstract void Treat();

    public void SetDiscount(double percent)
    {
        DiscountPercent = percent;
    }

    public  void GeneralReport()
    {
        Diagnose();
        Treat();
        double discountAmount = BillAmount -  BillAmount * (DiscountPercent / 100);
        Console.WriteLine($"[Bill] Patient: {PatientName} | Total BDT  {BillAmount} TK ");
        Console.WriteLine($" Admitted: {AdmissionDate: yyyy-MM-dd HH:mm}");
        Console.WriteLine($" [Discount]:  {DiscountPercent}%  | After discount: BDT {discountAmount}");
    }


}
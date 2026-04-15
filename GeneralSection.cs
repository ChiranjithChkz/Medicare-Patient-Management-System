public class GeneralPatient : Patient, IInsurable
{

    private string _insurable;
    
    public string Insurables
    {
        get {return _insurable;}
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
         
                throw new ArgumentException("Insurance Id cannot be empty");
                
            _insurable = value;
           
        }
    }
    private string _symptoms;
    public string Symptoms
    {
        get {return _symptoms; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            
                throw new ArgumentException("Symptoms cannot be empty.");
            _symptoms = value;
            
        }
    }

    public void ProcessInsuranceClaim()
    {
        Console.WriteLine($"[Insurance] Processing claim for {PatientName}");
        Console.WriteLine($"Insurance ID: {PatientId}     |        Claim Amount: BDT {BillAmount}");
    }

    string IInsurable.GetInsuranceDetails()
    {
        return $"Provider: National Health | ID : {Insurables} | Status: Active";
    }



    public GeneralPatient(string name, int id, string sym, string insurable) : base(name, id)
    {
        Symptoms = sym;
        Insurables = insurable;
    }

    public override void Diagnose()
    {

        Console.WriteLine("------------------General Patient------------------");
        Console.WriteLine();
        Console.WriteLine($"[Diagnose] Patient #{PatientId} {PatientName} : General Checkup | Symptoms: {Symptoms} ");

    }
 
    public override void Treat()
    {

        Console.WriteLine($"[Treat] Prescribing medication and rest for {PatientName}");
        SetBillAmount(800);
    }
}
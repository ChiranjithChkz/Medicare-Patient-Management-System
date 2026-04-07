class Program
{
    public static void Main(string[] args)
    {
         Patient[] patients = new Patient[]
         {
             new GeneralPatient("chiji", 101, "Fever, cough"),
             new EmergencyPatient("Karim", 102, "Cardiac Arrest"),
             new SurgeryPatient("FAtema",103,"Appendectomy", "Dr. Khan")
         };

         foreach(Patient p in patients)
        {
            p.GeneralReport();
            Console.WriteLine();
        }

    }
}
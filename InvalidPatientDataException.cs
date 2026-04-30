using Medicare;

public class InvalidPatientDataException : MediCareException
{
    public string FieldName { get; }
    public object InvalidValue { get; }

    public InvalidPatientDataException() : base("Invalid patient data provided.")
    {
        FieldName = "UNKNOWN";
        InvalidValue="UNKNOWN";
    }
    
    public InvalidPatientDataException(string fieldName, object invalidValue) : base($"Invalid value for '{fieldName}' : '{invalidValue}'")
    {
        FieldName = fieldName;
        InvalidValue = invalidValue;
    }

    public InvalidPatientDataException(string message, Exception inner) : base(message, inner)
    {
        FieldName = "UNKNOWN";
        InvalidValue="UNKNOWN";
    }
    
}
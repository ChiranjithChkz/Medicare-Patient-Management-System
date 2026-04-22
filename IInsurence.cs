public interface IInsurable
{
    void ProcessInsuranceClaim();
    string GetInsuranceDetails();
    string InsuranceId { get; }
}
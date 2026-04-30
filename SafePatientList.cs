using System.Collections;
using System.Collections.Generic;

class SafePatientList : IEnumerable<Patient>
{
    private List<Patient> patients = new List<Patient>();

    public void Add(Patient p)
    {
        if (p == null)
            throw new ArgumentNullException("Patient cannot be null");

        patients.Add(p);
    }

    public int Count => patients.Count;

    public IEnumerator<Patient> GetEnumerator()
    {
        return patients.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
namespace App
{
    public class Patient
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
    }

    public interface IPatientRepository
    {
        Patient GetPatient(int id);
    }

    public class PatientService
    {
        private readonly IPatientRepository _repository;

        public PatientService(IPatientRepository repository)
        {
            _repository = repository;
        }

        public string GetPatientSummary(int id)
        {
            var patient = _repository.GetPatient(id);
            return $"{patient.Name}, {patient.Age} years old, {patient.Gender} from {patient.Address}";
        }
    }
}

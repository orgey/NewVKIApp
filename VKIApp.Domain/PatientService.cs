
using System.Text.Json;
using NewVKIApp.Data.IO;

namespace NewVKIApp.Domain
{
    public class PatientService
    {
        public static List<Patient> patientList = new List<Patient>();
        
        public static List<Patient> GetAllPatient()
        {
            LoadListFromFile();
            return patientList;
        }

        private static void LoadListFromFile()
        {
            string json = FileOperation.ReadPatient();
            if(json != null)
            {
                patientList = JsonSerializer.Deserialize<List<Patient>>(json,
                                new JsonSerializerOptions { IncludeFields = true });
            }
            
        }

        public static Patient SavePatient(string? patientName, int patientHeight, int patientWeight, Doctor doctor)
        {
            Patient h = new Patient();
            h.patientNo = patientList.Count;
            h.patientName = patientName;
            h.patientHeight = patientHeight;
            h.patientWeight = patientWeight;
            h.doctor = doctor;
            patientList.Add(h);
            Write();
            return h;
        }
        public static Patient SavePatient(string? patientName, int patientHeight, int patientWeight, Doctor doctor, int patientNo)
        {
            Patient h = patientList[patientNo];
            h.patientName = patientName;
            h.patientHeight = patientHeight;
            h.patientWeight = patientWeight;
            h.doctor = doctor;
            Write();
            return h;
        }

        public static Patient GetSelectedPatient(int secim)
        {
            LoadListFromFile();
            return patientList.ElementAt(secim);
        }
        public static void Write()
        {
            string json = JsonSerializer.Serialize(patientList,
                new JsonSerializerOptions { IncludeFields = true });
            FileOperation.WritePatient(json);

        }

        public static void DeletePatient(int delete)
        {
            patientList.RemoveAt(delete);
            for (int i = 0; i < patientList.Count; i++)
            {
                patientList[i].patientNo = i;
            }
            Write();
        }
    }
}

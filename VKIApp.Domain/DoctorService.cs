
using System.Text.Json;

using NewVKIApp.Data.IO;

namespace NewVKIApp.Domain
{
    public class DoctorService
    {
        private static List<Doctor> drlist = new List<Doctor>();

        public static List<Doctor> GetAllDoctors()
        {
            LoadDrListFromFile();
            return drlist;
        }

        private static void LoadDrListFromFile()
        {
            string json = FileOperation.ReadDr();          
            if (json != null)
            {
                drlist = JsonSerializer.Deserialize<List<Doctor>>(json,
                    new JsonSerializerOptions { IncludeFields = true });
            }

        }
        public static List<Patient> FilterDoctors(int drID)
        {
            List<Patient> patientlist = PatientService.GetAllPatient();
            List<Patient> filteredList = new List<Patient>();

            foreach (Patient p in patientlist)
            {
                if (p.doctor.doctorId == drID)
                {
                    filteredList.Add(p);
                }
            }
            return filteredList;
        }

        public static Doctor SaveDoctors(string drName)
        {
            Doctor doctor = new Doctor();
            doctor.doctorName = drName;
            doctor.doctorId = drlist.Count;
            drlist.Add(doctor);
            Write();
            return doctor;
        }
        public static Doctor EditDoctor(int indexNo, string drName)
        {
            LoadListFromFile();
            drlist[indexNo].doctorName = drName;
            Write();
            return drlist[indexNo];

        }
        public static void DeleteDoctor(int indexNo)
        {
            drlist.RemoveAt(indexNo);
            for (int i = 0; i < drlist.Count; i++)
            {
                drlist[i].doctorId = i;
            }
            Write();
        }
        private static void LoadListFromFile()
        {
            string json = FileOperation.ReadDr();
            drlist = JsonSerializer.Deserialize<List<Doctor>>(json,
                new JsonSerializerOptions { IncludeFields = true });
        }


        public static Doctor SaveDoctor(string doctorName)
        {
            Doctor d = new Doctor();
            d.doctorName = doctorName;
            d.doctorId = drlist.Count;
            drlist.Add(d);
            Write();
            return d;
        }

        public static Doctor GetSelectedDoctor(int dr)
        {
            LoadListFromFile();
            return drlist.ElementAt(dr);
        }

        public static Doctor SaveDoctor(string? doctorName, int drNo)
        {
            Doctor d = drlist[drNo];
            d.doctorName = doctorName;
            d.doctorId = drNo;
            Write();
            return d;
        }
        public static void Write()
        {
            string json = JsonSerializer.Serialize(drlist,
                new JsonSerializerOptions { IncludeFields = true });
            FileOperation.WriteDr(json);

        }
    }

}


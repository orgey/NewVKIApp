using System;
using System.Numerics;
using NewVKIApp.Domain;

namespace VKIApp.Presentation.ConsoleUI
{
    public class Program
    {
        public static void Main()
        {

            Menu();

        }
        static string secim;

        private static void Menu()
        {
            Console.WriteLine("1. Hasta Islemleri\n2. Doktor Islemleri");
            secim = Console.ReadLine();
            Console.Clear();
            if (secim == "1")
            {
                Console.WriteLine("1. Hasta Islemleri\n");
                PatientMenu();
            }
            else if (secim == "2")
            {
                Console.WriteLine("2. Doktor Islemleri\n");

                DoctorMenu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Lutfen Gecerli Bir Giris Yapin!");
                Menu();
            }
            Again();

        }
        private static void SplitMenus()
        {
            Console.WriteLine("--------------------------------------");

        }

        private static void DoctorMenu()
        {
            SplitMenus();
            Console.WriteLine("1. Yeni Doktor\n2. Doktor Listele\n3. Doktor Duzenle\n4. Doktor Filtrele\n5. Doktor Sil");
            secim = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("2. Doktor Islemleri\n");

            switch (secim)
            {
                case "1":
                    Console.WriteLine(" 1. Yeni Doktor\n");

                    AddDoctor();
                    break;
                case "2":
                    Console.WriteLine(" 2. Doktor Listele\n");
                    DoctorList();
                    break;
                case "3":
                    Console.WriteLine(" 3. Doktor Duzenle");
                    EditDoctorMenu();
                    break;
                case "4":
                    Console.WriteLine(" 4. Doktor Filtrele");
                    FilterDoctor();
                    break;
                case "5":
                    Console.WriteLine(" 5. Doktor Sil");
                    DeleteDoctor();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Lutfen Gecerli Bir Giris Yapin!");
                    DoctorMenu();
                    break;
            }

        }

        private static void FilterDoctor()
        {
            Console.WriteLine("Lutfen Secmek Istediginiz Doktorun Numarasini Giriniz.");
            var doctorList = DoctorList();
            secim = Console.ReadLine();
            if (int.TryParse(secim, out int doktorsecim) && doktorsecim - 1 < doctorList.Count)
            {
                var secilenDr = DoctorService.FilterDoctors(doktorsecim - 1);
                PrintList(secilenDr);

            }
        }

        private static void PatientMenu()
        {
            SplitMenus();
            Console.WriteLine("1. Yeni Hasta\n2. Hasta Listele\n3. Hasta Duzenle\n4. Hasta Sil");
            secim = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("1. Hasta Islemleri\n");
            switch (secim)
            {
                case "1":
                    Console.WriteLine(" 1. Yeni Hasta\n");
                    NewPatient();
                    break;
                case "2":
                    Console.WriteLine(" 2. Hasta Listele\n");
                    PatientList();
                    break;
                case "3":
                    Console.WriteLine(" 3. Hasta Duzenle\n");
                    EditPatientMenu();
                    break;
                case "4":
                    Console.WriteLine(" 4. Hasta Sil\n");
                    DeletePatient();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Lutfen Gecerli Bir Giris Yapin!");
                    PatientMenu();
                    break;
            }

        }
        private static void DeleteDoctor()
        {
            var doctorList = DoctorList();
            Console.WriteLine("Lutfen Silmek Istediginiz Doktorun Numarasini Giriniz.");
            secim = Console.ReadLine();
            if (int.TryParse(secim, out int doktorsecim) && doktorsecim - 1 < doctorList.Count)
            {
                DoctorService.DeleteDoctor(doktorsecim - 1);
                Console.WriteLine("Silme Islemi Basarili!");
            }
            else
            {
                Console.WriteLine("Lutfen Gecerli Bir Hasta Seciniz!");
                DeleteDoctor();
            }

        }
        private static void DeletePatient()
        {
            PatientList();
            Console.WriteLine("Lutfen Silmek Istediginiz Hastanin Numarasini Giriniz.");
            var patientList = PatientService.GetAllPatient();
            secim = Console.ReadLine();
            if (int.TryParse(secim, out int hastasecim) && hastasecim - 1 < patientList.Count)
            {
                PatientService.DeletePatient(hastasecim - 1);
                Console.WriteLine("Silme Islemi Basarili!");
            }
            else
            {
                Console.WriteLine("Lutfen Gecerli Bir Hasta Seciniz!");
                DeletePatient();
            }

        }

        private static void EditDoctorMenu()
        {
            DoctorList();
            Console.WriteLine("Lutfen Degistirmek Istediginiz Doktorun Numarasini Giriniz.");
            var doctorList = DoctorService.GetAllDoctors();
            secim = Console.ReadLine();
            if (int.TryParse(secim, out int doctor) && doctor - 1 < doctorList.Count)
            {
                EditDoctor(doctor - 1);
            }
            else
            {
                Console.WriteLine("Lutfen Gecerli Bir Doktor Seciniz!");
            }
        }



        private static void EditPatientMenu()
        {
            PatientList();
            Console.WriteLine("Lutfen Degistirmek Istediginiz Hastanin Numarasini Giriniz.");
            var patientList = PatientService.GetAllPatient();
            secim = Console.ReadLine();
            if (int.TryParse(secim, out int hastasecim) && hastasecim - 1 < patientList.Count)
            {
                EditPatient(hastasecim - 1);
            }
            else
            {
                Console.WriteLine("Lutfen Gecerli Bir Hasta Seciniz!");
                EditPatientMenu();
            }

        }

        private static void EditDoctor(int dr)
        {
            Doctor selectedDr = DoctorService.GetSelectedDoctor(dr);
            Console.WriteLine($"Doktorun Eski Adi : {selectedDr.doctorName}");
            Console.WriteLine("Lutfen Hasta Adini Giriniz : ");
            string doctorName = Console.ReadLine();
            var x = DoctorService.SaveDoctor(doctorName, dr);
            Console.WriteLine(x.DoctorInfo());
            Console.WriteLine("Doktor Duzenlendi!");
        }

        private static void EditPatient(int secim)
        {
            Patient selectedPatient = PatientService.GetSelectedPatient(secim);
            Console.WriteLine($"Hastanin Eski Adi : {selectedPatient.patientName}");
            Console.WriteLine("Lutfen Hasta Adini Giriniz : ");
            string patientName = Console.ReadLine();

            Console.WriteLine($"Hastanin Eski Boyu : {selectedPatient.patientHeight}");
            Console.WriteLine("Lutfen Hasta Boyunu Giriniz : ");
            int patientHeight = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Hastanin Eski Kilosu : {selectedPatient.patientWeight}");
            Console.WriteLine("Lutfen Hasta Kilosunu Giriniz : ");
            int patientWeight = Convert.ToInt32(Console.ReadLine());

            Doctor doctor = ChooseDoctor();
            Patient p = PatientService.SavePatient(patientName, patientHeight, patientWeight, doctor, secim);

            Console.WriteLine(p.PatientINFO());
            Console.WriteLine("Hasta Degistirildi.");

        }
        private static List<Doctor> DoctorList()
        {
            List<Doctor> doctorList = DoctorService.GetAllDoctors();
            PrintList(doctorList);
            return doctorList;
        }
        private static void PatientList()
        {
            List<Patient> patientList = PatientService.GetAllPatient();
            PrintList(patientList);
        }

        private static void PrintList(List<Patient> patientList)
        {
            Console.WriteLine("----------- Hasta Listesi Başlangıcı ----------");
            foreach (Patient p in patientList)
            {
                SetColor(p.Diagnose());
                Console.WriteLine(p.PatientINFO());
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(p.doctor.DoctorInfo());
                Console.WriteLine("--------------------------------------");
            }
            Console.WriteLine("----------- Hasta Listesi Sonu ----------");
        }

        private static void SetColor(string diagnose)
        {
            switch (diagnose)
            {
                case "Zayif":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "Normal":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "Hafif Kilolu":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "Obez":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    break;
            }
        }

        private static void PrintList(List<Doctor> doctorList)
        {
            Console.WriteLine("----------- Doktor Listesi Başlangıcı ----------");
            foreach (Doctor d in doctorList)
            {

                Console.WriteLine(d.DoctorInfo());
                Console.WriteLine("--------------------------------------");
            }
            Console.WriteLine("----------- Doktor Listesi Sonu ----------");
        }

        private static void Again()
        {
            Console.WriteLine("Menüye dönmek için Enter");
            Console.ReadLine();
            Console.Clear();
            Menu();
        }

        private static void NewPatient()
        {
            Console.WriteLine("Lutfen Hasta Adini Giriniz : ");
            string patientName = Console.ReadLine();
            Console.WriteLine("Lutfen Hasta Boyunu Giriniz : ");
            int patientHeight = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Lutfen Hasta Kilosunu Giriniz : ");
            int patientWeight = Convert.ToInt32(Console.ReadLine());
            Doctor doctor = ChooseDoctor();
            Patient p = PatientService.SavePatient(patientName, patientHeight, patientWeight, doctor);
            SetColor(p.Diagnose());
            Console.WriteLine(p.PatientINFO());
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(p.doctor.DoctorInfo());
            Console.WriteLine("Hasta Database'e Eklendi.");
        }

        private static Doctor ChooseDoctor()
        {
            var drlist = DoctorList();

            Console.WriteLine($"{drlist.Count + 1} - Yeni Doktor Ekle");
            Console.WriteLine("Lutfen Doktor Secin");
            secim = Console.ReadLine();
            if (int.TryParse(secim, out int drsecim) && drsecim <= drlist.Count && drsecim > 0)
            {
                return drlist[drsecim - 1];
            }
            else if (drsecim == drlist.Count + 1)
            {
                return AddDoctor();
            }
            else
            {
                Console.WriteLine("Lutfen Gecerli Bir Doktor Giriniz!");
                return ChooseDoctor();
            }
        }

        private static Doctor AddDoctor()
        {
            Console.WriteLine("Lutfen Eklenecek Doktorun Adini Giriniz : ");
            string doctorName = Console.ReadLine();
            Doctor d = DoctorService.SaveDoctor(doctorName);
            Console.WriteLine(d.DoctorInfo());
            Console.WriteLine("Doktor Database'e Eklendi.");
            return d;
        }
    }
}
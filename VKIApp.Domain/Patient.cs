using System.Text;

namespace NewVKIApp.Domain
{
    public class Patient
    {
        public int patientNo;
        public string patientName;
        public float patientHeight;
        public float patientWeight;
        public float patientVKI;
        public string patientDiagnose;
        public Doctor doctor;

        public float VKICalculate()
        {
            return (patientWeight / ((patientHeight / 100) * (patientHeight / 100)));
        }

        public string Diagnose()
        {
            patientVKI = VKICalculate();

            if (patientVKI < 18.49)
            {
                return "Zayif";
            }
            else if (patientVKI < 24.99)
            {
                return "Normal";
            }

            else if (patientVKI < 29.99)
            {
                return "Hafif Kilolu";
            }
            else
            {
                return "Obez";
            }
        }
        public string PatientINFO()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Hasta No : {patientNo + 1}\n   ");
            sb.Append($"Hasta Adi : {patientName}\n   ");
            sb.Append($"Hasta Boyu : {patientHeight}\n   ");
            sb.Append($"Hasta Kilosu : {patientWeight} \n   ");
            sb.Append($"Hastanin VKI Degeri : {VKICalculate()}\n   ");
            sb.Append($"Hastanin Teshisi : {Diagnose()}");

            return sb.ToString();
        }
    }
}

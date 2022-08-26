
using System.Text;

namespace NewVKIApp.Domain
{
    public class Doctor
    {
        public string doctorName;
        public int doctorId;


        public string DoctorInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Doktor No : {doctorId + 1} \n  ");
            sb.Append($"Doktor Adi : {doctorName}");
            return sb.ToString();
        }
    }

}

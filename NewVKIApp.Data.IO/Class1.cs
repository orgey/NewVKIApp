namespace NewVKIApp.Data.IO
{
    public class FileOperation
    {


        public static void WriteDr(string data)
        {
            File.WriteAllText("datadr.txt", data);
        }
        public static string ReadDr()
        {
            if (File.Exists("datadr.txt"))
            {
                return File.ReadAllText("datadr.txt");

            }
            else
            {
                return null;
            }
        }
        public static void WritePatient(string data)
        {
            File.WriteAllText("datapatient.txt", data);
        }
        public static string ReadPatient()
        {
            if (File.Exists("datapatient.txt"))
            {
                return File.ReadAllText("datapatient.txt");

            }
            else
            {
                return null;
            }
        }
    }
}
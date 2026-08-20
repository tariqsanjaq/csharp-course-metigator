using System.Text;

namespace Task16_StreamIOFileOperations
{
    internal class ByteStreamDemo
    {
        public static void WriteBytes(string filePath)
        {
            using (FileStream fileStream = new(filePath, FileMode.Create, FileAccess.Write))
            {
                for (int i = 65; i < 91; i++)
                {
                    fileStream.WriteByte((byte)i);
                }
            }
        }
        public static void ReadBytes(string filePath)
        {
            byte[] buffer = new byte[10];
            int bytesRead;
            using (FileStream fs = new(filePath, FileMode.Open, FileAccess.Read))
            {
                while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    Console.WriteLine(Encoding.UTF8.GetString(buffer, 0, bytesRead));
                }
            }
        }
        public static void SeekDemo(string filePath)
        {
            byte[] buffer = new byte[10];

            using (FileStream fs = new(filePath, FileMode.Open, FileAccess.Read))
            {
                fs.Seek(5, SeekOrigin.Begin);
                int bytesRead = fs.Read(buffer, 0, buffer.Length);
                Console.WriteLine(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            }
        }
    }
}

namespace Task16_StreamIOFileOperations
{
    internal class NoteRepository
    {
        private readonly string _repository;
        public NoteRepository(string year, string month)
        {
            _repository = Path.Combine(Directory.GetCurrentDirectory(), "Notes", year, month);
            Directory.CreateDirectory(_repository);
        }
        public string GetPath()
        {
            return _repository;
        }
        public void Save(Note note)
        {
            string filePath = BuildPath($"{note.Id}-{note.Title}"); 
            using (StreamWriter sw = new(filePath))
            {
                sw.WriteLine(note.Id);
                sw.WriteLine(note.CreatedAt.ToString("yyyy/MM/dd HH:mm"));
                sw.WriteLine(note.Title);
                sw.WriteLine(note.Content);
            }
        }
        public string Read(string fileName)
        {
            string filePath = BuildPath(fileName);
            using (StreamReader sr = new StreamReader(filePath))
            {

                return sr.ReadToEnd();
            }

        }

        public List<string> ReadLines(string fileName)
        {
            string filePath = BuildPath(fileName);
            using (StreamReader sr = new StreamReader(filePath))
            {
                string? line;
                List<string> strings = new List<string>();
                while ((line = sr.ReadLine()) != null)
                {
                    strings.Add(line);
                }

                return strings;
            }
        }

        public void Append(string fileName, string text)
        {
            string filePath = BuildPath(fileName);
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine(text);
            }

        }
        public void Copy(string fileName, string destinationFolder)
        {
            string filePath = BuildPath(fileName);
            string destination = Path.Combine(destinationFolder, $"{fileName}.txt");
            Directory.CreateDirectory(destinationFolder);
            File.Copy(filePath, destination,true);
        }
        public void Move(string fileName, string destinationFolder)
        {
            string filePath = BuildPath(fileName);
            string destination = Path.Combine(destinationFolder, $"{fileName}.txt");
            Directory.CreateDirectory(destinationFolder);
            File.Move(filePath, destination,true);
        }
        public void ShowFileInfo(string fileName)
        {
            string filePath = BuildPath(fileName);
            FileInfo info = new FileInfo(filePath);
            Console.WriteLine($"Size: {info.Length} bytes");
            Console.WriteLine($"Created: {info.CreationTime}");
            Console.WriteLine($"Modified: {info.LastWriteTime}");
        }
        private string BuildPath(string fileName)
        {
            return Path.Combine(_repository, $"{fileName}.txt");
        }
    }
}

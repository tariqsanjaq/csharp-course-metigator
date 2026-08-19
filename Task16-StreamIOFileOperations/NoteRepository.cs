namespace Task16_StreamIOFileOperations
{
    internal class NoteRepository
    {
        // a field for the root path
        private readonly string _repository;
        // a method that builds /Notes/{year}/{month}/ and creates it,
        public NoteRepository(string year, string month)
        {
            _repository = Path.Combine(Directory.GetCurrentDirectory(), "Notes", year, month);
            Directory.CreateDirectory(_repository);
        }
        // returning the full path so callers can use it
        public string GetPath()
        {
            return _repository;
        }
        public void Save(Note note)
        {
            string filePath = Path.Combine(_repository, $"{note.Id}-{note.Title}.txt");
            using (StreamWriter sw = new(filePath))
            {
                sw.WriteLine(note.Id);
                sw.WriteLine(note.CreatedAt);
                sw.WriteLine(note.Title);
                sw.WriteLine(note.Content);
            }
        }
        public string Read(string fileName)
        {
            string filePath = Path.Combine(_repository, $"{fileName}.txt");
            using (StreamReader sr = new StreamReader(filePath)) 
            {
                
                return sr.ReadToEnd();
            }

        }

        public List<string> ReadLines(string fileName)
        {
            string filePath = Path.Combine(_repository, $"{fileName}.txt");
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
            string filePath = Path.Combine(_repository, $"{fileName}.txt");
            using (StreamWriter sw = new StreamWriter(filePath,true))
            {
                sw.WriteLine(text);
            }

        }

    }
}

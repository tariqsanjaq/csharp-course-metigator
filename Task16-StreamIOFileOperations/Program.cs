namespace Task16_StreamIOFileOperations
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DateTime now = DateTime.Now;
            NoteRepository repo = new NoteRepository(now.ToString("yyyy"), now.ToString("MMMM"));

            Console.WriteLine("=== 1. Directory Structure ===");
            Console.WriteLine($"  {repo.GetPath()}");

            Console.WriteLine("\n=== 2. StreamWriter ===");
            string[] titles = { "meeting", "ideas", "todo", "draft" };
            for (int i = 0; i < titles.Length; i++)
            {
                repo.Save(new Note(i + 1, titles[i], $"Content of the {titles[i]} note."));
                Console.WriteLine($"  saved: {i + 1}-{titles[i]}.txt");
            }

            Console.WriteLine("\n=== 3. StreamReader ===");
            Console.WriteLine("  -- ReadToEnd --");
            Console.WriteLine(repo.Read("1-meeting"));

            Console.WriteLine("  -- ReadLine loop --");
            foreach (string line in repo.ReadLines("1-meeting"))
                Console.WriteLine($"  {line}");

            Console.WriteLine("\n=== 4. Append ===");
            repo.Append("1-meeting", "appended line one");
            repo.Append("1-meeting", "appended line two");
            foreach (string line in repo.ReadLines("1-meeting"))
                Console.WriteLine($"  {line}");

            Console.WriteLine("\n=== 5. Copy & Move ===");
            string archive = Path.Combine(repo.GetPath(), "Archive");
            repo.Copy("4-draft", archive);
            Console.WriteLine("  copied 4-draft (original stays)");
            repo.Move("2-ideas", archive);
            Console.WriteLine("  moved 2-ideas (original gone)");

            Console.WriteLine("\n=== 6. FileInfo ===");
            repo.ShowFileInfo("3-todo");

            Console.WriteLine("\n=== 7. FileStream ===");
            string bytesFile = Path.Combine(repo.GetPath(), "bytes.dat");
            ByteStreamDemo.WriteBytes(bytesFile);
            Console.WriteLine("  -- read in 10-byte chunks --");
            ByteStreamDemo.ReadBytes(bytesFile);
            Console.WriteLine("  -- seek 5, then read 10 --");
            ByteStreamDemo.SeekDemo(bytesFile);

            Console.WriteLine("\n=== 8. Disposal Patterns ===");
            string disposal = Path.Combine(repo.GetPath(), "disposal.txt");
            DisposalPatterns.ManualClose(disposal);
            DisposalPatterns.TryFinally(disposal);
            DisposalPatterns.UsingBlock(disposal);
            DisposalPatterns.UsingDeclaration(disposal);
            Console.WriteLine("  all four patterns wrote successfully");
        }
    }
}
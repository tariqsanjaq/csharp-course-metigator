using Task16_StreamIOFileOperations;

internal class Program
{
    private static void Main(string[] args)
    {
        NoteRepository repo = new NoteRepository("2026", "August");
        repo.Save(new Note(1, "first note", "hello world"));
        Console.WriteLine(repo.GetPath());
    }
}
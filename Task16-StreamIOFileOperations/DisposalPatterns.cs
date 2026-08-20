namespace Task16_StreamIOFileOperations
{

    /// <summary>
    /// Demonstrates the evolution of resource management and disposal patterns in C#.
    /// Shows four approaches to disposing unmanaged resources (like StreamWriter):
    /// 1. Manual Close (prone to resource leaks on exceptions)
    /// 2. Try-Finally block (safe but verbose)
    /// 3. Using block (syntactic sugar for try-finally)
    /// 4. Using declaration (modern C# 8+ syntax, clean and scopes to the method)
    /// </summary>
    internal class DisposalPatterns
    {
        // 1. Manually closes the stream. 
        // Not recommended: if an exception occurs before Close(), the file remains locked.
        public static void ManualClose(string filePath)
        {
            StreamWriter sw = new StreamWriter(filePath);
            sw.WriteLine("hellow");
            sw.Close();
        }

        // 2. Safely ensures the stream is closed, even if an exception is thrown. 
        // This is reliable but requires verbose boilerplate code.
        public static void TryFinally(string filePath)
        {
            StreamWriter? sw = null;
            try
            {
                sw = new StreamWriter(filePath);
                sw.WriteLine("hellow");
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }
        }

        // 3. Syntactic sugar for try-finally. 
        // Automatically calls Dispose() (which calls Close) at the end of the curly braces.
        public static void UsingBlock(string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine("hello");
            }
        }

        // 4. Modern C# 8+ syntax. Cleanest approach. 
        // Automatically disposes of the resource at the end of the method's scope.
        public static void UsingDeclaration(string filePath)
        {
            using StreamWriter sw = new StreamWriter(filePath);
            sw.WriteLine("hello");
        }
    }
}




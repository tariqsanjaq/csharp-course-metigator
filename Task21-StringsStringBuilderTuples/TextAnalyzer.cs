using System.Text;

namespace Task21_StringsStringBuilderTuples
{
    internal class TextAnalyzer
    {
        // Core analysis method: calculates text metrics and returns them as a named tuple
        public (int Words, int Chars, string MostFrequent, string Longest, int Sentences) Analyze(string text)
        {
            // Split input into words, trimming whitespace and removing empty entries
            string[] words = text.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            // Case-insensitive dictionary to track word occurrence counts
            Dictionary<string, int> wordCounts = new(StringComparer.OrdinalIgnoreCase);

            // Count occurrences for each word
            foreach (var item in words)
            {
                if (!wordCounts.TryGetValue(item, out int count))
                {
                    wordCounts.Add(item, 1);
                }
                else
                {
                    wordCounts[item] = ++count;
                }
            }

            // Identify the word with the highest frequency count
            string mostFrequentWord = "";
            int highestCount = 0;
            foreach (var item in wordCounts)
            {
                if (highestCount < item.Value)
                {
                    highestCount = item.Value;
                    mostFrequentWord = item.Key;
                }
            }

            // Find the word with the longest character length
            int maxLength = 0;
            string longestWord = "";
            foreach (string item in words)
            {
                if (maxLength < item.Length)
                {
                    maxLength = item.Length;
                    longestWord = item;
                }
            }

            // Split by sentence terminators (!, ?, .) to calculate total sentence count
            char[] sentenceTerminators = new char[] { '!', '?', '.' };
            string[] sentences = text.Split(sentenceTerminators, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            // Return all collected metrics as a named tuple
            return (words.Length, text.Length, mostFrequentWord, longestWord, sentences.Length);
        }

        // Formats the analyzed tuple values into a readable multi-line string report
        public string BuildReport((int Words, int Chars, string MostFrequent, string Longest, int Sentences) result)
        {
            StringBuilder sb = new();
            sb.AppendLine($"Word count: {result.Words}");
            sb.AppendLine($"Character count: {result.Chars}");
            sb.AppendLine($"Most frequent word: {result.MostFrequent}");
            sb.AppendLine($"Longest word: {result.Longest}");
            sb.AppendLine($"Sentence count: {result.Sentences}");
            return sb.ToString();
        }
    }
}
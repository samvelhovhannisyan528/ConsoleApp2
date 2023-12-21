using System.Text.RegularExpressions;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "859 ADAMS apartment avenue road road road road road road road road 7";

            // Define a regular expression pattern to match the street number, name, and apartment number
            string pattern = @"(\d+)\s*([a-zA-Z\s]+)\s*(\d+)";

            // Create a dictionary to store word abbreviations
            Dictionary<string, string> wordAbbreviations = new Dictionary<string, string>
            {
                { "Avenue", "AVE" },
                { "apartment", "APTS" },
                { "road", "RDS" },
                { "street", "STS" }
                // Add more mappings as needed
            };

            // Use Regex.Match to find the match in the input string
            Match match = Regex.Match(input, pattern);

            // Check if a match is found
            if (match.Success)
            {
                // Extract the captured groups from the match
                string streetNumber = match.Groups[1].Value;
                string streetName = match.Groups[2].Value;

                // Replace words with their abbreviations using the dictionary
                foreach (var kvp in wordAbbreviations)
                {
                    streetName = streetName.Replace(kvp.Key, kvp.Value, StringComparison.OrdinalIgnoreCase);
                }

                string apartmentNumber = match.Groups[3].Value;

                // Construct the desired output format
                string result = $"{streetNumber} {streetName} {apartmentNumber}";

                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("No match found");
            }
        }
    }
}

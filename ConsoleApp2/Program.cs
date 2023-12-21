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


//public interface IWordAbbreviationService
//{
//    string Abbreviate(string input);
//}

//public class WordAbbreviationService : IWordAbbreviationService
//{
//    private readonly Dictionary<string, string> wordAbbreviations;

//    public WordAbbreviationService()
//    {
//        wordAbbreviations = new Dictionary<string, string>
//        {
//            { "Avenue", "AVE" },
//            { "apartment", "APTS" },
//            { "road", "RDS" },
//            { "street", "STS" }
//            // Add more mappings as needed
//        };
//    }

//    public string Abbreviate(string input)
//    {
//        foreach (var kvp in wordAbbreviations)
//        {
//            input = input.Replace(kvp.Key, kvp.Value, StringComparison.OrdinalIgnoreCase);
//        }
//        return input;
//    }
//}

//public class AddressService
//{
//    private readonly IWordAbbreviationService wordAbbreviationService;

//    public AddressService(IWordAbbreviationService wordAbbreviationService)
//    {
//        this.wordAbbreviationService = wordAbbreviationService;
//    }

//    public Address ProcessAddress(string input)
//    {
//        // Use a regular expression to parse the input and extract components
//        // Create an Address object and set its properties
//        // Abbreviate the street name using the word abbreviation service

//        // Example:
//        var match = Regex.Match(input, @"(\d+)\s*([a-zA-Z\s]+)\s*(\d+)");
//        if (match.Success)
//        {
//            var address = new Address
//            {
//                StreetNumber = match.Groups[1].Value,
//                StreetName = wordAbbreviationService.Abbreviate(match.Groups[2].Value),
//                ApartmentNumber = match.Groups[3].Value
//            };

//            return address;
//        }

//        return null; // Handle invalid input as needed
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        var wordAbbreviationService = new WordAbbreviationService();
//        var addressService = new AddressService(wordAbbreviationService);

//        string input = "859 Adams Avenue No7";
//        Address result = addressService.ProcessAddress(input);

//        if (result != null)
//        {
//            Console.WriteLine($"{result.StreetNumber} {result.StreetName} {result.ApartmentNumber}");
//        }
//        else
//        {
//            Console.WriteLine("Invalid address format");
//        }
//    }
//}
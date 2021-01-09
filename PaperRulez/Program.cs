using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PaperRulez
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> keywords = new List<string>();
            try
            {
                // Open the text file using a stream reader.
                using (var sr = new StreamReader("./client/1234_test.txt"))
                {
                    // Read the stream as a string, and write the string to the console.
                    string file = sr.ReadToEnd();

                    Match matchParameters = Regex.Match(file, @"\|(.*)\n");
                    Match typeOfProcessing = Regex.Match(file, @"^(.+)\|");
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("File: \n" + file);

                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Type of processing: " + typeOfProcessing.Groups[1].Value);
                    Console.WriteLine("Match parameters: " + matchParameters.Groups[1].Value);
                    Console.WriteLine("-----------------------------");
                    string[] parameters = matchParameters.Groups[1].Value.Split(",");

                    foreach (var parameter in parameters)
                    {
                        Console.WriteLine($"<{parameter}>");
                    }

                    Utilities.LookupInFile(file, parameters[0]);
                    keywords = parameters;
                }

                var lookupStore = new LookupStore();
                lookupStore.Record("client", "1234", keywords);
            }

            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}


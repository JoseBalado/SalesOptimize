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

                    lookupInFile(file, parameters[0]);
                }
            }

            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        static public void lookupInFile(string file, string parameter)
        {
          foreach (Match match in Regex.Matches(file, parameter, RegexOptions.IgnoreCase))
          {
             Console.WriteLine("Found '{0}' at position {1}", match.Value, match.Index);
          }
       }
    }

    class LookupStore : ILookupStore
    {
        public void Record (string client, string documentId, IEnumerable<string> keywords)
        {
            Console.WriteLine("Hello Record!");
        }

    }
}


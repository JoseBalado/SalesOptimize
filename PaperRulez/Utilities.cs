using System;
using System.IO;
using System.Text.RegularExpressions;

namespace PaperRulez
{
    static class Utilities
    {
        static public string LoadFile(string client, string documentId)
        {
            try
            {
                // Open the text file using a stream reader.
                using (var sr = new StreamReader("./client/1234_test.txt"))
                {
                    // Read the stream as a string, and write the string to the console.
                    string file = sr.ReadToEnd();
                    return file;
                }
            }

            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return null;
            }
        }

        static public void LookupInFile(string file, string parameter)
        {
          foreach (Match match in Regex.Matches(file, parameter, RegexOptions.IgnoreCase))
          {
             Console.WriteLine("Found '{0}' at position {1}", match.Value, match.Index);
          }
       }
    }
}


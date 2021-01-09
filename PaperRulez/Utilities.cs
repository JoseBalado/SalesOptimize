using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PaperRulez
{
    static class Utilities
    {
        static public IEnumerable<string>  FindParameters(string file)
        {
            Match matchParameters = Regex.Match(file, @"\|(.*)\n");
            Console.WriteLine("Match parameters: " + matchParameters.Groups[1].Value);
            IEnumerable<string> parameters = matchParameters.Groups[1].Value.Split(",");
            return parameters;
        }

        static public string LoadFile(string client, string documentId, string contentType)
        {
            try
            {
                // Open the text file using a stream reader.
                using (var sr = new StreamReader($"./{client}/{documentId}_{contentType}.txt"))
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

        static public void LookupInFile(string file, IEnumerable<string> parameters)
        {
            foreach(string parameter in parameters)
            {
              bool isFirst = true;
              foreach (Match match in Regex.Matches(file, parameter, RegexOptions.IgnoreCase))
              {
                  if(isFirst)
                  {
                      isFirst = false;
                  }
                  else
                  {
                     Console.WriteLine("Found '{0}' at position {1}", match.Value, match.Index);
                  }
              }
            }
            Console.WriteLine("--------------------------------------------");
        }

        static public string TypeOfProcessing(string file)
        {
            Match typeOfProcessing = Regex.Match(file, @"^(.+)\|");
            Console.WriteLine("Type of processing: " + typeOfProcessing.Groups[1].Value);
            return typeOfProcessing.Groups[1].Value;
       }
    }
}


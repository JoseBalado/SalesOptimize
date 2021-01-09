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
                string file = Utilities.LoadFile("client", "documentId");

                Match matchParameters = Regex.Match(file, @"\|(.*)\n");
                // Match typeOfProcessing = Regex.Match(file, @"^(.+)\|");
                string typeOfProcessing = Utilities.TypeOfProcessing(file);

                Console.WriteLine("-----------------------------");
                Console.WriteLine("File: \n" + file);

                Console.WriteLine("-----------------------------");
                // Console.WriteLine("Type of processing: " + typeOfProcessing.Groups[1].Value);
                Console.WriteLine("Match parameters: " + matchParameters.Groups[1].Value);
                Console.WriteLine("-----------------------------");
                string[] parameters = matchParameters.Groups[1].Value.Split(",");

                Utilities.LookupInFile(file, parameters[0]);
                IEnumerable<string> keywords = parameters;

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


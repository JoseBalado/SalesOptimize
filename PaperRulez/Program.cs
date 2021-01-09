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
                const string client = "client";
                const string documentId = "1234";
                const string contentType = "test";

                string file = Utilities.LoadFile(client, documentId, contentType);
                Console.WriteLine("File: \n" + file);
                Console.WriteLine("-----------------------------");

                string typeOfProcessing = Utilities.TypeOfProcessing(file);
                IEnumerable<string> parameters = Utilities.FindParameters(file);
                IEnumerable<string> keywords = parameters;

                var lookupStore = new LookupStore();

                Utilities.LookupInFile(file, keywords);
                lookupStore.Record(client, documentId, keywords);
            }

            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }
    }
}


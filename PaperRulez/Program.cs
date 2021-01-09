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
                Console.WriteLine("File: \n" + file);
                Console.WriteLine("-----------------------------");

                string typeOfProcessing = Utilities.TypeOfProcessing(file);
                IEnumerable<string> parameters = Utilities.FindParameters(file);
                IEnumerable<string> keywords = parameters;

                var lookupStore = new LookupStore();
                lookupStore.Record("client", "1234", keywords);
            }

            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }
    }
}


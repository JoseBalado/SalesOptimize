using System;
using System.IO;

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
                    Console.WriteLine(sr.ReadToEnd());
                }
            }

            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}


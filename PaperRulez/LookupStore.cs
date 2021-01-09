using System;
using System.IO;
using System.Collections.Generic;

namespace PaperRulez
{
    class LookupStore : ILookupStore
    {
        public void Record (string client, string documentId, IEnumerable<string> keywords)
        {
            Console.WriteLine($"Saving record for client: {client}, documentId: {documentId}, with keywords:");
            foreach (var keyword in keywords)
            {
                Console.WriteLine($"<{keyword}>");
            }
        }

    }
}    


using System;
using System.Text.RegularExpressions;

namespace PaperRulez
{
    static class Utilities
    {
        static public void LookupInFile(string file, string parameter)
        {
          foreach (Match match in Regex.Matches(file, parameter, RegexOptions.IgnoreCase))
          {
             Console.WriteLine("Found '{0}' at position {1}", match.Value, match.Index);
          }
       }
    }
}


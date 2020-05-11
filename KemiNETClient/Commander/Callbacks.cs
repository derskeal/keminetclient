using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CommandLine;

namespace KemiNETClient.Commander
{
    public class Callbacks
    {
        public static int RunVerb(StartOption startOption)
        {
            // send to server

            Console.WriteLine(startOption.Verbose);
            return 0;
        }
        
        
        public static int RunVerb(CommitOptions t)
        {
            //Console.WriteLine(t.Verbose);
            return 0;

        }

        public static int HandleErrors(IEnumerable<Error> errors)
        {
            foreach (var error in errors.OfType<NamedError>())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Error.WriteLine(error.NameInfo.ShortName);
                Console.Error.WriteLine(error.NameInfo.LongName);
            }
            return 1;
        }

    }
}
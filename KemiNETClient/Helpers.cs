using System;

namespace KemiNETClient
{
    public static class Helpers
    {
        public static string VerifyArgument(string argument)
        {
            foreach (var value in Enum.GetValues(typeof(Constants.CLIArguments)))
            {
                return argument == value.ToString() ? argument : "Invalid argument";
            }

            return null;
        }
    }
}
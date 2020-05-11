using CommandLine;

namespace KemiNETClient.Commander
{
    public class Options
    {
        [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
        public bool Verbose { get; set; }
            
        [Option('o', "output", Required = false, HelpText = "Set output to file.")]
        public bool Output { get; set; }
    }
        
    [Verb("start", HelpText = "Start a process")]
    public class StartOption {
        [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages." )]
        public bool Verbose { get; set; }

        [Value(0, Required = true, HelpText = "Program to run")]
        public bool ProgramExecutable { get; set; }
        
        [Value(1, Required = false, HelpText = "Arguments to be passed to program" )]
        public bool ProgramArguments { get; set; }
    }
    [Verb("commit", HelpText = "Record changes to the repository.")]
    public class CommitOptions {
        //commit options here
    }
    [Verb("clone", HelpText = "Clone a repository into a new directory.")]
    class CloneOptions {
        //clone options here
    }
}
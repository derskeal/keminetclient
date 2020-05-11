using System;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using CommandLine;
using KemiNETClient.Commander;

namespace KemiNETClient
{
    public class Program
    {
        public static int Main(string[] args)
        {
            return Parser.Default.ParseArguments<StartOption,CommitOptions>(args)
                .MapResult(
                    (StartOption opts) => Callbacks.RunVerb(opts),
                    (CommitOptions opts) => Callbacks.RunVerb(opts),
                    Callbacks.HandleErrors);
        }
        
        
    }
}
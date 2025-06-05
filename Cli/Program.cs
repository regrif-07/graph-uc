using System.CommandLine;
using Cli.CommandBuilding;

namespace Cli;

internal static class Program
{
    private static int Main(string[] args)
    {
        var rootCommand = RootCommandBuilder.BuildRootCommand();

        return rootCommand.Invoke(args);
    }
}
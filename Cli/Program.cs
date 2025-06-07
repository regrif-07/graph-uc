using System.CommandLine;
using Cli.Commands.Builders;
using Cli.Debug;

namespace Cli;

internal static class Program
{
    private static int Main(string[] args)
    {
        var rootCommand = new RootCommandBuilder(
            new DebugUnitCommandHandler(),
            new DebugConversionCommandHandler(),
            new DebugConvertCommandHandler()
        ).BuildRootCommand();
        
        return rootCommand.Invoke(args);
    }
}
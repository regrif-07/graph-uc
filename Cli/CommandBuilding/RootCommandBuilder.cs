using System.CommandLine;

namespace Cli.CommandBuilding;

internal static class RootCommandBuilder
{
    public static RootCommand BuildRootCommand()
    {
        var rootCommand = new RootCommand("Graph based unit converter");
        
        rootCommand.AddCommand(UnitCommandBuilder.BuildUnitsCommand());
        rootCommand.AddCommand(ConversionCommandBuilder.BuildConversionCommand());
        rootCommand.AddCommand(ConvertCommandBuilder.BuildConvertCommand());

        return rootCommand;
    }
}
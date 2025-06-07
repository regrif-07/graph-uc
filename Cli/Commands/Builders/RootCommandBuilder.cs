using System.CommandLine;
using Cli.Commands.HandlingInterfaces;

namespace Cli.Commands.Builders;

internal sealed class RootCommandBuilder
{
    private readonly UnitCommandBuilder _unitCommandBuilder;
    private readonly ConversionCommandBuilder _conversionCommandBuilder;
    private readonly ConvertCommandBuilder _convertCommandBuilder;

    public RootCommandBuilder(
        IUnitCommandHandler unitCommandHandler,
        IConversionCommandHandler conversionCommandHandler,
        IConvertCommandHandler convertCommandHandler
    )
    {
        _unitCommandBuilder = new UnitCommandBuilder(unitCommandHandler);
        _conversionCommandBuilder = new ConversionCommandBuilder(conversionCommandHandler);
        _convertCommandBuilder = new ConvertCommandBuilder(convertCommandHandler);
    }

    public RootCommand BuildRootCommand()
    {
        var rootCommand = new RootCommand("Graph based unit converter");
        
        rootCommand.AddCommand(_unitCommandBuilder.BuildUnitsCommand());
        rootCommand.AddCommand(_conversionCommandBuilder.BuildConversionCommand());
        rootCommand.AddCommand(_convertCommandBuilder.BuildConvertCommand());

        return rootCommand;
    }
}
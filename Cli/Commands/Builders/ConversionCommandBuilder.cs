using System.CommandLine;
using Cli.Commands.Common;
using Cli.Commands.HandlingInterfaces;

namespace Cli.Commands.Builders;

internal sealed class ConversionCommandBuilder
{
    private readonly IConversionCommandHandler _conversionCommandHandler;

    public ConversionCommandBuilder(IConversionCommandHandler conversionCommandHandler)
    {
        _conversionCommandHandler = conversionCommandHandler;
    }

    public Command BuildConversionCommand()
    {
        var conversionCommand = new Command("conversion", "Manage conversions");
        
        conversionCommand.AddCommand(BuildAddCommand());
        conversionCommand.AddCommand(BuildDisplayCommand());
        conversionCommand.AddCommand(BuildRemoveCommand());
        
        return conversionCommand;
    }

    private Command BuildAddCommand()
    {
        var sourceUnitOption = CommonOptions.SourceUnit("The name of the source unit (from which the conversion is made)", true);
        var targetUnitOption = CommonOptions.TargetUnit("The name of the target unit (to which the conversion is made)", true);
        var expressionOption = CommonOptions.Expression("The conversion expression", true);
        
        var addCommand = new Command("add", "Add a conversion")
        {
            sourceUnitOption,
            targetUnitOption,
            expressionOption
        };
        
        addCommand.SetHandler(
            _conversionCommandHandler.AddCommandHandler,
            sourceUnitOption,
            targetUnitOption,
            expressionOption
        );

        return addCommand;
    }

    private Command BuildDisplayCommand()
    {
        var targetUnitOption = CommonOptions.TargetUnit("Display all conversions from a unit with a matching name");
        
        var displayCommand = new Command("display", "Display all conversions")
        {
            targetUnitOption
        };
        
        displayCommand.SetHandler(_conversionCommandHandler.DisplayCommandHandler, targetUnitOption);
        
        return displayCommand;
    }
    
    private Command BuildRemoveCommand()
    {
        var sourceUnitOption = CommonOptions.SourceUnit("The name of the source unit (from which the conversion is made)", true);
        var targetUnitOption = CommonOptions.TargetUnit("The name of the target unit (to which the conversion is made)", true);
        
        var removeCommand = new Command("remove", "Remove a conversion")
        {
            sourceUnitOption,
            targetUnitOption
        };
        
        removeCommand.SetHandler(_conversionCommandHandler.RemoveCommandHandler, sourceUnitOption, targetUnitOption);

        return removeCommand;
    }
}
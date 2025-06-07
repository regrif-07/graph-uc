using System.CommandLine;

namespace Cli.CommandBuilding;

internal static class ConversionCommandBuilder
{
    public static Command BuildConversionCommand()
    {
        var conversionCommand = new Command("conversion", "Manage conversions");
        
        conversionCommand.AddCommand(BuildAddCommand());
        conversionCommand.AddCommand(BuildDisplayCommand());
        conversionCommand.AddCommand(BuildRemoveCommand());
        
        return conversionCommand;
    }

    private static Command BuildAddCommand()
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

        return addCommand;
    }

    private static Command BuildDisplayCommand()
    {
        var targetUnitOption = CommonOptions.TargetUnit("Display all conversions from a unit with a matching name");
        
        var displayCommand = new Command("display", "Display all conversions")
        {
            targetUnitOption
        };

        return displayCommand;
    }
    
    private static Command BuildRemoveCommand()
    {
        var sourceUnitOption = CommonOptions.SourceUnit("The name of the source unit (from which the conversion is made)", true);
        var targetUnitOption = CommonOptions.TargetUnit("The name of the target unit (to which the conversion is made)", true);
        
        var removeCommand = new Command("remove", "Remove a conversion")
        {
            sourceUnitOption,
            targetUnitOption
        };

        return removeCommand;
    }
}
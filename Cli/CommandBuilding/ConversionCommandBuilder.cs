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
        var addCommand = new Command("add", "Add a conversion")
        {
            CommonOptions.SourceUnit("The name of the source unit (from which the conversion is made)", isRequired: true),
            CommonOptions.TargetUnit("The name of the target unit (to which the conversion is made)", isRequired: true),
            CommonOptions.Expression("The conversion expression", isRequired: true)
        };

        return addCommand;
    }

    private static Command BuildDisplayCommand()
    {
        var displayCommand = new Command("display", "Display all conversions")
        {
            CommonOptions.TargetUnit("Display all conversions from a unit with a matching name")
        };

        return displayCommand;
    }
    
    private static Command BuildRemoveCommand()
    {
        var removeCommand = new Command("remove", "Remove a conversion")
        {
            CommonOptions.SourceUnit("The name of the source unit (from which the conversion is made)", isRequired: true),
            CommonOptions.TargetUnit("The name of the target unit (to which the conversion is made)", isRequired: true)
        };

        return removeCommand;
    }
}
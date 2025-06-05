using System.CommandLine;

namespace Cli;

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
        var sourceNameOption = new Option<string>(
            name: "--source-name",
            description: "The name of the source unit (from which the conversion is made)."
        )
        {
            IsRequired = true,
        };
        var targetNameOption = new Option<string>(
            name: "--target-name",
            description: "The name of the target unit (to which the conversion is made)."
        )
        {
            IsRequired = true,
        };
        var expressionOption = new Option<string>(
            name: "--expression",
            description: "The conversion expression."
        )
        {
            IsRequired = true,
        };
        
        var addCommand = new Command("add", "Add a conversion")
        {
            sourceNameOption,
            targetNameOption,
            expressionOption,
        };

        return addCommand;
    }

    private static Command BuildDisplayCommand()
    {
        var targetNameOption = new Option<string>(
            name: "--target-name",
            description: "Display all conversions from a unit with a matching name."
        )
        {
            IsRequired = false,
        };
        
        var displayCommand = new Command("display", "Display all conversions")
        {
            targetNameOption,
        };

        return displayCommand;
    }
    
    private static Command BuildRemoveCommand()
    {
        var sourceNameOption = new Option<string>(
            name: "--source-name",
            description: "The name of the source unit (from which the conversion is made)."
        )
        {
            IsRequired = true,
        };
        var targetNameOption = new Option<string>(
            name: "--target-name",
            description: "The name of the target unit (to which the conversion is made)."
        )
        {
            IsRequired = true,
        };
        
        var removeCommand = new Command("remove", "Remove a conversion")
        {
            sourceNameOption,
            targetNameOption,
        };

        return removeCommand;
    }
}
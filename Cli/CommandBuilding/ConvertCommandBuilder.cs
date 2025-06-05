using System.CommandLine;

namespace Cli.CommandBuilding;

internal static class ConvertCommandBuilder
{
    public static Command BuildConvertCommand()
    {
        var sourceValueArgument = new Argument<double>(
            name: "source-value",
            description: "The numeric value of the source unit."
        );
        var sourceNameArgument = new Argument<string>(
            name: "source-name",
            description: "The name of the source unit (from which the conversion is made)."
        );
        var targetNameArgument = new Argument<string>(
            name: "target-name",
            description: "The name of the target unit (to which the conversion is made)."
        );

        var convertCommand = new Command("convert", "Perform a conversion")
        {
            sourceValueArgument,
            sourceNameArgument,
            targetNameArgument,
        };

        return convertCommand;
    }
}
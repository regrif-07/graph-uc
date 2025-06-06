using System.CommandLine;

namespace Cli.CommandBuilding;

internal static class ConvertCommandBuilder
{
    public static Command BuildConvertCommand()
    {
        var convertCommand = new Command("convert", "Perform a conversion")
        {
            CommonOptions.SourceValue("The numeric value of the source unit", true),
            CommonOptions.SourceUnit("The name of the source unit (from which the conversion is made", true),
            CommonOptions.TargetUnit("The name of the target unit (to which the conversion is made)", true)
        };

        return convertCommand;
    }
}
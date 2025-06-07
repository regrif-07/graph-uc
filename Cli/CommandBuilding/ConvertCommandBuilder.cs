using System.CommandLine;

namespace Cli.CommandBuilding;

internal static class ConvertCommandBuilder
{
    public static Command BuildConvertCommand()
    {
        var sourceValueOption = CommonOptions.SourceValue("The numeric value of the source unit", true);
        var sourceUnitOption = CommonOptions.SourceUnit("The name of the source unit (from which the conversion is made", true);
        var targetUnitOption = CommonOptions.TargetUnit("The name of the target unit (to which the conversion is made)", true);
        
        var convertCommand = new Command("convert", "Perform a conversion")
        {
            sourceValueOption,
            sourceUnitOption,
            targetUnitOption
        };

        return convertCommand;
    }
}
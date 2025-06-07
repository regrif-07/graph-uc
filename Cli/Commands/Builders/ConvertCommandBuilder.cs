using System.CommandLine;
using Cli.Commands.Common;
using Cli.Commands.HandlingInterfaces;

namespace Cli.Commands.Builders;

internal sealed class ConvertCommandBuilder
{
    private readonly IConvertCommandHandler _convertCommandHandler;

    public ConvertCommandBuilder(IConvertCommandHandler convertCommandHandler)
    {
        _convertCommandHandler = convertCommandHandler;
    }

    public Command BuildConvertCommand()
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
        
        convertCommand.SetHandler(
            _convertCommandHandler.ConvertCommandHandler,
            sourceValueOption,
            sourceUnitOption,
            targetUnitOption
        );

        return convertCommand;
    }
}
namespace Cli.Commands.HandlingInterfaces;

internal interface IConvertCommandHandler
{
    public void ConvertCommandHandler(double sourceValue, string sourceUnitName, string targetUnitName);
}
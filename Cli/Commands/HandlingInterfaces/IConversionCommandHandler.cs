namespace Cli.Commands.HandlingInterfaces;

internal interface IConversionCommandHandler
{
    public void AddCommandHandler(string sourceUnitName, string targetUnitName, string expression);
    
    public void DisplayCommandHandler(string? targetUnitName);

    public void RemoveCommandHandler(string sourceUnitName, string targetUnitName);
}
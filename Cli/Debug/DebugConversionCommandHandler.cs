using Cli.Commands.HandlingInterfaces;

namespace Cli.Debug;

internal class DebugConversionCommandHandler : IConversionCommandHandler
{
    public void AddCommandHandler(string sourceUnitName, string targetUnitName, string expression)
    {
        Console.WriteLine($"[DEBUG] Adding conversion: {sourceUnitName} -> {targetUnitName} with expression: {expression}");
    }

    public void DisplayCommandHandler(string? targetUnitName)
    {
        Console.WriteLine(targetUnitName == null
            ? "[DEBUG] Displaying all conversions"
            : $"[DEBUG] Displaying conversions for unit: {targetUnitName}");
    }

    public void RemoveCommandHandler(string sourceUnitName, string targetUnitName)
    {
        Console.WriteLine($"[DEBUG] Removing conversion: {sourceUnitName} -> {targetUnitName}");
    }
}
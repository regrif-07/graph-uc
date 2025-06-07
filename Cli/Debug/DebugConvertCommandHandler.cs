using Cli.Commands.HandlingInterfaces;

namespace Cli.Debug;

internal class DebugConvertCommandHandler : IConvertCommandHandler
{
    public void ConvertCommandHandler(double sourceValue, string sourceUnitName, string targetUnitName)
    {
        Console.WriteLine($"[DEBUG] Converting: {sourceValue} {sourceUnitName} to {targetUnitName}");
    }
}
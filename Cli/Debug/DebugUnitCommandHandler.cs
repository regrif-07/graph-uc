using Cli.Commands.HandlingInterfaces;

namespace Cli.Debug;

internal class DebugUnitCommandHandler : IUnitCommandHandler
{
    public void AddCommandHandler(string singleName, string pluralName, IEnumerable<string> otherNames)
    {
        var otherNamesStr = string.Join(", ", otherNames);
        Console.WriteLine($"[DEBUG] Adding unit - Single: {singleName}, Plural: {pluralName}, Other names: [{otherNamesStr}]");
    }

    public void DisplayCommandHandler(string? targetUnitName)
    {
        Console.WriteLine(targetUnitName == null
            ? "[DEBUG] Displaying all units"
            : $"[DEBUG] Displaying unit: {targetUnitName}");
    }

    public void UpdateCommandHandler(
        string targetUnitName,
        string? singleNameUpdated,
        string? pluralNameUpdated,
        IEnumerable<string> otherNamesUpdated,
        IEnumerable<string> otherNamesToAdd)
    {
        Console.WriteLine($"[DEBUG] Updating unit: {targetUnitName}");

        if (singleNameUpdated != null)
        {
            Console.WriteLine($"  - New single name: {singleNameUpdated}");
        }

        if (pluralNameUpdated != null)
        {
            Console.WriteLine($"  - New plural name: {pluralNameUpdated}");
        }

        var otherNamesUpdatedArray = otherNamesUpdated.ToArray();
        if (otherNamesUpdatedArray.Length != 0)
        {
            Console.WriteLine($"  - Updated other names: [{string.Join(", ", otherNamesUpdatedArray)}]");
        }

        var otherNamesToAddArray = otherNamesToAdd.ToArray();
        if (otherNamesToAddArray.Length != 0)
        {
            Console.WriteLine($"  - Adding other names: [{string.Join(", ", otherNamesToAddArray)}]");
        }
    }

    public void RemoveCommandHandler(string targetUnitName)
    {
        Console.WriteLine($"[DEBUG] Removing unit: {targetUnitName}");
    }
}
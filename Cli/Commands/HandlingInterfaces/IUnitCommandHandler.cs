namespace Cli.Commands.HandlingInterfaces;

internal interface IUnitCommandHandler
{
    public void AddCommandHandler(string singleName, string pluralName, IEnumerable<string> otherNames);
    
    public void DisplayCommandHandler(string? targetUnitName);
    
    public void UpdateCommandHandler(
        string targetUnitName,
        string? singleNameUpdated,
        string? pluralNameUpdated,
        IEnumerable<string> otherNamesUpdated,
        IEnumerable<string> otherNamesToAdd
    );
    
    public void RemoveCommandHandler(string targetUnitName);
}
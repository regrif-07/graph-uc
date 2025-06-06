using System.CommandLine;
using System.CommandLine.Parsing;

namespace Cli.CommandBuilding;

internal static class UnitCommandBuilder
{
    public static Command BuildUnitsCommand()
    {
        var unitCommand = new Command("unit", "Manage units");
        
        unitCommand.AddCommand(BuildAddCommand());
        unitCommand.AddCommand(BuildDisplayCommand());
        unitCommand.AddCommand(BuildUpdateCommand());
        unitCommand.AddCommand(BuildRemoveCommand());
        
        return unitCommand;
    }

    private static Command BuildAddCommand()
    {
        var addCommand = new Command("add", "Add a unit")
        {
            CommonOptions.SingleName("The single name of the unit", isRequired: true),
            CommonOptions.PluralName("The plural name of the unit", isRequired: true),
            CommonOptions.OtherNames("The list of other names of the unit")
        };
        
        return addCommand;
    }

    private static Command BuildDisplayCommand()
    {
        var displayCommand = new Command("display", "Display all units")
        {
            CommonOptions.TargetUnit("Display a unit with a matching name")
        };
        
        return displayCommand;
    }

    private static Command BuildUpdateCommand()
    {
        var updateCommand = new Command("update", "Update a unit")
        {
            CommonOptions.TargetUnit("The name of the target unit that will be updated", isRequired: true),
            CommonOptions.SingleName("The updated single name of the unit"),
            CommonOptions.PluralName("The updated plural name of the unit"),
            CommonOptions.OtherNames("The updated list of other names of the unit (will overwrite the old one)"),
            CommonOptions.OtherNamesAdd("The list of other names that will be combined with existing one")
        };
        
        updateCommand.AddValidator(ValidateUpdateCommand);
        return updateCommand;
    }
    
    private static void ValidateUpdateCommand(CommandResult result)
    {
        var singleName = result.GetValueForOption(result.Command.Options.OfType<Option<string>>()
            .First(o => o.Name == "single-name"));
        var pluralName = result.GetValueForOption(result.Command.Options.OfType<Option<string>>()
            .First(o => o.Name == "plural-name"));
        var otherNames = result.GetValueForOption(result.Command.Options.OfType<Option<IEnumerable<string>>>()
            .First(o => o.Name == "other-names"));
        var otherNamesToAdd = result.GetValueForOption(result.Command.Options.OfType<Option<IEnumerable<string>>>()
            .First(o => o.Name == "other-names-add"));

        if (string.IsNullOrEmpty(singleName) &&
            string.IsNullOrEmpty(pluralName) &&
            otherNames?.Any() != true &&
            otherNamesToAdd?.Any() != true)
        {
            result.ErrorMessage = "You must provide at least one field to update.";
        }
    }
    
    private static Command BuildRemoveCommand()
    {
        var removeCommand = new Command("remove", "Remove a unit")
        {
            CommonOptions.TargetUnit("The name of the target unit that will be deleted", isRequired: true)
        };

        return removeCommand;
    }
}
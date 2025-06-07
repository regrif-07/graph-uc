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
        var singleNameOption = CommonOptions.SingleName("The single name of the unit", true);
        var pluralNameOption = CommonOptions.PluralName("The plural name of the unit", true);
        var otherNamesOption = CommonOptions.OtherNames("The list of other names of the unit");
        
        var addCommand = new Command("add", "Add a unit")
        {
            singleNameOption,
            pluralNameOption,
            otherNamesOption
        };
        
        return addCommand;
    }

    private static Command BuildDisplayCommand()
    {
        var targetUnitOption = CommonOptions.TargetUnit("Display a unit with a matching name");
        
        var displayCommand = new Command("display", "Display all units")
        {
            targetUnitOption
        };
        
        return displayCommand;
    }

    private static Command BuildUpdateCommand()
    {
        var targetUnitOption = CommonOptions.TargetUnit("The name of the target unit that will be updated", true);
        var singleNameOption = CommonOptions.SingleName("The updated single name of the unit");
        var pluralNameOption = CommonOptions.PluralName("The updated plural name of the unit");
        var otherNamesOption = CommonOptions.OtherNames("The updated list of other names of the unit (will overwrite the old one)");
        var otherNamesAddOption = CommonOptions.OtherNamesAdd("The list of other names that will be combined with existing one");
        
        var updateCommand = new Command("update", "Update a unit")
        {
            targetUnitOption,
            singleNameOption,
            pluralNameOption,
            otherNamesOption,
            otherNamesAddOption
        };
        
        updateCommand.AddValidator(CommonValidators.BuildAtLeastOneOptionRequiredValidator(
            ["single-name", "plural-name", "other-names", "other-names-add"]
        ));
        return updateCommand;
    }
    
    private static Command BuildRemoveCommand()
    {
        var targetUnitOption = CommonOptions.TargetUnit("The name of the target unit that will be deleted", true);
        
        var removeCommand = new Command("remove", "Remove a unit")
        {
            targetUnitOption
        };

        return removeCommand;
    }
}
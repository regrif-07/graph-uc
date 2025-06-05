using System.CommandLine;

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
        var singleNameOption = new Option<string>(
            name: "--single-name",
            description: "The single name of the unit."
        )
        {
            IsRequired = true,
        };
        var pluralNameOption = new Option<string>(
            name: "--plural-name",
            description: "The plural name of the unit."
        )
        {
            IsRequired = true,
        };
        var otherNamesOption = new Option<IEnumerable<string>>(
            name: "--other-names",
            description: "The list of other names of the unit."
        )
        {
            IsRequired = false,
        };
        
        var addCommand = new Command("add", "Add a unit")
        {
            singleNameOption,
            pluralNameOption,
            otherNamesOption,
        };
        
        return addCommand;
    }

    private static Command BuildDisplayCommand()
    {
        var targetNameOption = new Option<string>(
            name: "--target-name",
            description: "Display a unit with a matching name."
        )
        {
            IsRequired = false,
        };

        var displayCommand = new Command("display", "Display all units")
        {
            targetNameOption,
        };
        
        return displayCommand;
    }

    private static Command BuildUpdateCommand()
    {
        var targetNameOption = new Option<string>(
            name: "--target-name",
            description: "The name of the target unit that will be updated."
        )
        {
            IsRequired = true
        };
        var singleNameOption = new Option<string>(
            name: "--single-name",
            description: "The updated single name of the unit."
        )
        {
            IsRequired = false,
        };
        var pluralNameOption = new Option<string>(
            name: "--plural-name",
            description: "The updated plural name of the unit."
        )
        {
            IsRequired = false,
        };
        var otherNamesOption = new Option<IEnumerable<string>>(
            name: "--other-names",
            description: "The updated list of other names of the unit (will overwrite the old one)."
        )
        {
            IsRequired = false,
        };
        var otherNamesAddOption = new Option<IEnumerable<string>>(
            name: "--other-names-add",
            description: "The list of other names that will be combined with existing one."
        )
        {
            IsRequired = false,
        };

        var updateCommand = new Command("update", "Update a unit")
        {
            targetNameOption,
            singleNameOption,
            pluralNameOption,
            otherNamesOption,
            otherNamesAddOption,
        };
        
        // enforce that at least one update target option is provided
        updateCommand.AddValidator(result =>
        {
            var singleName = result.GetValueForOption(singleNameOption);
            var pluralName = result.GetValueForOption(pluralNameOption);
            var otherNames = result.GetValueForOption(otherNamesOption);
            var otherNamesToAdd = result.GetValueForOption(otherNamesAddOption);

            if (string.IsNullOrEmpty(singleName) &&
                string.IsNullOrEmpty(pluralName) &&
                (otherNames is null || !otherNames.Any()) &&
                (otherNamesToAdd is null || !otherNamesToAdd.Any()))
            {
                result.ErrorMessage = "You must provide the data to update.";
            }
        });

        return updateCommand;
    }
    
    private static Command BuildRemoveCommand()
    {
        var targetNameOption = new Option<string>(
            name: "--target-name",
            description: "The name of the target unit that will be deleted."
        )
        {
            IsRequired = true
        };
        
        var removeCommand = new Command("remove", "Remove a unit")
        {
            targetNameOption,
        };

        return removeCommand;
    }
}
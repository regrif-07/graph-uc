using System.CommandLine.Parsing;

namespace Cli.Commands.Common;

internal static class CommonValidators
{
    public static readonly ValidateSymbolResult<OptionResult> EmptyStringNotAllowedValidator = result =>
    {
        var stringOptionValue = result.GetValueOrDefault<string>();
        if (string.IsNullOrWhiteSpace(stringOptionValue))
        {
            result.ErrorMessage = $"The value for the \"{result.Option.Name}\" must not be empty.";
        }
    };

    public static readonly ValidateSymbolResult<OptionResult> EmptyStringInCollectionNotAllowedValidator = result =>
    {
        var stringCollectionOptionValue = result.GetValueOrDefault<IEnumerable<string>>();
        if (stringCollectionOptionValue?.Any(string.IsNullOrWhiteSpace) == true)
        {
            result.ErrorMessage = $"\"{result.Option.Name}\" must not contain empty elements.";
        }
    };
    
    public static ValidateSymbolResult<CommandResult> BuildAtLeastOneOptionRequiredValidator(
        IEnumerable<string> optionNames,
        bool emptyStringOptionsAllowed = false
    )
    {
        return result =>
        {
            // iterate over all options in the specified group where at least one option should be provided
            foreach (var option in result.Command.Options.Where(o => optionNames.Contains(o.Name)))
            {
                object? optionValue;
                try
                {
                    // some options (like IEnumerable<T>) will throw an exception when no arguments are provided
                    optionValue = result.GetValueForOption(option); 
                }
                catch (InvalidOperationException)
                {
                    optionValue = null;
                }
                
                switch (optionValue)
                {
                    case null:
                        break;
                    
                    case string stringOptionValue:
                        if (emptyStringOptionsAllowed || !string.IsNullOrWhiteSpace(stringOptionValue))
                        {
                            return;
                        }

                        break;

                    case IEnumerable<string> stringCollectionOptionValue:
                        var stringArrayOptionValue = stringCollectionOptionValue.ToArray();
                        if (stringArrayOptionValue.Length != 0 &&
                            (emptyStringOptionsAllowed || stringArrayOptionValue.All(s => !string.IsNullOrWhiteSpace(s))))
                        {
                            return;
                        }

                        break;
                    
                    default:
                        return;
                }
            }
            
            result.ErrorMessage = "You must provide at least one field to update.";
        };
    }
}
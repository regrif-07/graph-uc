using System.Collections;
using System.CommandLine.Parsing;

namespace Cli.CommandBuilding;

internal static class CommonValidators
{
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

                    case IEnumerable<string> enumerableStringOptionValue:
                        var stringArrayOptionValue = enumerableStringOptionValue.ToArray();
                        if (stringArrayOptionValue.Length != 0 &&
                            (emptyStringOptionsAllowed || stringArrayOptionValue.All(s => !string.IsNullOrWhiteSpace(s))))
                        {
                            return;
                        }

                        break;
                    
                    case IEnumerable enumerableOptionValue:
                        if (enumerableOptionValue.Cast<object>().Any())
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
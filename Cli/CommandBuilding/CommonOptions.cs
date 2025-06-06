using System.CommandLine;

namespace Cli.CommandBuilding;

internal static class CommonOptions
{
    public static Option<string> TargetUnit(string description, bool isRequired = false) =>
        new("--target-unit", description) { IsRequired = isRequired };

    public static Option<string> SourceUnit(string description, bool isRequired = false) =>
        new("--source-unit", description) { IsRequired = isRequired };

    public static Option<string> SingleName(string description, bool isRequired = false) =>
        new("--single-name", description) { IsRequired = isRequired };

    public static Option<string> PluralName(string description, bool isRequired = false) =>
        new("--plural-name", description) { IsRequired = isRequired };

    public static Option<IEnumerable<string>> OtherNames(string description, bool isRequired = false) =>
        new("--other-names", description) { IsRequired = isRequired, AllowMultipleArgumentsPerToken = true };

    public static Option<IEnumerable<string>> OtherNamesAdd(string description, bool isRequired = false) =>
        new("--other-names-add", description) { IsRequired = isRequired, AllowMultipleArgumentsPerToken = true };

    public static Option<string> Expression(string description, bool isRequired = false) =>
        new("--expression", description) { IsRequired = isRequired };

    public static Option<double> SourceValue(string description, bool isRequired = false) =>
        new("--source-value", description) { IsRequired = isRequired };
}
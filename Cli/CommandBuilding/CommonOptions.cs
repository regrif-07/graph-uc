using System.CommandLine;

namespace Cli.CommandBuilding;

internal static class CommonOptions
{
    public static Option<string> TargetUnit(string description, bool isRequired = false) =>
        CreateNonEmptyStringOption("--target-unit", description, isRequired);

    public static Option<string> SourceUnit(string description, bool isRequired = false) =>
        CreateNonEmptyStringOption("--source-unit", description, isRequired);

    public static Option<string> SingleName(string description, bool isRequired = false) =>
        CreateNonEmptyStringOption("--single-name", description, isRequired);

    public static Option<string> PluralName(string description, bool isRequired = false) =>
        CreateNonEmptyStringOption("--plural-name", description, isRequired);

    public static Option<IEnumerable<string>> OtherNames(string description, bool isRequired = false) =>
        CreateNonEmptyStringCollectionOption("--other-names", description, isRequired);

    public static Option<IEnumerable<string>> OtherNamesAdd(string description, bool isRequired = false) =>
        CreateNonEmptyStringCollectionOption("--other-names-add", description, isRequired);

    public static Option<string> Expression(string description, bool isRequired = false) =>
        CreateNonEmptyStringOption("--expression", description, isRequired);

    public static Option<double> SourceValue(string description, bool isRequired = false)
        => CreateDoubleOption("--source-value", description, isRequired);

    private static Option<string> CreateNonEmptyStringOption(string name, string description, bool isRequired)
    {
        var nonEmptyStringOption = new Option<string>(name, description) { IsRequired = isRequired };
        nonEmptyStringOption.AddValidator(CommonValidators.EmptyStringNotAllowedValidator);
        return nonEmptyStringOption;
    }

    private static Option<IEnumerable<string>> CreateNonEmptyStringCollectionOption(
        string name, 
        string description,
        bool isRequired
    )
    {
        var nonEmptyStringCollectionOption = new Option<IEnumerable<string>>(name, description)
        {
            IsRequired = isRequired,
            AllowMultipleArgumentsPerToken = true
        };
        nonEmptyStringCollectionOption.AddValidator(CommonValidators.EmptyStringInCollectionNotAllowedValidator);
        return nonEmptyStringCollectionOption;
    }

    private static Option<double> CreateDoubleOption(string name, string description, bool isRequired)
    {
        return new Option<double>(
            name,
            CommonArgumentParsers.BuildDoubleArgumentParser(name),
            false,
            description
        )
        {
            IsRequired = isRequired
        };
    }
}

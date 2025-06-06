using System.CommandLine.Parsing;

namespace Cli.CommandBuilding;

internal static class CommonArgumentParsers
{
    public static ParseArgument<double> BuildDoubleArgumentParser(string argumentName) => result =>
    {
        if (result.Tokens.Count != 1)
        {
            result.ErrorMessage = $"You should provide exactly one numeric value for the \"{argumentName}\".";
            return 0.0;
        }

        if (double.TryParse(result.Tokens[0].Value, out var value))
        {
            return value;
        }

        result.ErrorMessage = $"The value provided for the \"{argumentName}\" is not numeric.";
        return 0.0;
    };
}
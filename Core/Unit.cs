namespace Core;

public sealed class Unit
{
    public Unit(string pluralName, string singleName, params string[] otherNames)
    {
        PluralName = pluralName;
        SingleName = singleName;
        OtherNames = otherNames.ToList();

        if (AllNames.Any(string.IsNullOrWhiteSpace))
        {
            throw new ArgumentException("name cannot be null or empty");
        }
    }

    public string PluralName { get; }
    public string SingleName { get; }
    public List<string> OtherNames { get; }

    public IEnumerable<string> AllNames
    {
        get
        {
            yield return PluralName;
            yield return SingleName;
            foreach (var otherName in OtherNames)
            {
                yield return otherName;
            }
        }
    }

    public override string ToString() => PluralName;
}
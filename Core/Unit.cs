namespace Core;

public class Unit
{
    public Unit(string pluralName, string singleName, params string[] otherNames)
    {
        PluralName = pluralName;
        SingleName = singleName;
        OtherNames = otherNames.ToList();
    }

    public string PluralName { get; set; }
    public string SingleName { get; set; }
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
}
namespace Interfaces.Options
{
  public class OptionItem
  {
    private object _defaultValue;
    public string Name { get; set; }
    public object DefaultValue
    {
      get => _defaultValue;
      set => _defaultValue =
        ItemType == OptionItemType.Bool && value is bool
        || ItemType == OptionItemType.Integer && value is int
        || ItemType == OptionItemType.String && value is string
        ? value : null;
    }
    public OptionItemType ItemType { get; set; }
    public override string ToString()
    {
      return Name;
    }
  }
}
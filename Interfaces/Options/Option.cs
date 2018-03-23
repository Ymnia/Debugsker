namespace Interfaces.Options
{
  public interface IOption
  {
    string CollectionName { get; }
    OptionItem[] Items { get; }
  }
}
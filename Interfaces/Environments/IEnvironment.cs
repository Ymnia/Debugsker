namespace Interfaces.Environments
{
  public interface IEnvironment
  {
    string Name { get; }
    Connection[] Connections { get; }
  }
}
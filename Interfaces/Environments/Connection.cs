namespace Interfaces.Environments
{
  public class Connection
  {
    public string ConnectionName;
    public string LoginString;
    public string UserName;
    public string PassWord;
    public string ConnectionString;
    public string APIKey;
    public string APIPublicKey;
    public string BaseURL;
    public string ManagementUrl;

    public override string ToString()
    {
      return ConnectionName;
    }
  }
}
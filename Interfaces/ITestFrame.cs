using System.Collections.Generic;
using System.Windows.Forms;

namespace Interfaces
{
  public interface ITestFrame
  {
    string Title { get; }
    Dictionary<string, Panel> Frames { get; }
  }
}
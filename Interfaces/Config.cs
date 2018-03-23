using Interfaces.Environments;
using System;
using System.Collections.Generic;

namespace Interfaces
{
  public static class Config
  {
    #region connection

    private static Connection _current;
    public static event Action<Connection> ConnectionChanged;
    public static Connection CurrentSelectedConnection
    {
      get => _current;
      set
      {
        ConnectionChanged?.Invoke(value);
        _current = value;
      }
    }

    #endregion

    #region Options

    private static Dictionary<string, bool> _booleanOptions = new Dictionary<string, bool>();
    private static Dictionary<string, int> _integerOptions = new Dictionary<string, int>();
    private static Dictionary<string, string> _stringOptions = new Dictionary<string, string>();
    public static event Action<string, Type> OptionChanged;

    public static bool? GetBooleanOption(string key) => _booleanOptions.TryGetValue(key, out bool value) ? (bool?)value : null;
    public static int? GetIntegerOption(string key) => _integerOptions.TryGetValue(key, out int value) ? (int?)value : null;
    public static string GetStringOption(string key) => _stringOptions.TryGetValue(key, out string value) ? value : null;

    public static bool SetOption(string key, object value)
    {
      if (SetBooleanOption(key, value)) return true;
      if (SetIntegerOption(key, value)) return true;
      if (SetStringOption(key, value)) return true;
      return false;
    }

    public static bool SetBooleanOption(string key, object value)
    {
      if (value == null || !(value is bool)) return false;
      if (_booleanOptions.ContainsKey(key))
        _booleanOptions[key] = (bool)value;
      else
        _booleanOptions.Add(key, (bool)value);
      OptionChanged?.Invoke(key, typeof(bool));
      return true;
    }

    public static bool SetIntegerOption(string key, object value)
    {

      if (!int.TryParse(value.ToString(), out var parsed)) return false;
      if (_integerOptions.ContainsKey(key))
        _integerOptions[key] = parsed;
      else
        _integerOptions.Add(key, parsed);
      OptionChanged?.Invoke(key, typeof(int));
      return true;
    }

    public static bool SetStringOption(string key, object value)
    {
      if (_stringOptions.ContainsKey(key))
        _stringOptions[key] = value.ToString();
      else
        _stringOptions.Add(key, value.ToString());
      OptionChanged?.Invoke(key, typeof(string));
      return true;
    }

    #endregion
  }
}
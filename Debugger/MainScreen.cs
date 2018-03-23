﻿// ReSharper disable UnusedVariable
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Interfaces;
using Interfaces.Environments;
using Interfaces.Options;

namespace Debugger
{
  public partial class MainScreen : Form
  {
    #region visual magic

    private string _pluginLocation;
    private int _informationBlockSize = 175;
    private static List<IEnvironment> _environments;
    private readonly Color[] _scheme =
    {
      Color.FromArgb(00, 40, 00),
      Color.FromArgb(00, 90, 00),
      Color.FromArgb(44, 120, 44),
      Color.FromArgb(63, 150, 63),
      Color.FromArgb(74, 180, 74)
    };

    #endregion

    public MainScreen()
    {
      InitializeComponent();
      LoadConfiguration();
      LoadEnvironments();
      LoadOptions();
      LoadPlugins();
      LoadAdditionalBlocks();
    }

    private void LoadConfiguration()
    {
      SetPluginLocation();
      SetBlockDimension();
    }

    private void LoadEnvironments()
    {
      _environments = CreateInstancesFromPlugins<IEnvironment>();
      foreach (var env in _environments)
      {
        var devider = new ToolStripMenuItem(env.Name);
        devider.Font = new Font(devider.Font, FontStyle.Underline);
        environmentsToolStripMenuItem.DropDownItems.Add(devider);
        if(env.Connections == null) continue;
        foreach (var envDet in env.Connections)
        {
          var item = new ToolStripMenuItem(envDet.ToString()) { CheckOnClick = true };
          item.CheckedChanged += CheckEnvironment;
          item.CheckedChanged += (o, i) => { Config.CurrentSelectedConnection = item.Checked ? envDet : null; };
          environmentsToolStripMenuItem.DropDownItems.Add(item);
          var informationBlock = new Panel { Parent = flowLayoutPanel1, BackColor = _scheme[0], Height = _informationBlockSize, Width = _informationBlockSize };
          var label = new Label { Parent = informationBlock, Text = envDet.ConnectionName, TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill, Font = new Font(informationBlock.Font, FontStyle.Bold), ForeColor = Color.Wheat };
          var panelN = new Panel { Parent = informationBlock, Height = 10, BackColor = _scheme[0], Dock = DockStyle.Top };
          var panelE = new Panel { Parent = informationBlock, Width = 10, BackColor = _scheme[0], Dock = DockStyle.Right };
          var panelS = new Panel { Parent = informationBlock, Height = 10, BackColor = _scheme[0], Dock = DockStyle.Bottom };
          var panelW = new Panel { Parent = informationBlock, Width = 10, BackColor = _scheme[0], Dock = DockStyle.Left };
          Config.ConnectionChanged += c => { informationBlock.BackColor = c?.ConnectionName == envDet.ConnectionName ? _scheme[1] : _scheme[0]; };
        }
      }
    }

    private void LoadOptions()
    {
      var options = CreateInstancesFromPlugins<IOption>();
      foreach (var opt in options)
      {
        var devider = new ToolStripMenuItem(opt.CollectionName);
        devider.Font = new Font(devider.Font, FontStyle.Underline);
        optionsToolStripMenuItem.DropDownItems.Add(devider);
        if (opt.Items == null) continue;
        foreach (var optDet in opt.Items)
        {
          var panelColor = Color.White;
          var item = new ToolStripMenuItem(optDet.ToString());
          var subItem = new ToolStripTextBox($"{optDet.Name}.Value");
          subItem.KeyUp += (o, i) => { if (i.KeyCode == Keys.Enter) optionsToolStripMenuItem.HideDropDown(); };
          subItem.KeyDown += (o, i) => { if (i.KeyCode == Keys.Enter) i.SuppressKeyPress = true; };
          switch (optDet.ItemType)
          {
            case OptionItemType.Bool:
              {
                panelColor = _scheme[2];
                Config.SetBooleanOption(optDet.Name, optDet.DefaultValue);
                item.CheckOnClick = true;
                item.Checked = Config.GetBooleanOption(optDet.Name) ?? false;
                item.CheckedChanged += (o, i) => Config.SetBooleanOption(optDet.Name, ((ToolStripMenuItem)o).Checked);
                break;
              }
            case OptionItemType.String:
              {
                panelColor = _scheme[3];
                Config.SetStringOption(optDet.Name, optDet.DefaultValue);
                subItem.Text = optDet.DefaultValue.ToString();
                subItem.TextChanged += (o, i) => Config.SetStringOption(optDet.Name, subItem.Text);
                item.DropDownItems.Add(subItem);
                break;
              }
            case OptionItemType.Integer:
              {
                panelColor = _scheme[4];
                Config.SetIntegerOption(optDet.Name, optDet.DefaultValue);
                subItem.Text = Config.GetIntegerOption(optDet.Name)?.ToString();
                subItem.TextChanged += (o, i) =>
                {
                  if (!Config.SetIntegerOption(optDet.Name, subItem.Text))
                    subItem.Text = string.Empty;
                };
                subItem.KeyUp += (o, i) =>
                {
                  var val = Config.GetIntegerOption(optDet.Name);
                  if (i.KeyCode == Keys.Up)
                  {
                    Config.SetIntegerOption(optDet.Name, val++);
                  }
                  if (i.KeyCode == Keys.Down)
                  {
                    Config.SetIntegerOption(optDet.Name, val--);
                  }
                  subItem.Text = val.ToString();
                };
                item.DropDownItems.Add(subItem);
                break;
              }
          }

          var informationBlock = new Panel { Parent = flowLayoutPanel1, BackColor = panelColor, Height = _informationBlockSize, Width = _informationBlockSize };
          var title = new Label { Text = optDet.Name, Parent = informationBlock, TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Top };
          var content = new Label { Text = optDet.DefaultValue.ToString(), Parent = informationBlock, TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill };
          Config.OptionChanged += (s, t) =>
          {
            if (s != optDet.Name) return;
            content.Text =
            (t == typeof(bool) ? Config.GetBooleanOption(optDet.Name)?.ToString()
            : t == typeof(int) ? Config.GetIntegerOption(optDet.Name)?.ToString()
            : t == typeof(string) ? Config.GetStringOption(optDet.Name)
            : null)
            ?? string.Empty;
          };
          optionsToolStripMenuItem.DropDownItems.Add(item);
        }
      }
    }

    private void LoadPlugins()
    {
      var plugins = CreateInstancesFromPlugins<ITestFrame>();
      foreach (var plugin in plugins)
      {
        foreach (var frame in plugin.Frames)
        {
          frame.Value.Parent = new TabPage(frame.Key) { Parent = Tabs, AutoScroll = true };
        }
      }
    }

    private void LoadAdditionalBlocks()
    {
      var blocksets = CreateInstancesFromPlugins<IPluginFrontPageBlocks>();
      foreach (var blockset in blocksets)
      {
        if (blockset.Blocks == null) continue;
        foreach (var block in blockset.Blocks)
        {
          block.Parent = flowLayoutPanel1;
          block.Height = _informationBlockSize;
          block.Width = _informationBlockSize;
        }
      }
    }

    private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Dispose(true);
      Application.Exit();
    }

    private List<T> CreateInstancesFromPlugins<T>()
    {
      var pattern = ConfigurationManager.AppSettings[AppSettingKeys.PluginSearchPattern.ToString()]?.Trim();
      if (string.IsNullOrEmpty(pattern)) pattern = "*.dll";
      var instances = new List<T>();

      foreach (var file in Directory.EnumerateFiles(_pluginLocation, pattern))
      {
        try
        {
          var ass = Assembly.LoadFile(file);
          foreach (var type in ass.GetTypes())
          {
            if (!typeof(T).IsAssignableFrom(type))
              continue;
            if (type.IsAbstract || type.IsInterface)
              continue;
            try
            {
              instances.Add((T)Activator.CreateInstance(type));
            }
            catch { }
          }
        }
        catch { }
      }
      return instances;
    }

    private void CheckEnvironment(object sender, EventArgs e)
    {
      if (!(sender is ToolStripMenuItem)) return;
      var item = (ToolStripMenuItem)sender;
      foreach (var i in optionsToolStripMenuItem.DropDownItems)
      {
        if (i == sender) continue;
        ((ToolStripMenuItem)i).Checked = false;
      }
    }

    private void SetPluginLocation()
    {
      _pluginLocation = Environment.CurrentDirectory;

      var settingLocation = ConfigurationManager.AppSettings[AppSettingKeys.PluginLocation.ToString()]?.Trim();
      if (string.IsNullOrEmpty(settingLocation) || Directory.Exists(settingLocation))
        return;

      _pluginLocation = settingLocation;
    }

    private void SetBlockDimension()
    {
      var settingSize = ConfigurationManager.AppSettings[AppSettingKeys.InformationBlockSize.ToString()]?.Trim();
      if (!string.IsNullOrEmpty(settingSize))
        int.TryParse(settingSize, out _informationBlockSize);

      if (_informationBlockSize < 90)
        _informationBlockSize = 175;
    }
  }
}
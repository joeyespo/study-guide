using System;
using System.IO;
using System.Windows.Forms;


namespace Uberware
{
  public class SettingsException : ApplicationException
  {}
  
  public class Settings
	{
    
    private string m_SettingsFile = "";
    
    protected Settings ()
		{}
    
    
    public static string AppName
    { get { return System.Reflection.Assembly.GetExecutingAssembly().GetName().Name; } }
    
    public static string HomePath
    { get { return Environment.GetFolderPath(Environment.SpecialFolder.Personal); } }
    
    // !!!!! Current directory if not in a bin folder
    public static string SettingsRoot
    {
      get
      {
        return Path.Combine(HomePath, "Settings");
      }
    }
    
    public static string SettingsPath
    { get { return Path.Combine(SettingsRoot, AppName); } }
    
    
    protected static Settings FromUserSettings (Settings s)
    { return FromFile(s, Path.Combine(SettingsPath, "Config.ini"), true); }
    protected static Settings FromFile (Settings s, string FileName, bool IsUserSettings)
    {
      // Failsafe .. check for default settings
      if (s == null) return null;
      
      // Add 'save' event handler
      if (IsUserSettings) Application.ApplicationExit += new EventHandler(s.SaveSettingsHandler);
      
      // Load settings
      if (!File.Exists(FileName))
      {
        if (IsUserSettings)
        {
          // Notify first use
          if (MessageBox.Show("This is your first time using " + AppName + ".\n"
              + "Default settings will now be saved.\n",
              AppName + " Settings", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
            return null;
          
          // Save default settings
          try
          { s.SaveSettings(new StreamWriter(File.OpenWrite(FileName))); }
          catch (IOException)
          { return null; }
          
          s.m_SettingsFile = FileName;
          return s;
        }
      }
      
      try
      {
        if (s.LoadSettings(File.OpenText(FileName)) == false) return null;
        s.m_SettingsFile = FileName;
        return s;
      }
      catch (IOException)
      { return null; }
    }
    
    private void SaveSettingsHandler (object sender, EventArgs e)
    { Save(); }
    
    
    public bool Save ()
    {
      if (m_SettingsFile == "")
      {
        MessageBox.Show("Settings will not be saved.");
        return false;
      }
      
      return SaveSettings(new StreamWriter(File.OpenWrite(m_SettingsFile)));
    }
    
    
    
    protected virtual bool LoadDefault ()
    { return false; }
    
    protected virtual bool LoadSettings (StreamReader file)
    { return false; }
    
    protected virtual bool SaveSettings (StreamWriter file)
    { return false; }
    
	}
}

using System;
using System.IO;


namespace Uberware.Study
{
  public class MatchingSettings : Settings
  {
    
    public bool PlaySounds = true;
    public string [] Sounds = new string []
    {
      "Sounds\\Begin.wav",              // 'Begin' sound
      "Sounds\\Correct.wav",            // 'Correct' sound
      "Sounds\\Wrong.wav",              // 'Wrong' sound
      "Sounds\\Complete.wav",           // 'Complete' sound
      "Sounds\\Perfect.wav",            // 'Perfect' sound
    };
    
    
    
    public static MatchingSettings FromUserSettings ()
    { return (MatchingSettings)Settings.FromUserSettings(new MatchingSettings()); }
    public static MatchingSettings FromFile (string FileName, bool IsUserSettings)
    { return (MatchingSettings)Settings.FromFile(new MatchingSettings(), FileName, IsUserSettings); }
    
    
    
    protected override bool LoadSettings (StreamReader file)
    {
      file.ReadLine();
      return true;
    }
    
    protected override bool SaveSettings (StreamWriter file)
    {
      file.WriteLine();
      return true;
    }
    
  }
}

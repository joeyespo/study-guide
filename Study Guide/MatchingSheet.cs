using System;
using System.Collections;
using System.IO;


namespace Uberware.Study
{
	public class MatchingSheet
	{
		
    // Major = major file format changes; minor = still loadable format if > current
    public static readonly Version SheetVersion = new Version(1, 0);
    
    public string Title;
    public string Author;
    public string Description;
    public string Group;
    public string [] Terms;
    public string [] Definitions;
    public string Filename;
    
    public MatchingSheet () : this("", "", "", "", new string [0], new string [0], "")
    {}
    public MatchingSheet (string Title, string [] Terms, string [] Definitions) : this(Title, "", "", "", Terms, Definitions, "")
    {}
    public MatchingSheet (string Title, string Author, string [] Terms, string [] Definitions) : this(Title, Author, "", "", Terms, Definitions, "")
    {}
    public MatchingSheet (string Title, string Author, string Description, string [] Terms, string [] Definitions) : this(Title, Author, Description, "", Terms, Definitions, "")
    {}
    public MatchingSheet (string Title, string Author, string Description, string Group, string [] Terms, string [] Definitions) : this(Title, Author, Description, Group, Terms, Definitions, "")
    {}
    private MatchingSheet (string Title, string Author, string Description, string Group, string [] Terms, string [] Definitions, string Filename)
		{
      this.Title = Title;
      this.Author = Author;
      this.Description = Description;
      this.Group = Group;
      
      this.Terms = Terms;
      this.Definitions = Definitions;
      
      this.Filename = Filename;
    }
    
    
    public int TermCount
    { get { return Terms.Length; } }
    
    
    public bool Save ()
    {
      FileStream fs = File.OpenWrite(Filename);
      if (fs == null) return false;
      StreamWriter file = new StreamWriter(fs);
      
      // File information
      if (Title       != "") file.WriteLine("@Title       = " + Title);
      if (Author      != "") file.WriteLine("@Author      = " + Author);
      if (Description != "") file.WriteLine("@Description = " + Description);
      if (Group       != "") file.WriteLine("@Group       = " + Group);
      if ((Title != "") || (Author != "") || (Description != "") || (Group != "")) file.WriteLine();
      file.WriteLine();
      
      // Study sheet data
      file.WriteLine("# Terms and Definitions");
      for (int i = 0; i < TermCount; i++)
      {
        file.Write(Terms[i]);
        file.Write(" = ");
        file.WriteLine(EscapeString(Definitions[i]));
      }
      
      // Done
      file.Flush(); file.Close();
      
      return true;
    }
    
    public static MatchingSheet FromFile (string Filename)
    {
      string title = "", author = "", desc = "", group = "";
      ArrayList terms = new ArrayList();
      ArrayList defs = new ArrayList();
      
      string line;
      string name, val;
      int n;
      
      StreamReader file;
      
      try
      { file = File.OpenText(Filename); }
      catch (FileNotFoundException)
      { return null; }
      
      while (file.Peek() != -1)
      {
        line = file.ReadLine().Trim();
        if (line.Length == 0) continue;
        
        if ((n = line.IndexOf('=')) == -1) continue;
        name = line.Substring(0, n).Trim(); val = line.Substring(n+1).Trim();
        if ((name.Length == 0) || (val.Length == 0)) continue;
        
        // Check for comment line
        if (line[0] == '#') continue;
        
        if (line[0] == '@')
        {
          name = name.Substring(1);
          
          switch (name.ToUpper())
          {
            case "TITLE": title = val; break;
            case "AUTHOR": author = val; break;
            case "DESCRIPTION": desc = DescapeString(val); break;
            case "GROUP": group = val; break;
            default: continue;
          }
        }
        else
        {
          terms.Add(name);
          defs.Add(DescapeString(val));
        }
      }
      
      // Done
      file.Close();
      
      return new MatchingSheet(title, author, desc, group, (string [])terms.ToArray(typeof(string)), (string [])defs.ToArray(typeof(string)), Filename);
    }
    
    public static string EscapeString (string s)
    {
      string res = s.Replace("\n", "\\n").Replace(",", "\\,").Replace("\\", "\\\\");
      if (res.EndsWith("\n")) res = res.Remove((res.Length - 1), 1);
      return res;
    }
    public static string DescapeString (string s)
    {
      string res = s.Replace("\\\\", "\\").Replace("\\,", ",").Replace("\\n", "\n");
      if (!res.EndsWith("\n")) res += '\n';
      return res;
    }
    
  }
}

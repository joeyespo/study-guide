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
    public string FileName;
    
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
    private MatchingSheet (string Title, string Author, string Description, string Group, string [] Terms, string [] Definitions, string FileName)
    {
      this.Title = Title;
      this.Author = Author;
      this.Description = Description;
      this.Group = Group;
      
      this.Terms = Terms;
      this.Definitions = Definitions;
      
      this.FileName = FileName;
    }
    
    
    public int TermCount
    { get { return Terms.Length; } }
    
    
    public override string ToString ()
    {
      StringWriter str = new StringWriter();
      
      bool b = Save(str);
      str.Close();
      
      if (!b) return "";
      return str.GetStringBuilder().ToString();
    }
    
    public bool Save ()
    {
      bool b;
      
      FileStream fs = File.OpenWrite(FileName);
      if (fs == null) return false;
      
      b = Save(fs);
      fs.Close();
      
      return b;
    }
    
    public bool Save (Stream s)
    { return Save(new StreamWriter(s)); }
    public bool Save (TextWriter file)
    {
      // File information
      if (Title       != "") file.WriteLine("@Title: " + Title);
      if (Author      != "") file.WriteLine("@Author: " + Author);
      if (Description != "") file.WriteLine("@Description: " + EscapeString(Description));
      if (Group       != "") file.WriteLine("@Group: " + Group);
      
      if ((TermCount > 0) && ((Title != "") || (Author != "") || (Description != "") || (Group != "")))
      { file.WriteLine(); file.WriteLine(); }
      
      // Study sheet data
      if (TermCount > 0) file.WriteLine("# Terms and Definitions");
      for (int i = 0; i < TermCount; i++)
      {
        file.Write(Terms[i]);
        file.Write(": ");
        file.WriteLine(EscapeString(Definitions[i]));
      }
      file.Flush();
      
      return true;
    }
    
    
    public static MatchingSheet FromString (string text, string FileName)
    { return FromFile(new System.IO.StringReader(text), FileName); }
    public static MatchingSheet FromString (string text)
    { return FromString(text, ""); }
    
    public static MatchingSheet FromFile (string FileName)
    {
      StreamReader file;
      
      try
      { file = File.OpenText(FileName); }
      catch (FileNotFoundException)
      { return null; }
      
      MatchingSheet sheet = FromFile(file);
      file.Close();
      
      return sheet;
    }
    public static MatchingSheet FromFile (TextReader file)
    { return FromFile(file, ""); }
    public static MatchingSheet FromFile (TextReader file, string FileName)
    {
      string title = "", author = "", desc = "", group = "";
      ArrayList terms = new ArrayList();
      ArrayList defs = new ArrayList();
      
      string line;
      string name, val;
      
      while (file.Peek() != -1)
      {
        int n, n2;
        
        line = file.ReadLine().Trim();
        if (line.Length == 0) continue;
        
        n  = line.IndexOf('=');
        n2 = line.IndexOf(':');
        
        if (((n2 < n) && (n2 != -1)) || (n == -1)) n = n2;
        if (n == -1) continue;
        
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
      
      return new MatchingSheet(title, author, desc, group, (string [])terms.ToArray(typeof(string)), (string [])defs.ToArray(typeof(string)), FileName);
    }
    
    public static string Normalize (string text)
    {
      StringReader reader = new StringReader(text);
      MatchingSheet sheet = FromFile(reader);
      reader.Close();
      
      StringWriter writer = new StringWriter();
      writer.NewLine = GetNewLine(text, writer.NewLine);
      
      bool b = sheet.Save(writer);
      writer.Close();
      
      if (!b) return "";
      return writer.GetStringBuilder().ToString();
    }
    
    
    
    private static string GetNewLine (string s)
    { return GetNewLine(s, ""); }
    private static string GetNewLine (string s, string Default)
    {
      int n1, n2;
      
      n1 = s.IndexOf("\r\n");
      n2 = s.IndexOf("\n\r");
      
      if ((n1 != -1) || (n2 != -1))
      {
        if (((n1 < n2) && (n1 != -1)) || (n2 == -1))
          return "\r\n";
        else
          return "\n\r";
      }
      else
      {
        if (s.IndexOf("\n") != -1) return "\n";
        if (s.IndexOf("\r") != -1) return "\r";
      }
      
      return Default;
    }
    
    private static string EscapeString (string s)
    {
      string res = s;
      if (res.EndsWith("\n")) res = res.Remove((res.Length - 1), 1);
      return res.Replace("\\", "\\\\").Replace(",", "\\,").Replace("\n", "\\n");
    }
    private static string DescapeString (string s)
    {
      string res = s.Replace("\\n", "\n").Replace("\\,", ",").Replace("\\\\", "\\");
      return (res + "\n");
    }
  }
}

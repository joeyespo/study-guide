using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace Uberware.Study
{
  public class frmMain : System.Windows.Forms.Form
  {
    
    #region API Imports
    
    [DllImport("winmm.dll", EntryPoint="PlaySound", SetLastError=true, CallingConvention=CallingConvention.Winapi)]
    static extern bool sndPlaySound( string pszSound, IntPtr hMod, SoundFlags sf );

    [Flags]
    public enum SoundFlags : int
    {
      SND_SYNC = 0x0000,  /* play synchronously (default) */
      SND_ASYNC = 0x0001,  /* play asynchronously */
      SND_NODEFAULT = 0x0002,  /* silence (!default) if sound not found */
      SND_MEMORY = 0x0004,  /* pszSound points to a memory file */
      SND_LOOP = 0x0008,  /* loop the sound until next sndPlaySound */
      SND_NOSTOP = 0x0010,  /* don't stop any currently playing sound */
      SND_NOWAIT = 0x00002000, /* don't wait if the driver is busy */
      SND_ALIAS = 0x00010000, /* name is a registry alias */
      SND_ALIAS_ID = 0x00110000, /* alias is a predefined ID */
      SND_FileName = 0x00020000, /* name is file name */
      SND_RESOURCE = 0x00040004  /* name is resource name or atom */
    }
    
    #endregion
    
    
    #region Class Variables
    
    private static MatchingSettings m_Settings = null;   // !!!!!
    
    private MatchingSheet m_Sheet = null;
    
    private bool m_MultiTerm = false;
    private string [] m_MultiTermList = null;
    private string [] m_MultiTermListAquired = null;
    private ArrayList m_MultiTermListRemains = new ArrayList();
    private int m_MultiTermNum = 0;
    
    private Font m_BoldFont = null;
    private Font m_RegularFont = null;
    
    private bool m_AutoBeginStudy = false;
    private bool m_Studying = false;
    private bool m_Improving = false;
    
    private int [] m_TermList = null;
    private int m_TermNum = 0;
    private int m_TermIndex = 0;
    
    private int m_Correct = 0;
    
    private ArrayList m_ImproveList = null;
    
    
    #region Controls
    
    private System.Windows.Forms.TextBox txtTitle;
    private System.Windows.Forms.GroupBox grpLine01;
    private System.Windows.Forms.GroupBox grpLine02;
    private System.Windows.Forms.Label lblDefinition;
    private System.Windows.Forms.TextBox txtRemaining;
    private System.Windows.Forms.Label lblRemaining;
    private System.Windows.Forms.GroupBox grpLine03;
    private System.Windows.Forms.TextBox txtTotal;
    private System.Windows.Forms.Button btnMenu;
    private System.Windows.Forms.GroupBox grpLine04;
    private System.Windows.Forms.Panel panTerms;
    private System.Windows.Forms.Panel panImprove;
    private System.Windows.Forms.Label lblTotal;
    private System.Windows.Forms.Label lblTermList;
    private System.Windows.Forms.Splitter splTerms;
    private System.Windows.Forms.Panel panTermList;
    private System.Windows.Forms.Label lblImprove;
    private System.Windows.Forms.Label lblCorrect;
    private System.Windows.Forms.Label lblWrong;
    private System.Windows.Forms.TextBox txtCorrect;
    private System.Windows.Forms.TextBox txtWrong;
    private System.Windows.Forms.ListBox lstTermList;
    private System.Windows.Forms.ListBox lstImprove;
    private System.Windows.Forms.ContextMenu menuMain;
    private System.Windows.Forms.MenuItem menuMainOpen;
    private System.Windows.Forms.MenuItem menuMainClose;
    private System.Windows.Forms.MenuItem menuMainLine01;
    private System.Windows.Forms.OpenFileDialog openFileDialog;
    private System.Windows.Forms.Button btnExit;
    private System.Windows.Forms.Button btnStudy;
    private System.Windows.Forms.Button btnSelect;
    private System.Windows.Forms.Timer tmrResetColors;
    private System.Windows.Forms.MenuItem menuMainEdit;
    private System.Windows.Forms.MenuItem menuMainNew;
    private System.Windows.Forms.RichTextBox txtDefinition;
    private System.Windows.Forms.Panel panDefinition;
    private System.Windows.Forms.MenuItem menuMainLine02;
    private System.Windows.Forms.Button btnEditor;
    private System.Windows.Forms.MenuItem menuMainExit;
    private System.Windows.Forms.MenuItem menuMainLine03;
    private System.Windows.Forms.MenuItem menuMainAbout;
    private System.Windows.Forms.MenuItem menuMainPreferences;
    private System.Windows.Forms.Label lblMessage;
    private System.Windows.Forms.TextBox txtMultiTerms;
    private System.Windows.Forms.TextBox txtMultiTermCount;
    private System.Windows.Forms.Label lblMultiTermCount;
    private System.Windows.Forms.TextBox txtMultiTermPos;
    private System.Windows.Forms.Panel panMultiTerm;
    private System.Windows.Forms.Label lblMultiTerms;
    private System.Windows.Forms.Timer tmrResetMessage;
    private System.Windows.Forms.MenuItem menuMainSoundEffects;
    private System.Windows.Forms.Timer tmrResetMultiTerm;
    
    private System.ComponentModel.IContainer components;
    
    #endregion
    
    #endregion
    
    #region Class Construction
    
    public frmMain()
    {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();
    }
    
    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose( bool disposing )
    {
      if( disposing )
      {
        if (components != null) 
        {
          components.Dispose();
        }
      }
      base.Dispose( disposing );
    }
    
		#region Windows Form Designer generated code
    
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
      this.txtTitle = new System.Windows.Forms.TextBox();
      this.grpLine01 = new System.Windows.Forms.GroupBox();
      this.lblDefinition = new System.Windows.Forms.Label();
      this.grpLine02 = new System.Windows.Forms.GroupBox();
      this.txtRemaining = new System.Windows.Forms.TextBox();
      this.lblRemaining = new System.Windows.Forms.Label();
      this.grpLine03 = new System.Windows.Forms.GroupBox();
      this.lblTotal = new System.Windows.Forms.Label();
      this.txtTotal = new System.Windows.Forms.TextBox();
      this.btnStudy = new System.Windows.Forms.Button();
      this.btnMenu = new System.Windows.Forms.Button();
      this.grpLine04 = new System.Windows.Forms.GroupBox();
      this.lblTermList = new System.Windows.Forms.Label();
      this.panTerms = new System.Windows.Forms.Panel();
      this.panTermList = new System.Windows.Forms.Panel();
      this.btnSelect = new System.Windows.Forms.Button();
      this.lstTermList = new System.Windows.Forms.ListBox();
      this.splTerms = new System.Windows.Forms.Splitter();
      this.panImprove = new System.Windows.Forms.Panel();
      this.lblImprove = new System.Windows.Forms.Label();
      this.lstImprove = new System.Windows.Forms.ListBox();
      this.lblCorrect = new System.Windows.Forms.Label();
      this.lblWrong = new System.Windows.Forms.Label();
      this.txtCorrect = new System.Windows.Forms.TextBox();
      this.txtWrong = new System.Windows.Forms.TextBox();
      this.menuMain = new System.Windows.Forms.ContextMenu();
      this.menuMainNew = new System.Windows.Forms.MenuItem();
      this.menuMainOpen = new System.Windows.Forms.MenuItem();
      this.menuMainClose = new System.Windows.Forms.MenuItem();
      this.menuMainLine01 = new System.Windows.Forms.MenuItem();
      this.menuMainEdit = new System.Windows.Forms.MenuItem();
      this.menuMainLine02 = new System.Windows.Forms.MenuItem();
      this.menuMainSoundEffects = new System.Windows.Forms.MenuItem();
      this.menuMainPreferences = new System.Windows.Forms.MenuItem();
      this.menuMainAbout = new System.Windows.Forms.MenuItem();
      this.menuMainLine03 = new System.Windows.Forms.MenuItem();
      this.menuMainExit = new System.Windows.Forms.MenuItem();
      this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.btnExit = new System.Windows.Forms.Button();
      this.tmrResetColors = new System.Windows.Forms.Timer(this.components);
      this.txtDefinition = new System.Windows.Forms.RichTextBox();
      this.panDefinition = new System.Windows.Forms.Panel();
      this.lblMessage = new System.Windows.Forms.Label();
      this.btnEditor = new System.Windows.Forms.Button();
      this.txtMultiTerms = new System.Windows.Forms.TextBox();
      this.txtMultiTermCount = new System.Windows.Forms.TextBox();
      this.lblMultiTermCount = new System.Windows.Forms.Label();
      this.txtMultiTermPos = new System.Windows.Forms.TextBox();
      this.lblMultiTerms = new System.Windows.Forms.Label();
      this.panMultiTerm = new System.Windows.Forms.Panel();
      this.tmrResetMessage = new System.Windows.Forms.Timer(this.components);
      this.tmrResetMultiTerm = new System.Windows.Forms.Timer(this.components);
      this.panTerms.SuspendLayout();
      this.panTermList.SuspendLayout();
      this.panImprove.SuspendLayout();
      this.panDefinition.SuspendLayout();
      this.panMultiTerm.SuspendLayout();
      this.SuspendLayout();
      // 
      // txtTitle
      // 
      this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.txtTitle.BackColor = System.Drawing.SystemColors.Control;
      this.txtTitle.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.txtTitle.ForeColor = System.Drawing.SystemColors.GrayText;
      this.txtTitle.Location = new System.Drawing.Point(8, 8);
      this.txtTitle.Name = "txtTitle";
      this.txtTitle.ReadOnly = true;
      this.txtTitle.Size = new System.Drawing.Size(356, 26);
      this.txtTitle.TabIndex = 0;
      this.txtTitle.Text = "( nothing loaded )";
      this.txtTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // grpLine01
      // 
      this.grpLine01.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.grpLine01.Location = new System.Drawing.Point(0, 36);
      this.grpLine01.Name = "grpLine01";
      this.grpLine01.Size = new System.Drawing.Size(376, 3);
      this.grpLine01.TabIndex = 1;
      this.grpLine01.TabStop = false;
      // 
      // lblDefinition
      // 
      this.lblDefinition.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.lblDefinition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblDefinition.Location = new System.Drawing.Point(8, 48);
      this.lblDefinition.Name = "lblDefinition";
      this.lblDefinition.Size = new System.Drawing.Size(356, 16);
      this.lblDefinition.TabIndex = 2;
      this.lblDefinition.Text = "Definition:";
      // 
      // grpLine02
      // 
      this.grpLine02.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.grpLine02.Location = new System.Drawing.Point(0, 168);
      this.grpLine02.Name = "grpLine02";
      this.grpLine02.Size = new System.Drawing.Size(376, 3);
      this.grpLine02.TabIndex = 5;
      this.grpLine02.TabStop = false;
      // 
      // txtRemaining
      // 
      this.txtRemaining.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
      this.txtRemaining.BackColor = System.Drawing.SystemColors.Control;
      this.txtRemaining.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtRemaining.Location = new System.Drawing.Point(332, 180);
      this.txtRemaining.Name = "txtRemaining";
      this.txtRemaining.ReadOnly = true;
      this.txtRemaining.Size = new System.Drawing.Size(32, 20);
      this.txtRemaining.TabIndex = 11;
      this.txtRemaining.Text = "";
      this.txtRemaining.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // lblRemaining
      // 
      this.lblRemaining.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
      this.lblRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblRemaining.Location = new System.Drawing.Point(204, 184);
      this.lblRemaining.Name = "lblRemaining";
      this.lblRemaining.Size = new System.Drawing.Size(124, 16);
      this.lblRemaining.TabIndex = 10;
      this.lblRemaining.Text = "Remaining:";
      // 
      // grpLine03
      // 
      this.grpLine03.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.grpLine03.Location = new System.Drawing.Point(0, 232);
      this.grpLine03.Name = "grpLine03";
      this.grpLine03.Size = new System.Drawing.Size(376, 3);
      this.grpLine03.TabIndex = 14;
      this.grpLine03.TabStop = false;
      // 
      // lblTotal
      // 
      this.lblTotal.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
      this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblTotal.Location = new System.Drawing.Point(204, 208);
      this.lblTotal.Name = "lblTotal";
      this.lblTotal.Size = new System.Drawing.Size(124, 16);
      this.lblTotal.TabIndex = 12;
      this.lblTotal.Text = "Total:";
      // 
      // txtTotal
      // 
      this.txtTotal.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
      this.txtTotal.BackColor = System.Drawing.SystemColors.Control;
      this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtTotal.Location = new System.Drawing.Point(332, 204);
      this.txtTotal.Name = "txtTotal";
      this.txtTotal.ReadOnly = true;
      this.txtTotal.Size = new System.Drawing.Size(32, 20);
      this.txtTotal.TabIndex = 13;
      this.txtTotal.Text = "";
      this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // btnStudy
      // 
      this.btnStudy.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
      this.btnStudy.Location = new System.Drawing.Point(104, 456);
      this.btnStudy.Name = "btnStudy";
      this.btnStudy.Size = new System.Drawing.Size(88, 36);
      this.btnStudy.TabIndex = 18;
      this.btnStudy.Text = "&Begin";
      this.btnStudy.Click += new System.EventHandler(this.btnStudy_Click);
      // 
      // btnMenu
      // 
      this.btnMenu.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
      this.btnMenu.Location = new System.Drawing.Point(8, 456);
      this.btnMenu.Name = "btnMenu";
      this.btnMenu.Size = new System.Drawing.Size(88, 36);
      this.btnMenu.TabIndex = 17;
      this.btnMenu.Text = "&Menu";
      this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
      this.btnMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMenu_MouseDown);
      // 
      // grpLine04
      // 
      this.grpLine04.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.grpLine04.Location = new System.Drawing.Point(0, 444);
      this.grpLine04.Name = "grpLine04";
      this.grpLine04.Size = new System.Drawing.Size(376, 3);
      this.grpLine04.TabIndex = 16;
      this.grpLine04.TabStop = false;
      // 
      // lblTermList
      // 
      this.lblTermList.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.lblTermList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblTermList.Name = "lblTermList";
      this.lblTermList.Size = new System.Drawing.Size(188, 16);
      this.lblTermList.TabIndex = 0;
      this.lblTermList.Text = "Term Selection:";
      // 
      // panTerms
      // 
      this.panTerms.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.panTerms.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                           this.panTermList,
                                                                           this.splTerms,
                                                                           this.panImprove});
      this.panTerms.Location = new System.Drawing.Point(8, 244);
      this.panTerms.Name = "panTerms";
      this.panTerms.Size = new System.Drawing.Size(356, 192);
      this.panTerms.TabIndex = 15;
      // 
      // panTermList
      // 
      this.panTermList.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                              this.btnSelect,
                                                                              this.lblTermList,
                                                                              this.lstTermList});
      this.panTermList.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panTermList.Name = "panTermList";
      this.panTermList.Size = new System.Drawing.Size(188, 192);
      this.panTermList.TabIndex = 0;
      // 
      // btnSelect
      // 
      this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.btnSelect.Enabled = false;
      this.btnSelect.Location = new System.Drawing.Point(0, 164);
      this.btnSelect.Name = "btnSelect";
      this.btnSelect.Size = new System.Drawing.Size(188, 28);
      this.btnSelect.TabIndex = 2;
      this.btnSelect.Text = "&Select";
      this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
      // 
      // lstTermList
      // 
      this.lstTermList.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.lstTermList.BackColor = System.Drawing.SystemColors.Control;
      this.lstTermList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lstTermList.IntegralHeight = false;
      this.lstTermList.Location = new System.Drawing.Point(0, 16);
      this.lstTermList.Name = "lstTermList";
      this.lstTermList.Size = new System.Drawing.Size(188, 146);
      this.lstTermList.Sorted = true;
      this.lstTermList.TabIndex = 1;
      this.lstTermList.DoubleClick += new System.EventHandler(this.lstTermList_DoubleClick);
      this.lstTermList.Leave += new System.EventHandler(this.lstTermList_Leave);
      this.lstTermList.Enter += new System.EventHandler(this.lstTermList_Enter);
      // 
      // splTerms
      // 
      this.splTerms.Dock = System.Windows.Forms.DockStyle.Right;
      this.splTerms.Location = new System.Drawing.Point(188, 0);
      this.splTerms.Name = "splTerms";
      this.splTerms.Size = new System.Drawing.Size(8, 192);
      this.splTerms.TabIndex = 1;
      this.splTerms.TabStop = false;
      // 
      // panImprove
      // 
      this.panImprove.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                             this.lblImprove,
                                                                             this.lstImprove});
      this.panImprove.Dock = System.Windows.Forms.DockStyle.Right;
      this.panImprove.Location = new System.Drawing.Point(196, 0);
      this.panImprove.Name = "panImprove";
      this.panImprove.Size = new System.Drawing.Size(160, 192);
      this.panImprove.TabIndex = 2;
      // 
      // lblImprove
      // 
      this.lblImprove.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.lblImprove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblImprove.Name = "lblImprove";
      this.lblImprove.Size = new System.Drawing.Size(160, 16);
      this.lblImprove.TabIndex = 0;
      this.lblImprove.Text = "Terms to work on:";
      // 
      // lstImprove
      // 
      this.lstImprove.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.lstImprove.BackColor = System.Drawing.SystemColors.Control;
      this.lstImprove.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lstImprove.IntegralHeight = false;
      this.lstImprove.Location = new System.Drawing.Point(0, 16);
      this.lstImprove.Name = "lstImprove";
      this.lstImprove.Size = new System.Drawing.Size(160, 176);
      this.lstImprove.TabIndex = 1;
      this.lstImprove.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstImprove_MouseDown);
      this.lstImprove.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lstImprove_MouseMove);
      this.lstImprove.SelectedIndexChanged += new System.EventHandler(this.lstImprove_SelectedIndexChanged);
      // 
      // lblCorrect
      // 
      this.lblCorrect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblCorrect.Location = new System.Drawing.Point(8, 184);
      this.lblCorrect.Name = "lblCorrect";
      this.lblCorrect.Size = new System.Drawing.Size(124, 16);
      this.lblCorrect.TabIndex = 6;
      this.lblCorrect.Text = "Correct:";
      // 
      // lblWrong
      // 
      this.lblWrong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblWrong.Location = new System.Drawing.Point(8, 208);
      this.lblWrong.Name = "lblWrong";
      this.lblWrong.Size = new System.Drawing.Size(124, 16);
      this.lblWrong.TabIndex = 8;
      this.lblWrong.Text = "Wrong:";
      // 
      // txtCorrect
      // 
      this.txtCorrect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtCorrect.Location = new System.Drawing.Point(136, 180);
      this.txtCorrect.Name = "txtCorrect";
      this.txtCorrect.ReadOnly = true;
      this.txtCorrect.Size = new System.Drawing.Size(32, 20);
      this.txtCorrect.TabIndex = 7;
      this.txtCorrect.Text = "";
      this.txtCorrect.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // txtWrong
      // 
      this.txtWrong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtWrong.Location = new System.Drawing.Point(136, 204);
      this.txtWrong.Name = "txtWrong";
      this.txtWrong.ReadOnly = true;
      this.txtWrong.Size = new System.Drawing.Size(32, 20);
      this.txtWrong.TabIndex = 9;
      this.txtWrong.Text = "";
      this.txtWrong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // menuMain
      // 
      this.menuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                             this.menuMainNew,
                                                                             this.menuMainOpen,
                                                                             this.menuMainClose,
                                                                             this.menuMainLine01,
                                                                             this.menuMainEdit,
                                                                             this.menuMainLine02,
                                                                             this.menuMainSoundEffects,
                                                                             this.menuMainPreferences,
                                                                             this.menuMainAbout,
                                                                             this.menuMainLine03,
                                                                             this.menuMainExit});
      // 
      // menuMainNew
      // 
      this.menuMainNew.Index = 0;
      this.menuMainNew.Text = "&New...";
      this.menuMainNew.Click += new System.EventHandler(this.menuMainNew_Click);
      // 
      // menuMainOpen
      // 
      this.menuMainOpen.Index = 1;
      this.menuMainOpen.Text = "&Open...";
      this.menuMainOpen.Click += new System.EventHandler(this.menuMainOpen_Click);
      // 
      // menuMainClose
      // 
      this.menuMainClose.Enabled = false;
      this.menuMainClose.Index = 2;
      this.menuMainClose.Text = "&Close";
      this.menuMainClose.Click += new System.EventHandler(this.menuMainClose_Click);
      // 
      // menuMainLine01
      // 
      this.menuMainLine01.Index = 3;
      this.menuMainLine01.Text = "-";
      // 
      // menuMainEdit
      // 
      this.menuMainEdit.Enabled = false;
      this.menuMainEdit.Index = 4;
      this.menuMainEdit.Text = "&Edit sheet...";
      this.menuMainEdit.Click += new System.EventHandler(this.menuMainEdit_Click);
      // 
      // menuMainLine02
      // 
      this.menuMainLine02.Index = 5;
      this.menuMainLine02.Text = "-";
      // 
      // menuMainSoundEffects
      // 
      this.menuMainSoundEffects.Index = 6;
      this.menuMainSoundEffects.Text = "&Sound Effects";
      this.menuMainSoundEffects.Click += new System.EventHandler(this.menuMainSoundEffects_Click);
      // 
      // menuMainPreferences
      // 
      this.menuMainPreferences.Index = 7;
      this.menuMainPreferences.Text = "&Preferences...";
      this.menuMainPreferences.Visible = false;
      this.menuMainPreferences.Click += new System.EventHandler(this.menuMainPreferences_Click);
      // 
      // menuMainAbout
      // 
      this.menuMainAbout.Index = 8;
      this.menuMainAbout.Text = "Ab&out...";
      this.menuMainAbout.Click += new System.EventHandler(this.menuMainAbout_Click);
      // 
      // menuMainLine03
      // 
      this.menuMainLine03.Index = 9;
      this.menuMainLine03.Text = "-";
      // 
      // menuMainExit
      // 
      this.menuMainExit.Index = 10;
      this.menuMainExit.Text = "E&xit";
      this.menuMainExit.Click += new System.EventHandler(this.menuMainExit_Click);
      // 
      // openFileDialog
      // 
      this.openFileDialog.DefaultExt = "sheet";
      this.openFileDialog.Filter = "Study Sheet Files (*.sheet)|*.sheet|All Files (*.*)|*.*";
      this.openFileDialog.Title = "Open Study Sheet";
      // 
      // btnExit
      // 
      this.btnExit.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
      this.btnExit.Location = new System.Drawing.Point(292, 460);
      this.btnExit.Name = "btnExit";
      this.btnExit.Size = new System.Drawing.Size(72, 32);
      this.btnExit.TabIndex = 20;
      this.btnExit.Text = "E&xit";
      this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
      // 
      // tmrResetColors
      // 
      this.tmrResetColors.Interval = 500;
      this.tmrResetColors.Tick += new System.EventHandler(this.tmrResetColors_Tick);
      // 
      // txtDefinition
      // 
      this.txtDefinition.BackColor = System.Drawing.SystemColors.Control;
      this.txtDefinition.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.txtDefinition.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtDefinition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.txtDefinition.Name = "txtDefinition";
      this.txtDefinition.ReadOnly = true;
      this.txtDefinition.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
      this.txtDefinition.Size = new System.Drawing.Size(354, 70);
      this.txtDefinition.TabIndex = 0;
      this.txtDefinition.Text = "";
      this.txtDefinition.ContentsResized += new System.Windows.Forms.ContentsResizedEventHandler(this.txtDefinition_ContentsResized);
      this.txtDefinition.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.txtDefinition_LinkClicked);
      // 
      // panDefinition
      // 
      this.panDefinition.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.panDefinition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panDefinition.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                this.lblMessage,
                                                                                this.txtDefinition});
      this.panDefinition.Location = new System.Drawing.Point(8, 64);
      this.panDefinition.Name = "panDefinition";
      this.panDefinition.Size = new System.Drawing.Size(356, 72);
      this.panDefinition.TabIndex = 3;
      // 
      // lblMessage
      // 
      this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblMessage.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblMessage.Name = "lblMessage";
      this.lblMessage.Size = new System.Drawing.Size(354, 70);
      this.lblMessage.TabIndex = 1;
      this.lblMessage.Text = ":: Message ::";
      this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.lblMessage.Visible = false;
      // 
      // btnEditor
      // 
      this.btnEditor.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
      this.btnEditor.Location = new System.Drawing.Point(212, 460);
      this.btnEditor.Name = "btnEditor";
      this.btnEditor.Size = new System.Drawing.Size(72, 32);
      this.btnEditor.TabIndex = 19;
      this.btnEditor.Text = "&Editor...";
      this.btnEditor.Click += new System.EventHandler(this.btnEditor_Click);
      // 
      // txtMultiTerms
      // 
      this.txtMultiTerms.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.txtMultiTerms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtMultiTerms.Location = new System.Drawing.Point(60, 0);
      this.txtMultiTerms.Name = "txtMultiTerms";
      this.txtMultiTerms.ReadOnly = true;
      this.txtMultiTerms.Size = new System.Drawing.Size(226, 20);
      this.txtMultiTerms.TabIndex = 1;
      this.txtMultiTerms.Text = "";
      // 
      // txtMultiTermCount
      // 
      this.txtMultiTermCount.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
      this.txtMultiTermCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtMultiTermCount.Location = new System.Drawing.Point(332, 0);
      this.txtMultiTermCount.Name = "txtMultiTermCount";
      this.txtMultiTermCount.ReadOnly = true;
      this.txtMultiTermCount.Size = new System.Drawing.Size(24, 20);
      this.txtMultiTermCount.TabIndex = 4;
      this.txtMultiTermCount.Text = "";
      this.txtMultiTermCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // lblMultiTermCount
      // 
      this.lblMultiTermCount.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
      this.lblMultiTermCount.Location = new System.Drawing.Point(318, 4);
      this.lblMultiTermCount.Name = "lblMultiTermCount";
      this.lblMultiTermCount.Size = new System.Drawing.Size(14, 12);
      this.lblMultiTermCount.TabIndex = 3;
      this.lblMultiTermCount.Text = "of";
      // 
      // txtMultiTermPos
      // 
      this.txtMultiTermPos.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
      this.txtMultiTermPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtMultiTermPos.Location = new System.Drawing.Point(294, 0);
      this.txtMultiTermPos.Name = "txtMultiTermPos";
      this.txtMultiTermPos.ReadOnly = true;
      this.txtMultiTermPos.Size = new System.Drawing.Size(24, 20);
      this.txtMultiTermPos.TabIndex = 2;
      this.txtMultiTermPos.Text = "";
      this.txtMultiTermPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // lblMultiTerms
      // 
      this.lblMultiTerms.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblMultiTerms.Location = new System.Drawing.Point(0, 4);
      this.lblMultiTerms.Name = "lblMultiTerms";
      this.lblMultiTerms.Size = new System.Drawing.Size(56, 16);
      this.lblMultiTerms.TabIndex = 0;
      this.lblMultiTerms.Text = "Multiple:";
      // 
      // panMultiTerm
      // 
      this.panMultiTerm.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.panMultiTerm.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                               this.txtMultiTermPos,
                                                                               this.lblMultiTermCount,
                                                                               this.lblMultiTerms,
                                                                               this.txtMultiTermCount,
                                                                               this.txtMultiTerms});
      this.panMultiTerm.Location = new System.Drawing.Point(8, 140);
      this.panMultiTerm.Name = "panMultiTerm";
      this.panMultiTerm.Size = new System.Drawing.Size(356, 20);
      this.panMultiTerm.TabIndex = 4;
      this.panMultiTerm.VisibleChanged += new System.EventHandler(this.panMultiTerm_VisibleChanged);
      // 
      // tmrResetMessage
      // 
      this.tmrResetMessage.Interval = 3000;
      this.tmrResetMessage.Tick += new System.EventHandler(this.tmrResetMessage_Tick);
      // 
      // tmrResetMultiTerm
      // 
      this.tmrResetMultiTerm.Interval = 500;
      this.tmrResetMultiTerm.Tick += new System.EventHandler(this.tmrResetMultiTerm_Tick);
      // 
      // frmMain
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(372, 497);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.panMultiTerm,
                                                                  this.btnEditor,
                                                                  this.panDefinition,
                                                                  this.panTerms,
                                                                  this.btnMenu,
                                                                  this.btnStudy,
                                                                  this.txtRemaining,
                                                                  this.lblRemaining,
                                                                  this.lblDefinition,
                                                                  this.grpLine01,
                                                                  this.txtTitle,
                                                                  this.grpLine02,
                                                                  this.grpLine03,
                                                                  this.lblTotal,
                                                                  this.txtTotal,
                                                                  this.grpLine04,
                                                                  this.lblCorrect,
                                                                  this.lblWrong,
                                                                  this.txtCorrect,
                                                                  this.txtWrong,
                                                                  this.btnExit});
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MinimumSize = new System.Drawing.Size(368, 468);
      this.Name = "frmMain";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Study Guide";
      this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMain_Closing);
      this.Load += new System.EventHandler(this.frmMain_Load);
      this.Activated += new System.EventHandler(this.frmMain_Activated);
      this.panTerms.ResumeLayout(false);
      this.panTermList.ResumeLayout(false);
      this.panImprove.ResumeLayout(false);
      this.panDefinition.ResumeLayout(false);
      this.panMultiTerm.ResumeLayout(false);
      this.ResumeLayout(false);

    }
		
    #endregion
    
    #endregion
    
    
    #region Entry Point of Application
    
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main (string [] args)
    {
      frmMain form = new frmMain();
      
      // !!!!! Load settings
      //m_Settings = (MatchingSettings)MatchingSettings.FromUserSettings();
      m_Settings = new MatchingSettings();  // Get default preferences
      
      // Parse command line
      foreach (string arg in args)
      {
        if (arg.Length == 0) continue;
        
        if (arg[0] == '-')
        {
          // Get options
          switch (arg)
          {
            case "-b": form.m_AutoBeginStudy = true; break;
          }
        }
        else
        {
          // Load sheet
          form.DoOpen(arg);
          break;
        }
      }
      
      // Run app
      Application.Run(form);
    }
    
    #endregion
    
    
    
    private void frmMain_Load(object sender, System.EventArgs e)
    {
      m_BoldFont = txtDefinition.Font;
      m_RegularFont = new Font(txtDefinition.Font, FontStyle.Regular);
      panMultiTerm.Visible = false;
    }
    
    private void frmMain_Activated(object sender, System.EventArgs e)
    {
      if (m_Studying)
      {
        if (m_Improving)
          lstImprove.Focus();
        else
          lstTermList.Focus();
      }
      else
      {
        if (m_Sheet != null)
          btnStudy.Focus();
        else
          btnMenu.Focus();
        
        if (m_AutoBeginStudy)
        {
          m_AutoBeginStudy = false;
          DoStudy();
        }
      }
    }
    
    private void frmMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    { if (!DoClose()) e.Cancel = true; }
    
    
    
    private void menuMainNew_Click(object sender, System.EventArgs e)
    { DoNew(); }
    private void menuMainOpen_Click(object sender, System.EventArgs e)
    { DoOpen(); }
    private void menuMainEdit_Click(object sender, System.EventArgs e)
    { DoEdit(); }
    private void menuMainClose_Click(object sender, System.EventArgs e)
    { DoClose(); }
    // !!!!!
    private void menuMainSoundEffects_Click(object sender, System.EventArgs e)
    { menuMainSoundEffects.Checked = !menuMainSoundEffects.Checked; }
    private void menuMainPreferences_Click(object sender, System.EventArgs e)
    { DoPreferences(); }
    private void menuMainAbout_Click(object sender, System.EventArgs e)
    { DoAbout(); }
    private void menuMainExit_Click(object sender, System.EventArgs e)
    { this.Close(); }
    
    
    private void btnMenu_Click(object sender, System.EventArgs e)
    { menuMain.Show(btnMenu.Parent, new Point(btnMenu.Left, btnMenu.Bottom)); }
    private void btnMenu_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    { menuMain.Show(btnMenu.Parent, new Point(btnMenu.Left, btnMenu.Bottom)); }
    
    private void btnStudy_Click(object sender, System.EventArgs e)
    { DoStudy(); }
    private void btnEditor_Click(object sender, System.EventArgs e)
    { DoShowEditor(); }
    private void btnExit_Click(object sender, System.EventArgs e)
    { this.Close(); }
    
    
    private void btnSelect_Click(object sender, System.EventArgs e)
    { DoSelectTerm(); }
    private void lstTermList_DoubleClick(object sender, System.EventArgs e)
    { DoSelectTerm(); }
    
    private void tmrResetColors_Tick(object sender, System.EventArgs e)
    { DoResetColors(); }
    private void tmrResetMultiTerm_Tick(object sender, System.EventArgs e)
    { DoResetMultiple(); }
    private void tmrResetMessage_Tick(object sender, System.EventArgs e)
    { DoResetMessage(); }
    
    private void lstImprove_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    { if (e.Button == MouseButtons.Left) lstImprove_SelectedIndexChanged(sender, new EventArgs()); }
    private void lstImprove_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
    { if (e.Button == MouseButtons.Left) lstImprove_SelectedIndexChanged(sender, new EventArgs()); }
    private void lstImprove_SelectedIndexChanged(object sender, System.EventArgs e)
    { DoShowImproveItem(); }
    
    private void lstTermList_Enter(object sender, System.EventArgs e)
    { if (btnSelect.Enabled) this.AcceptButton = btnSelect; }
    private void lstTermList_Leave(object sender, System.EventArgs e)
    { this.AcceptButton = null; }
    
    bool b = false;
    private void txtDefinition_ContentsResized(object sender, System.Windows.Forms.ContentsResizedEventArgs e)
    {
      if (!this.Visible) return;
      if (this.WindowState == FormWindowState.Minimized) return;
      if (b) return;
      
      if ((e.NewRectangle.Height > txtDefinition.ClientSize.Height) && (txtDefinition.Font.Bold))
      {
        b = true;
        txtDefinition.Font = m_RegularFont;
        string s = txtDefinition.Rtf;
        txtDefinition.Clear();
        txtDefinition.Rtf = s;
        b = false;
      }
    }
    
    private void panMultiTerm_VisibleChanged(object sender, System.EventArgs e)
    { panDefinition.Height = (( panMultiTerm.Visible )?( (panMultiTerm.Top - 4) ):( panMultiTerm.Top + panMultiTerm.Height )) - panDefinition.Top; }
    
    private void txtDefinition_LinkClicked(object sender, System.Windows.Forms.LinkClickedEventArgs e)
    {
      try // Call the Process.Start method to open the default browser with a URL:
      { System.Diagnostics.Process.Start(e.LinkText); }
      catch (Win32Exception)
      {}
      catch   // Failsafe
      { MessageBox.Show(this, "Could not start browser process.", "Study Guide", MessageBoxButtons.OK, MessageBoxIcon.Error); }
    }
    
    
    
    private bool DoNew ()
    {
      return DoShowEditor("-n");
    }
    
    private bool DoOpen ()
    {
      if (openFileDialog.ShowDialog(this) == DialogResult.Cancel) return false;
      return DoOpen(openFileDialog.FileName);
    }
    private bool DoOpen (string FileName)
    {
      try
      { return DoOpen(MatchingSheet.FromFile(FileName)); }
      catch (IOException e)
      { MessageBox.Show(this, e.Message, "File Load Error"); }
      return false;
    }
    private bool DoOpen (MatchingSheet sheet)
    { return DoOpen(sheet, false); }
    private bool DoOpen (MatchingSheet sheet, bool testSheet)
    {
      if (!DoClose()) return false;
      if (sheet == null) return false;
      
      m_Sheet = sheet;
      
      txtTitle.Text = m_Sheet.Title;
      txtTitle.ForeColor = Color.FromKnownColor(KnownColor.InfoText);
      txtTitle.BackColor = Color.FromKnownColor(KnownColor.Info);
      
      menuMainClose.Enabled = (!testSheet);
      menuMainEdit.Enabled = (!testSheet);
      
      return true;
    }
    
    private bool DoEdit ()
    {
      if (m_Sheet == null) return false;
      return DoShowEditor(m_Sheet.FileName);
    }
    
    private bool DoClose ()
    {
      if (m_Sheet == null) return true;
      
      if (m_Studying)
        if (!DoStudy(true)) return false;
      
      m_Sheet = null;
      txtTitle.Text = "( nothing loaded )";
      txtTitle.ForeColor = Color.FromKnownColor(KnownColor.GrayText);
      txtTitle.BackColor = Color.FromKnownColor(KnownColor.Control);
      
      menuMainClose.Enabled = false;
      menuMainEdit.Enabled = false;
      
      txtRemaining.Text = ""; txtTotal.Text = "";
      txtCorrect.Text = ""; txtWrong.Text = "";
      DoResetColors();
      
      return true;
    }
    
    private bool DoPreferences ()
    {
      // !!!!!
      //MatchingSettings settings = (new frmSettings()).ShowDialog(this, m_Settings);
      //if (settings != null) m_Settings = settings;
      
      MessageBox.Show(":: Preferences ::");
      return true;
    }
    
    private bool DoAbout ()
    {
      frmAbout form = new frmAbout();
      form.ShowDialog(this);
      return true;
    }
    
    
    private bool DoShowEditor ()
    { return DoShowEditor(""); }
    private bool DoShowEditor (string arg)
    { return DoShowEditor( new string [] { arg }); }
    private bool DoShowEditor (string [] args)
    {
      string cmdline = "";
      
      // Build command line
      foreach (string arg in args)
      {
        if (cmdline != "") cmdline += " ";
        cmdline += (( arg.IndexOf(' ') == -1 )?( arg ):( '"' + arg + '"' ));
      }
      
      try
      { System.Diagnostics.Process.Start(Path.Combine(Application.StartupPath, "Study Guide Editor"), cmdline); }
      catch (Win32Exception e)
      {
        // Failsafe
        MessageBox.Show(this, "Could not run editor:\n\n" + e.Message, "Study Guide", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
      }
      
      return true;
    }
    
    
    
    private void DoShowDefinition (string definition)
    {
      // !!!!! Mini-HTML
      //if (definition.Substring(0, 1) == ((char)27).ToString())
      //{
      //  if (!MatchingSheet.TextEquals(txtDefinition.Rtf, definition.Substring(1)))
      //  {
      //    txtDefinition.Clear();
      //    txtDefinition.Font = m_BoldFont;
      //    txtDefinition.Rtf = definition.Substring(1);
      //  }
      //}
      //else
      //{
      //  if (txtDefinition.Text != definition)
      //  {
      //    txtDefinition.Clear();
      //    txtDefinition.Font = m_BoldFont;
      //    txtDefinition.Text = definition;
      //  }
      //}
      
      if (txtDefinition.Text != definition)
      {
        txtDefinition.Clear();
        txtDefinition.Font = m_BoldFont;
        txtDefinition.Text = definition;
      }
    }
    
    
    private bool DoNextTerm ()
    { return DoNextTerm (false); }
    private bool DoNextTerm (bool noRefresh)
    {
      // Update 'remaining' count
      txtRemaining.Text = (m_Sheet.TermCount - m_TermNum).ToString();
      
      // Check for end of study
      m_TermNum++;
      if (m_TermNum > m_TermList.Length)
      {
        m_MultiTerm = false;
        DoStudy(noRefresh);  // End of study
        return true;
      }
      
      // Update term and definition
      m_TermIndex = m_TermList[(m_TermNum-1)];
      DoShowDefinition(m_Sheet.Definitions[m_TermIndex]);
      
      bool b = m_MultiTerm == false;
      string [] aMultiTermList = MatchingSheet.SplitTerms(m_Sheet.Terms[m_TermIndex]);
      m_MultiTerm = (aMultiTermList.Length > 1);
      
      if (m_MultiTerm) DoResetMultiple();
      m_MultiTermNum = 0;
      m_MultiTermList = aMultiTermList;
      m_MultiTermListAquired = new string [m_MultiTermList.Length];
      m_MultiTermListRemains.Clear(); m_MultiTermListRemains.AddRange(m_MultiTermList);
      if (b) DoResetMultiple();
      
      lstTermList.SelectedIndex = 0; lstTermList.SelectedIndex = -1;
      lstTermList.Focus();
      return true;
    }
    
    private bool DoSelectTerm ()
    {
      bool bCorrect;
      
      if (lstTermList.SelectedIndex == -1) return false;
      if (tmrResetColors.Enabled) tmrResetColors_Tick(tmrResetColors, new EventArgs());
      string item = (string)lstTermList.SelectedItem;
      
      // Multi-term selection
      if (m_MultiTerm)
      {
        m_MultiTermNum++;
        txtMultiTermPos.Text = m_MultiTermNum.ToString();
        
        // Check for wrong
        if (!m_MultiTermListRemains.Contains(item))
          return DoSelectTerm(false);
        // Remove term from list of remaining terms
        m_MultiTermListRemains.Remove(item);
        
        // Get 'aquired' list
        txtMultiTerms.Text = "";
        for (int i = 0; i < m_MultiTermListAquired.Length; i++)
        {
          if (m_MultiTermListAquired[i] == null)
          {
            if (item != m_MultiTermList[i]) continue;
            m_MultiTermListAquired[i] = item;
          }
          
          if (txtMultiTerms.Text != "") txtMultiTerms.Text += ", ";
          txtMultiTerms.Text += m_MultiTermListAquired[i];
        }
        
        // Check for correct (completely answered)
        if (m_MultiTermNum >= m_MultiTermList.Length)
        {
          // Signal multi-term to user
          DoSelectTerm(true);
          SignalSelectMultiTerm(true);
          return true;
        }
        
        lstTermList.SelectedIndex = 0; lstTermList.SelectedIndex = -1;
        lstTermList.Focus();
        
        // Signal to user
        SignalSelectTerm(true, true, false);
        SignalSelectMultiTerm(false);
        return true;
      }
      
      bCorrect = false;
      for (int i = 0; i < m_Sheet.TermCount; i++)
        if ((string.Compare(item, m_Sheet.Terms[i], true) == 0) && (i == m_TermIndex))
        {
          bCorrect = true;
          break;
        }
      return DoSelectTerm(bCorrect);
    }
    
    private bool DoSelectTerm (bool bCorrect)
    {
      if (bCorrect)
      {
        // Correct
        m_Correct++;
        txtCorrect.Text = m_Correct.ToString();
      }
      else
      {
        // Wrong
        txtWrong.Text = (m_TermNum - m_Correct).ToString();
        m_ImproveList.Add(m_TermIndex);
        // Hide current multi-term if wrong
        m_MultiTerm = false;
        if (panMultiTerm.Visible == true)
          panMultiTerm.Visible = false;
      }
      
      // Remember 'completed'
      bool bCompleted = (m_TermNum < m_TermList.Length);
      
      // First do next item
      DoNextTerm();
      
      // Signal to user
      SignalSelectTerm(bCorrect, bCompleted);
      return true;
    }
    
    private void SignalSelectTerm (bool bCorrect)
    { SignalSelectTerm(bCorrect, true, true); }
    private void SignalSelectTerm (bool bCorrect, bool bPlaySound)
    { SignalSelectTerm(bCorrect, bPlaySound, true); }
    private void SignalSelectTerm (bool bCorrect, bool bPlaySound, bool bShowColors)
    {
      // Force refresh
      DoResetColors();
      
      // Signal correct/wrong answer to user
      if (bCorrect)
      {
        // Show colors
        if (bShowColors) 
        {
          lblCorrect.ForeColor = Color.SeaGreen;
          txtCorrect.BackColor = Color.PaleGreen;
        } this.Refresh();
        tmrResetColors.Enabled = true;
        
        // Play sound
        if (bPlaySound) PlaySound(MatchingSounds.Correct);
      }
      else
      {
        // Show colors
        if (bShowColors) 
        {
          lblWrong.ForeColor = Color.Firebrick;
          txtWrong.BackColor = Color.Salmon;
        } this.Refresh();
        tmrResetColors.Enabled = true;
        
        // Play sound
        if (bPlaySound) PlaySound(MatchingSounds.Wrong);
      }
    }
    
    // To be called immediately after SignalSelectTerm
    private void SignalSelectMultiTerm (bool bComplete)
    {
      // Force reset
      DoResetMultiple(tmrResetMultiTerm.Enabled);
      
      // Show colors
      lblMultiTerms.ForeColor = Color.SeaGreen;
      if (bComplete)
      {
        txtMultiTerms.BackColor = Color.PaleGreen;
        txtMultiTermCount.BackColor = Color.PaleGreen;
      }
      txtMultiTermPos.BackColor = Color.PaleGreen;
      tmrResetColors.Interval = (( bComplete )?( 800 ):( 500 ));
      
      tmrResetMultiTerm.Enabled = false;
      tmrResetMultiTerm.Interval = (( bComplete )?( 800 ):( 500 ));
      tmrResetMultiTerm.Enabled = true;
    }
    
    
    
    private bool DoStudy ()
    { return DoStudy(false); }
    private bool DoStudy (bool forceStop)
    { return DoStudy(forceStop, false); }
    private bool DoStudy (bool forceStop, bool noRefresh)
    {
      if (!m_Studying)
      {
        if (m_Sheet == null)
          if (!DoOpen()) return false;
        
        if (m_Sheet.TermCount == 0)
        {
          MessageBox.Show(this, "Could not begin; the Study Sheet is empty.", "Study Guide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          return false;
        }
        
        m_Studying = true;
        
        btnStudy.Text = "&Stop";
        Color bgc = Color.FromKnownColor(KnownColor.Window);
        txtDefinition.BackColor = bgc;
        txtRemaining.BackColor = bgc; txtTotal.BackColor = bgc;
        lstTermList.BackColor = bgc;
        btnSelect.Enabled = true;
        DoResetMessage();
        DoResetColors();
        
        lstTermList.Items.Clear();
        lstTermList.BeginUpdate();
        for (int i = 0; i < m_Sheet.TermCount; i++)
        {
          foreach (string item in MatchingSheet.SplitTerms(m_Sheet.Terms[i]))
          {
            bool b = true;
            for (int n = 0; n < lstTermList.Items.Count; n++)
            {
              if (string.Compare((string)lstTermList.Items[n], item, true) == 0)
              { b = false; break; }
            }
            
            if (b) lstTermList.Items.Add(item);
          }
        }
        try { lstTermList.EndUpdate(); }
        catch (NullReferenceException) {}
        
        txtTotal.Text = m_Sheet.TermCount.ToString(); txtRemaining.Text = txtTotal.Text;
        txtCorrect.Text = "0"; txtWrong.Text = "0";
        
        m_MultiTermList = null;
        m_MultiTermListRemains.Clear();
        txtMultiTerms.BackColor = bgc;
        txtMultiTermPos.BackColor = bgc;
        txtMultiTermCount.BackColor = bgc;
        
        m_Correct = 0;
        m_TermNum = 0;
        m_ImproveList = new ArrayList(m_Sheet.TermCount);
        
        m_MultiTerm = false;
        
        RandomizeTerms();
        
        // Play begin sound
        PlaySound(MatchingSounds.Begin);
        
        if (!noRefresh) this.Refresh();
        return DoNextTerm();
      }
      else if (m_Improving)
      {
        m_Improving = false;
        m_Studying = false;
        
        lstImprove.BackColor = Color.FromKnownColor(KnownColor.Control);
        lstImprove.Items.Clear();
        
        Color bgc = Color.FromKnownColor(KnownColor.Control);
        txtRemaining.BackColor = bgc; txtTotal.BackColor = bgc;
        DoResetColors();
        
        btnStudy.Text = "&Begin";
        txtDefinition.Text = "";
        txtDefinition.BackColor = bgc;
        m_ImproveList = null;
        
        m_MultiTermList = null;
        m_MultiTermListRemains.Clear();
        
        if (!noRefresh) this.Refresh();
        return true;
      }
      else
      {
        Color bgc = Color.FromKnownColor(KnownColor.Control);
        lstTermList.BackColor = bgc;
        txtDefinition.Text = "";
        btnSelect.Enabled = false;
        
        lstTermList.Items.Clear();
        
        // Check for improvement
        if ((m_ImproveList.Count > 0) && (forceStop == false))
        {
          m_Improving = true;
          
          lstImprove.BackColor = Color.FromKnownColor(KnownColor.Window);
          
          lstImprove.Items.Clear();
          if (m_ImproveList.Count > 0)
          {
            lstImprove.BeginUpdate();
            for (int i = 0; i < m_ImproveList.Count; i++)
              lstImprove.Items.Add(m_Sheet.Terms[(int)m_ImproveList[i]]);
            lstImprove.EndUpdate();
          }
          
          btnStudy.Text = "&Done";
          lstImprove.Focus();
        }
        else
        {
          m_Studying = false;
          
          txtRemaining.BackColor = bgc; txtTotal.BackColor = bgc;
          DoResetColors();
          
          btnStudy.Text = "&Begin";
          txtDefinition.BackColor = bgc;
          
          m_MultiTermList = null;
          m_MultiTermListRemains.Clear();
          
          m_ImproveList = null;
        }
        
        // Signal to user
        if (m_TermNum > m_Sheet.TermCount)
        {
          if (m_Correct == m_Sheet.TermCount)
          {
            // Perfect
            PlaySound(MatchingSounds.Perfect);
            lblMessage.Text = "Perfect!!"; lblMessage.BackColor = Color.LightSkyBlue; lblMessage.ForeColor = Color.LightYellow;
          }
          else
          {
            PlaySound(MatchingSounds.Complete);
            int p = ((int)(100 * ((double)m_Correct / (double)m_Sheet.TermCount)));
            if (p >= 90) { lblMessage.Text = "Excellent!"; lblMessage.BackColor = Color.LightSteelBlue; lblMessage.ForeColor = Color.Honeydew; }
            else if (p >= 80) { lblMessage.Text = "Great work!"; lblMessage.BackColor = Color.LightSteelBlue; lblMessage.ForeColor = Color.Honeydew; }
            else if (p >= 75) { lblMessage.Text = "Good job!"; lblMessage.BackColor = Color.LightSteelBlue; lblMessage.ForeColor = Color.Honeydew; }
            else if (p >= 70) { lblMessage.Text = "Not bad!"; lblMessage.BackColor = Color.Thistle; lblMessage.ForeColor = Color.GhostWhite; }
            else if (p >= 60) { lblMessage.Text = "Keep working!"; lblMessage.BackColor = Color.Thistle; lblMessage.ForeColor = Color.GhostWhite; }
            else if (p >= 50) { lblMessage.Text = "Keep it up!"; lblMessage.BackColor = Color.Thistle; lblMessage.ForeColor = Color.GhostWhite; }
            else if (p >= 25) { lblMessage.Text = "Needs some work!"; lblMessage.BackColor = Color.RosyBrown; lblMessage.ForeColor = Color.LightPink; }
            else 
            {
              lblMessage.BackColor = Color.RosyBrown; lblMessage.ForeColor = Color.LightPink;
              switch ((new Random(unchecked((int)DateTime.Now.Ticks))).Next(5))
              {
                case 1: lblMessage.Text = "Keep practicing!"; break;
                case 2: lblMessage.Text = "Don't give up!"; break;
                case 3: lblMessage.Text = "Uh oh! Keep trying!"; break;
                case 4: lblMessage.Text = "You'll get it!"; break;
                default: lblMessage.Text = "Don't get discouraged!"; break;
              }
            }
          }
          lblMessage.Visible = true;
          txtDefinition.Visible = false;
        }
        else
        {
          m_MultiTerm = false;
          panMultiTerm.Visible = false;
          DoResetColors();
        }
        
        // Enable timer
        tmrResetMessage.Enabled = true;
        
        // Refresh form
        if (!noRefresh) this.Refresh();
        return true;
      }
    }
    
    private void DoResetColors ()
    {
      Color bgc = Color.FromKnownColor(KnownColor.ControlText);
      lblCorrect.ForeColor = bgc;
      lblWrong.ForeColor = bgc;
      
      bgc = Color.FromKnownColor(KnownColor.Control);
      txtCorrect.BackColor = (( m_Studying )?( Color.FromKnownColor(KnownColor.Window) ):( bgc ));
      txtWrong.BackColor = (( m_Studying )?( Color.FromKnownColor(KnownColor.Window) ):( bgc ));
      
      tmrResetColors.Interval = 500;
      tmrResetColors.Enabled = false;
    }
    
    private void DoResetMultiple ()
    { DoResetMultiple(true); }
    private void DoResetMultiple (bool ResetAll)
    {
      if (ResetAll) panMultiTerm.Visible = m_MultiTerm;
      
      Color bgc = Color.FromKnownColor(KnownColor.Window);
      txtMultiTerms.BackColor = bgc;
      txtMultiTermPos.BackColor = bgc;
      txtMultiTermCount.BackColor = bgc;
      lblMultiTerms.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
      
      if (ResetAll)
      {
        if (m_MultiTermNum == 0) txtMultiTerms.Text = "";
        txtMultiTermPos.Text = m_MultiTermNum.ToString();
        if (m_MultiTermList != null) txtMultiTermCount.Text = m_MultiTermList.Length.ToString();
        else txtMultiTermCount.Text = "";
      }
      
      tmrResetMultiTerm.Enabled = false;
    }
    
    private void DoResetMessage ()
    {
      txtDefinition.Visible = true;
      lblMessage.Visible = false;
      
      tmrResetMessage.Enabled = false;
    }
    
    private bool DoShowImproveItem ()
    {
      if (lstImprove.SelectedIndex == -1) return false;
      if (m_ImproveList == null) return false;
      
      lblMessage.Visible = false; txtDefinition.Visible = true;
      DoShowDefinition(m_Sheet.Definitions[(int)m_ImproveList[lstImprove.SelectedIndex]]);
      return true;
    }
    
    
    private void PlaySound (MatchingSounds sound)
    {
      string FileName;
      
      // Failsafe
      if (!m_Settings.PlaySounds) return;
      
      // !!!!!
      if (!menuMainSoundEffects.Checked) return;
      
      // Get FileName
      FileName = "";
      switch (sound)
      {
        case MatchingSounds.Begin: FileName = m_Settings.Sounds[0]; break;
        case MatchingSounds.Correct: FileName = m_Settings.Sounds[1]; break;
        case MatchingSounds.Wrong: FileName = m_Settings.Sounds[2]; break;
        case MatchingSounds.Complete: FileName = m_Settings.Sounds[3]; break;
        case MatchingSounds.Perfect: FileName = m_Settings.Sounds[4]; break;
        default: return;
      }
      
      // Play sound
      sndPlaySound(FileName, IntPtr.Zero, (SoundFlags.SND_FileName | SoundFlags.SND_ASYNC | SoundFlags.SND_NOWAIT));
    }
    
    private void RandomizeTerms ()
    {
      int val = 0; bool b;
      m_TermList = new int [m_Sheet.TermCount];
      Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
      
      for (int i = 0; i < m_Sheet.TermCount; i++)
        m_TermList[i] = -1;
      
      b = false;
      for (int i = 0; i < m_Sheet.TermCount; i++)
      {
        if (!b) val = rnd.Next(m_Sheet.TermCount);
        
        // Check to see if value was already used
        b = false;
        for (int i2 = 0; i2 < m_Sheet.TermCount; i2++)
        {
          if (m_TermList[i2] == val)
          {
            // Value was already used; increase to next value
            val = ((val + 1) % m_Sheet.TermCount);
            b = true;
            break;
          }
        }
        
        // Repeat current term with new value
        if (b) { i--; continue; }
        
        // Term is unique; use it
        m_TermList[i] = val;
      }
    }
    
  }
}

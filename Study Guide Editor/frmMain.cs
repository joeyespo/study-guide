using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Uberware.Study
{
	public class frmMain : System.Windows.Forms.Form
	{
    
    #region Class Variables
    
    private const string c_Title = "Study Guide Editor";
    private bool m_SheetDirty = false;
    private bool m_DesignMode = false;
    private MatchingSheet m_Sheet = null;
    private bool m_InternalEditing = false;
    private int m_AddHeight = 0;
    
    #region Controls
    
    private System.Windows.Forms.TextBox txtTitle;
    private System.Windows.Forms.Label lblAuthor;
    private System.Windows.Forms.TextBox txtAuthor;
    private System.Windows.Forms.TextBox txtGroup;
    private System.Windows.Forms.Label lblGroup;
    private System.Windows.Forms.Label lblDescription;
    private System.Windows.Forms.CheckBox chkInfo;
    private System.Windows.Forms.GroupBox grpInfo;
    private System.Windows.Forms.Panel panSheet;
    private System.Windows.Forms.GroupBox grpAdd;
    private System.Windows.Forms.Button btnAddTerm;
    private System.Windows.Forms.CheckBox chkAdd;
    private System.Windows.Forms.Label lblDefinitionAdd;
    private System.Windows.Forms.Panel panAdd;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.RichTextBox txtDefinitionAdd;
    private System.Windows.Forms.Splitter splAdd;
    private System.Windows.Forms.MainMenu menuMain;
    private System.Windows.Forms.MenuItem menuFile;
    private System.Windows.Forms.MenuItem menuFileNew;
    private System.Windows.Forms.MenuItem menuFileOpen;
    private System.Windows.Forms.MenuItem menuFileSave;
    private System.Windows.Forms.MenuItem menuFileSaveAs;
    private System.Windows.Forms.MenuItem menuFileClose;
    private System.Windows.Forms.MenuItem menuFileLine01;
    private System.Windows.Forms.MenuItem menuFileExit;
    private System.Windows.Forms.MenuItem menuEditorPreferences;
    private System.Windows.Forms.MenuItem menuHelpAbout;
    private System.Windows.Forms.Button btnExit;
    private System.Windows.Forms.Button btnTest;
    private System.Windows.Forms.Panel panTermsModify;
    private System.Windows.Forms.Button btnPlayer;
    private System.Windows.Forms.OpenFileDialog openFileDialog;
    private System.Windows.Forms.SaveFileDialog saveFileDialog;
    private System.Windows.Forms.CheckBox chkReadOnly;
    private System.Windows.Forms.Panel panInfo;
    private System.Windows.Forms.RichTextBox txtDescription;
    private System.Windows.Forms.RichTextBox txtSource;
    private System.Windows.Forms.Button btnNormalize;
    private System.Windows.Forms.Button btnMenu;
    private System.Windows.Forms.ContextMenu menuMenu;
    private System.Windows.Forms.MenuItem menuFileLine02;
    private System.Windows.Forms.MenuItem menuMenuExit;
    private System.Windows.Forms.MenuItem menuView;
    private System.Windows.Forms.MenuItem menuViewSource;
    private System.Windows.Forms.MenuItem menuViewDesigner;
    private System.Windows.Forms.MenuItem menuTools;
    private System.Windows.Forms.Panel panDesigner;
    private System.Windows.Forms.Panel panSource;
    private System.Windows.Forms.Panel panAddDefinition;
    private System.Windows.Forms.Panel panAddTermFooter;
    private System.Windows.Forms.Splitter splAddSep;
    private System.Windows.Forms.Panel panAddTerm;
    private System.Windows.Forms.Label lblTermsAdd;
    private System.Windows.Forms.TextBox txtTermsAdd;
    private System.Windows.Forms.Panel panAddTermTextBox;
    private System.Windows.Forms.CheckBox chkMultiTerm;
    private System.Windows.Forms.Panel panAddItem;
    private System.Windows.Forms.MenuItem menuDesigner;
    private System.Windows.Forms.MenuItem menuDesignerAddTerm;
    private System.Windows.Forms.MenuItem menuHelp;
    private System.Windows.Forms.Panel panDefinition;
    private System.Windows.Forms.RichTextBox txtDefinition;
    private System.Windows.Forms.Label lblDefinition;
    private System.Windows.Forms.Splitter splDefinition;
    private System.Windows.Forms.Panel panTerms;
    private System.Windows.Forms.ListBox lstTermList;
    private System.Windows.Forms.Splitter splTerms;
    private System.Windows.Forms.TextBox txtMultiTerm;
    private System.Windows.Forms.Label lblTermList;
    private System.Windows.Forms.Panel panItems;
		
    /// <summary> Required designer variable. </summary>
		private System.ComponentModel.Container components = null;
    
    #endregion
    
    #endregion
    
    #region Class Construction
    
    public frmMain ()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}
    
		#region Windows Form Designer generated code
    
    /// <summary> Clean up any resources being used. </summary>
    protected override void Dispose (bool disposing)
    {
      if( disposing )
      {
        if(components != null)
        {
          components.Dispose();
        }
      }
      base.Dispose( disposing );
    }
		
    /// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
      System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
      this.txtTitle = new System.Windows.Forms.TextBox();
      this.lblAuthor = new System.Windows.Forms.Label();
      this.txtAuthor = new System.Windows.Forms.TextBox();
      this.txtGroup = new System.Windows.Forms.TextBox();
      this.lblGroup = new System.Windows.Forms.Label();
      this.lblDescription = new System.Windows.Forms.Label();
      this.grpInfo = new System.Windows.Forms.GroupBox();
      this.txtDescription = new System.Windows.Forms.RichTextBox();
      this.chkInfo = new System.Windows.Forms.CheckBox();
      this.panSheet = new System.Windows.Forms.Panel();
      this.panTermsModify = new System.Windows.Forms.Panel();
      this.chkReadOnly = new System.Windows.Forms.CheckBox();
      this.btnDelete = new System.Windows.Forms.Button();
      this.splAdd = new System.Windows.Forms.Splitter();
      this.panAdd = new System.Windows.Forms.Panel();
      this.chkAdd = new System.Windows.Forms.CheckBox();
      this.grpAdd = new System.Windows.Forms.GroupBox();
      this.panAddItem = new System.Windows.Forms.Panel();
      this.panAddDefinition = new System.Windows.Forms.Panel();
      this.txtDefinitionAdd = new System.Windows.Forms.RichTextBox();
      this.lblDefinitionAdd = new System.Windows.Forms.Label();
      this.panAddTermFooter = new System.Windows.Forms.Panel();
      this.btnAddTerm = new System.Windows.Forms.Button();
      this.splAddSep = new System.Windows.Forms.Splitter();
      this.panAddTerm = new System.Windows.Forms.Panel();
      this.panAddTermTextBox = new System.Windows.Forms.Panel();
      this.chkMultiTerm = new System.Windows.Forms.CheckBox();
      this.txtTermsAdd = new System.Windows.Forms.TextBox();
      this.lblTermsAdd = new System.Windows.Forms.Label();
      this.btnExit = new System.Windows.Forms.Button();
      this.btnTest = new System.Windows.Forms.Button();
      this.menuMain = new System.Windows.Forms.MainMenu();
      this.menuFile = new System.Windows.Forms.MenuItem();
      this.menuFileNew = new System.Windows.Forms.MenuItem();
      this.menuFileOpen = new System.Windows.Forms.MenuItem();
      this.menuFileClose = new System.Windows.Forms.MenuItem();
      this.menuFileLine01 = new System.Windows.Forms.MenuItem();
      this.menuFileSave = new System.Windows.Forms.MenuItem();
      this.menuFileSaveAs = new System.Windows.Forms.MenuItem();
      this.menuFileLine02 = new System.Windows.Forms.MenuItem();
      this.menuFileExit = new System.Windows.Forms.MenuItem();
      this.menuView = new System.Windows.Forms.MenuItem();
      this.menuViewSource = new System.Windows.Forms.MenuItem();
      this.menuViewDesigner = new System.Windows.Forms.MenuItem();
      this.menuTools = new System.Windows.Forms.MenuItem();
      this.menuEditorPreferences = new System.Windows.Forms.MenuItem();
      this.menuDesigner = new System.Windows.Forms.MenuItem();
      this.menuDesignerAddTerm = new System.Windows.Forms.MenuItem();
      this.menuHelp = new System.Windows.Forms.MenuItem();
      this.menuHelpAbout = new System.Windows.Forms.MenuItem();
      this.btnPlayer = new System.Windows.Forms.Button();
      this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
      this.panInfo = new System.Windows.Forms.Panel();
      this.panDesigner = new System.Windows.Forms.Panel();
      this.panSource = new System.Windows.Forms.Panel();
      this.btnNormalize = new System.Windows.Forms.Button();
      this.txtSource = new System.Windows.Forms.RichTextBox();
      this.btnMenu = new System.Windows.Forms.Button();
      this.menuMenu = new System.Windows.Forms.ContextMenu();
      this.menuMenuExit = new System.Windows.Forms.MenuItem();
      this.panItems = new System.Windows.Forms.Panel();
      this.panDefinition = new System.Windows.Forms.Panel();
      this.txtDefinition = new System.Windows.Forms.RichTextBox();
      this.lblDefinition = new System.Windows.Forms.Label();
      this.splDefinition = new System.Windows.Forms.Splitter();
      this.panTerms = new System.Windows.Forms.Panel();
      this.lstTermList = new System.Windows.Forms.ListBox();
      this.splTerms = new System.Windows.Forms.Splitter();
      this.txtMultiTerm = new System.Windows.Forms.TextBox();
      this.lblTermList = new System.Windows.Forms.Label();
      this.grpInfo.SuspendLayout();
      this.panSheet.SuspendLayout();
      this.panTermsModify.SuspendLayout();
      this.panAdd.SuspendLayout();
      this.grpAdd.SuspendLayout();
      this.panAddItem.SuspendLayout();
      this.panAddDefinition.SuspendLayout();
      this.panAddTermFooter.SuspendLayout();
      this.panAddTerm.SuspendLayout();
      this.panAddTermTextBox.SuspendLayout();
      this.panInfo.SuspendLayout();
      this.panDesigner.SuspendLayout();
      this.panSource.SuspendLayout();
      this.panItems.SuspendLayout();
      this.panDefinition.SuspendLayout();
      this.panTerms.SuspendLayout();
      this.SuspendLayout();
      // 
      // txtTitle
      // 
      this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.txtTitle.BackColor = System.Drawing.SystemColors.Control;
      this.txtTitle.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.txtTitle.ForeColor = System.Drawing.SystemColors.GrayText;
      this.txtTitle.Name = "txtTitle";
      this.txtTitle.Size = new System.Drawing.Size(480, 22);
      this.txtTitle.TabIndex = 0;
      this.txtTitle.Text = "( nothing loaded )";
      this.txtTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
      this.txtTitle.Leave += new System.EventHandler(this.txtTitle_Leave);
      this.txtTitle.Enter += new System.EventHandler(this.txtTitle_Enter);
      // 
      // lblAuthor
      // 
      this.lblAuthor.Location = new System.Drawing.Point(8, 20);
      this.lblAuthor.Name = "lblAuthor";
      this.lblAuthor.Size = new System.Drawing.Size(168, 16);
      this.lblAuthor.TabIndex = 0;
      this.lblAuthor.Text = "Author:";
      // 
      // txtAuthor
      // 
      this.txtAuthor.BackColor = System.Drawing.SystemColors.Control;
      this.txtAuthor.Location = new System.Drawing.Point(8, 36);
      this.txtAuthor.Name = "txtAuthor";
      this.txtAuthor.ReadOnly = true;
      this.txtAuthor.Size = new System.Drawing.Size(168, 20);
      this.txtAuthor.TabIndex = 1;
      this.txtAuthor.Text = "";
      this.txtAuthor.TextChanged += new System.EventHandler(this.txtAuthor_TextChanged);
      // 
      // txtGroup
      // 
      this.txtGroup.BackColor = System.Drawing.SystemColors.Control;
      this.txtGroup.Location = new System.Drawing.Point(8, 80);
      this.txtGroup.Name = "txtGroup";
      this.txtGroup.ReadOnly = true;
      this.txtGroup.Size = new System.Drawing.Size(168, 20);
      this.txtGroup.TabIndex = 5;
      this.txtGroup.Text = "";
      this.txtGroup.TextChanged += new System.EventHandler(this.txtGroup_TextChanged);
      this.txtGroup.Leave += new System.EventHandler(this.txtGroup_Leave);
      this.txtGroup.Enter += new System.EventHandler(this.txtGroup_Enter);
      // 
      // lblGroup
      // 
      this.lblGroup.Location = new System.Drawing.Point(8, 64);
      this.lblGroup.Name = "lblGroup";
      this.lblGroup.Size = new System.Drawing.Size(168, 16);
      this.lblGroup.TabIndex = 4;
      this.lblGroup.Text = "Group:";
      // 
      // lblDescription
      // 
      this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.lblDescription.Location = new System.Drawing.Point(184, 20);
      this.lblDescription.Name = "lblDescription";
      this.lblDescription.Size = new System.Drawing.Size(288, 16);
      this.lblDescription.TabIndex = 2;
      this.lblDescription.Text = "Description:";
      // 
      // grpInfo
      // 
      this.grpInfo.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.grpInfo.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.txtDescription,
                                                                          this.lblGroup,
                                                                          this.lblDescription,
                                                                          this.txtAuthor,
                                                                          this.txtGroup,
                                                                          this.lblAuthor});
      this.grpInfo.Name = "grpInfo";
      this.grpInfo.Size = new System.Drawing.Size(480, 108);
      this.grpInfo.TabIndex = 1;
      this.grpInfo.TabStop = false;
      // 
      // txtDescription
      // 
      this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.txtDescription.BackColor = System.Drawing.SystemColors.Control;
      this.txtDescription.Location = new System.Drawing.Point(184, 36);
      this.txtDescription.Name = "txtDescription";
      this.txtDescription.ReadOnly = true;
      this.txtDescription.Size = new System.Drawing.Size(288, 64);
      this.txtDescription.TabIndex = 3;
      this.txtDescription.Text = "";
      this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
      this.txtDescription.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.LinkClicked);
      // 
      // chkInfo
      // 
      this.chkInfo.Checked = true;
      this.chkInfo.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkInfo.Location = new System.Drawing.Point(8, 0);
      this.chkInfo.Name = "chkInfo";
      this.chkInfo.Size = new System.Drawing.Size(120, 16);
      this.chkInfo.TabIndex = 0;
      this.chkInfo.Text = "Sheet &Information";
      this.chkInfo.CheckedChanged += new System.EventHandler(this.chkInfo_CheckedChanged);
      // 
      // panSheet
      // 
      this.panSheet.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.panSheet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panSheet.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                           this.panItems,
                                                                           this.panTermsModify,
                                                                           this.splAdd,
                                                                           this.panAdd});
      this.panSheet.DockPadding.All = 8;
      this.panSheet.Location = new System.Drawing.Point(0, 148);
      this.panSheet.Name = "panSheet";
      this.panSheet.Size = new System.Drawing.Size(480, 288);
      this.panSheet.TabIndex = 2;
      // 
      // panTermsModify
      // 
      this.panTermsModify.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                 this.chkReadOnly,
                                                                                 this.btnDelete});
      this.panTermsModify.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panTermsModify.Location = new System.Drawing.Point(8, 138);
      this.panTermsModify.Name = "panTermsModify";
      this.panTermsModify.Size = new System.Drawing.Size(462, 28);
      this.panTermsModify.TabIndex = 1;
      // 
      // chkReadOnly
      // 
      this.chkReadOnly.Appearance = System.Windows.Forms.Appearance.Button;
      this.chkReadOnly.Location = new System.Drawing.Point(80, 0);
      this.chkReadOnly.Name = "chkReadOnly";
      this.chkReadOnly.Size = new System.Drawing.Size(80, 28);
      this.chkReadOnly.TabIndex = 0;
      this.chkReadOnly.Text = "Read-&only";
      this.chkReadOnly.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.chkReadOnly.CheckedChanged += new System.EventHandler(this.chkReadOnly_CheckedChanged);
      // 
      // btnDelete
      // 
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new System.Drawing.Size(72, 28);
      this.btnDelete.TabIndex = 1;
      this.btnDelete.Text = "De&lete";
      this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
      // 
      // splAdd
      // 
      this.splAdd.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.splAdd.Location = new System.Drawing.Point(8, 166);
      this.splAdd.Name = "splAdd";
      this.splAdd.Size = new System.Drawing.Size(462, 12);
      this.splAdd.TabIndex = 2;
      this.splAdd.TabStop = false;
      // 
      // panAdd
      // 
      this.panAdd.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                         this.chkAdd,
                                                                         this.grpAdd});
      this.panAdd.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panAdd.Location = new System.Drawing.Point(8, 178);
      this.panAdd.Name = "panAdd";
      this.panAdd.Size = new System.Drawing.Size(462, 100);
      this.panAdd.TabIndex = 3;
      // 
      // chkAdd
      // 
      this.chkAdd.Checked = true;
      this.chkAdd.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkAdd.Location = new System.Drawing.Point(8, 0);
      this.chkAdd.Name = "chkAdd";
      this.chkAdd.Size = new System.Drawing.Size(76, 16);
      this.chkAdd.TabIndex = 0;
      this.chkAdd.Text = "A&dd Item";
      this.chkAdd.CheckedChanged += new System.EventHandler(this.chkAdd_CheckedChanged);
      // 
      // grpAdd
      // 
      this.grpAdd.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.grpAdd.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                         this.panAddItem});
      this.grpAdd.Name = "grpAdd";
      this.grpAdd.Size = new System.Drawing.Size(462, 100);
      this.grpAdd.TabIndex = 1;
      this.grpAdd.TabStop = false;
      this.grpAdd.Enter += new System.EventHandler(this.grpAdd_Enter);
      this.grpAdd.Leave += new System.EventHandler(this.grpAdd_Leave);
      // 
      // panAddItem
      // 
      this.panAddItem.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                             this.panAddDefinition,
                                                                             this.panAddTermFooter,
                                                                             this.splAddSep,
                                                                             this.panAddTerm});
      this.panAddItem.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panAddItem.Location = new System.Drawing.Point(3, 16);
      this.panAddItem.Name = "panAddItem";
      this.panAddItem.Size = new System.Drawing.Size(456, 81);
      this.panAddItem.TabIndex = 0;
      // 
      // panAddDefinition
      // 
      this.panAddDefinition.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                   this.txtDefinitionAdd,
                                                                                   this.lblDefinitionAdd});
      this.panAddDefinition.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panAddDefinition.DockPadding.Bottom = 8;
      this.panAddDefinition.DockPadding.Right = 8;
      this.panAddDefinition.DockPadding.Top = 8;
      this.panAddDefinition.Location = new System.Drawing.Point(232, 0);
      this.panAddDefinition.Name = "panAddDefinition";
      this.panAddDefinition.Size = new System.Drawing.Size(224, 52);
      this.panAddDefinition.TabIndex = 2;
      // 
      // txtDefinitionAdd
      // 
      this.txtDefinitionAdd.BackColor = System.Drawing.SystemColors.Control;
      this.txtDefinitionAdd.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtDefinitionAdd.Location = new System.Drawing.Point(0, 24);
      this.txtDefinitionAdd.Name = "txtDefinitionAdd";
      this.txtDefinitionAdd.Size = new System.Drawing.Size(216, 20);
      this.txtDefinitionAdd.TabIndex = 1;
      this.txtDefinitionAdd.Text = "";
      this.txtDefinitionAdd.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.LinkClicked);
      // 
      // lblDefinitionAdd
      // 
      this.lblDefinitionAdd.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblDefinitionAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblDefinitionAdd.Location = new System.Drawing.Point(0, 8);
      this.lblDefinitionAdd.Name = "lblDefinitionAdd";
      this.lblDefinitionAdd.Size = new System.Drawing.Size(216, 16);
      this.lblDefinitionAdd.TabIndex = 0;
      this.lblDefinitionAdd.Text = "Definition:";
      // 
      // panAddTermFooter
      // 
      this.panAddTermFooter.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                   this.btnAddTerm});
      this.panAddTermFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panAddTermFooter.Location = new System.Drawing.Point(232, 52);
      this.panAddTermFooter.Name = "panAddTermFooter";
      this.panAddTermFooter.Size = new System.Drawing.Size(224, 29);
      this.panAddTermFooter.TabIndex = 3;
      // 
      // btnAddTerm
      // 
      this.btnAddTerm.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
      this.btnAddTerm.Location = new System.Drawing.Point(164, 0);
      this.btnAddTerm.Name = "btnAddTerm";
      this.btnAddTerm.Size = new System.Drawing.Size(52, 24);
      this.btnAddTerm.TabIndex = 0;
      this.btnAddTerm.Text = "&Add";
      this.btnAddTerm.Click += new System.EventHandler(this.btnAddTerm_Click);
      // 
      // splAddSep
      // 
      this.splAddSep.Location = new System.Drawing.Point(224, 0);
      this.splAddSep.MinExtra = 75;
      this.splAddSep.MinSize = 75;
      this.splAddSep.Name = "splAddSep";
      this.splAddSep.Size = new System.Drawing.Size(8, 81);
      this.splAddSep.TabIndex = 1;
      this.splAddSep.TabStop = false;
      this.splAddSep.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splAddSep_SplitterMoved);
      // 
      // panAddTerm
      // 
      this.panAddTerm.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                             this.panAddTermTextBox,
                                                                             this.lblTermsAdd});
      this.panAddTerm.Dock = System.Windows.Forms.DockStyle.Left;
      this.panAddTerm.DockPadding.Bottom = 8;
      this.panAddTerm.DockPadding.Left = 8;
      this.panAddTerm.DockPadding.Top = 8;
      this.panAddTerm.Name = "panAddTerm";
      this.panAddTerm.Size = new System.Drawing.Size(224, 81);
      this.panAddTerm.TabIndex = 0;
      // 
      // panAddTermTextBox
      // 
      this.panAddTermTextBox.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                    this.chkMultiTerm,
                                                                                    this.txtTermsAdd});
      this.panAddTermTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panAddTermTextBox.Location = new System.Drawing.Point(8, 24);
      this.panAddTermTextBox.Name = "panAddTermTextBox";
      this.panAddTermTextBox.Size = new System.Drawing.Size(216, 49);
      this.panAddTermTextBox.TabIndex = 0;
      this.panAddTermTextBox.SizeChanged += new System.EventHandler(this.panAddTermTextBox_SizeChanged);
      // 
      // chkMultiTerm
      // 
      this.chkMultiTerm.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.chkMultiTerm.Location = new System.Drawing.Point(0, 24);
      this.chkMultiTerm.Name = "chkMultiTerm";
      this.chkMultiTerm.Size = new System.Drawing.Size(216, 28);
      this.chkMultiTerm.TabIndex = 2;
      this.chkMultiTerm.Text = "Multiple Te&rms";
      this.chkMultiTerm.CheckedChanged += new System.EventHandler(this.chkMultiTerm_CheckedChanged);
      // 
      // txtTermsAdd
      // 
      this.txtTermsAdd.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.txtTermsAdd.BackColor = System.Drawing.SystemColors.Control;
      this.txtTermsAdd.Name = "txtTermsAdd";
      this.txtTermsAdd.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
      this.txtTermsAdd.Size = new System.Drawing.Size(216, 20);
      this.txtTermsAdd.TabIndex = 1;
      this.txtTermsAdd.Text = "";
      this.txtTermsAdd.MultilineChanged += new System.EventHandler(this.txtTermsAdd_MultilineChanged);
      this.txtTermsAdd.Leave += new System.EventHandler(this.txtTermsAdd_Leave);
      this.txtTermsAdd.Enter += new System.EventHandler(this.txtTermsAdd_Enter);
      // 
      // lblTermsAdd
      // 
      this.lblTermsAdd.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblTermsAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblTermsAdd.Location = new System.Drawing.Point(8, 8);
      this.lblTermsAdd.Name = "lblTermsAdd";
      this.lblTermsAdd.Size = new System.Drawing.Size(216, 16);
      this.lblTermsAdd.TabIndex = 0;
      this.lblTermsAdd.Text = "Term:";
      // 
      // btnExit
      // 
      this.btnExit.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
      this.btnExit.Location = new System.Drawing.Point(416, 456);
      this.btnExit.Name = "btnExit";
      this.btnExit.Size = new System.Drawing.Size(72, 32);
      this.btnExit.TabIndex = 5;
      this.btnExit.Text = "E&xit";
      this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
      // 
      // btnTest
      // 
      this.btnTest.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
      this.btnTest.Location = new System.Drawing.Point(104, 452);
      this.btnTest.Name = "btnTest";
      this.btnTest.Size = new System.Drawing.Size(88, 36);
      this.btnTest.TabIndex = 3;
      this.btnTest.Text = "&Test...";
      this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
      // 
      // menuMain
      // 
      this.menuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                             this.menuFile,
                                                                             this.menuView,
                                                                             this.menuTools,
                                                                             this.menuDesigner,
                                                                             this.menuHelp});
      // 
      // menuFile
      // 
      this.menuFile.Index = 0;
      this.menuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                             this.menuFileNew,
                                                                             this.menuFileOpen,
                                                                             this.menuFileClose,
                                                                             this.menuFileLine01,
                                                                             this.menuFileSave,
                                                                             this.menuFileSaveAs,
                                                                             this.menuFileLine02,
                                                                             this.menuFileExit});
      this.menuFile.Text = "&File";
      // 
      // menuFileNew
      // 
      this.menuFileNew.Index = 0;
      this.menuFileNew.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
      this.menuFileNew.Text = "&New";
      this.menuFileNew.Click += new System.EventHandler(this.menuFileNew_Click);
      // 
      // menuFileOpen
      // 
      this.menuFileOpen.Index = 1;
      this.menuFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
      this.menuFileOpen.Text = "&Open...";
      this.menuFileOpen.Click += new System.EventHandler(this.menuFileOpen_Click);
      // 
      // menuFileClose
      // 
      this.menuFileClose.Index = 2;
      this.menuFileClose.Text = "&Close";
      this.menuFileClose.Click += new System.EventHandler(this.menuFileClose_Click);
      // 
      // menuFileLine01
      // 
      this.menuFileLine01.Index = 3;
      this.menuFileLine01.Text = "-";
      // 
      // menuFileSave
      // 
      this.menuFileSave.Index = 4;
      this.menuFileSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
      this.menuFileSave.Text = "&Save";
      this.menuFileSave.Click += new System.EventHandler(this.menuFileSave_Click);
      // 
      // menuFileSaveAs
      // 
      this.menuFileSaveAs.Index = 5;
      this.menuFileSaveAs.Text = "Save &As...";
      this.menuFileSaveAs.Click += new System.EventHandler(this.menuFileSaveAs_Click);
      // 
      // menuFileLine02
      // 
      this.menuFileLine02.Index = 6;
      this.menuFileLine02.Text = "-";
      // 
      // menuFileExit
      // 
      this.menuFileExit.Index = 7;
      this.menuFileExit.Text = "E&xit";
      this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
      // 
      // menuView
      // 
      this.menuView.Index = 1;
      this.menuView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                             this.menuViewSource,
                                                                             this.menuViewDesigner});
      this.menuView.Text = "&View";
      // 
      // menuViewSource
      // 
      this.menuViewSource.Index = 0;
      this.menuViewSource.Shortcut = System.Windows.Forms.Shortcut.Ctrl0;
      this.menuViewSource.Text = "View &Source";
      this.menuViewSource.Click += new System.EventHandler(this.menuViewSource_Click);
      // 
      // menuViewDesigner
      // 
      this.menuViewDesigner.Index = 1;
      this.menuViewDesigner.Shortcut = System.Windows.Forms.Shortcut.CtrlShift0;
      this.menuViewDesigner.Text = "View &Designer";
      this.menuViewDesigner.Click += new System.EventHandler(this.menuViewDesigner_Click);
      // 
      // menuTools
      // 
      this.menuTools.Index = 2;
      this.menuTools.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                              this.menuEditorPreferences});
      this.menuTools.Text = "&Tools";
      // 
      // menuEditorPreferences
      // 
      this.menuEditorPreferences.Index = 0;
      this.menuEditorPreferences.Text = "&Preferences...";
      this.menuEditorPreferences.Click += new System.EventHandler(this.menuEditorPreferences_Click);
      // 
      // menuDesigner
      // 
      this.menuDesigner.Index = 3;
      this.menuDesigner.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                 this.menuDesignerAddTerm});
      this.menuDesigner.Text = "&Designer";
      // 
      // menuDesignerAddTerm
      // 
      this.menuDesignerAddTerm.Index = 0;
      this.menuDesignerAddTerm.Shortcut = System.Windows.Forms.Shortcut.CtrlD;
      this.menuDesignerAddTerm.Text = "A&dd Term";
      this.menuDesignerAddTerm.Click += new System.EventHandler(this.menuDesignerAddTerm_Click);
      // 
      // menuHelp
      // 
      this.menuHelp.Index = 4;
      this.menuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                             this.menuHelpAbout});
      this.menuHelp.Text = "&Help";
      // 
      // menuHelpAbout
      // 
      this.menuHelpAbout.Index = 0;
      this.menuHelpAbout.Text = "&About...";
      this.menuHelpAbout.Click += new System.EventHandler(this.menuHelpAbout_Click);
      // 
      // btnPlayer
      // 
      this.btnPlayer.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
      this.btnPlayer.Location = new System.Drawing.Point(336, 456);
      this.btnPlayer.Name = "btnPlayer";
      this.btnPlayer.Size = new System.Drawing.Size(72, 32);
      this.btnPlayer.TabIndex = 4;
      this.btnPlayer.Text = "&Player...";
      this.btnPlayer.Click += new System.EventHandler(this.btnPlayer_Click);
      // 
      // panInfo
      // 
      this.panInfo.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.panInfo.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.chkInfo,
                                                                          this.grpInfo});
      this.panInfo.Location = new System.Drawing.Point(0, 32);
      this.panInfo.Name = "panInfo";
      this.panInfo.Size = new System.Drawing.Size(480, 108);
      this.panInfo.TabIndex = 1;
      // 
      // panDesigner
      // 
      this.panDesigner.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.panDesigner.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                              this.panInfo,
                                                                              this.txtTitle,
                                                                              this.panSheet});
      this.panDesigner.Location = new System.Drawing.Point(8, 8);
      this.panDesigner.Name = "panDesigner";
      this.panDesigner.Size = new System.Drawing.Size(480, 436);
      this.panDesigner.TabIndex = 0;
      // 
      // panSource
      // 
      this.panSource.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.panSource.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                            this.btnNormalize,
                                                                            this.txtSource});
      this.panSource.Location = new System.Drawing.Point(8, 8);
      this.panSource.Name = "panSource";
      this.panSource.Size = new System.Drawing.Size(480, 436);
      this.panSource.TabIndex = 1;
      // 
      // btnNormalize
      // 
      this.btnNormalize.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
      this.btnNormalize.Location = new System.Drawing.Point(388, 404);
      this.btnNormalize.Name = "btnNormalize";
      this.btnNormalize.Size = new System.Drawing.Size(92, 32);
      this.btnNormalize.TabIndex = 0;
      this.btnNormalize.Text = "&Normalize";
      this.btnNormalize.Click += new System.EventHandler(this.btnNormalize_Click);
      // 
      // txtSource
      // 
      this.txtSource.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.txtSource.BackColor = System.Drawing.SystemColors.Control;
      this.txtSource.Name = "txtSource";
      this.txtSource.Size = new System.Drawing.Size(480, 396);
      this.txtSource.TabIndex = 1;
      this.txtSource.Text = "";
      this.txtSource.TextChanged += new System.EventHandler(this.txtSource_TextChanged);
      this.txtSource.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.LinkClicked);
      // 
      // btnMenu
      // 
      this.btnMenu.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
      this.btnMenu.Location = new System.Drawing.Point(8, 452);
      this.btnMenu.Name = "btnMenu";
      this.btnMenu.Size = new System.Drawing.Size(88, 36);
      this.btnMenu.TabIndex = 2;
      this.btnMenu.Text = "&Menu";
      this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
      this.btnMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMenu_MouseDown);
      // 
      // menuMenu
      // 
      this.menuMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                             this.menuMenuExit});
      // 
      // menuMenuExit
      // 
      this.menuMenuExit.Index = 0;
      this.menuMenuExit.Text = "E&xit";
      this.menuMenuExit.Click += new System.EventHandler(this.menuMenuExit_Click);
      // 
      // panItems
      // 
      this.panItems.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                           this.panDefinition,
                                                                           this.splDefinition,
                                                                           this.panTerms});
      this.panItems.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panItems.Location = new System.Drawing.Point(8, 8);
      this.panItems.Name = "panItems";
      this.panItems.Size = new System.Drawing.Size(462, 130);
      this.panItems.TabIndex = 0;
      // 
      // panDefinition
      // 
      this.panDefinition.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                this.txtDefinition,
                                                                                this.lblDefinition});
      this.panDefinition.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panDefinition.DockPadding.Bottom = 8;
      this.panDefinition.Location = new System.Drawing.Point(236, 0);
      this.panDefinition.Name = "panDefinition";
      this.panDefinition.Size = new System.Drawing.Size(226, 130);
      this.panDefinition.TabIndex = 2;
      // 
      // txtDefinition
      // 
      this.txtDefinition.BackColor = System.Drawing.SystemColors.Control;
      this.txtDefinition.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtDefinition.Location = new System.Drawing.Point(0, 16);
      this.txtDefinition.Name = "txtDefinition";
      this.txtDefinition.ReadOnly = true;
      this.txtDefinition.Size = new System.Drawing.Size(226, 106);
      this.txtDefinition.TabIndex = 1;
      this.txtDefinition.Text = "";
      // 
      // lblDefinition
      // 
      this.lblDefinition.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblDefinition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblDefinition.Name = "lblDefinition";
      this.lblDefinition.Size = new System.Drawing.Size(226, 16);
      this.lblDefinition.TabIndex = 0;
      this.lblDefinition.Text = "Definitions:";
      // 
      // splDefinition
      // 
      this.splDefinition.Location = new System.Drawing.Point(228, 0);
      this.splDefinition.MinExtra = 75;
      this.splDefinition.MinSize = 75;
      this.splDefinition.Name = "splDefinition";
      this.splDefinition.Size = new System.Drawing.Size(8, 130);
      this.splDefinition.TabIndex = 1;
      this.splDefinition.TabStop = false;
      this.splDefinition.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splDefinition_SplitterMoved);
      // 
      // panTerms
      // 
      this.panTerms.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                           this.lstTermList,
                                                                           this.splTerms,
                                                                           this.txtMultiTerm,
                                                                           this.lblTermList});
      this.panTerms.Dock = System.Windows.Forms.DockStyle.Left;
      this.panTerms.DockPadding.Bottom = 8;
      this.panTerms.Name = "panTerms";
      this.panTerms.Size = new System.Drawing.Size(228, 130);
      this.panTerms.TabIndex = 0;
      // 
      // lstTermList
      // 
      this.lstTermList.BackColor = System.Drawing.SystemColors.Control;
      this.lstTermList.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lstTermList.IntegralHeight = false;
      this.lstTermList.Location = new System.Drawing.Point(0, 16);
      this.lstTermList.Name = "lstTermList";
      this.lstTermList.Size = new System.Drawing.Size(228, 78);
      this.lstTermList.TabIndex = 2;
      this.lstTermList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstTermList_MouseDown);
      this.lstTermList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstTermList_KeyPress);
      this.lstTermList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lstTermList_MouseMove);
      this.lstTermList.SelectedIndexChanged += new System.EventHandler(this.lstTermList_SelectedIndexChanged);
      // 
      // splTerms
      // 
      this.splTerms.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.splTerms.Location = new System.Drawing.Point(0, 94);
      this.splTerms.Name = "splTerms";
      this.splTerms.Size = new System.Drawing.Size(228, 8);
      this.splTerms.TabIndex = 1;
      this.splTerms.TabStop = false;
      this.splTerms.Visible = false;
      // 
      // txtMultiTerm
      // 
      this.txtMultiTerm.BackColor = System.Drawing.SystemColors.Control;
      this.txtMultiTerm.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.txtMultiTerm.Location = new System.Drawing.Point(0, 102);
      this.txtMultiTerm.Name = "txtMultiTerm";
      this.txtMultiTerm.ReadOnly = true;
      this.txtMultiTerm.Size = new System.Drawing.Size(228, 20);
      this.txtMultiTerm.TabIndex = 3;
      this.txtMultiTerm.Text = "";
      this.txtMultiTerm.Visible = false;
      // 
      // lblTermList
      // 
      this.lblTermList.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblTermList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblTermList.Name = "lblTermList";
      this.lblTermList.Size = new System.Drawing.Size(228, 16);
      this.lblTermList.TabIndex = 0;
      this.lblTermList.Text = "Terms:";
      // 
      // frmMain
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(496, 493);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.btnPlayer,
                                                                  this.btnExit,
                                                                  this.btnTest,
                                                                  this.btnMenu,
                                                                  this.panDesigner,
                                                                  this.panSource});
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Menu = this.menuMain;
      this.MinimumSize = new System.Drawing.Size(368, 480);
      this.Name = "frmMain";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Study Guide Editor [Design]";
      this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMain_Closing);
      this.SizeChanged += new System.EventHandler(this.frmMain_SizeChanged);
      this.Load += new System.EventHandler(this.frmMain_Load);
      this.Activated += new System.EventHandler(this.frmMain_Activated);
      this.grpInfo.ResumeLayout(false);
      this.panSheet.ResumeLayout(false);
      this.panTermsModify.ResumeLayout(false);
      this.panAdd.ResumeLayout(false);
      this.grpAdd.ResumeLayout(false);
      this.panAddItem.ResumeLayout(false);
      this.panAddDefinition.ResumeLayout(false);
      this.panAddTermFooter.ResumeLayout(false);
      this.panAddTerm.ResumeLayout(false);
      this.panAddTermTextBox.ResumeLayout(false);
      this.panInfo.ResumeLayout(false);
      this.panDesigner.ResumeLayout(false);
      this.panSource.ResumeLayout(false);
      this.panItems.ResumeLayout(false);
      this.panDefinition.ResumeLayout(false);
      this.panTerms.ResumeLayout(false);
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
      
      // Load sheet
      if (args.Length > 0)
      {
        if (args[0] == ".") form.DoNew();
        else form.DoOpen(args[0]);
      }
      
      // Run app
      Application.Run(form);
    }
    
    #endregion
    
    
    private void frmMain_Load(object sender, System.EventArgs e)
    {
      // Populate context menu
      menuMenu.MenuItems.RemoveAt(0);       // Remove 'Exit' menu item
      menuMenu.MergeMenu(menuFile);         // Append 'File' menu items
      menuMenu.MenuItems.RemoveAt(7);       // Remove 'File' menu's exit
      menuMenu.MergeMenu(menuTools);        // Append 'Editor' menu items
      menuMenu.MergeMenu(menuHelp);        // Append 'About' menu items
      menuMenu.MenuItems.Add("-");          // Add a separator menu item
      menuMenu.MenuItems.Add(menuMenuExit); // Add the 'Exit' menu item
      
      // Close all checks via the CheckedChanged functions
      chkInfo.Checked = false;
      chkAdd.Checked = false;
      
      // Adjust min/max sizes
      splAdd.MinSize = (chkMultiTerm.Height + lblTermsAdd.Height + txtAuthor.Height + chkMultiTerm.Height) + 8;
      splAdd.MinExtra = (lblTermList.Height + txtAuthor.Height + splTerms.Height + txtAuthor.Height + panTermsModify.Height) + 16;
      
      // Show designer mode
      DoShowDesigner();
    }
    
    private void frmMain_Activated(object sender, System.EventArgs e)
    {
      if (m_Sheet != null)
      {
        if (m_DesignMode)
        {
          if (m_Sheet.Title == "")
            txtTitle.Focus();
          else if ((chkInfo.Checked) && (m_Sheet.Author == ""))
            txtAuthor.Focus();
          else if ((chkInfo.Checked) && (m_Sheet.Description == ""))
            txtDescription.Focus();
          else if ((lstTermList.Items.Count == 0) && (chkAdd.Checked))
            txtTermsAdd.Focus();
          else
            lstTermList.Focus();
        }
        else
          txtSource.Focus();
      }
      else
        btnMenu.Focus();
    }
    
    private void frmMain_SizeChanged(object sender, System.EventArgs e)
    {
      if (this.WindowState == FormWindowState.Minimized) return;
      splAddSep.SplitPosition = splAddSep.SplitPosition;
    }
    
    private void frmMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    { if (!DoClose()) e.Cancel = true; }
    
    
    
    private void menuFileNew_Click(object sender, System.EventArgs e)
    { DoNew(); }
    private void menuFileOpen_Click(object sender, System.EventArgs e)
    { DoOpen(); }
    private void menuFileClose_Click(object sender, System.EventArgs e)
    { DoClose(); }
    private void menuFileSave_Click(object sender, System.EventArgs e)
    { DoSave(); }
    private void menuFileSaveAs_Click(object sender, System.EventArgs e)
    { DoSaveAs(); }
    private void menuViewSource_Click(object sender, System.EventArgs e)
    {
      if (!m_DesignMode) return;
      
      DoShowSource();
      frmMain_Activated(this, new EventArgs());
    }
    private void menuViewDesigner_Click(object sender, System.EventArgs e)
    {
      if (m_DesignMode) return;
      
      DoShowDesigner();
      frmMain_Activated(this, new EventArgs());
    }
    private void menuEditorPreferences_Click(object sender, System.EventArgs e)
    { DoPreferences(); }
    private void menuHelpAbout_Click(object sender, System.EventArgs e)
    { DoAbout(); }
    private void menuFileExit_Click(object sender, System.EventArgs e)
    { this.Close(); }
    private void menuMenuExit_Click(object sender, System.EventArgs e)
    { this.Close(); }
    
    
    private void btnMenu_Click(object sender, System.EventArgs e)
    { menuMenu.GetContextMenu().Show(btnMenu.Parent, new Point(btnMenu.Left, btnMenu.Bottom)); }
    private void btnMenu_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    { menuMenu.GetContextMenu().Show(btnMenu.Parent, new Point(btnMenu.Left, btnMenu.Bottom)); }
    
    private void btnTest_Click(object sender, System.EventArgs e)
    { DoTest(); }
    private void btnPlayer_Click(object sender, System.EventArgs e)
    { DoShowPlayer(); }
    private void btnExit_Click(object sender, System.EventArgs e)
    { this.Close(); }
    
    private void btnAddTerm_Click(object sender, System.EventArgs e)
    { DoAddTerm(); }
    
    private void btnNormalize_Click(object sender, System.EventArgs e)
    {
      if (m_Sheet == null) return;
      
      string s = MatchingSheet.Normalize(txtSource.Text);
      if (s != txtSource.Text) txtSource.Text = s;
      txtSource.Focus();
    }
    private void txtSource_TextChanged(object sender, System.EventArgs e)
    { if ((!m_InternalEditing) && (m_Sheet != null)) DoMakeDirty(); }
    
    
    
    private void txtTitle_Enter(object sender, System.EventArgs e)
    {
      if (m_Sheet == null) return;  // Failsafe
      if (m_Sheet.Title == "")
      {
        txtTitle.SelectionStart = 0; txtTitle.SelectionLength = 0;
        SetTitle(""); txtTitle.ForeColor = Color.FromKnownColor(KnownColor.InfoText);
        return;
      }
      
      txtTitle.SelectionStart = 0; txtTitle.SelectionLength = txtTitle.TextLength;
    }
    private void txtTitle_Leave (object sender, System.EventArgs e)
    {
      if (m_Sheet == null) return;  // Failsafe
      
      if (txtTitle.Text == "")
      {
        m_Sheet.Title = "";
        SetTitle("( untitled )"); txtTitle.ForeColor = Color.FromKnownColor(KnownColor.GrayText);
        txtTitle.SelectionStart = 0; txtTitle.SelectionLength = 0;
      }
    }
    private void txtTitle_TextChanged(object sender, System.EventArgs e)
    {
      if (m_Sheet == null) return;  // Failsafe
      if (m_InternalEditing) return;
      
      // Set 'title' info
      m_Sheet.Title = txtTitle.Text;
      DoMakeDirty();
    }
    
    private void txtGroup_Enter(object sender, System.EventArgs e)
    {
      if (m_Sheet == null) return;  // Failsafe
      if (m_Sheet.Group == "")
      {
        txtGroup.SelectionStart = 0; txtGroup.SelectionLength = 0;
        txtGroup.Text = ""; txtGroup.ForeColor = Color.FromKnownColor(KnownColor.WindowText);
        return;
      }
      
      txtGroup.SelectionStart = 0; txtGroup.SelectionLength = txtGroup.TextLength;
    }
    private void txtGroup_Leave(object sender, System.EventArgs e)
    {
      if (m_Sheet == null) return;  // Failsafe
      
      // Set 'group' info
      if (txtGroup.Text == "")
      {
        m_Sheet.Group = "";
        SetGroup("( All Groups )"); txtGroup.ForeColor = Color.FromKnownColor(KnownColor.GrayText);
        txtGroup.SelectionStart = 0; txtGroup.SelectionLength = 0;
      }
    }
    private void txtGroup_TextChanged(object sender, System.EventArgs e)
    {
      if (m_Sheet == null) return;  // Failsafe
      if (m_InternalEditing) return;
      
      // Set 'group' info
      m_Sheet.Group = txtGroup.Text;
      DoMakeDirty();
    }
    
    private void txtAuthor_TextChanged(object sender, System.EventArgs e)
    {
      if (m_Sheet == null) return;
      if (m_InternalEditing) return;
      
      // Set 'author' info
      m_Sheet.Author = txtAuthor.Text;
      DoMakeDirty();
    }
    
    private void txtDescription_TextChanged(object sender, System.EventArgs e)
    {
      if (m_Sheet == null) return;
      if (m_InternalEditing) return;
      
      // Set 'description' info
      m_Sheet.Description = txtDescription.Text;
      DoMakeDirty();
    }
    
    
    
    private void btnDelete_Click(object sender, System.EventArgs e)
    {
      // !!!!!
    }
    
    
    private void chkInfo_CheckedChanged(object sender, System.EventArgs e)
    {
      // Show/hide 'Sheet Information'
      this.SuspendLayout();
      grpInfo.Enabled = chkInfo.Checked;
      panInfo.Height = (( chkInfo.Checked )?( txtDescription.Top + txtDescription.Height + 8 ):( chkInfo.Height + 4 ));
      panSheet.Top = panInfo.Top + panInfo.Height + 8;
      panSheet.Height = (panDesigner.Height - panSheet.Top);
      this.ResumeLayout();
      
      if ((m_Sheet != null) && (chkInfo.Checked))
      {
        if (m_Sheet.Author == "")
          txtAuthor.Focus();
        else if (m_Sheet.Description == "")
          txtDescription.Focus();
      }
    }
    private void chkAdd_CheckedChanged(object sender, System.EventArgs e)
    {
      // Show/hide 'Add Item'
      this.SuspendLayout();
      grpAdd.Enabled = chkAdd.Checked;
      if (!chkAdd.Checked) m_AddHeight = panAdd.Height;
      panAdd.Height = (( chkAdd.Checked )?( m_AddHeight ):( chkAdd.Height + 4 ));
      splAdd.Enabled = chkAdd.Checked;
      this.ResumeLayout();
      
      if ((m_Sheet != null) && (chkAdd.Checked)) txtTermsAdd.Focus();
    }
    
    private bool grpAddFocus;
    private void grpAdd_Enter(object sender, System.EventArgs e)
    { grpAddFocus = true;  this.AcceptButton = btnAddTerm; }
    private void grpAdd_Leave(object sender, System.EventArgs e)
    { grpAddFocus = false; this.AcceptButton = null; }
    private void txtTermsAdd_Enter(object sender, System.EventArgs e)
    { if (chkMultiTerm.Checked) this.AcceptButton = null; }
    private void txtTermsAdd_Leave(object sender, System.EventArgs e)
    { this.AcceptButton = (( grpAddFocus )?( btnAddTerm ):( null )); }
    
    private void chkReadOnly_CheckedChanged(object sender, System.EventArgs e)
    {
      // !!!!!
    }
    
    private void lstTermList_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
      // !!!!! shortcut keys
    }
    
    
    
    private void lstTermList_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    { if (e.Button == MouseButtons.Left) lstTermList_SelectedIndexChanged(sender, new EventArgs()); }
    private void lstTermList_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
    { if (e.Button == MouseButtons.Left) lstTermList_SelectedIndexChanged(sender, new EventArgs()); }
    private void lstTermList_SelectedIndexChanged (object sender, System.EventArgs e)
    {
      if (m_Sheet == null) return;
      
      if (lstTermList.SelectedIndex != -1)
      {
        txtDefinition.Text = "";  // !!!!!
        txtDefinition.ReadOnly = chkReadOnly.Checked;
      }
      else
      {
        txtDefinition.Text = "";
        txtDefinition.ReadOnly = true;
      }
    }
    
    private void LinkClicked (object sender, System.Windows.Forms.LinkClickedEventArgs e)
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
      if (!DoClose()) return false;
      
      DoUpdateSheet(new MatchingSheet());
      DoMakeDirty();
      
      if (m_DesignMode)
        txtTitle.Focus();
      else
        txtSource.Focus();
      
      return true;
    }
    
    private bool DoOpen ()
    {
      if (openFileDialog.ShowDialog(this) != DialogResult.OK) return false;
      return DoOpen(openFileDialog.FileName);
    }
    private bool DoOpen (string FileName)
    {
      if (!DoClose()) return false;
      string s = "";
      
      try
      {
        TextReader file = new StreamReader(FileName);
        s = file.ReadToEnd();
        file.Close();
      }
      catch (IOException e)
      {
        MessageBox.Show(this, e.Message, "File Load Error");
        return false;
      }
      
      MatchingSheet sheet = MatchingSheet.FromString(s, FileName);
      if (sheet == null) return false;
      
      DoUpdateSheet(sheet);
      DoMakeDirty(false);
      SetSource(s);
      
      chkAdd.Checked = (m_Sheet.TermCount == 0);
      if (m_DesignMode)
        lstTermList.Focus();
      else
        txtSource.Focus();
      
      return true;
    }
    private bool DoOpen (MatchingSheet sheet)
    {
      if (sheet == null) return false;
      if (!DoClose()) return false;
      
      DoUpdateSheet(sheet);
      DoMakeDirty(false);
      
      chkAdd.Checked = (m_Sheet.TermCount == 0);
      if (m_DesignMode)
        lstTermList.Focus();
      else
        txtSource.Focus();
      
      return true;
    }
    
    private bool DoClose ()
    {
      if (m_Sheet == null) return true;
      
      if (m_SheetDirty)
      {
        DialogResult result;
        if (m_Sheet.FileName == "")
          result = MessageBox.Show(this, "Save first?", "Study Sheet Editor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        else
          result = MessageBox.Show(this, "Save changes to " + m_Sheet.FileName + "?", "Study Sheet Editor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        
        if (result == DialogResult.Yes)
          if (!DoSave()) return false;
        if (result == DialogResult.Cancel) return false;
      }
      
      DoUpdateSheet(null);
      DoMakeDirty(false);
      
      // Make sure sheet is empty
      chkAdd.Checked = false;
      txtSource.Text = "";
      btnMenu.Focus();
      return true;
    }
    
    private bool DoSave ()
    {
      if (m_Sheet == null) return false;
      if (m_Sheet.FileName == "")
        if (!DoSaveAs()) return false;
      
      DoMakeDirty(false);
      
      try
      {
        if (txtSource.Text == "")
        { m_Sheet.Save(); }
        else
        {
          StreamWriter file = new StreamWriter(m_Sheet.FileName);
          file.Write(txtSource.Text);
          file.Flush(); file.Close();
        }
      }
      catch (IOException e)
      {
        MessageBox.Show(this, e.Message, "File Load Error");
        return false;
      }
      
      return true;
    }
    
    private bool DoSaveAs (string FileName)
    {
      m_Sheet.FileName = FileName;
      return DoSave();
    }
    private bool DoSaveAs ()
    {
      if (m_Sheet == null) return false;
      
      saveFileDialog.FileName = GetSheetFileName();
      if (saveFileDialog.ShowDialog(this) != DialogResult.OK) return false;
      return DoSaveAs(saveFileDialog.FileName);
    }
    
    
    
    private void DoShowSource ()
    { DoShowMode(false); }
    private void DoShowDesigner ()
    { DoShowMode(true); }
    
    private void DoShowMode (bool DesignerMode)
    {
      MatchingSheet sheet = null;
      
      if (m_Sheet != null)
      {
        if (m_DesignMode)
          sheet = m_Sheet;
        else
          sheet = MatchingSheet.FromString(txtSource.Text, m_Sheet.FileName);
        
        DoUpdateSheet(null);
      }
      
      m_DesignMode = DesignerMode;
      DoUpdateSheet(sheet);
      UpdateWindowText();
      
      SuspendLayout();
      menuDesigner.Visible = m_DesignMode;
      panDesigner.Visible = m_DesignMode;
      panSource.Visible = !m_DesignMode;
      ResumeLayout();
    }
    
    private bool DoPreferences ()
    {
      // !!!!!
      MessageBox.Show(":: Preferences ::");
      return true;
    }
    
    private bool DoAbout ()
    {
      frmAbout form = new frmAbout();
      form.ShowDialog(this);
      return true;
    }
    
    
    private bool DoTest ()
    {
      if (!DoSave()) return false;
      return DoShowPlayer();
    }
    
    private bool DoShowPlayer ()
    { return DoShowPlayer(""); }
    private bool DoShowPlayer (string arguments)
    {
      try
      { System.Diagnostics.Process.Start(Path.Combine(Application.StartupPath, "Study Guide"), (( arguments == "" )?( "" ):('"' + arguments + '"')) ); }
      catch (Win32Exception e)
      {
        // Failsafe
        MessageBox.Show(this, "Could not run editor:\n\n" + e.Message, "Study Guide Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
      }
      
      return true;
    }
    
    
    private void DoAddTerm ()
    {
      // Failsafe
      if (txtTermsAdd.Text == "")
      {
        MessageBox.Show(this, "Could not add; required term.", "Study Guide Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        txtTermsAdd.Focus();
        return;
      }
      if (txtDefinitionAdd.Text == "")
      {
        MessageBox.Show(this, "Could not add; required definition.", "Study Guide Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        txtDefinitionAdd.Focus();
        return;
      }
      
      DoAddTerm(txtTermsAdd.Text, txtDefinitionAdd.Text);
      
      txtTermsAdd.Text = "";
      txtDefinitionAdd.Text = "";
      txtTermsAdd.Focus();
    }
    private void DoAddTerm (string term, string definition)
    {
      // !!!!! Add unique
      
      string [] terms = new String [(m_Sheet.Terms.Length + 1)];
      m_Sheet.Terms.CopyTo(terms, 0);
      terms[m_Sheet.Terms.Length] = term;
      m_Sheet.Terms = terms;
      
      string [] definitions = new String [(m_Sheet.Definitions.Length + 1)];
      m_Sheet.Definitions.CopyTo(definitions, 0);
      definitions[m_Sheet.Definitions.Length] = definition;
      m_Sheet.Definitions = definitions;
      
      // Add to list
      lstTermList.Items.Add(m_Sheet.Terms[(m_Sheet.Terms.Length - 1)]);
      
      DoMakeDirty();
      DoUpdateSheetItems();
    }
    
    
    private string GetSheetTitle ()
    {
      if (m_Sheet == null) return "";
      return (( (txtTitle.Text == "") || (txtTitle.Text == "( untitled )") )?( "Untitled" ):( txtTitle.Text ));
    }
    private string GetSheetFileTitle ()
    {
      if (m_Sheet == null) return "";
      return (( m_Sheet.FileName == "" )?( GetSheetTitle() ):( Path.GetFileName(m_Sheet.FileName) ));
    }
    private string GetSheetFileName ()
    {
      if (m_Sheet == null) return "";
      return (( m_Sheet.FileName == "" )?( GetSheetTitle() ):( m_Sheet.FileName ));
    }
    
    private void DoMakeDirty ()
    { DoMakeDirty(true); }
    private void DoMakeDirty (bool IsDirty)
    {
      m_SheetDirty = IsDirty;
      if (m_DesignMode && IsDirty)
        SetSource("");
      UpdateWindowText();
    }
    
    private void DoUpdateSheet (MatchingSheet sheet, bool IsDirty)
    {
      DoMakeDirty(IsDirty);
      DoUpdateSheet(sheet);
    }
    private void DoUpdateSheet (MatchingSheet sheet)
    {
      m_Sheet = sheet;
      DoUpdateSheet();
    }
    private void DoUpdateSheet ()
    {
      SuspendLayout();
      m_InternalEditing = true;
      
      if (m_Sheet != null)
      {
        menuFileClose.Enabled = true;
        menuFileSave.Enabled = true;
        menuFileSaveAs.Enabled = true;
        menuDesignerAddTerm.Enabled = true;
        
        Color cbg = Color.FromKnownColor(KnownColor.Window);
        
        if (!m_DesignMode)
        {
          txtSource.BackColor = cbg;
          if (txtSource.Text == "")
            txtSource.Text = m_Sheet.ToString();   // Get sheet text from sheet data
          txtSource.ReadOnly = false;
          btnNormalize.Enabled = true;
        }
        else
        {
          txtTitle.ForeColor = Color.FromKnownColor(KnownColor.InfoText);
          txtTitle.BackColor = Color.FromKnownColor(KnownColor.Info);
          txtTitle.ReadOnly = false;
          txtTitle.Text = m_Sheet.Title; txtTitle_Leave(txtTitle, new EventArgs());
          
          txtAuthor.BackColor = cbg; txtAuthor.ReadOnly = false; txtAuthor.Text = m_Sheet.Author;
          txtDescription.BackColor = cbg; txtDescription.ReadOnly = false; txtDescription.Text = m_Sheet.Description;
          txtGroup.BackColor = cbg; txtGroup.ReadOnly = false; txtGroup.Text = m_Sheet.Group;
          txtGroup_Leave(txtGroup, new EventArgs());
          
          lstTermList.Items.Clear();
          if (m_Sheet.TermCount > 0)
          {
            lstTermList.BeginUpdate();
            for (int i = 0; i < m_Sheet.TermCount; i++)
            {
              lstTermList.Items.Add(m_Sheet.Terms[i]);
            }
            lstTermList.EndUpdate();
          }
          lstTermList.BackColor = cbg;
          txtDefinition.BackColor = cbg; lstTermList_SelectedIndexChanged(lstTermList, new EventArgs());
          
          chkReadOnly.Enabled = true; chkReadOnly.Checked = true;
          
          txtTermsAdd.BackColor = cbg; txtTermsAdd.ReadOnly = false;
          txtDefinitionAdd.BackColor = cbg; txtDefinitionAdd.ReadOnly = false;
          chkMultiTerm.Enabled = true;
          btnAddTerm.Enabled = true;
        }
      }
      else
      {
        menuFileClose.Enabled = false;
        menuFileSave.Enabled = false;
        menuFileSaveAs.Enabled = false;
        menuDesignerAddTerm.Enabled = false;
        
        Color cbg = Color.FromKnownColor(KnownColor.Control);
        
        if (!m_DesignMode)
        {
          txtSource.ReadOnly = true;
          txtSource.BackColor = cbg;
          btnNormalize.Enabled = false;
          // Source text (txtSource.Text) stays the same
        }
        else
        {
          txtTitle.ForeColor = Color.FromKnownColor(KnownColor.GrayText);
          txtTitle.BackColor = Color.FromKnownColor(KnownColor.Control);
          txtTitle.ReadOnly = true;
          txtTitle.Text = "( nothing loaded )";
          
          txtAuthor.BackColor = cbg; txtAuthor.ReadOnly = true; txtAuthor.Text = "";
          txtDescription.BackColor = cbg; txtAuthor.ReadOnly = true; txtDescription.Text = "";
          txtGroup.BackColor = cbg; txtAuthor.ReadOnly = true; txtGroup.Text = "";
          
          lstTermList.Items.Clear();
          lstTermList.BackColor = cbg;
          txtDefinition.BackColor = cbg; txtDefinition.ReadOnly = true;
          
          chkReadOnly.Enabled = false; chkReadOnly.Checked = false;
          
          txtTermsAdd.BackColor = cbg; txtTermsAdd.ReadOnly = true; txtTermsAdd.Text = "";
          txtDefinitionAdd.BackColor = cbg; txtDefinitionAdd.ReadOnly = true; txtDefinitionAdd.Text = "";
          chkMultiTerm.Enabled = false;
          btnAddTerm.Enabled = false;
        }
      }
      
      DoUpdateSheetItems();
      
      m_InternalEditing = false;
      ResumeLayout();
    }
    
    private void DoUpdateSheetItems ()
    {
      btnDelete.Enabled = ((m_Sheet != null) && (m_Sheet.Terms.Length > 0));
      btnTest.Enabled = btnDelete.Enabled;
    }
    
    
    
    private void SetSource (string s)
    { SetInternalControlText(txtSource, s); }
    private void SetTitle (string s)
    { SetInternalControlText(txtTitle, s); }
    private void SetGroup (string s)
    { SetInternalControlText(txtGroup, s); }
    private void SetAuthor (string s)
    { SetInternalControlText(txtAuthor, s); }
    private void SetDescription (string s)
    { SetInternalControlText(txtDescription, s); }
    
    
    private void SetInternalControlText (Control control, string s)
    {
      if (m_InternalEditing)
      { control.Text = s; return; }
      
      m_InternalEditing = true;
      control.Text = s;
      m_InternalEditing = false;
    }
    
    private void UpdateWindowText ()
    {
      this.Text = c_Title + (( m_DesignMode )?( " [Design]" ):( "" ));
      if (m_Sheet != null)
        this.Text += (( m_Sheet.FileName == "" )?( "" ):( " - " + Path.GetFileName(m_Sheet.FileName) )) + (( m_SheetDirty )?( " *" ):( "" ));
    }
    
    // !!!!! Option:
    private void splDefinition_SplitterMoved(object sender, System.Windows.Forms.SplitterEventArgs e)
    {
      if (this.WindowState == FormWindowState.Minimized) return;
      int newPos = ((splDefinition.SplitPosition - 2) - 1);
      if (splAddSep.SplitPosition != newPos) splAddSep.SplitPosition = newPos;
    }
    private void splAddSep_SplitterMoved(object sender, System.Windows.Forms.SplitterEventArgs e)
    {
      if (this.WindowState == FormWindowState.Minimized) return;
      int newPos = ((splAddSep.SplitPosition + 2) + 1);
      if (splDefinition.SplitPosition != newPos) splDefinition.SplitPosition = newPos;
    }
    
    private void txtTermsAdd_MultilineChanged(object sender, System.EventArgs e)
    { panAddTermTextBox_SizeChanged(sender, new EventArgs()); }
    
    private void panAddTermTextBox_SizeChanged(object sender, System.EventArgs e)
    {
      txtTermsAdd.Height = (panAddTermTextBox.Height - (chkMultiTerm.Height + 1));
      chkMultiTerm.Top = (txtTermsAdd.Top + (txtTermsAdd.Height + 2));
    }
    private void chkMultiTerm_CheckedChanged(object sender, System.EventArgs e)
    {
      txtTermsAdd.Multiline = chkMultiTerm.Checked;
      if ((!txtTermsAdd.Multiline) && (txtTermsAdd.Lines.Length > 0))
        txtTermsAdd.Text = txtTermsAdd.Lines[0];
      chkMultiTerm.Text = (( chkMultiTerm.Checked )?( "Multiple Te&rms (one per line)" ):( "Multiple Te&rms" ));
      
      if (m_DesignMode)
      { chkAdd.Checked = true; txtTermsAdd.Focus(); }
    }
    
    private void menuDesignerAddTerm_Click(object sender, System.EventArgs e)
    {
      if (m_Sheet == null) return;
      chkAdd.Checked = true;
      txtTermsAdd.Focus();
    }
    
  }
}

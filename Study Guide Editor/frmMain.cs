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
    
    private bool m_SheetDirty = false;
    private MatchingSheet m_Sheet = null;
    private int m_AddHeight = 0;
    
    #region Controls
    
    private System.Windows.Forms.TextBox txtTitle;
    private System.Windows.Forms.Label lblAuthor;
    private System.Windows.Forms.TextBox txtAuthor;
    private System.Windows.Forms.TextBox txtGroup;
    private System.Windows.Forms.Label lblGroup;
    private System.Windows.Forms.TextBox txtDescription;
    private System.Windows.Forms.Label lblDescription;
    private System.Windows.Forms.CheckBox chkInfo;
    private System.Windows.Forms.GroupBox grpInfo;
    private System.Windows.Forms.Panel panSheet;
    private System.Windows.Forms.Label lblTermList;
    private System.Windows.Forms.Label lblDefinition;
    private System.Windows.Forms.ListBox lstTermList;
    private System.Windows.Forms.GroupBox grpAdd;
    private System.Windows.Forms.CheckBox chkMultiTerm;
    private System.Windows.Forms.Button btnAddTerm;
    private System.Windows.Forms.TextBox txtTermsAdd;
    private System.Windows.Forms.CheckBox chkAdd;
    private System.Windows.Forms.Label lblTermsAdd;
    private System.Windows.Forms.Label lblDefinitionAdd;
    private System.Windows.Forms.TextBox txtMultiTerm;
    private System.Windows.Forms.Panel panTerms;
    private System.Windows.Forms.Panel panAdd;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.CheckBox chkEdit;
    private System.Windows.Forms.RichTextBox rtbDefinition;
    private System.Windows.Forms.RichTextBox rtbDefinitionAdd;
    private System.Windows.Forms.Splitter splAdd;
    private System.Windows.Forms.Splitter splDefinition;
    private System.Windows.Forms.Splitter splTerms;
    private System.Windows.Forms.ContextMenu menuMain;
    private System.Windows.Forms.MenuItem menuMainNew;
    private System.Windows.Forms.MenuItem menuMainOpen;
    private System.Windows.Forms.MenuItem menuMainSave;
    private System.Windows.Forms.MenuItem menuMainSaveAs;
    private System.Windows.Forms.MenuItem menuMainClose;
    private System.Windows.Forms.MenuItem menuMainLine01;
    private System.Windows.Forms.MenuItem menuMainLine02;
    private System.Windows.Forms.MenuItem menuMainExit;
    private System.Windows.Forms.Button btnMenu;
    private System.Windows.Forms.Button btnExit;
    private System.Windows.Forms.Button btnTest;
    private System.Windows.Forms.Panel panDefinition;
    private System.Windows.Forms.Panel panTermsModify;
    private System.Windows.Forms.Button btnPlayer;
    private System.Windows.Forms.OpenFileDialog openFileDialog;
    private System.Windows.Forms.MenuItem menuMainLine03;
    private System.Windows.Forms.MenuItem menuMainPreferences;
    private System.Windows.Forms.MenuItem menuMainAbout;
    private System.Windows.Forms.SaveFileDialog saveFileDialog;
		
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
      this.txtDescription = new System.Windows.Forms.TextBox();
      this.lblDescription = new System.Windows.Forms.Label();
      this.grpInfo = new System.Windows.Forms.GroupBox();
      this.chkInfo = new System.Windows.Forms.CheckBox();
      this.panSheet = new System.Windows.Forms.Panel();
      this.panDefinition = new System.Windows.Forms.Panel();
      this.rtbDefinition = new System.Windows.Forms.RichTextBox();
      this.lblDefinition = new System.Windows.Forms.Label();
      this.splDefinition = new System.Windows.Forms.Splitter();
      this.panTerms = new System.Windows.Forms.Panel();
      this.lstTermList = new System.Windows.Forms.ListBox();
      this.splTerms = new System.Windows.Forms.Splitter();
      this.txtMultiTerm = new System.Windows.Forms.TextBox();
      this.lblTermList = new System.Windows.Forms.Label();
      this.panTermsModify = new System.Windows.Forms.Panel();
      this.chkEdit = new System.Windows.Forms.CheckBox();
      this.btnDelete = new System.Windows.Forms.Button();
      this.splAdd = new System.Windows.Forms.Splitter();
      this.panAdd = new System.Windows.Forms.Panel();
      this.chkAdd = new System.Windows.Forms.CheckBox();
      this.grpAdd = new System.Windows.Forms.GroupBox();
      this.chkMultiTerm = new System.Windows.Forms.CheckBox();
      this.btnAddTerm = new System.Windows.Forms.Button();
      this.txtTermsAdd = new System.Windows.Forms.TextBox();
      this.lblTermsAdd = new System.Windows.Forms.Label();
      this.lblDefinitionAdd = new System.Windows.Forms.Label();
      this.rtbDefinitionAdd = new System.Windows.Forms.RichTextBox();
      this.btnMenu = new System.Windows.Forms.Button();
      this.btnExit = new System.Windows.Forms.Button();
      this.btnTest = new System.Windows.Forms.Button();
      this.menuMain = new System.Windows.Forms.ContextMenu();
      this.menuMainNew = new System.Windows.Forms.MenuItem();
      this.menuMainOpen = new System.Windows.Forms.MenuItem();
      this.menuMainClose = new System.Windows.Forms.MenuItem();
      this.menuMainLine01 = new System.Windows.Forms.MenuItem();
      this.menuMainSave = new System.Windows.Forms.MenuItem();
      this.menuMainSaveAs = new System.Windows.Forms.MenuItem();
      this.menuMainLine02 = new System.Windows.Forms.MenuItem();
      this.menuMainPreferences = new System.Windows.Forms.MenuItem();
      this.menuMainAbout = new System.Windows.Forms.MenuItem();
      this.menuMainLine03 = new System.Windows.Forms.MenuItem();
      this.menuMainExit = new System.Windows.Forms.MenuItem();
      this.btnPlayer = new System.Windows.Forms.Button();
      this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
      this.grpInfo.SuspendLayout();
      this.panSheet.SuspendLayout();
      this.panDefinition.SuspendLayout();
      this.panTerms.SuspendLayout();
      this.panTermsModify.SuspendLayout();
      this.panAdd.SuspendLayout();
      this.grpAdd.SuspendLayout();
      this.SuspendLayout();
      // 
      // txtTitle
      // 
      this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.txtTitle.BackColor = System.Drawing.SystemColors.Control;
      this.txtTitle.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.txtTitle.ForeColor = System.Drawing.SystemColors.GrayText;
      this.txtTitle.Location = new System.Drawing.Point(8, 8);
      this.txtTitle.Name = "txtTitle";
      this.txtTitle.ReadOnly = true;
      this.txtTitle.Size = new System.Drawing.Size(480, 22);
      this.txtTitle.TabIndex = 0;
      this.txtTitle.Text = "( nothing loaded )";
      this.txtTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
      this.txtAuthor.Leave += new System.EventHandler(this.txtAuthor_Leave);
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
      this.txtGroup.Leave += new System.EventHandler(this.txtGroup_Leave);
      this.txtGroup.Enter += new System.EventHandler(this.txtGroup_Enter);
      // 
      // lblGroup
      // 
      this.lblGroup.Location = new System.Drawing.Point(8, 64);
      this.lblGroup.Name = "lblGroup";
      this.lblGroup.Size = new System.Drawing.Size(168, 16);
      this.lblGroup.TabIndex = 4;
      this.lblGroup.Text = "Group Name:";
      // 
      // txtDescription
      // 
      this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.txtDescription.BackColor = System.Drawing.SystemColors.Control;
      this.txtDescription.Location = new System.Drawing.Point(184, 36);
      this.txtDescription.Multiline = true;
      this.txtDescription.Name = "txtDescription";
      this.txtDescription.ReadOnly = true;
      this.txtDescription.Size = new System.Drawing.Size(288, 64);
      this.txtDescription.TabIndex = 3;
      this.txtDescription.Text = "";
      this.txtDescription.Leave += new System.EventHandler(this.txtDescription_Leave);
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
      this.grpInfo.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.grpInfo.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.lblGroup,
                                                                          this.lblDescription,
                                                                          this.txtAuthor,
                                                                          this.txtGroup,
                                                                          this.lblAuthor,
                                                                          this.txtDescription});
      this.grpInfo.Location = new System.Drawing.Point(8, 40);
      this.grpInfo.Name = "grpInfo";
      this.grpInfo.Size = new System.Drawing.Size(480, 108);
      this.grpInfo.TabIndex = 2;
      this.grpInfo.TabStop = false;
      this.grpInfo.Text = "File Information";
      // 
      // chkInfo
      // 
      this.chkInfo.Checked = true;
      this.chkInfo.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkInfo.Location = new System.Drawing.Point(16, 40);
      this.chkInfo.Name = "chkInfo";
      this.chkInfo.Size = new System.Drawing.Size(116, 16);
      this.chkInfo.TabIndex = 1;
      this.chkInfo.Text = "Sheet Information";
      this.chkInfo.CheckedChanged += new System.EventHandler(this.chkInfo_CheckedChanged);
      // 
      // panSheet
      // 
      this.panSheet.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.panSheet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panSheet.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                           this.panDefinition,
                                                                           this.splDefinition,
                                                                           this.panTerms,
                                                                           this.panTermsModify,
                                                                           this.splAdd,
                                                                           this.panAdd});
      this.panSheet.DockPadding.All = 8;
      this.panSheet.Location = new System.Drawing.Point(8, 156);
      this.panSheet.Name = "panSheet";
      this.panSheet.Size = new System.Drawing.Size(480, 329);
      this.panSheet.TabIndex = 3;
      // 
      // panDefinition
      // 
      this.panDefinition.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                this.rtbDefinition,
                                                                                this.lblDefinition});
      this.panDefinition.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panDefinition.Location = new System.Drawing.Point(236, 8);
      this.panDefinition.Name = "panDefinition";
      this.panDefinition.Size = new System.Drawing.Size(234, 139);
      this.panDefinition.TabIndex = 1;
      // 
      // rtbDefinition
      // 
      this.rtbDefinition.BackColor = System.Drawing.SystemColors.Control;
      this.rtbDefinition.Dock = System.Windows.Forms.DockStyle.Fill;
      this.rtbDefinition.Location = new System.Drawing.Point(0, 16);
      this.rtbDefinition.Name = "rtbDefinition";
      this.rtbDefinition.ReadOnly = true;
      this.rtbDefinition.Size = new System.Drawing.Size(234, 123);
      this.rtbDefinition.TabIndex = 1;
      this.rtbDefinition.Text = "";
      // 
      // lblDefinition
      // 
      this.lblDefinition.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblDefinition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblDefinition.Name = "lblDefinition";
      this.lblDefinition.Size = new System.Drawing.Size(234, 16);
      this.lblDefinition.TabIndex = 0;
      this.lblDefinition.Text = "Definition:";
      // 
      // splDefinition
      // 
      this.splDefinition.Location = new System.Drawing.Point(228, 8);
      this.splDefinition.Name = "splDefinition";
      this.splDefinition.Size = new System.Drawing.Size(8, 139);
      this.splDefinition.TabIndex = 0;
      this.splDefinition.TabStop = false;
      // 
      // panTerms
      // 
      this.panTerms.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                           this.lstTermList,
                                                                           this.splTerms,
                                                                           this.txtMultiTerm,
                                                                           this.lblTermList});
      this.panTerms.Dock = System.Windows.Forms.DockStyle.Left;
      this.panTerms.Location = new System.Drawing.Point(8, 8);
      this.panTerms.Name = "panTerms";
      this.panTerms.Size = new System.Drawing.Size(220, 139);
      this.panTerms.TabIndex = 0;
      // 
      // lstTermList
      // 
      this.lstTermList.BackColor = System.Drawing.SystemColors.Control;
      this.lstTermList.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lstTermList.IntegralHeight = false;
      this.lstTermList.Location = new System.Drawing.Point(0, 16);
      this.lstTermList.Name = "lstTermList";
      this.lstTermList.Size = new System.Drawing.Size(220, 95);
      this.lstTermList.Sorted = true;
      this.lstTermList.TabIndex = 1;
      this.lstTermList.SelectedIndexChanged += new System.EventHandler(this.lstTermList_SelectedIndexChanged);
      // 
      // splTerms
      // 
      this.splTerms.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.splTerms.Location = new System.Drawing.Point(0, 111);
      this.splTerms.MinExtra = 20;
      this.splTerms.MinSize = 20;
      this.splTerms.Name = "splTerms";
      this.splTerms.Size = new System.Drawing.Size(220, 8);
      this.splTerms.TabIndex = 2;
      this.splTerms.TabStop = false;
      this.splTerms.Visible = false;
      // 
      // txtMultiTerm
      // 
      this.txtMultiTerm.BackColor = System.Drawing.SystemColors.Control;
      this.txtMultiTerm.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.txtMultiTerm.Location = new System.Drawing.Point(0, 119);
      this.txtMultiTerm.Multiline = true;
      this.txtMultiTerm.Name = "txtMultiTerm";
      this.txtMultiTerm.ReadOnly = true;
      this.txtMultiTerm.Size = new System.Drawing.Size(220, 20);
      this.txtMultiTerm.TabIndex = 3;
      this.txtMultiTerm.Text = "";
      this.txtMultiTerm.Visible = false;
      // 
      // lblTermList
      // 
      this.lblTermList.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblTermList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblTermList.Name = "lblTermList";
      this.lblTermList.Size = new System.Drawing.Size(220, 16);
      this.lblTermList.TabIndex = 0;
      this.lblTermList.Text = "Terms:";
      // 
      // panTermsModify
      // 
      this.panTermsModify.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                 this.chkEdit,
                                                                                 this.btnDelete});
      this.panTermsModify.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panTermsModify.Location = new System.Drawing.Point(8, 147);
      this.panTermsModify.Name = "panTermsModify";
      this.panTermsModify.Size = new System.Drawing.Size(462, 32);
      this.panTermsModify.TabIndex = 2;
      // 
      // chkEdit
      // 
      this.chkEdit.Appearance = System.Windows.Forms.Appearance.Button;
      this.chkEdit.Enabled = false;
      this.chkEdit.Location = new System.Drawing.Point(0, 4);
      this.chkEdit.Name = "chkEdit";
      this.chkEdit.Size = new System.Drawing.Size(68, 28);
      this.chkEdit.TabIndex = 0;
      this.chkEdit.Text = "&Edit";
      this.chkEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.chkEdit.CheckedChanged += new System.EventHandler(this.chkEdit_CheckedChanged);
      // 
      // btnDelete
      // 
      this.btnDelete.Enabled = false;
      this.btnDelete.Location = new System.Drawing.Point(72, 4);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new System.Drawing.Size(68, 28);
      this.btnDelete.TabIndex = 1;
      this.btnDelete.Text = "&Delete";
      // 
      // splAdd
      // 
      this.splAdd.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.splAdd.Location = new System.Drawing.Point(8, 179);
      this.splAdd.MinExtra = 82;
      this.splAdd.MinSize = 82;
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
      this.panAdd.Location = new System.Drawing.Point(8, 191);
      this.panAdd.Name = "panAdd";
      this.panAdd.Size = new System.Drawing.Size(462, 128);
      this.panAdd.TabIndex = 3;
      // 
      // chkAdd
      // 
      this.chkAdd.Checked = true;
      this.chkAdd.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkAdd.Location = new System.Drawing.Point(8, 0);
      this.chkAdd.Name = "chkAdd";
      this.chkAdd.Size = new System.Drawing.Size(68, 16);
      this.chkAdd.TabIndex = 1;
      this.chkAdd.Text = "Add Item";
      this.chkAdd.CheckedChanged += new System.EventHandler(this.chkAdd_CheckedChanged);
      // 
      // grpAdd
      // 
      this.grpAdd.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.grpAdd.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                         this.chkMultiTerm,
                                                                         this.btnAddTerm,
                                                                         this.txtTermsAdd,
                                                                         this.lblTermsAdd,
                                                                         this.lblDefinitionAdd,
                                                                         this.rtbDefinitionAdd});
      this.grpAdd.Name = "grpAdd";
      this.grpAdd.Size = new System.Drawing.Size(462, 128);
      this.grpAdd.TabIndex = 0;
      this.grpAdd.TabStop = false;
      this.grpAdd.Text = "Add Item";
      // 
      // chkMultiTerm
      // 
      this.chkMultiTerm.Enabled = false;
      this.chkMultiTerm.Location = new System.Drawing.Point(8, 60);
      this.chkMultiTerm.Name = "chkMultiTerm";
      this.chkMultiTerm.Size = new System.Drawing.Size(196, 16);
      this.chkMultiTerm.TabIndex = 2;
      this.chkMultiTerm.Text = "Multiple Terms";
      this.chkMultiTerm.CheckedChanged += new System.EventHandler(this.chkMultiTerm_CheckedChanged);
      // 
      // btnAddTerm
      // 
      this.btnAddTerm.Enabled = false;
      this.btnAddTerm.Location = new System.Drawing.Point(156, 96);
      this.btnAddTerm.Name = "btnAddTerm";
      this.btnAddTerm.Size = new System.Drawing.Size(48, 24);
      this.btnAddTerm.TabIndex = 5;
      this.btnAddTerm.Text = "Add";
      // 
      // txtTermsAdd
      // 
      this.txtTermsAdd.BackColor = System.Drawing.SystemColors.Control;
      this.txtTermsAdd.Location = new System.Drawing.Point(8, 36);
      this.txtTermsAdd.Multiline = true;
      this.txtTermsAdd.Name = "txtTermsAdd";
      this.txtTermsAdd.ReadOnly = true;
      this.txtTermsAdd.Size = new System.Drawing.Size(196, 20);
      this.txtTermsAdd.TabIndex = 1;
      this.txtTermsAdd.Text = "";
      // 
      // lblTermsAdd
      // 
      this.lblTermsAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblTermsAdd.Location = new System.Drawing.Point(8, 20);
      this.lblTermsAdd.Name = "lblTermsAdd";
      this.lblTermsAdd.Size = new System.Drawing.Size(196, 16);
      this.lblTermsAdd.TabIndex = 0;
      this.lblTermsAdd.Text = "Term:";
      // 
      // lblDefinitionAdd
      // 
      this.lblDefinitionAdd.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.lblDefinitionAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.lblDefinitionAdd.Location = new System.Drawing.Point(212, 20);
      this.lblDefinitionAdd.Name = "lblDefinitionAdd";
      this.lblDefinitionAdd.Size = new System.Drawing.Size(241, 16);
      this.lblDefinitionAdd.TabIndex = 3;
      this.lblDefinitionAdd.Text = "Definition:";
      // 
      // rtbDefinitionAdd
      // 
      this.rtbDefinitionAdd.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.rtbDefinitionAdd.BackColor = System.Drawing.SystemColors.Control;
      this.rtbDefinitionAdd.Location = new System.Drawing.Point(212, 36);
      this.rtbDefinitionAdd.Name = "rtbDefinitionAdd";
      this.rtbDefinitionAdd.ReadOnly = true;
      this.rtbDefinitionAdd.Size = new System.Drawing.Size(241, 84);
      this.rtbDefinitionAdd.TabIndex = 4;
      this.rtbDefinitionAdd.Text = "";
      // 
      // btnMenu
      // 
      this.btnMenu.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
      this.btnMenu.Location = new System.Drawing.Point(8, 496);
      this.btnMenu.Name = "btnMenu";
      this.btnMenu.Size = new System.Drawing.Size(80, 32);
      this.btnMenu.TabIndex = 4;
      this.btnMenu.Text = "&Menu";
      this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
      this.btnMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMenu_MouseDown);
      // 
      // btnExit
      // 
      this.btnExit.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
      this.btnExit.Location = new System.Drawing.Point(408, 496);
      this.btnExit.Name = "btnExit";
      this.btnExit.Size = new System.Drawing.Size(80, 32);
      this.btnExit.TabIndex = 6;
      this.btnExit.Text = "&Exit";
      this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
      // 
      // btnTest
      // 
      this.btnTest.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
      this.btnTest.Enabled = false;
      this.btnTest.Location = new System.Drawing.Point(96, 496);
      this.btnTest.Name = "btnTest";
      this.btnTest.Size = new System.Drawing.Size(80, 32);
      this.btnTest.TabIndex = 5;
      this.btnTest.Text = "&Test...";
      this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
      // 
      // menuMain
      // 
      this.menuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                             this.menuMainNew,
                                                                             this.menuMainOpen,
                                                                             this.menuMainClose,
                                                                             this.menuMainLine01,
                                                                             this.menuMainSave,
                                                                             this.menuMainSaveAs,
                                                                             this.menuMainLine02,
                                                                             this.menuMainPreferences,
                                                                             this.menuMainAbout,
                                                                             this.menuMainLine03,
                                                                             this.menuMainExit});
      // 
      // menuMainNew
      // 
      this.menuMainNew.Index = 0;
      this.menuMainNew.Text = "&New";
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
      // menuMainSave
      // 
      this.menuMainSave.Enabled = false;
      this.menuMainSave.Index = 4;
      this.menuMainSave.Text = "&Save";
      this.menuMainSave.Click += new System.EventHandler(this.menuMainSave_Click);
      // 
      // menuMainSaveAs
      // 
      this.menuMainSaveAs.Enabled = false;
      this.menuMainSaveAs.Index = 5;
      this.menuMainSaveAs.Text = "&Save As...";
      this.menuMainSaveAs.Click += new System.EventHandler(this.menuMainSaveAs_Click);
      // 
      // menuMainLine02
      // 
      this.menuMainLine02.Index = 6;
      this.menuMainLine02.Text = "-";
      // 
      // menuMainPreferences
      // 
      this.menuMainPreferences.Index = 7;
      this.menuMainPreferences.Text = "&Preferences...";
      this.menuMainPreferences.Click += new System.EventHandler(this.menuMainPreferences_Click);
      // 
      // menuMainAbout
      // 
      this.menuMainAbout.Index = 8;
      this.menuMainAbout.Text = "&About...";
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
      this.menuMainExit.Text = "&Exit";
      this.menuMainExit.Click += new System.EventHandler(this.menuMainExit_Click);
      // 
      // btnPlayer
      // 
      this.btnPlayer.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
      this.btnPlayer.Location = new System.Drawing.Point(328, 496);
      this.btnPlayer.Name = "btnPlayer";
      this.btnPlayer.Size = new System.Drawing.Size(72, 32);
      this.btnPlayer.TabIndex = 21;
      this.btnPlayer.Text = "&Player...";
      this.btnPlayer.Click += new System.EventHandler(this.btnPlayer_Click);
      // 
      // openFileDialog
      // 
      this.openFileDialog.DefaultExt = "sheet";
      this.openFileDialog.Filter = "Study Sheet Files (*.sheet)|*.sheet|All Files (*.*)|*.*";
      this.openFileDialog.Title = "Open Study Sheet";
      // 
      // saveFileDialog
      // 
      this.saveFileDialog.DefaultExt = "sheet";
      this.saveFileDialog.FileName = "untitled";
      this.saveFileDialog.Filter = "Study Sheet Files (*.sheet)|*.sheet|All Files (*.*)|*.*";
      this.saveFileDialog.Title = "Open Study Sheet";
      // 
      // frmMain
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(496, 533);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.btnPlayer,
                                                                  this.chkInfo,
                                                                  this.btnMenu,
                                                                  this.panSheet,
                                                                  this.grpInfo,
                                                                  this.txtTitle,
                                                                  this.btnExit,
                                                                  this.btnTest});
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "frmMain";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Study Guide: Matching [Edit]";
      this.Load += new System.EventHandler(this.frmMain_Load);
      this.Activated += new System.EventHandler(this.frmMain_Activated);
      this.grpInfo.ResumeLayout(false);
      this.panSheet.ResumeLayout(false);
      this.panDefinition.ResumeLayout(false);
      this.panTerms.ResumeLayout(false);
      this.panTermsModify.ResumeLayout(false);
      this.panAdd.ResumeLayout(false);
      this.grpAdd.ResumeLayout(false);
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
      // Close all checks via the CheckedChanged functions
      chkInfo.Checked = false;
      chkAdd.Checked = false;
      
      // Adjust min/max sizes
      splAdd.MinSize = txtGroup.Height + chkMultiTerm.Height + lblTermsAdd.Height + 32;
      splAdd.MinExtra = splAdd.MinSize;
    }
    
    private void frmMain_Activated(object sender, System.EventArgs e)
    {
      if (m_Sheet != null)
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
        btnMenu.Focus();
    }
    
    
    
    private void menuMainNew_Click(object sender, System.EventArgs e)
    { DoNew(); }
    private void menuMainOpen_Click(object sender, System.EventArgs e)
    { DoOpen(); }
    private void menuMainClose_Click(object sender, System.EventArgs e)
    { DoClose(); }
    private void menuMainSave_Click(object sender, System.EventArgs e)
    { DoSave(); }
    private void menuMainSaveAs_Click(object sender, System.EventArgs e)
    { DoSaveAs(); }
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
    
    private void btnTest_Click(object sender, System.EventArgs e)
    { DoTest(); }
    private void btnPlayer_Click(object sender, System.EventArgs e)
    { DoShowPlayer(); }
    private void btnExit_Click(object sender, System.EventArgs e)
    { this.Close(); }
    
    
    private void chkInfo_CheckedChanged(object sender, System.EventArgs e)
    {
      // Show/hide 'Sheet Information'
      grpInfo.Enabled = chkInfo.Checked;
      grpInfo.Height = (( chkInfo.Checked )?( txtDescription.Top + txtDescription.Height + 8 ):( chkInfo.Height + 4 ));
      panSheet.Top = grpInfo.Top + grpInfo.Height + 8;
      panSheet.Height = (this.ClientSize.Height - (btnMenu.Height + 8)) - (panSheet.Top + 8);
    }
    private void chkAdd_CheckedChanged(object sender, System.EventArgs e)
    {
      // Show/hide 'Add Item'
      grpAdd.Enabled = chkAdd.Checked;
      if (!chkAdd.Checked) m_AddHeight = panAdd.Height;
      panAdd.Height = (( chkAdd.Checked )?( m_AddHeight ):( chkAdd.Height + 4 ));
      splAdd.Enabled = chkAdd.Checked;
    }
    
    private void chkMultiTerm_CheckedChanged(object sender, System.EventArgs e)
    { chkMultiTerm.Text = (( chkMultiTerm.Checked )?( "Multiple Terms (one per line)" ):( "Multiple Terms" )); }
    private void chkEdit_CheckedChanged(object sender, System.EventArgs e)
    {
      // !!!!!
    }
    
    
    private void txtTitle_Enter(object sender, System.EventArgs e)
    {
      if (m_Sheet == null) return;  // Failsafe
      if (m_Sheet.Title == "")
      {
        txtTitle.SelectionStart = 0; txtTitle.SelectionLength = 0;
        txtTitle.Text = ""; txtTitle.ForeColor = Color.FromKnownColor(KnownColor.InfoText);
        return;
      }
      
      txtTitle.SelectionStart = 0; txtTitle.SelectionLength = txtTitle.TextLength;
    }
    private void txtTitle_Leave (object sender, System.EventArgs e)
    {
      if (m_Sheet == null) return;  // Failsafe
      if (txtTitle.Text != "")
      { m_Sheet.Title = txtTitle.Text; return; }
      
      m_Sheet.Title = "";
      txtTitle.Text = "( untitled )"; txtTitle.ForeColor = Color.FromKnownColor(KnownColor.GrayText);
      txtTitle.SelectionStart = 0; txtTitle.SelectionLength = 0;
    }
    
    
    private void txtAuthor_Leave(object sender, System.EventArgs e)
    { if (m_Sheet != null)  m_Sheet.Author = txtAuthor.Text; }
    
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
      if (txtGroup.Text != "")
      { m_Sheet.Group = txtGroup.Text; return; }
      
      m_Sheet.Group = "";
      txtGroup.Text = "( All Groups )"; txtGroup.ForeColor = Color.FromKnownColor(KnownColor.GrayText);
      txtGroup.SelectionStart = 0; txtGroup.SelectionLength = 0;
    }
    
    private void txtDescription_Leave (object sender, System.EventArgs e)
    { if (m_Sheet != null)  m_Sheet.Description = txtDescription.Text; }
    
    
    private void lstTermList_SelectedIndexChanged (object sender, System.EventArgs e)
    {
      if (m_Sheet == null) return;
      
      if (lstTermList.Items.Count > 0)
      {
        rtbDefinition.Text = "";  // !!!!!
        rtbDefinition.ReadOnly = true;
      }
      else
      {
        rtbDefinition.Text = "";
        rtbDefinition.ReadOnly = true;
      }
    }
    
    
    
    private bool DoNew ()
    {
      if (!DoClose()) return false;
      
      m_Sheet = new MatchingSheet();
      DoUpdateSheet(true);
      return true;
    }
    
    private bool DoOpen ()
    {
      if (openFileDialog.ShowDialog(this) != DialogResult.OK) return false;
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
    {
      if (!DoClose()) return false;
      
      m_Sheet = sheet;
      DoUpdateSheet(false);
      
      return true;
    }
    
    private bool DoClose ()
    {
      if (m_Sheet == null) return true;
      
      if (m_SheetDirty)
      {
        DialogResult result;
        if (m_Sheet.Filename == "")
          result = MessageBox.Show(this, "Save first?", "Study Sheet Editor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        else
          result = MessageBox.Show(this, "Save changes to " + m_Sheet.Filename + "?", "Study Sheet Editor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        
        if (result == DialogResult.Yes)
          if (!DoSave()) return false;
        if (result == DialogResult.Cancel) return false;
      }
      
      m_Sheet = null;
      DoUpdateSheet(false);
      
      return true;
    }
    
    private bool DoSave ()
    {
      if (m_Sheet == null) return false;
      if (m_Sheet.Filename == "")
        if (!DoSaveAs()) return false;
      
      m_SheetDirty = false;
      return m_Sheet.Save();
    }
    
    private bool DoSaveAs (string Filename)
    {
      m_Sheet.Filename = Filename;
      return DoSave();
    }
    private bool DoSaveAs ()
    {
      if (m_Sheet == null) return false;
      
      saveFileDialog.FileName = (( m_Sheet.Filename == "" )?( txtTitle.Text ):( m_Sheet.Filename ));
      if (saveFileDialog.ShowDialog(this) != DialogResult.OK) return false;
      return DoSaveAs(saveFileDialog.FileName);
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
    
    
    private void DoUpdateSheet (bool IsDirty)
    {
      m_SheetDirty = IsDirty;
      
      if (m_Sheet != null)
      {
        txtTitle.ForeColor = Color.FromKnownColor(KnownColor.InfoText);
        txtTitle.BackColor = Color.FromKnownColor(KnownColor.Info);
        txtTitle.ReadOnly = false;
        txtTitle.Text = m_Sheet.Title; txtTitle_Leave(txtTitle, new EventArgs());
        
        Color cbg = Color.FromKnownColor(KnownColor.Window);
        
        txtAuthor.BackColor = cbg; txtAuthor.ReadOnly = false; txtAuthor.Text = "";
        txtDescription.BackColor = cbg; txtDescription.ReadOnly = false; txtDescription.Text = "";
        txtGroup.BackColor = cbg; txtGroup.ReadOnly = false; txtGroup.Text = "";
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
        rtbDefinition.BackColor = cbg; lstTermList_SelectedIndexChanged(lstTermList, new EventArgs());
        
        chkEdit.Enabled = true;
        
        menuMainClose.Enabled = true;
        menuMainSave.Enabled = true;
        menuMainSaveAs.Enabled = true;
      }
      else
      {
        txtTitle.ForeColor = Color.FromKnownColor(KnownColor.GrayText);
        txtTitle.BackColor = Color.FromKnownColor(KnownColor.Control);
        txtTitle.ReadOnly = true;
        txtTitle.Text = "( nothing loaded )";
        
        Color cbg = Color.FromKnownColor(KnownColor.Control);
        
        txtAuthor.BackColor = cbg; txtAuthor.ReadOnly = true; txtAuthor.Text = "";
        txtDescription.BackColor = cbg; txtAuthor.ReadOnly = true; txtDescription.Text = "";
        txtGroup.BackColor = cbg; txtAuthor.ReadOnly = true; txtGroup.Text = "";
        
        lstTermList.Items.Clear();
        lstTermList.BackColor = cbg;
        rtbDefinition.BackColor = cbg; rtbDefinition.ReadOnly = true;
        
        chkEdit.Enabled = false; chkEdit.Checked = false;
        
        menuMainClose.Enabled = false;
        menuMainSave.Enabled = false;
        menuMainSaveAs.Enabled = false;
      }
      
      DoUpdateSheetItems();
    }
    
    private void DoUpdateSheetItems ()
    {
      btnDelete.Enabled = ((m_Sheet == null) && (lstTermList.Items.Count > 0));
      btnTest.Enabled = btnDelete.Enabled;
    }
    
  }
}

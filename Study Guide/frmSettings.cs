using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Uberware.Study
{
	/// <summary>
	/// Summary description for frmMatchingPref.
	/// </summary>
	public class frmSettings : System.Windows.Forms.Form
	{
    
    #region Class Variables
    
    private MatchingSettings m_Settings = new MatchingSettings();
    
    #region Controls
    
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.CheckBox checkBox1;
    private System.Windows.Forms.Label lblCorrectSound;
    private System.Windows.Forms.TabControl tabsPreferences;
    private System.Windows.Forms.TabPage tabGeneral;
    private System.Windows.Forms.TabPage tabSounds;
    private System.Windows.Forms.TextBox txtCorrectSound;
    private System.Windows.Forms.Button btnCorrectSound;
    private System.Windows.Forms.Label lblWrongSound;
    private System.Windows.Forms.Button btnWrongSound;
    private System.Windows.Forms.TextBox txtWrongSound;
    private System.Windows.Forms.Button btnCompleteSound;
    private System.Windows.Forms.TextBox txtCompleteSound;
    private System.Windows.Forms.Label lblCompleteSound;
    private System.Windows.Forms.Label lblBeginSound;
    private System.Windows.Forms.Button btnBeginSound;
    private System.Windows.Forms.TextBox txtBeginSound;
    private System.Windows.Forms.Button btnPerfectSound;
    private System.Windows.Forms.TextBox txtPerfectSound;
    private System.Windows.Forms.Label lblPerfectSound;
    private System.Windows.Forms.Button btnOK;
		
    /// <summary> Required designer variable. </summary>
		private System.ComponentModel.Container components = null;
    
    #endregion
    
    #endregion
		
    #region Class Construction
    
    public frmSettings()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		#region Windows Form Designer generated code
    
    /// <summary> Clean up any resources being used. </summary>
    protected override void Dispose( bool disposing )
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
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnOK = new System.Windows.Forms.Button();
      this.checkBox1 = new System.Windows.Forms.CheckBox();
      this.lblCorrectSound = new System.Windows.Forms.Label();
      this.tabsPreferences = new System.Windows.Forms.TabControl();
      this.tabGeneral = new System.Windows.Forms.TabPage();
      this.tabSounds = new System.Windows.Forms.TabPage();
      this.btnCompleteSound = new System.Windows.Forms.Button();
      this.txtCompleteSound = new System.Windows.Forms.TextBox();
      this.lblCompleteSound = new System.Windows.Forms.Label();
      this.lblBeginSound = new System.Windows.Forms.Label();
      this.btnBeginSound = new System.Windows.Forms.Button();
      this.txtBeginSound = new System.Windows.Forms.TextBox();
      this.btnCorrectSound = new System.Windows.Forms.Button();
      this.txtCorrectSound = new System.Windows.Forms.TextBox();
      this.lblWrongSound = new System.Windows.Forms.Label();
      this.btnWrongSound = new System.Windows.Forms.Button();
      this.txtWrongSound = new System.Windows.Forms.TextBox();
      this.btnPerfectSound = new System.Windows.Forms.Button();
      this.txtPerfectSound = new System.Windows.Forms.TextBox();
      this.lblPerfectSound = new System.Windows.Forms.Label();
      this.tabsPreferences.SuspendLayout();
      this.tabSounds.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(396, 304);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 32);
      this.btnCancel.TabIndex = 2;
      this.btnCancel.Text = "&Cancel";
      // 
      // btnOK
      // 
      this.btnOK.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
      this.btnOK.Location = new System.Drawing.Point(312, 304);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(75, 32);
      this.btnOK.TabIndex = 1;
      this.btnOK.Text = "&OK";
      // 
      // checkBox1
      // 
      this.checkBox1.Checked = true;
      this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
      this.checkBox1.Location = new System.Drawing.Point(12, 12);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new System.Drawing.Size(96, 16);
      this.checkBox1.TabIndex = 0;
      this.checkBox1.Text = "Play Sounds";
      // 
      // lblCorrectSound
      // 
      this.lblCorrectSound.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.lblCorrectSound.Location = new System.Drawing.Point(12, 84);
      this.lblCorrectSound.Name = "lblCorrectSound";
      this.lblCorrectSound.Size = new System.Drawing.Size(432, 16);
      this.lblCorrectSound.TabIndex = 4;
      this.lblCorrectSound.Text = "Correct:";
      // 
      // tabsPreferences
      // 
      this.tabsPreferences.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.tabsPreferences.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                  this.tabGeneral,
                                                                                  this.tabSounds});
      this.tabsPreferences.Location = new System.Drawing.Point(8, 8);
      this.tabsPreferences.Name = "tabsPreferences";
      this.tabsPreferences.SelectedIndex = 0;
      this.tabsPreferences.Size = new System.Drawing.Size(464, 288);
      this.tabsPreferences.TabIndex = 0;
      // 
      // tabGeneral
      // 
      this.tabGeneral.Location = new System.Drawing.Point(4, 22);
      this.tabGeneral.Name = "tabGeneral";
      this.tabGeneral.Size = new System.Drawing.Size(456, 262);
      this.tabGeneral.TabIndex = 0;
      this.tabGeneral.Text = "General";
      // 
      // tabSounds
      // 
      this.tabSounds.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                            this.btnCompleteSound,
                                                                            this.txtCompleteSound,
                                                                            this.lblCompleteSound,
                                                                            this.lblBeginSound,
                                                                            this.btnBeginSound,
                                                                            this.txtBeginSound,
                                                                            this.btnCorrectSound,
                                                                            this.txtCorrectSound,
                                                                            this.lblCorrectSound,
                                                                            this.checkBox1,
                                                                            this.lblWrongSound,
                                                                            this.btnWrongSound,
                                                                            this.txtWrongSound,
                                                                            this.btnPerfectSound,
                                                                            this.txtPerfectSound,
                                                                            this.lblPerfectSound});
      this.tabSounds.Location = new System.Drawing.Point(4, 22);
      this.tabSounds.Name = "tabSounds";
      this.tabSounds.Size = new System.Drawing.Size(456, 262);
      this.tabSounds.TabIndex = 1;
      this.tabSounds.Text = "Sounds";
      // 
      // btnCompleteSound
      // 
      this.btnCompleteSound.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
      this.btnCompleteSound.Location = new System.Drawing.Point(420, 188);
      this.btnCompleteSound.Name = "btnCompleteSound";
      this.btnCompleteSound.Size = new System.Drawing.Size(24, 20);
      this.btnCompleteSound.TabIndex = 12;
      this.btnCompleteSound.Text = "...";
      // 
      // txtCompleteSound
      // 
      this.txtCompleteSound.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.txtCompleteSound.Location = new System.Drawing.Point(12, 188);
      this.txtCompleteSound.Name = "txtCompleteSound";
      this.txtCompleteSound.Size = new System.Drawing.Size(406, 20);
      this.txtCompleteSound.TabIndex = 11;
      this.txtCompleteSound.Text = "";
      // 
      // lblCompleteSound
      // 
      this.lblCompleteSound.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.lblCompleteSound.Location = new System.Drawing.Point(12, 172);
      this.lblCompleteSound.Name = "lblCompleteSound";
      this.lblCompleteSound.Size = new System.Drawing.Size(432, 16);
      this.lblCompleteSound.TabIndex = 10;
      this.lblCompleteSound.Text = "Complete:";
      // 
      // lblBeginSound
      // 
      this.lblBeginSound.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.lblBeginSound.Location = new System.Drawing.Point(12, 40);
      this.lblBeginSound.Name = "lblBeginSound";
      this.lblBeginSound.Size = new System.Drawing.Size(432, 16);
      this.lblBeginSound.TabIndex = 1;
      this.lblBeginSound.Text = "Begin:";
      // 
      // btnBeginSound
      // 
      this.btnBeginSound.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
      this.btnBeginSound.Location = new System.Drawing.Point(420, 56);
      this.btnBeginSound.Name = "btnBeginSound";
      this.btnBeginSound.Size = new System.Drawing.Size(24, 20);
      this.btnBeginSound.TabIndex = 3;
      this.btnBeginSound.Text = "...";
      // 
      // txtBeginSound
      // 
      this.txtBeginSound.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.txtBeginSound.Location = new System.Drawing.Point(12, 56);
      this.txtBeginSound.Name = "txtBeginSound";
      this.txtBeginSound.Size = new System.Drawing.Size(406, 20);
      this.txtBeginSound.TabIndex = 2;
      this.txtBeginSound.Text = "";
      // 
      // btnCorrectSound
      // 
      this.btnCorrectSound.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
      this.btnCorrectSound.Location = new System.Drawing.Point(420, 100);
      this.btnCorrectSound.Name = "btnCorrectSound";
      this.btnCorrectSound.Size = new System.Drawing.Size(24, 20);
      this.btnCorrectSound.TabIndex = 6;
      this.btnCorrectSound.Text = "...";
      // 
      // txtCorrectSound
      // 
      this.txtCorrectSound.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.txtCorrectSound.Location = new System.Drawing.Point(12, 100);
      this.txtCorrectSound.Name = "txtCorrectSound";
      this.txtCorrectSound.Size = new System.Drawing.Size(406, 20);
      this.txtCorrectSound.TabIndex = 5;
      this.txtCorrectSound.Text = "";
      // 
      // lblWrongSound
      // 
      this.lblWrongSound.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.lblWrongSound.Location = new System.Drawing.Point(12, 128);
      this.lblWrongSound.Name = "lblWrongSound";
      this.lblWrongSound.Size = new System.Drawing.Size(432, 16);
      this.lblWrongSound.TabIndex = 7;
      this.lblWrongSound.Text = "Wrong:";
      // 
      // btnWrongSound
      // 
      this.btnWrongSound.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
      this.btnWrongSound.Location = new System.Drawing.Point(420, 144);
      this.btnWrongSound.Name = "btnWrongSound";
      this.btnWrongSound.Size = new System.Drawing.Size(24, 20);
      this.btnWrongSound.TabIndex = 9;
      this.btnWrongSound.Text = "...";
      // 
      // txtWrongSound
      // 
      this.txtWrongSound.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.txtWrongSound.Location = new System.Drawing.Point(12, 144);
      this.txtWrongSound.Name = "txtWrongSound";
      this.txtWrongSound.Size = new System.Drawing.Size(406, 20);
      this.txtWrongSound.TabIndex = 8;
      this.txtWrongSound.Text = "";
      // 
      // btnPerfectSound
      // 
      this.btnPerfectSound.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
      this.btnPerfectSound.Location = new System.Drawing.Point(420, 232);
      this.btnPerfectSound.Name = "btnPerfectSound";
      this.btnPerfectSound.Size = new System.Drawing.Size(24, 20);
      this.btnPerfectSound.TabIndex = 15;
      this.btnPerfectSound.Text = "...";
      // 
      // txtPerfectSound
      // 
      this.txtPerfectSound.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.txtPerfectSound.Location = new System.Drawing.Point(12, 232);
      this.txtPerfectSound.Name = "txtPerfectSound";
      this.txtPerfectSound.Size = new System.Drawing.Size(406, 20);
      this.txtPerfectSound.TabIndex = 14;
      this.txtPerfectSound.Text = "";
      // 
      // lblPerfectSound
      // 
      this.lblPerfectSound.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.lblPerfectSound.Location = new System.Drawing.Point(12, 216);
      this.lblPerfectSound.Name = "lblPerfectSound";
      this.lblPerfectSound.Size = new System.Drawing.Size(432, 16);
      this.lblPerfectSound.TabIndex = 13;
      this.lblPerfectSound.Text = "Perfect:";
      // 
      // frmSettings
      // 
      this.AcceptButton = this.btnOK;
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(480, 341);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.tabsPreferences,
                                                                  this.btnOK,
                                                                  this.btnCancel});
      this.Name = "frmSettings";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Study Guide: Matching Preferences";
      this.tabsPreferences.ResumeLayout(false);
      this.tabSounds.ResumeLayout(false);
      this.ResumeLayout(false);

    }
		
    #endregion
    
    #endregion
    
    public MatchingSettings ShowDialog (IWin32Window owner, MatchingSettings settings)
    {
      m_Settings = settings;
      
      if (ShowDialog(owner) == DialogResult.Cancel) return null;
      return m_Settings;
    }
    
	}
}

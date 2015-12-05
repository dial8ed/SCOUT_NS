using SCOUT.WinForms.Controls;

namespace SCOUT.WinForms
{
    partial class SuperConfirmForm2
    {
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary>
	/// Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing)
	{
	    if (disposing && (components != null))
	    {
		components.Dispose();
	    }
	    base.Dispose(disposing);
	}

	#region Windows Form Designer generated code

	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
	    this.sysIcon1 = new SysIcon();
	    this.button1 = new DevExpress.XtraEditors.SimpleButton();
	    this.button2 = new DevExpress.XtraEditors.SimpleButton();
	    this.button3 = new DevExpress.XtraEditors.SimpleButton();
	    this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
	    this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
	    this.capLabel = new System.Windows.Forms.Label();
	    this.msgLabel = new System.Windows.Forms.Label();
	    this.label3 = new System.Windows.Forms.Label();
	    this.confDetailLabel = new System.Windows.Forms.Label();
	    ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
	    this.panelControl1.SuspendLayout();
	    ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
	    this.SuspendLayout();
	    // 
	    // sysIcon1
	    // 
	    this.sysIcon1.IconIndex = IconIndex.Warning;
	    this.sysIcon1.Location = new System.Drawing.Point(12, 12);
	    this.sysIcon1.Name = "sysIcon1";
	    this.sysIcon1.Size = new System.Drawing.Size(32, 32);
	    this.sysIcon1.TabIndex = 0;
	    this.sysIcon1.Text = "sysIcon1";
	    // 
	    // button1
	    // 
	    this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
	    this.button1.Location = new System.Drawing.Point(86, 14);
	    this.button1.Name = "button1";
	    this.button1.Size = new System.Drawing.Size(75, 23);
	    this.button1.TabIndex = 1;
	    this.button1.Text = "b1";
	    // 
	    // button2
	    // 
	    this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
	    this.button2.Location = new System.Drawing.Point(167, 14);
	    this.button2.Name = "button2";
	    this.button2.Size = new System.Drawing.Size(75, 23);
	    this.button2.TabIndex = 2;
	    this.button2.Text = "b2";
	    // 
	    // button3
	    // 
	    this.button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
	    this.button3.Location = new System.Drawing.Point(248, 14);
	    this.button3.Name = "button3";
	    this.button3.Size = new System.Drawing.Size(75, 23);
	    this.button3.TabIndex = 3;
	    this.button3.Text = "b3";
	    // 
	    // panelControl1
	    // 
	    this.panelControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
	    this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
	    this.panelControl1.Controls.Add(this.button3);
	    this.panelControl1.Controls.Add(this.button1);
	    this.panelControl1.Controls.Add(this.button2);
	    this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
	    this.panelControl1.Location = new System.Drawing.Point(0, 224);
	    this.panelControl1.Name = "panelControl1";
	    this.panelControl1.Size = new System.Drawing.Size(409, 49);
	    this.panelControl1.TabIndex = 4;
	    // 
	    // textEdit1
	    // 
	    this.textEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
	    this.textEdit1.Location = new System.Drawing.Point(104, 185);
	    this.textEdit1.Name = "textEdit1";
	    this.textEdit1.Size = new System.Drawing.Size(293, 20);
	    this.textEdit1.TabIndex = 5;
	    // 
	    // capLabel
	    // 
	    this.capLabel.AutoSize = true;
	    this.capLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
	    this.capLabel.Location = new System.Drawing.Point(50, 12);
	    this.capLabel.Name = "capLabel";
	    this.capLabel.Size = new System.Drawing.Size(64, 13);
	    this.capLabel.TabIndex = 6;
	    this.capLabel.Text = "WARNING:";
	    // 
	    // msgLabel
	    // 
	    this.msgLabel.Location = new System.Drawing.Point(50, 25);
	    this.msgLabel.Name = "msgLabel";
	    this.msgLabel.Size = new System.Drawing.Size(347, 139);
	    this.msgLabel.TabIndex = 7;
	    this.msgLabel.Text = "msgLabel";
	    // 
	    // label3
	    // 
	    this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
	    this.label3.AutoSize = true;
	    this.label3.Location = new System.Drawing.Point(50, 188);
	    this.label3.Name = "label3";
	    this.label3.Size = new System.Drawing.Size(48, 13);
	    this.label3.TabIndex = 8;
	    this.label3.Text = "&Confirm:";
	    // 
	    // confDetailLabel
	    // 
	    this.confDetailLabel.Location = new System.Drawing.Point(50, 164);
	    this.confDetailLabel.Name = "confDetailLabel";
	    this.confDetailLabel.Size = new System.Drawing.Size(330, 13);
	    this.confDetailLabel.TabIndex = 9;
	    this.confDetailLabel.Text = "If you are sure you want to do this then type {0} in the box below:";
	    // 
	    // SuperConfirmForm2
	    // 
	    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	    this.ClientSize = new System.Drawing.Size(409, 273);
	    this.Controls.Add(this.confDetailLabel);
	    this.Controls.Add(this.msgLabel);
	    this.Controls.Add(this.label3);
	    this.Controls.Add(this.capLabel);
	    this.Controls.Add(this.textEdit1);
	    this.Controls.Add(this.panelControl1);
	    this.Controls.Add(this.sysIcon1);
	    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
	    this.MaximizeBox = false;
	    this.MinimizeBox = false;
	    this.Name = "SuperConfirmForm2";
	    this.ShowInTaskbar = false;
	    this.Text = "Confirm";
	    this.SizeChanged += new System.EventHandler(this.SuperConfirmForm2_SizeChanged);
	    ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
	    this.panelControl1.ResumeLayout(false);
	    ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
	    this.ResumeLayout(false);
	    this.PerformLayout();

	}

	#endregion

	private SysIcon sysIcon1;
	private DevExpress.XtraEditors.SimpleButton button1;
	private DevExpress.XtraEditors.SimpleButton button2;
	private DevExpress.XtraEditors.SimpleButton button3;
	private DevExpress.XtraEditors.PanelControl panelControl1;
	private DevExpress.XtraEditors.TextEdit textEdit1;
	private System.Windows.Forms.Label capLabel;
	private System.Windows.Forms.Label msgLabel;
	private System.Windows.Forms.Label label3;
	private System.Windows.Forms.Label confDetailLabel;
    }
}
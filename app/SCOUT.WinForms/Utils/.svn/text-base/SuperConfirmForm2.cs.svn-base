using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SCOUT.WinForms.Controls;

namespace SCOUT.WinForms
{
    public partial class SuperConfirmForm2 : DevExpress.XtraEditors.XtraForm
    {
	#region Member Variables

	public string m_confirmText = "yes";

	public MessageBoxButtons m_buttons = 
	    MessageBoxButtons.OKCancel;

	public MessageBoxDefaultButton m_defaultButton = 
	    MessageBoxDefaultButton.Button1;

	#endregion


	public SuperConfirmForm2()
	{
	    InitializeComponent();

	    UpdateConfirmInfo();
	    UpdateButtons();
	}

	#region Utility

	private void UpdateConfirmInfo()
	{
	    confDetailLabel.Text =
		    String.Format("If you are sure you want to do this " +
			"then type {0} in the box below:", m_confirmText);
	}

	private void UpdateButtons()
	{
	    string b1Text = "OK";
	    string b2Text = "Cancel";
	    string b3Text = "";

	    button1.DialogResult = DialogResult.OK;
	    button2.DialogResult = DialogResult.Cancel;
	    
	    switch (m_buttons)
	    {
	    case MessageBoxButtons.OK:
		b2Text = "";
		break;

	    case MessageBoxButtons.YesNoCancel:
		button3.DialogResult = DialogResult.Cancel;
		b3Text = "Cancel";

		// Fall through to next case

		/*
		 * But we can't fall through like C/C++ because C# doesn't 
		 * allow that....
		 */
		button1.DialogResult = DialogResult.Yes;
		button2.DialogResult = DialogResult.No;

		b1Text = "Yes";
		b2Text = "No";
		break;

	    case MessageBoxButtons.YesNo:
		button1.DialogResult = DialogResult.Yes;
		button2.DialogResult = DialogResult.No;

		b1Text = "Yes";
		b2Text = "No";
		break;

	    case MessageBoxButtons.AbortRetryIgnore:
		button1.DialogResult = DialogResult.Abort;
		button2.DialogResult = DialogResult.Retry;
		button3.DialogResult = DialogResult.Ignore;

		b1Text = "Abort";
		b2Text = "Retry";
		b3Text = "Ignore";
		break;

	    case MessageBoxButtons.RetryCancel:
		button1.DialogResult = DialogResult.Retry;
		b1Text = "Retry";
		break;
	    }

	    SuspendLayout();

	    button1.Text = b1Text;
	    button2.Text = b2Text;
	    button3.Text = b3Text;

	    button2.Visible = (b2Text != "");
	    button3.Visible = (b3Text != "");

	    switch (m_defaultButton)
	    {
	    case MessageBoxDefaultButton.Button1:
		AcceptButton = button1;
		break;

	    case MessageBoxDefaultButton.Button2:
		AcceptButton = button2;
		break;

	    case MessageBoxDefaultButton.Button3:
		AcceptButton = button3;
		break;
	    }

	    ResumeLayout();

	    CenterButtons();
	}

	private void CenterButtons()
	{
	    int w = button1.Width;

	    if (button2.Visible)
	    {
		w += button1.Margin.Right;
		w += button2.Width;
		w += button2.Margin.Left;
	    }

	    if (button3.Visible)
	    {
		if (!button2.Visible)
		    w += button1.Margin.Right;
		else
		    w += button2.Margin.Right;

		w += button3.Width;
		w += button3.Margin.Left;
	    }

	    SuspendLayout();

	    int x = (Width - w) / 2;

	    button1.Left = x;
	    x += button1.Width;
	    x += button1.Margin.Right;

	    if (button2.Visible)
	    {
		x += button2.Margin.Left;
		button2.Left = x;

		x += button2.Width;
		x += button2.Margin.Right;
	    }

	    if (button3.Visible)
	    {
		x += button3.Margin.Left;

		button3.Left = x;
	    }

	    ResumeLayout();
	}

	#endregion

	#region Properties

	public string Message
	{
	    get { return msgLabel.Text; }
	    set { msgLabel.Text = value; }
	}

	public string CaptionLabel
	{
	    get { return capLabel.Text; }
	    set { capLabel.Text = value; }
	}

	public string ConfirmText
	{
	    get { return m_confirmText; }
	    set
	    {
		m_confirmText = value;
		UpdateConfirmInfo();
	    }
	}

	public MessageBoxButtons Buttons
	{
	    get { return m_buttons; }
	    set
	    {
		m_buttons = value;
		UpdateButtons();
	    }
	}

	public MessageBoxDefaultButton DefaultButton
	{
	    get { return m_defaultButton; }
	    set
	    {
		m_defaultButton = value;
		UpdateButtons();
	    }
	}

	public IconIndex MessageIcon
	{
	    get { return sysIcon1.IconIndex; }
	    set { sysIcon1.IconIndex = value; }
	}

	#endregion

	#region Events

	private void SuperConfirmForm2_SizeChanged(object sender, EventArgs e)
	{
	    CenterButtons();
	}

	#endregion
    }
}
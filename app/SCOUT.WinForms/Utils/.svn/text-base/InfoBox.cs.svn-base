using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using SCOUT.Core.Data;
using SCOUT.WinForms.Controls;

namespace SCOUT.WinForms
{
    public class InfoBox
    {
	#region Member Variables

	private string m_caption = "";

	private InfoBoxType m_type = InfoBoxType.MessageBox;

	private bool m_iconSetByUser = false;
	private MessageBoxIcon m_icon =
	    MessageBoxIcon.Information;

	private MessageBoxButtons m_buttons = 
	    MessageBoxButtons.OK;

	private MessageBoxDefaultButton m_defButton =
	    MessageBoxDefaultButton.Button1;

	#endregion

	#region Constructors

	public InfoBox()
	{
	}

	#endregion

	#region Utility

	/// <summary>
	/// Gets the dialog result of the default button.
	/// </summary>
	/// <returns></returns>
	private DialogResult GetDefaultButtonResult()
	{
	    DialogResult rval = DialogResult.OK;

	    switch (Buttons)
	    {
	    case MessageBoxButtons.OK:
		rval = DialogResult.OK;	// Just to be safe.
		break;

	    case MessageBoxButtons.OKCancel:
		if (DefaultButton == MessageBoxDefaultButton.Button2)
		    rval = DialogResult.Cancel;

		break;

	    case MessageBoxButtons.YesNo:
		if (DefaultButton == MessageBoxDefaultButton.Button1)
		    rval = DialogResult.Yes;
		else
		    rval = DialogResult.No;

		break;

	    case MessageBoxButtons.YesNoCancel:
		switch (DefaultButton)
		{
		case MessageBoxDefaultButton.Button1:
		    rval = DialogResult.Yes;
		    break;

		case MessageBoxDefaultButton.Button2:
		    rval = DialogResult.No;
		    break;

		default:
		case MessageBoxDefaultButton.Button3:
		    rval = DialogResult.Cancel;
		    break;
		}
		break;

	    case MessageBoxButtons.AbortRetryIgnore:
		switch (DefaultButton)
		{
		default:
		case MessageBoxDefaultButton.Button1:
		    rval = DialogResult.Abort;
		    break;

		case MessageBoxDefaultButton.Button2:
		    rval = DialogResult.Retry;
		    break;

		case MessageBoxDefaultButton.Button3:
		    rval = DialogResult.Ignore;
		    break;
		}

		break;

	    case MessageBoxButtons.RetryCancel:
		if (DefaultButton == MessageBoxDefaultButton.Button1)
		    rval = DialogResult.Retry;
		else
		    rval = DialogResult.Cancel;

		break;
	    }

	    return rval;
	}

	private DialogResult DoStdMessageBox(string msg, string cap)
	{
	    DialogResult rval = GetDefaultButtonResult();

	    rval = DevExpress.XtraEditors.XtraMessageBox.Show(
		msg,
		cap,
		Buttons,
		Icon,
		DefaultButton);

	    return rval;
	}

	private DialogResult DoSuperConfirmBox(string msg, string cap)
	{
	    SuperConfirmForm2 dlg = new SuperConfirmForm2();

	    dlg.Text = cap;
	    dlg.Message = msg;
	    dlg.Buttons = Buttons;
	    dlg.DefaultButton = DefaultButton;

	    switch (Icon)
	    {
		/*
		 * NOTE:
		 * Some of the case lables are commented out because
		 * they are actually the same value (which would produce
		 * a compiler error).  They are left here for clarity 
		 * for the programmer though.
		 */

	    case MessageBoxIcon.Asterisk:
	    //case MessageBoxIcon.Information:
		dlg.MessageIcon = IconIndex.Information;
		break;

	    
	    case MessageBoxIcon.Warning:
	    //case MessageBoxIcon.Exclamation:
		dlg.MessageIcon = IconIndex.Information;
		break;

	    case MessageBoxIcon.Error:
	    //case MessageBoxIcon.Hand:
	    //case MessageBoxIcon.Stop:
		dlg.MessageIcon = IconIndex.Error;
		break;

	    case MessageBoxIcon.Question:
		dlg.MessageIcon = IconIndex.Question;
		break;

	    default:
	    case MessageBoxIcon.None:
		dlg.MessageIcon = IconIndex.Information;
		break;
	    }

	    return dlg.ShowDialog();
	}

	#endregion

	#region Properties

	public string Caption
	{
	    get { return m_caption; }
	    set { m_caption = value; }
	}

	public InfoBoxType Type
	{
	    get { return m_type; }
	    set { m_type = value; }
	}

	public MessageBoxIcon Icon
	{
	    get { return m_icon; }
	    set 
	    { 
		m_icon = value;
		m_iconSetByUser = true;
	    }
	}

	public MessageBoxButtons Buttons
	{
	    get { return m_buttons; }
	    set 
	    { 
		m_buttons = value;

		if (!m_iconSetByUser)
		{
		    // Try and make a guess as to which icon the user wants.

		    switch (value)
		    {
		    case MessageBoxButtons.OK:
			m_icon = MessageBoxIcon.Information;
			break;

		    case MessageBoxButtons.YesNo:
		    case MessageBoxButtons.YesNoCancel:
			m_icon = MessageBoxIcon.Question;
			break;

		    case MessageBoxButtons.AbortRetryIgnore:
		    case MessageBoxButtons.RetryCancel:
			m_icon = MessageBoxIcon.Error;
			break;

		    default:
			m_icon = MessageBoxIcon.Exclamation;
			break;
		    }
		}
	    }
	}

	public MessageBoxDefaultButton DefaultButton
	{
	    get { return m_defButton; }
	    set { m_defButton = value; }
	}

	#endregion

	#region Interface

	public DialogResult Show(string fmt, params object[] args)
	{
	    string msg = SCOUT.Core.Data.Helpers.FixNewLines(String.Format(fmt, args));
	    string cap = Application.ProductName;
	    DialogResult rval;

	    if (m_caption != "")
		cap += " " + m_caption;

	    switch (Type)
	    {
	    default:
	    case InfoBoxType.MessageBox:
		rval = DoStdMessageBox(msg, cap);
		break;

	    case InfoBoxType.SuperConfirmBox:
		rval = DoSuperConfirmBox(msg, cap);
		break;
	    }

	    return rval;
	}

	#endregion
    }

    public enum InfoBoxType
    {
	MessageBox,
	SuperConfirmBox
    }
}

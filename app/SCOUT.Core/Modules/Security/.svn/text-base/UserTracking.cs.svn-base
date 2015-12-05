using System;
using System.Security.Principal;

namespace SCOUT.Core.Data
{
    public class UserTracking
    {
	#region Member Variables

	private IUserInfoGetter s_infoGetter = null;

	private string m_createdBy;
	private string m_updatedBy;

	private DateTime m_createdDate;
	private DateTime m_lastUpdated;

	#endregion

	#region Construction

	internal UserTracking()
	{
	    SetCreationInfo();
	}

	#endregion

	#region Properties

	public string CreatedBy
	{
	    get { return m_createdBy; }
	    internal set { m_createdBy = value; }
	}

	public string UpdatedBy
	{
	    get { return m_updatedBy; }
	    internal set { m_updatedBy = value; }
	}

	public DateTime CreatedDate
	{
	    get { return m_createdDate; }
	    internal set { m_createdDate = value; }
	}

	public DateTime LastUpdated
	{
	    get { return m_lastUpdated; }
	    internal set { m_lastUpdated = value; }
	}

	#endregion

	#region Utiltiy

	private void SetCreationInfo()
	{
	    m_createdBy = GetCurrentUserLoginName();
	    m_createdDate = DateTime.Now;

	    SetUpdateInfo();
	}

	internal void SetUpdateInfo()
	{
	    m_updatedBy = GetCurrentUserLoginName();
	    m_lastUpdated = DateTime.Now;
	}

	private string GetCurrentUserLoginName()
	{
	    string rval = "";

	    if (s_infoGetter == null)
	    {
		WindowsIdentity wi = WindowsIdentity.GetCurrent();
		rval = wi.Name;
	    }
	    else
		rval = s_infoGetter.UserLoginName;

	    return rval;
	}

	public void SetUserInfoGetter(IUserInfoGetter infoGetter)
	{
        s_infoGetter = infoGetter;
        SetCreationInfo();
        SetUpdateInfo();	    
	}

	#endregion
    }

    public interface IUserInfoGetter
    {
	string UserLoginName { get; }
    }
}

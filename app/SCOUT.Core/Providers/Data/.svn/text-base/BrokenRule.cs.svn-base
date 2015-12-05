using System;
using System.Resources;
using System.Reflection;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SCOUT.Core.Data
{
	/// <summary>
	/// Represents a broken rule in a business object.
	/// </summary>
	public class BrokenRule
    {
        #region Member Variables

        private string m_name;
        private string m_col;
        private string m_desc = null;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new rule with the given internal name.
        /// </summary>
        /// <param name="name">Inernal name of the rule.</param>
        /// <param name="col">The column the rule was broken on.</param>
		public BrokenRule(string name, string col)
		{
            m_name = name;
            m_col = col;
		}

        /// <summary>
        /// Creates a new rule with the given internal name and description.
        /// </summary>
        /// <param name="name">Inernal name of the rule.</param>
        /// <param name="desc">A fixed description, if none is given, then one
        /// will be loaded from the resource file.</param>
        /// <param name="col">The column the rule was broken on.</param>
        public BrokenRule(string name, string desc, string col)
        {
            m_name = name;
            m_col = col;
            m_desc = desc;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Internal name of the rule.
        /// </summary>
        /// <example>BAD_STKREFID</example>
        public string Name { get { return m_name; } }

        /// <summary>
        /// Name of the column with the error.
        /// </summary>
        public string Column { get { return m_col; } }

        /// <summary>
        /// The description of the rule.
        /// </summary>
        /// <note>
        /// If no description was provided, then try to load one from the 
        /// resource strings based on the user's language if available.
        /// 
        /// If no description is available then "Unknown broken rule \"X\"" is
        /// displayed where "X" is the internal name of the rule.
        /// </note>
        public string Description
        {
            get
            {
                if (m_desc == null)
                {
                    /*
                     * Attempt to load a language neutral description from
                     * the resources based on the rule's internal name.
                     */

                    // TODO: Hard coding is ugly!  Remove hard coded reference.
                    ResourceManager rm =
                        new ResourceManager("SCOUT.Resources.ErrorStrings",
                        Assembly.GetExecutingAssembly());
                    
                    try
                    {
                        m_desc = rm.GetString(m_name, 
                            Thread.CurrentThread.CurrentCulture);
                    }
                    catch (Exception)
                    {
                        m_desc = string.Format("Unknown broken rule \"{0}\"",
                            m_name);
                    }
                }

                return m_desc;
            }
        }

        #endregion

        #region Object Overloads

        public override bool Equals(object obj)
        {
            BrokenRule br = obj as BrokenRule;
            if (br != null)
                return (br.m_name == m_name);

            return false;
        }

        public override int GetHashCode()
        {
            return m_name.GetHashCode();
        }

        public override string ToString()
        {
            return Description;
        }

        #endregion
    }

    public class BrokenRuleException : System.Exception
    {
        private RobotBase m_robotBase;
	private VPObject m_vpObject;

        private List<BrokenRule> m_brokenRules;

        internal BrokenRuleException(RobotBase obj, 
            List<BrokenRule> BrokenRules)
        {
            m_robotBase = obj;
	    m_vpObject = null;
            m_brokenRules = BrokenRules;
        }

	internal BrokenRuleException(VPObject obj,
	    List<BrokenRule> BrokenRules)
	{
	    m_robotBase = null;
	    m_vpObject = obj;
	    m_brokenRules = BrokenRules;
	}

        public virtual RobotBase BaseObject
        {
            get { return m_robotBase; }
        }

	public virtual VPObject BaseVPObject
	{
	    get { return m_vpObject; }
	}

        public virtual List<BrokenRule> BrokenRules
        {
            get { return m_brokenRules; }
        }

        public override string Message
        {
            get 
	    {
		if (m_robotBase != null)
		    return m_robotBase.Error;
		else
		    return m_vpObject.Error;
	    }
        }
    }

    /// <summary>
    /// A list of broken rules.  Provides convieance functions for checking 
    /// rules which behave similar to the Assert functions in the NUnit testing
    /// framework.
    /// </summary>
    public class BrokenRules : List<BrokenRule>
    {
        /// <summary>
        /// If the condition is NOT true, then the rule is broken.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="name"></param>
        /// <param name="col"></param>
        public void IsTrue(bool condition, string name, string col)
        {
            if (!condition)
                Add(new BrokenRule(name, col));
        }

        /// <summary>
        /// If the condition is NOT true, then the rule is broken.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="name"></param>
        /// <param name="desc"></param>
        /// <param name="col"></param>
        public void IsTrue(bool condition, string name, string desc, string col)
        {
            if (!condition)
                Add(new BrokenRule(name, desc, col));
        }

        /// <summary>
        /// If the condition IS true, then the rule is broken.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="name"></param>
        /// <param name="col"></param>
        public void IsFalse(bool condition, string name, string col)
        {
            if (condition)
                Add(new BrokenRule(name, col));
        }

        /// <summary>
        /// If the condition IS true, then the rule is broken.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="name"></param>
        /// <param name="desc"></param>
        /// <param name="col"></param>
        public void IsFalse(bool condition, string name, string desc, 
            string col)
        {
            if (condition)
                Add(new BrokenRule(name, desc, col));
        }

        /// <summary>
        /// Verifies if the string is empty.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="name"></param>
        /// <param name="desc"></param>
        /// <param name="col"></param>
        public void IsEmpty(string str, string name, string desc, string col)
        {
            IsTrue((str == null) || (str == "") || (str == String.Empty),
                name, desc, col);
        }

        /// <summary>
        /// Verifies if the string is empty.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="name"></param>
        /// <param name="col"></param>
        public void IsEmpty(string str, string name, string col)
        {
            IsTrue((str == null) || (str == "") || (str == String.Empty),
                name, col);
        }

        /// <summary>
        /// Verifies that the string is NOT empty.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="name"></param>
        /// <param name="desc"></param>
        /// <param name="col"></param>
        public void IsNotEmpty(string str, string name, string desc, 
            string col)
        {
            IsTrue((str != null) && (str != "") && (str != String.Empty),
                name, desc, col);
        }

        /// <summary>
        /// Verifies that the string is NOT empty.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="name"></param>
        /// <param name="col"></param>
        public void IsNotEmpty(string str, string name, string col)
        {
            IsTrue((str != null) && (str != "") && (str != String.Empty),
                name, col);
        }

        /// <summary>
        /// Verifies that a list is empty.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="name"></param>
        /// <param name="col"></param>
        public void IsEmpty(IList list, string name, string col)
        {
            IsTrue(list.Count == 0, name, col);
        }

        /// <summary>
        /// Verifies that a list is empty.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="name"></param>
        /// <param name="desc"></param>
        /// <param name="col"></param>
        public void IsEmpty(IList list, string name, string desc, string col)
        {
            IsTrue(list.Count == 0, name, desc, col);
        }

        /// <summary>
        /// Verifies that a list is NOT empty.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="name"></param>
        /// <param name="col"></param>
        public void IsNotEmpty(IList list, string name, string col)
        {
            IsFalse(list.Count == 0, name, col);
        }

        /// <summary>
        /// Verifies that a list is NOT empty.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="name"></param>
        /// <param name="desc"></param>
        /// <param name="col"></param>
        public void IsNotEmpty(IList list, string name, string desc, string col)
        {
            IsFalse(list.Count == 0, name, desc, col);
        }

        /// <summary>
        /// Verifies that the object reference is null.
        /// </summary>
        /// <param name="o"></param>
        /// <param name="name"></param>
        /// <param name="desc"></param>
        /// <param name="col"></param>
        public void IsNull(object o, string name, string desc, string col)
        {
            if (o != null)
                Add(new BrokenRule(name, desc, col));
        }

        /// <summary>
        /// Verifies that the object points to a valid reference.
        /// </summary>
        /// <param name="o"></param>
        /// <param name="name"></param>
        /// <param name="desc"></param>
        /// <param name="col"></param>
        public void IsNotNull(object o, string name, string desc, string col)
        {
            if (o == null)
                Add(new BrokenRule(name, desc, col));
        }

        /// <summary>
        /// If obj is NOT in list, then the rule is broken.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        /// <param name="col"></param>
        public void Contains(IList list, Object obj, string name, string col)
        {
            if (!list.Contains(obj))
                Add(new BrokenRule(name, col));
        }

        /// <summary>
        /// If obj is NOT in list, then the rule is broken.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        /// <param name="desc"></param>
        /// <param name="col"></param>
        public void Contains(IList list, Object obj, string name, string desc,
            string col)
        {
            if (!list.Contains(obj))
                Add(new BrokenRule(name, desc, col));
        }

        /// <summary>
        /// If obj IS in list, then the rule is broken.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        /// <param name="col"></param>
        public void DoesNotContain(IList list, Object obj, string name,
            string col)
        {
            if (list.Contains(obj))
                Add(new BrokenRule(name, col));
        }

        /// <summary>
        /// If obj IS in list, then the rule is broken.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        /// <param name="desc"></param>
        /// <param name="col"></param>
        public void DoesNotContain(IList list, Object obj, string name,
            string desc, string col)
        {
            if (list.Contains(obj))
                Add(new BrokenRule(name, desc, col));
        }
    }
}

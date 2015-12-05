using System;
using System.Collections.Generic;
using System.Reflection;
using SCOUT.Core.Data;

namespace SCOUT.Core.Security
{
    public partial class UserSecurity
    {
        public class Action
        {
            #region Action List

            /*
             * TODO: 
             * List action constants here, values _MUST_ be unique.
             * 
             * Actions are added to the main list through reflection when 
             * the application starts.  The name of the constant is the
             * name that is displayed to the user.  E.g. "AdministrateUsers"
             * becomes "Administrate Users"
             */

            // Administration
            public const int AdministrateAdmins = -1;
            public const int AdministrateUsers = 0;
            public const int EditCompanies = 1;

            // Misc Stuff
            public const int CreateOrganizations = 50;

            // Sales
            public const int CreateSalesOrders = 100;
            public const int ShipItems = 101;

            // Purchasing
            public const int CreatePurchaseOrders = 200;
            public const int ReceiveItems = 201;

            // Inventory
            public const int SearchInventory = 300;
            public const int TransferInventory = 301;
            public const int CreateBins = 310;
            public const int ReserveBins = 311;
            public const int SplitLots = 320;
            public const int ChangePartNumbers = 321;
            public const int EditParts = 330;

            // Materials
            public const int MaterialAdjustments = 400;

            #endregion

            #region Member Variables

            private int m_value;
            private string m_title;

            #endregion

            #region Constructors

            internal Action(int Value, string Title)
            {
                m_value = Value;
                m_title = Title;
            }

            #endregion

            #region Properties

            public int Value
            {
                get { return m_value; }
                internal set { m_value = value; }
            }

            public string Title
            {
                get { return m_title; }
                internal set { m_title = value; }
            }

            #endregion

            #region Object Overrides

            public override string ToString()
            {
                return Title;
            }

            public override int GetHashCode()
            {
                return Value.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                Action a = obj as Action;

                if (a == null)
                    return false;

                return (a.Value == Value);
            }

            #endregion

            #region Operator Overloads

            static public implicit operator int(Action a)
            {
                return a.Value;
            }

            static public implicit operator Action(int i)
            {
                foreach (Action a in Actions)
                {
                    if (a.Value == i)
                        return a;
                }

                throw new Exception("Invalid action value");
            }

            #endregion
        }

        #region Action List

        static private List<Action> s_actions = null;

        static private void LoadActions()
        {
            s_actions = new List<Action>();

            // Build a list of actions based on our integer constants.
            Type ty = typeof(Action);
            FieldInfo[] fieldList = ty.GetFields(BindingFlags.Public |
                                                 BindingFlags.Static | BindingFlags.FlattenHierarchy);

            foreach (FieldInfo fi in fieldList)
            {
                if (fi.IsLiteral && !fi.IsInitOnly &&
                    (fi.FieldType == typeof(int)))
                {
                    int idx = (int)fi.GetValue(null);
                    string name = Helpers.SplitCamelCaps(fi.Name);

                    Action act = new Action(idx, name);

                    s_actions.Add(act);
                }
            }
        }

        static public List<Action> Actions
        {
            get
            {
                if (s_actions == null)
                    LoadActions();

                return s_actions;
            }
        }

        #endregion
    }
}
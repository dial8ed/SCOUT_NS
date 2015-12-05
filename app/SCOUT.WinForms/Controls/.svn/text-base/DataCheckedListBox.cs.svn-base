using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace SCOUT.WinForms.Controls
{
    [ToolboxBitmap(typeof(CheckedListBox))]
    public partial class DataCheckedListBox : CheckedListBox
    {
        public string m_listMember = "";
        public object m_foreignList = null;

        public bool m_updatingChecks = false;

        public DataCheckedListBox()
            : base()
        {
        }

        #region Properties

        protected bool UpdatingChecks
        {
            get { return m_updatingChecks; }
            set
            {
                if (m_updatingChecks != value)
                {
                    m_updatingChecks = value;

                    if (m_updatingChecks)
                        ResumeLayout();
                    else
                        SuspendLayout();
                }
            }
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        [RefreshProperties(RefreshProperties.All)]
        [Browsable(true)]
        public new object DataSource
        {
            get { return base.DataSource; }
            set { base.DataSource = value; }
        }

        [Category("Data")]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, " +
                       "System.Design, Version=2.0.0.0, Culture=neutral, " +
                       "PublicKeyToken=b03f5f7f11d50a3a")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, " +
                "System.Design, Version=2.0.0.0, Culture=neutral, " +
                "PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [Browsable(true)]
        public new string DisplayMember
        {
            get { return base.DisplayMember; }
            set { base.DisplayMember = value; }
        }

        [Category("Data")]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, " +
                       "System.Design, Version=2.0.0.0, Culture=neutral")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, " +
                "System.Design, Version=2.0.0.0, Culture=neutral", typeof(UITypeEditor))]
        [Browsable(true)]
        public new string ValueMember
        {
            get { return base.ValueMember; }
            set { base.ValueMember = value; }
        }

        [Category("Data")]
        [Description("Gets or sets the member property to use when " +
                     "checking items in the foriegn list.")]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, " +
                       "System.Design, Version=2.0.0.0, Culture=neutral, " +
                       "PublicKeyToken=b03f5f7f11d50a3a")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, " +
                "System.Design, Version=2.0.0.0, Culture=neutral, " +
                "PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [Browsable(true)]
        public string ListMember
        {
            get { return m_listMember; }
            set { m_listMember = value; }
        }

        [Category("Data")]
        [Description("Gets or sets the foriegn list to use for the " +
                     "checked items.")]
        [AttributeProvider(typeof(IListSource))]
        [RefreshProperties(RefreshProperties.All)]
        [Browsable(true)]
        public object ForeignList
        {
            get { return m_foreignList; }
            set
            {
                m_foreignList = value;
                CheckForeignItems();
            }
        }

        #endregion

        #region Helpers

        protected IList GetForeignInnerList()
        {
            if (m_foreignList == null)
                return null;

            if ((m_listMember == null) || (m_listMember == ""))
                return (m_foreignList as IList);

            PropertyInfo prop =
                m_foreignList.GetType().GetProperty(m_listMember);

            return (prop.GetValue(m_foreignList, new object[] { }) as
                    IList);
        }

        protected void CheckForeignItems()
        {
            IList ml = DataSource as IList;
            IList fl = GetForeignInnerList();

            if ((ml == null) || (fl == null))
                return;

            UpdatingChecks = true;
            for (int i = 0; i < ml.Count; ++i)
                SetItemChecked(i, fl.Contains(ml[i]));
            UpdatingChecks = false;
        }

        #endregion

        #region Events

        protected override void OnItemCheck(ItemCheckEventArgs ice)
        {
            base.OnItemCheck(ice);

            if (UpdatingChecks)
                return;

            IList ml = DataSource as IList;
            IList fl = GetForeignInnerList();

            if ((ml == null) || (fl == null))
                return;

            if (ice.NewValue == CheckState.Checked)
                fl.Add(ml[ice.Index]);
            else
                fl.Remove(ml[ice.Index]);
        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using DevExpress.Utils;
using DevExpress.XtraLayout;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.WinForms.Views;


namespace SCOUT.WinForms.Parts
{
    public partial class PartAttributesControl :
        DevExpress.XtraEditors.XtraUserControl
    {
        private Part m_part;
        private List<LayoutControlItem> m_layoutControls;

        /// <summary>
        /// Constructor
        /// </summary>
        public PartAttributesControl()
        {
            InitializeComponent();
            RegisterLayoutControls();
            DataSource = null;
        }

        /// <summary>
        /// Location of the attribute name labels
        /// </summary>
        public Locations TextLocation
        {
            set { SetLabelLocation(value); }
        }

        /// <summary>
        /// Sets all registered layout control items text position
        /// </summary>
        /// <param name="location"></param>
        private void SetLabelLocation(Locations location)
        {
            layoutControl1.SuspendLayout();

            foreach (LayoutControlItem item in m_layoutControls)
            {
                item.TextLocation = location;
            }

            layoutControl1.ResumeLayout();
        }

        /// <summary>
        /// Adds the form layout controls to a internal list
        /// </summary>
        private void RegisterLayoutControls()
        {
            m_layoutControls = new List<LayoutControlItem>();
            m_layoutControls.Add(layout1);
            m_layoutControls.Add(layout2);
            m_layoutControls.Add(layout3);
            m_layoutControls.Add(layout4);
            m_layoutControls.Add(layout5);
            m_layoutControls.Add(layout6);
            m_layoutControls.Add(layout7);
            m_layoutControls.Add(layout8);
            m_layoutControls.Add(layout9);
            m_layoutControls.Add(layout10);
        }

        /// <summary>
        /// Attribute data source
        /// </summary>
        public Part DataSource
        {
            get { return m_part; }
            set
            {
                m_part = value;
                if (m_part != null)
                {
                    WireEvents();
                    Bind();
                }
                else
                {
                    Clear();
                }
            }
        }

        /// <summary>
        /// Clears and hides the attribute display controls
        /// </summary>
        private void Clear()
        {
            // Hide the attribute panels
            ViewHelper.ProcessLayoutItems(ViewHelper.HideLayoutItem,
                                          m_layoutControls);

            // Clear the text 
            ViewHelper.ProcessLayoutItems(ViewHelper.ClearLayoutItemText,
                                          m_layoutControls);
        }

        /// <summary>
        /// Loads the attribute values into the form controls
        /// </summary>
        private void Bind()
        {
            if (m_part.Attributes == null)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage(
                    "There are no attributes to display",
                    UserMessageType.Information);
                return;
            }

            ViewHelper.ProcessLayoutItems(ViewHelper.ShowLayoutItem,
                                          m_layoutControls);

            LayoutValues(m_part.Attributes);
            LayoutHeader(m_part.ServiceCommodity.AttributesHeader);
        }

        /// <summary>
        /// ?
        /// </summary>
        /// <param name="item"></param>
        public void HandleTextChanged(LayoutControlItem item)
        {
            item.TextChanged += configLayout_TextChanged;
        }

        /// <summary>
        /// Loads the attribute values into the display controls
        /// </summary>
        /// <param name="values"></param>
        private void LayoutValues(PartAttributeValues values)
        {
            if (values == null) return;

            value1Text.Text = values.Attr1;
            value2Text.Text = values.Attr2;
            value3Text.Text = values.Attr3;
            value4Text.Text = values.Attr4;
            value5Text.Text = values.Attr5;
            value6Text.Text = values.Attr6;
            value7Text.Text = values.Attr7;
            value8Text.Text = values.Attr8;
            value9Text.Text = values.Attr9;
            value10Text.Text = values.Attr10;
        }

        /// <summary>
        /// Loads the attributes headers into the display controls
        /// </summary>
        /// <param name="header"></param>
        private void LayoutHeader(PartAttributesHeader header)
        {
            if (header == null) return;

            layout1.Text = header.Attr1;
            layout2.Text = header.Attr2;
            layout3.Text = header.Attr3;
            layout4.Text = header.Attr4;
            layout5.Text = header.Attr5;
            layout6.Text = header.Attr6;
            layout7.Text = header.Attr7;
            layout8.Text = header.Attr8;
            layout9.Text = header.Attr9;
            layout10.Text = header.Attr10;
        }


        private void WireEvents()
        {
            ViewHelper.ProcessLayoutItems(HandleTextChanged, m_layoutControls);
        }

        /// <summary>
        /// Shows or hides a control label.
        /// If a attribute is not defined then the label is not shown.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void configLayout_TextChanged(object sender, EventArgs e)
        {
            LayoutControlItem layoutItem = sender as LayoutControlItem;
            if (layoutItem != null)
            {
                if (layoutItem.Text == layoutItem.Name)
                    layoutItem.ContentVisible = false;
                else
                    layoutItem.ContentVisible = true;
            }
        }
    }
}
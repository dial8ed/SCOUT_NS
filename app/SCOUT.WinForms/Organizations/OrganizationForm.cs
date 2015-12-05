using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using SCOUT.Core.Data;
using SCOUT.WinForms.Core;

namespace SCOUT.WinForms
{
    public partial class OrganizationForm : Form
    {
        private BindingList<Organization> m_allOrgs;
        private BindingList<Organization> m_orgs;

        public OrganizationForm()
        {
            InitializeComponent();

            /*
             * We have to set this here to avoid a bug with how
             * the designer likes to order the setting of the 
             * properties and an exception that the split area
             * will throw if this is set before the splitter's
             * distance is set.
             */
            splitArea.Panel2MinSize = 180;

            ReloadOrgList(null);

#if DEBUG || WITH_TESTS
            // For testing.
            viewFilterList.Items.Add("None");
#endif
            viewFilterList.SelectedIndex = 0;           

            foreach (Control c in wrapperPanel.Controls)
            {
                c.Dock = DockStyle.Fill;
                c.Visible = false;
            }

            extraDispList.DataSource = wrapperPanel.Controls;
            extraDispList.DisplayMember = "Tag";
            extraDispList.SelectedIndex = 0;
        }

        

        private static bool Active(Organization o)
        {
            return o.Active;
        }

        private static bool Inactive(Organization o)
        {
            return !o.Active;
        }

        private void ApplyFilter()
        {
            if (m_allOrgs == null)
            {
                m_orgs = null;
                return;
            }

            List<Organization> l = new List<Organization>(m_allOrgs);
            string sel = viewFilterList.SelectedItem as string;

            switch(sel)
            {
#if DEBUG || WITH_TESTS
            case "None":
                // Special case, pretend none match.
                m_orgs = new BindingList<Organization>();
                break;
#endif
            case "All":
                m_orgs = m_allOrgs;
                return;

            case "Inactive":
                m_orgs = new BindingList<Organization>(l.FindAll(Inactive));
                break;

            case "Custom...":
                break;

            case "Active":
            default:
                m_orgs = new BindingList<Organization>(l.FindAll(Active));
                break;
            }
        }

        private void ReloadOrgList(Organization sel)
        {
            m_allOrgs = Organization.GetActiveOrganizations();

            ApplyFilter();
            UpdateBindings(sel);
        }

        private void ClearControl(Control c)
        {
            c.DataBindings.Clear();
            c.Text = "";
        }

        private void ClearBindings()
        {
            // First column
            ClearControl(nameTxt);
            ClearControl(regionTxt);

            addrList.DataBindings.Clear();
            addrList.DataSource = null;

            addrTxt.Text = "";

            // Second column
            ClearControl(phoneTxt);
            ClearControl(faxTxt);

            contList.DataBindings.Clear();
            contList.DataSource = null;

            contDetails.Text = "";

            // Bottom section
            ClearControl(notesTxt);

            custFieldList.DataBindings.Clear();
            custFieldList.DataSource = null;
        }

        private void SetBinding(string Prop, Control c, string DataProp)
        {
            c.DataBindings.Add(Prop, m_orgs, DataProp);
        }

        private void UpdateBindings(Organization sel)
        {
            ClearBindings();

            if (m_orgs == null)
                return;

            orgList.DataSource = m_orgs;
            orgList.DisplayMember = "Name";

            // First column
            SetBinding("Text", nameTxt, "Name");
            SetBinding("Text", regionTxt, "Region");

            SetBinding("DataSource", addrList, "Addresses");
            addrList.DisplayMember = "Label";

            // Second column
            SetBinding("Text", phoneTxt, "Phone");
            SetBinding("Text", faxTxt, "Fax");

            SetBinding("DataSource", contList, "Contacts");
            contList.DisplayMember = "Name";

            // Bottom section
            SetBinding("Text", notesTxt, "Notes");
            SetBinding("DataSource", custFieldList, "CustomFields");

            if (sel != null)
            {
                for (int i = 0; i < m_orgs.Count; ++i)
                {
                    Organization o = m_orgs[i];

                    if (o.Id == sel.Id)
                    {
                        orgList.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void UpdateListDetails(ComboBox cb, TextBox details)
        {
            if (cb.SelectedItem != null)
                details.Text = cb.SelectedItem.ToString();
            else
                details.Text = "";
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            EditOrganizationForm dlg = new EditOrganizationForm(null);

            if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                ReloadOrgList(dlg.Organization);
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            Organization o = orgList.SelectedValue as Organization;
            EditOrganizationForm dlg = new EditOrganizationForm(o);

            if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                ReloadOrgList(dlg.Organization);
        }

        private void extraDispList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Panel p;

            foreach (object o in extraDispList.Items)
            {
                p = o as Panel;
                p.Visible = false;
            }

            p = extraDispList.SelectedItem as Panel;
            p.Visible = true;
        }

        private void addrList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (addrList.SelectedItem != null)
                addrTxt.Text = addrList.SelectedItem.ToString();
            else
                addrTxt.Text = "";
        }

        private void mapLink_LinkClicked(object sender, 
            LinkLabelLinkClickedEventArgs e)
        {
            string query = "http://maps.google.com/maps?q={0}";
            string text = addrTxt.Text;

            text = text.Replace(Environment.NewLine, ",");
            text = Util.UriEncode(text);

            Process.Start(String.Format(query, text));
        }

        private void orgList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateListDetails(addrList, addrTxt);
            UpdateListDetails(contList, contDetails);
        }

        private void contList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (contList.SelectedItem != null)
            {
                Contact c = (Contact)contList.SelectedItem;
                contDetails.Text = c.Details;
            }
            else
                contDetails.Text = "";
        }

        private void emailLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Contact c = contList.SelectedValue as Contact;

            if ((c != null) && (c.Email != ""))
            {
                string query = String.Format("mailto:{0}", c.Email);

                Process.Start(query);
            }
        }

        private void viewFilterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Organization o = orgList.SelectedValue as Organization;

            ApplyFilter();
            UpdateBindings(o);
        }
    }
}
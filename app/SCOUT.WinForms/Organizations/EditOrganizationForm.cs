using System.Windows.Forms;
using SCOUT.Core.Data;
using System;

namespace SCOUT.WinForms
{
    public partial class EditOrganizationForm : Form
    {
        private Organization m_org = null;

        public EditOrganizationForm(Organization org)
        {
            InitializeComponent();

            if (org == null)
            {
                m_org = new Organization();
                Text = "New Organization";
            }
            else
            {
                m_org = org;
                Text = "Editing Organization: " + m_org.Name;
            }

            BindData(org);

            addrLayoutArea.DataBindings.Add("Enabled", this, "ValidAddress");
            contactLayoutArea.DataBindings.Add("Enabled", this, "ValidContact");
            defaultReturnTypeLookup.Properties.DataSource = Enum.GetValues(typeof (ReturnType));

        }

        #region Utility

        private void BindData(Organization org)
        {
            // Details Tab
            nameTxt.DataBindings.Add("Text", m_org, "Name");

            phoneTxt.DataBindings.Add("Text", m_org, "Phone");
            regionTxt.DataBindings.Add("Text", m_org, "Region");
            faxTxt.DataBindings.Add("Text", m_org, "Fax");
            notesTxt.DataBindings.Add("Text", m_org, "Notes");

            // Address Tab
            addrList.DataSource = m_org.Addresses;
            addrList.DisplayMember = "Label";

            labelTxt.DataBindings.Add("Text", m_org.Addresses, "Label");
            linesTxt.DataBindings.Add("Text", m_org.Addresses, "Street");

            streetOnlyChk.DataBindings.Add("Checked", m_org.Addresses, "StreetOnly");

            cityTxt.DataBindings.Add("Text", m_org.Addresses, "City");
            stateTxt.DataBindings.Add("Text", m_org.Addresses, "State");
            zipTxt.DataBindings.Add("Text", m_org.Addresses, "PostalCode");

            countryList.DataSource = Country.All;
            countryList.ValueMember = "A3";
            countryList.DisplayMember = "Name";

            countryList.DataBindings.Add("SelectedValue", m_org.Addresses,
                "CountryCode");
            zipTxt.DataBindings.Add("Mask", Country.All, "PCMask");

            // Contacts Tab
            contactsList.DataSource = m_org.Contacts;
            contactsList.DisplayMember = "Name";

            contactTxt.DataBindings.Add("Text", m_org.Contacts, "Name");
            contactEmailTxt.DataBindings.Add("Text", m_org.Contacts, "Email");
            contactPriPhoneTxt.DataBindings.Add("Text", m_org.Contacts, 
                "Phone");
            contactAltPhoneTxt.DataBindings.Add("Text", m_org.Contacts, 
                "AltPhone");
            contactFaxTxt.DataBindings.Add("Text", m_org.Contacts,
                "Fax");
            contactOtherTxt.DataBindings.Add("Text", m_org.Contacts,
                "Other");

            // Custom Fields Tab
            custFieldList.DataBindings.Add("DataSource", m_org, "CustomFields");

            // Misc stuff
            activeChk.DataBindings.Add("Checked", m_org, "Active");

            // Defaults
            defaultReturnTypeLookup.DataBindings.Add("EditValue", m_org, "DefaultReturnType");

        }

        private void ForceDataUpdate(Control c)
        {
            foreach (Binding b in c.DataBindings)
                b.ReadValue();
        }

        private bool Save()
        {
            try
            {
                m_org.Save();
            }
            catch (BrokenRuleException excp)
            {
		InfoBox ib = new InfoBox();

		ib.Icon = MessageBoxIcon.Error;
		ib.Show("Error saving organization:\r{0}", excp.Message);

                return false;
            }

            return true;
        }

        #endregion

        #region Properties

        public Organization Organization
        {
            get { return m_org; }
        }

        #region Enable/Disable Hack

        public bool ValidAddress
        {
            get
            {
                return (addrList.SelectedIndex >= 0);
            }
        }

        public bool ValidContact
        {
            get
            {
                return (contactsList.SelectedIndex >= 0);
            }
        }

        #endregion

        #endregion

        #region Events

        private void okBtn_Click(object sender, System.EventArgs e)
        {
            if (Save())
                DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void cancelBtn_Click(object sender, System.EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void newAddrBtn_Click(object sender, System.EventArgs e)
        {
            Address a = new Address(m_org);

            m_org.Addresses.Add(a);

            addrList.SelectedIndex = m_org.Addresses.IndexOf(a);
            ForceDataUpdate(addrLayoutArea);

            labelTxt.Select();
        }

        private void delAddrBtn_Click(object sender, System.EventArgs e)
        {
            if (m_org.Addresses.Count > 0)
            {
                Address a = m_org.Addresses[addrList.SelectedIndex];
		InfoBox ib = new InfoBox();
		DialogResult res;

		ib.Buttons = MessageBoxButtons.YesNo;
		res = ib.Show("You are about to delete the \"{0}\" address." +
		    "This operation cannot be undone.\r\r" +
                    "Are you sure you wish to do this?",
                    a.Label);

                if (res == DialogResult.Yes)
                    m_org.Addresses.Remove(a);
            }
        }

        private void defineFldsBtn_Click(object sender, System.EventArgs e)
        {
            CustomFieldDefForm dlg = new CustomFieldDefForm();

            dlg.ShowDialog(this);
        }

        private void newContBtn_Click(object sender, System.EventArgs e)
        {
            Contact c = new Contact(m_org);

            m_org.Contacts.Add(c);

            contactsList.SelectedIndex = m_org.Contacts.IndexOf(c);
            ForceDataUpdate(contactLayoutArea);

            contactTxt.Select();
        }

        private void delContBtn_Click(object sender, System.EventArgs e)
        {
            if (m_org.Contacts.Count > 0)
            {
                Contact c = m_org.Contacts[contactsList.SelectedIndex];
		InfoBox ib = new InfoBox();
		DialogResult res;

		ib.Buttons = MessageBoxButtons.YesNo;
		res = ib.Show("You are about to delete the contact \"{0}\".  " +
		    "This operation cannot be undone.\r\r" +
                    "Are you sure you wish to do this?",
                    c.Name);

                if (res == DialogResult.Yes)
                    m_org.Contacts.Remove(c);
            }
        }

        #endregion
    }
}

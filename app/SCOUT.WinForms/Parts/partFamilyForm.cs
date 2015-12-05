using System;
using DevExpress.Xpo;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.Core.Services;


namespace SCOUT.WinForms.Parts
{
    public partial class PartFamilyForm : DevExpress.XtraEditors.XtraForm
    {
        private PartFamily m_family;
        private IUnitOfWork m_session;

        public PartFamilyForm(PartFamily family)
        {
            InitializeComponent();
            m_family = family;
            Bind();
            WireEvents();
        }
        
        private void Bind()
        {
            m_session = m_family.Session;
            familyLabelText.DataBindings.Add("Text", m_family, "Label");
            memberGrid.DataSource = m_family.Members;
            commodityLookup.Properties.DataSource = PartService.GetPartServiceCommodities(m_session);
            commodityLookup.DataBindings.Add("EditValue", m_family, "ServiceCommodity!");
            allowOutgoingOverrideCheck.DataBindings.Add("Checked", m_family,
                                                        "AllowOutgoingOverride");

        }

        private void WireEvents()
        {
            okButton.Click += okButton_Click;
            cancelButton.Click += cancelButton_Click;
            partText.Validated += partText_Validated;
            removePartLink.LinkClicked += removePartLink_LinkClicked;
        }

        void removePartLink_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Part member = memberView.GetFocusedRow() as Part;
            if (member != null)
            {
                m_family.RemoveMember(member);
            }
        }

        void partText_Validated(object sender, EventArgs e)
        {
            AddPart();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                Scout.Core.Data.Save(m_session);
                Close();
            }
            catch (Exception ex)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage(ex.Message, UserMessageType.Error);
            }
        }

        private void addPartButton_Click(object sender, EventArgs e)
        {
            AddPart();
        }

        private void AddPart()
        {
            if (partText.Text.Length == 0) return;

            Part part = PartService.GetPartByPartNumber(m_session, partText.Text);

            if(!ValidPart(part)) return;

            m_family.AddMember(part);

            Reset();

        }

        private void Reset()
        {
            partText.Text = "";
            partText.Focus();
        }

        private bool ValidPart(Part part)
        {
            if (part == null)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage("Invalid Part Number", UserMessageType.Error);
                partText.SelectAll();
                partText.Focus();
                return false;
            }

            return true;
        }
    }
}
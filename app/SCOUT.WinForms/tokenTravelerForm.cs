using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.Xpo;
using SCOUT.Core.Data;
using SCOUT.Core.Services;

namespace SCOUT.WinForms
{
    public partial class TokenTravelerForm : DevExpress.XtraEditors.XtraForm
    {
        private List<KeyValuePair<string, string>> m_tokenTypeList;
        private IUnitOfWork m_uow;

        private XPCollection<TokenType> m_tokenTypes;

        private SerializedUnit m_serializedUnit;
        private DataRow m_unitData;
      
        public TokenTravelerForm(DataRow dataRow)
        {
            InitializeComponent();
            m_unitData = dataRow;
            Init();
        }

        private void Init()
        {
            m_uow = Scout.Core.Data.GetUnitOfWork();
            m_tokenTypes = new XPCollection<TokenType>(m_uow as XpoUnitOfWork);        
            tokenTypeSelList.Properties.Items.AddRange(m_tokenTypes);
            LoadUnit();
            WireEvents();            
        }

        private bool Save()
        {
            if (GatherTokenString())
            {
                try
                {
                    Scout.Core.Data.Save(m_uow);                    
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return false;
        }

        private bool GatherTokenString()
        {
            if(tokenTypeSelList.EditValue == null)
            {
                MessageBox.Show("Token traveler type is required.",
                                Application.ProductName,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return false;
            }

            m_serializedUnit.TokenTraveler = tokenGrid.ToString();
            m_serializedUnit.TokenType = (TokenType) tokenTypeSelList.EditValue;
            return true;
        }

        private void LoadUnit()
        {
            string lotId;
            lotId = m_unitData["Lot Id"].ToString();

            m_serializedUnit = Scout.Core.Service<IInventoryService>().GetSerializedUnitById(m_uow, lotId);
            
            if(m_serializedUnit != null)
            {
                serialNumberText.Text = m_serializedUnit.InitIdent;

                if (m_serializedUnit.TokenTraveler != null)
                {
                    DisplayProperties(m_serializedUnit.TokenTraveler);
                    tokenTypeSelList.EditValue = m_serializedUnit.TokenType;
                } 
            }          
        }

        private void WireEvents()
        {
            tokenTypeSelList.SelectedValueChanged += tokenTypeSelList_SelectedValueChanged;
        }

        void tokenTypeSelList_SelectedValueChanged(object sender, EventArgs e)
        {
            TokenType tokenType = tokenTypeSelList.EditValue as TokenType;
            if(tokenType != null)
            {
                DisplayProperties(tokenType.TokenString);
            }                       
        }

        private void DisplayProperties(string value)
        {
            tokenGrid.DisplayProperties(value);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            okButton.Focus();
            if(Save())
                Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
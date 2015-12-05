using System;
using System.Threading;
using System.Windows.Forms;
using SCOUT.Core.Data;


namespace SCOUT.WinForms.Orders
{
    public partial class PreAlertImportProgressForm : DevExpress.XtraEditors.XtraForm
    {
        private LineItemImportValidator m_validator;
        
        private delegate void WriteTextHandler(string text);

        private delegate void ProgressIncrementHandler();
        
        public PreAlertImportProgressForm(LineItemImportValidator validator)
        {
            InitializeComponent();
            m_validator = validator;
            m_validator.ItemProcessing += m_validator_ItemProcessing;
            m_validator.ValidationFinished += m_validator_ValidationFinished;

            progressBarControl1.Properties.Maximum = m_validator.LineItemCount;
            progressBarControl1.Properties.Step = 1;
            progressBarControl1.Position = Left;

            this.HandleCreated += importProgressForm_HandleCreated;
        
        }

        void importProgressForm_HandleCreated(object sender, EventArgs e)
        {
            StartValidationThread();
        }


        void m_validator_ValidationFinished()
        {
            DialogResult = DialogResult.OK;
        }


        private void StartValidationThread()
        {
            ThreadStart job = m_validator.Validate;
            Thread thread = new Thread(job);
            thread.Start();                 
        }


        void m_validator_ItemProcessing(object sender,ProcessingImportPartEventArgs e)
        {
            Invoke(new WriteTextHandler(WriteText), 
                new object[1]{e.ItemBeingProcessed.PartNumber});

            Invoke(new ProgressIncrementHandler(UpdateProgress));            
        }


        private void WriteText(string text)
        {
            currentLabel.Text = "Currently validating: " + text;
        }


        private void UpdateProgress()
        {            
            progressBarControl1.PerformStep();
        }
    }
}
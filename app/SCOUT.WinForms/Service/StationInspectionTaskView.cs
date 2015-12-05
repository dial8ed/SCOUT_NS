using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SCOUT.Core.Data;
using SCOUT.Core.Mvc;
using SCOUT.WinForms.Core;

namespace SCOUT.WinForms.Service
{
    public partial class StationInspectionTaskView : PassiveViewBase,
                                                     IStationInspectionTaskView
    {       
        public StationInspectionTaskView()
        {
            InitializeComponent();            
            WireEvents();
        }

        private void WireEvents()
        { 
            imagePathEdit.ButtonClick += imagePathEdit_ButtonClick;
            okButton.Click += okButton_Click;
            cancelButton.Click += cancelButton_Click;
        }

        void cancelButton_Click(object sender, EventArgs e)
        {            
            EventsController.ActionRequestEvents.Fire(this,"cancel");
        }

        void okButton_Click(object sender, EventArgs e)
        {
            EventsController.ActionRequestEvents.Fire(this, "save");
        }

        private void imagePathEdit_ButtonClick(object sender,
                                               DevExpress.XtraEditors.Controls.
                                                   ButtonPressedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = ImageService.ImageFilter;
            fileDialog.FilterIndex = 2;

            fileDialog.ShowDialog(this);

            if (!string.IsNullOrEmpty(fileDialog.FileName))
                LoadImageFromFile(fileDialog.FileName);
        }

        private void LoadImageFromFile(string filePath)
        {
            Image image = Image.FromFile(filePath);
            damagePictureEdit.Image = image;
        }

        public ServiceCode FailureCode
        {
            get { return failureLookUp.EditValue as ServiceCode; }
            set { failureLookUp.EditValue = value;}
        }

        public string DamageType
        {
            get
            {
                if (damageTypeEdit.SelectedItem == null)
                    return "";

                return damageTypeEdit.SelectedItem.ToString();
            }
            set
            {
                damageTypeEdit.SelectedItem = value;
            }
        }

        public string DamageMethod
        {
            get { 
                
                if(damageMethodLookUp.SelectedItem == null)
                    return "";
           
                return damageMethodLookUp.SelectedItem.ToString(); }

            set
            {
                damageMethodLookUp.SelectedItem = value;
            }
        }
    

        public string Comments
        {
            get { return commentsEdit.Text; }
            set { commentsEdit.Text = value;}
        }

        public Image Image
        {
            get { return damagePictureEdit.Image; }
            set { damagePictureEdit.Image = value;}
        }

        public RouteStationStep Step
        {
            get { return stepLookUp.EditValue as RouteStationStep; }
            set { stepLookUp.EditValue = value; }
        }

        public RouteStationProcess Process
        {
            set { 
                // Do Nothing 
            }
        }

        public ICollection<ServiceCode> FailCodes
        {
            set
            {
                failureLookUp.Properties.DataSource = value;
            }
        }

        public ICollection<RouteStationStep> Steps
        {
            set { stepLookUp.Properties.DataSource = value; }
        }
    }
}
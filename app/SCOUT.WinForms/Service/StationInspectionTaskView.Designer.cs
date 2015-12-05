using System;

namespace SCOUT.WinForms.Service
{
    partial class StationInspectionTaskView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.damageMethodLookUp = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cancelButton = new DevExpress.XtraEditors.SimpleButton();
            this.okButton = new DevExpress.XtraEditors.SimpleButton();
            this.imagePathEdit = new DevExpress.XtraEditors.ButtonEdit();
            this.damagePictureEdit = new DevExpress.XtraEditors.PictureEdit();
            this.commentsEdit = new DevExpress.XtraEditors.MemoEdit();
            this.failureLookUp = new DevExpress.XtraEditors.LookUpEdit();
            this.stepLookUp = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.damageTypeEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.damageMethodLookUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagePathEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.damagePictureEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commentsEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.failureLookUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepLookUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.damageTypeEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.damageMethodLookUp);
            this.layoutControl1.Controls.Add(this.cancelButton);
            this.layoutControl1.Controls.Add(this.okButton);
            this.layoutControl1.Controls.Add(this.imagePathEdit);
            this.layoutControl1.Controls.Add(this.damagePictureEdit);
            this.layoutControl1.Controls.Add(this.commentsEdit);
            this.layoutControl1.Controls.Add(this.failureLookUp);
            this.layoutControl1.Controls.Add(this.stepLookUp);
            this.layoutControl1.Controls.Add(this.labelControl1);
            this.layoutControl1.Controls.Add(this.damageTypeEdit);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(645, 407);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // damageMethodLookUp
            // 
            this.damageMethodLookUp.Location = new System.Drawing.Point(98, 111);
            this.damageMethodLookUp.Name = "damageMethodLookUp";
            this.damageMethodLookUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.damageMethodLookUp.Properties.Items.AddRange(new object[] {
            "PID",
            "CID"});
            this.damageMethodLookUp.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.damageMethodLookUp.Size = new System.Drawing.Size(229, 20);
            this.damageMethodLookUp.StyleController = this.layoutControl1;
            this.damageMethodLookUp.TabIndex = 13;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(480, 373);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(153, 22);
            this.cancelButton.StyleController = this.layoutControl1;
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "Cancel";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(331, 373);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(145, 22);
            this.okButton.StyleController = this.layoutControl1;
            this.okButton.TabIndex = 11;
            this.okButton.Text = "Ok";
            // 
            // imagePathEdit
            // 
            this.imagePathEdit.Location = new System.Drawing.Point(417, 39);
            this.imagePathEdit.Name = "imagePathEdit";
            this.imagePathEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.imagePathEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.imagePathEdit.Size = new System.Drawing.Size(216, 20);
            this.imagePathEdit.StyleController = this.layoutControl1;
            this.imagePathEdit.TabIndex = 10;
            // 
            // damagePictureEdit
            // 
            this.damagePictureEdit.Location = new System.Drawing.Point(331, 63);
            this.damagePictureEdit.Name = "damagePictureEdit";
            this.damagePictureEdit.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.damagePictureEdit.Size = new System.Drawing.Size(302, 306);
            this.damagePictureEdit.StyleController = this.layoutControl1;
            this.damagePictureEdit.TabIndex = 9;
            // 
            // commentsEdit
            // 
            this.commentsEdit.Location = new System.Drawing.Point(98, 135);
            this.commentsEdit.Name = "commentsEdit";
            this.commentsEdit.Size = new System.Drawing.Size(229, 234);
            this.commentsEdit.StyleController = this.layoutControl1;
            this.commentsEdit.TabIndex = 8;
            // 
            // failureLookUp
            // 
            this.failureLookUp.Location = new System.Drawing.Point(98, 63);
            this.failureLookUp.Name = "failureLookUp";
            this.failureLookUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.failureLookUp.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Category!", "Category"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "Code"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", "Description")});
            this.failureLookUp.Properties.NullText = "[Select failure]";
            this.failureLookUp.Size = new System.Drawing.Size(229, 20);
            this.failureLookUp.StyleController = this.layoutControl1;
            this.failureLookUp.TabIndex = 6;
            // 
            // stepLookUp
            // 
            this.stepLookUp.Location = new System.Drawing.Point(98, 39);
            this.stepLookUp.Name = "stepLookUp";
            this.stepLookUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.stepLookUp.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DisplayPrompt", "Step")});
            this.stepLookUp.Properties.DisplayMember = "DisplayPrompt";
            this.stepLookUp.Properties.NullText = "[Select step]";
            this.stepLookUp.Properties.ValueMember = "This";
            this.stepLookUp.Size = new System.Drawing.Size(229, 20);
            this.stepLookUp.StyleController = this.layoutControl1;
            this.stepLookUp.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(621, 23);
            this.labelControl1.StyleController = this.layoutControl1;
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Inspection Damage";
            // 
            // damageTypeEdit
            // 
            this.damageTypeEdit.Location = new System.Drawing.Point(98, 87);
            this.damageTypeEdit.Name = "damageTypeEdit";
            this.damageTypeEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.damageTypeEdit.Properties.Items.AddRange(new object[] {
            "PACKAGING",
            "BER",
            "REPAIRABLE"});
            this.damageTypeEdit.Properties.PopupSizeable = true;
            this.damageTypeEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.damageTypeEdit.Size = new System.Drawing.Size(229, 20);
            this.damageTypeEdit.StyleController = this.layoutControl1;
            this.damageTypeEdit.TabIndex = 7;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem1,
            this.emptySpaceItem2,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.layoutControlItem10});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(645, 407);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.stepLookUp;
            this.layoutControlItem2.CustomizationFormText = "Step:";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 27);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(319, 24);
            this.layoutControlItem2.Text = "Step:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(82, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.failureLookUp;
            this.layoutControlItem3.CustomizationFormText = "Failure:";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 51);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(319, 24);
            this.layoutControlItem3.Text = "Failure:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(82, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.damageTypeEdit;
            this.layoutControlItem4.CustomizationFormText = "Damage Type:";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 75);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(319, 24);
            this.layoutControlItem4.Text = "Damage Type:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(82, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.labelControl1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(625, 27);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 361);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(319, 26);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.commentsEdit;
            this.layoutControlItem5.CustomizationFormText = "Comments:";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 123);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(319, 238);
            this.layoutControlItem5.Text = "Comments:";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(82, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.damagePictureEdit;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(319, 51);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(306, 310);
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.imagePathEdit;
            this.layoutControlItem7.CustomizationFormText = "Image Path:";
            this.layoutControlItem7.Location = new System.Drawing.Point(319, 27);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(306, 24);
            this.layoutControlItem7.Text = "Image Path:";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(82, 13);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.okButton;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new System.Drawing.Point(319, 361);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(149, 26);
            this.layoutControlItem8.Text = "layoutControlItem8";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextToControlDistance = 0;
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.cancelButton;
            this.layoutControlItem9.CustomizationFormText = "layoutControlItem9";
            this.layoutControlItem9.Location = new System.Drawing.Point(468, 361);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(157, 26);
            this.layoutControlItem9.Text = "layoutControlItem9";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextToControlDistance = 0;
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.damageMethodLookUp;
            this.layoutControlItem10.CustomizationFormText = "Damage Method:";
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 99);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(319, 24);
            this.layoutControlItem10.Text = "Damage Method:";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(82, 13);
            // 
            // StationInspectionTaskView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 407);
            this.ControlBox = false;
            this.Controls.Add(this.layoutControl1);
            this.Name = "StationInspectionTaskView";
            this.Text = "Report Inspection Damage";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.damageMethodLookUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagePathEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.damagePictureEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commentsEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.failureLookUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepLookUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.damageTypeEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.LookUpEdit failureLookUp;
        private DevExpress.XtraEditors.LookUpEdit stepLookUp;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.PictureEdit damagePictureEdit;
        private DevExpress.XtraEditors.MemoEdit commentsEdit;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.SimpleButton cancelButton;
        private DevExpress.XtraEditors.SimpleButton okButton;
        private DevExpress.XtraEditors.ButtonEdit imagePathEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraEditors.ComboBoxEdit damageTypeEdit;
        private DevExpress.XtraEditors.ComboBoxEdit damageMethodLookUp;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;

    }
}
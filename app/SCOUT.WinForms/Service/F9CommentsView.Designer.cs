namespace SCOUT.WinForms.Service
{
    partial class F9CommentsView
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
            this.f9CommentsMemo = new DevExpress.XtraEditors.MemoEdit();
            this.partNumberText = new DevExpress.XtraEditors.TextEdit();
            this.serialText = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.f9CommentsMemo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partNumberText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serialText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.f9CommentsMemo);
            this.layoutControl1.Controls.Add(this.partNumberText);
            this.layoutControl1.Controls.Add(this.serialText);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(498, 302);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // f9CommentsMemo
            // 
            this.f9CommentsMemo.Location = new System.Drawing.Point(86, 60);
            this.f9CommentsMemo.Name = "f9CommentsMemo";
            this.f9CommentsMemo.Properties.ReadOnly = true;
            this.f9CommentsMemo.Size = new System.Drawing.Size(400, 230);
            this.f9CommentsMemo.StyleController = this.layoutControl1;
            this.f9CommentsMemo.TabIndex = 6;            
            // 
            // partNumberText
            // 
            this.partNumberText.Location = new System.Drawing.Point(86, 36);
            this.partNumberText.Name = "partNumberText";
            this.partNumberText.Properties.ReadOnly = true;
            this.partNumberText.Size = new System.Drawing.Size(400, 20);
            this.partNumberText.StyleController = this.layoutControl1;
            this.partNumberText.TabIndex = 5;
            // 
            // serialText
            // 
            this.serialText.Location = new System.Drawing.Point(86, 12);
            this.serialText.Name = "serialText";
            this.serialText.Properties.ReadOnly = true;
            this.serialText.Size = new System.Drawing.Size(400, 20);
            this.serialText.StyleController = this.layoutControl1;
            this.serialText.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(498, 302);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.serialText;
            this.layoutControlItem1.CustomizationFormText = "Serial Number:";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(478, 24);
            this.layoutControlItem1.Text = "Serial Number:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(70, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.partNumberText;
            this.layoutControlItem2.CustomizationFormText = "Part Number:";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(478, 24);
            this.layoutControlItem2.Text = "Part Number:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(70, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.f9CommentsMemo;
            this.layoutControlItem3.CustomizationFormText = "F9 Comments";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(478, 234);
            this.layoutControlItem3.Text = "F9 Comments";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(70, 13);
            // 
            // F9CommentsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 302);
            this.Controls.Add(this.layoutControl1);
            this.Name = "F9CommentsView";
            this.Text = "F9 Comments Viewer";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.f9CommentsMemo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.partNumberText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serialText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit partNumberText;
        private DevExpress.XtraEditors.TextEdit serialText;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.MemoEdit f9CommentsMemo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}
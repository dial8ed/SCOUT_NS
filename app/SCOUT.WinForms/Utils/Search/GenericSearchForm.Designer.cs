namespace SCOUT.CS.UI
{
    partial class GenericSearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenericSearchForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.searchBtn = new System.Windows.Forms.ToolStripButton();
            this.clearBtn = new System.Windows.Forms.ToolStripButton();
            this.exportBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.exportExcelLink = new System.Windows.Forms.ToolStripMenuItem();
            this.exportPDFLink = new System.Windows.Forms.ToolStripMenuItem();
            this.exportHTMLLink = new System.Windows.Forms.ToolStripMenuItem();
            this.exportRTFLink = new System.Windows.Forms.ToolStripMenuItem();
            this.printButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusTxt = new System.Windows.Forms.ToolStripStatusLabel();
            this.searchControl = new SCOUT.CS.UI.SearchControl2();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchBtn,
            this.clearBtn,
            this.exportBtn,
            this.printButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(846, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "searchCmds";
            // 
            // searchBtn
            // 
            this.searchBtn.Image = ((System.Drawing.Image)(resources.GetObject("searchBtn.Image")));
            this.searchBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(60, 22);
            this.searchBtn.Text = "&Search";
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.clearBtn.Image = global::SCOUT.CS.UI.Properties.Resources.cancel;
            this.clearBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(36, 22);
            this.clearBtn.Text = "&Clear";
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // exportBtn
            // 
            this.exportBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportExcelLink,
            this.exportPDFLink,
            this.exportHTMLLink,
            this.exportRTFLink});
            this.exportBtn.Image = ((System.Drawing.Image)(resources.GetObject("exportBtn.Image")));
            this.exportBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(68, 22);
            this.exportBtn.Text = "Export";
            this.exportBtn.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // exportExcelLink
            // 
            this.exportExcelLink.Image = global::SCOUT.CS.UI.Properties.Resources.page_excel;
            this.exportExcelLink.Name = "exportExcelLink";
            this.exportExcelLink.Size = new System.Drawing.Size(152, 22);
            this.exportExcelLink.Tag = "xls";
            this.exportExcelLink.Text = "Excel";
            // 
            // exportPDFLink
            // 
            this.exportPDFLink.Image = global::SCOUT.CS.UI.Properties.Resources.page_white_acrobat;
            this.exportPDFLink.Name = "exportPDFLink";
            this.exportPDFLink.Size = new System.Drawing.Size(152, 22);
            this.exportPDFLink.Tag = "pdf";
            this.exportPDFLink.Text = "PDF";
            // 
            // exportHTMLLink
            // 
            this.exportHTMLLink.Image = global::SCOUT.CS.UI.Properties.Resources.page_code;
            this.exportHTMLLink.Name = "exportHTMLLink";
            this.exportHTMLLink.Size = new System.Drawing.Size(152, 22);
            this.exportHTMLLink.Tag = "htm";
            this.exportHTMLLink.Text = "HTML";
            // 
            // exportRTFLink
            // 
            this.exportRTFLink.Image = global::SCOUT.CS.UI.Properties.Resources.page_word;
            this.exportRTFLink.Name = "exportRTFLink";
            this.exportRTFLink.Size = new System.Drawing.Size(152, 22);
            this.exportRTFLink.Tag = "rtf";
            this.exportRTFLink.Text = "RTF";
            // 
            // printButton
            // 
            this.printButton.AutoSize = false;
            this.printButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printButton.Image = global::SCOUT.CS.UI.Properties.Resources.printer;
            this.printButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(23, 22);
            this.printButton.Text = "Print";
            this.printButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusTxt});
            this.statusStrip1.Location = new System.Drawing.Point(0, 556);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(846, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusTxt
            // 
            this.statusTxt.Name = "statusTxt";
            this.statusTxt.Size = new System.Drawing.Size(831, 17);
            this.statusTxt.Spring = true;
            this.statusTxt.Text = "Ready";
            this.statusTxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // searchControl
            // 
            this.searchControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchControl.Location = new System.Drawing.Point(0, 25);
            this.searchControl.MultiSelect = false;
            this.searchControl.Name = "searchControl";
            this.searchControl.SearchOnEnter = true;
            this.searchControl.Size = new System.Drawing.Size(846, 531);
            this.searchControl.StoredProc = "";
            this.searchControl.TabIndex = 3;
            this.searchControl.OpenRow += new System.EventHandler<SCOUT.CS.UI.OpenRowEventArgs>(this.searchControl_OpenRow);
            // 
            // GenericSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 578);
            this.Controls.Add(this.searchControl);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "GenericSearchForm";
            this.ShowInTaskbar = false;
            this.Text = "Search";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton searchBtn;
        private System.Windows.Forms.ToolStripButton clearBtn;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusTxt;
        private SearchControl2 searchControl;
        private System.Windows.Forms.ToolStripButton printButton;
        private System.Windows.Forms.ToolStripDropDownButton exportBtn;
        private System.Windows.Forms.ToolStripMenuItem exportExcelLink;
        private System.Windows.Forms.ToolStripMenuItem exportPDFLink;
        private System.Windows.Forms.ToolStripMenuItem exportHTMLLink;
        private System.Windows.Forms.ToolStripMenuItem exportRTFLink;

    }
}
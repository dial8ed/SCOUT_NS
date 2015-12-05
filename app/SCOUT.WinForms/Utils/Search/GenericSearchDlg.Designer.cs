namespace SCOUT.WinForms
{
    partial class GenericSearchDlg
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
	    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenericSearchDlg));
	    this.searchControl = new SCOUT.WinForms.SearchControl2();
	    this.okBtn = new System.Windows.Forms.Button();
	    this.cancelBtn = new System.Windows.Forms.Button();
	    this.searchBtn = new System.Windows.Forms.Button();
	    this.operationGrp = new System.Windows.Forms.GroupBox();
	    this.repRadio = new System.Windows.Forms.RadioButton();
	    this.appRadio = new System.Windows.Forms.RadioButton();
	    this.clearBtn = new System.Windows.Forms.Button();
	    this.operationGrp.SuspendLayout();
	    this.SuspendLayout();
	    // 
	    // searchControl
	    // 
	    this.searchControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
	    this.searchControl.Location = new System.Drawing.Point(12, 12);
	    this.searchControl.MultiSelect = true;
	    this.searchControl.Name = "searchControl";
	    this.searchControl.SearchOnEnter = false;
	    this.searchControl.Size = new System.Drawing.Size(668, 413);
	    this.searchControl.StoredProc = "";
	    this.searchControl.TabIndex = 0;
	    // 
	    // okBtn
	    // 
	    this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
	    this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
	    this.okBtn.Location = new System.Drawing.Point(605, 478);
	    this.okBtn.Name = "okBtn";
	    this.okBtn.Size = new System.Drawing.Size(75, 23);
	    this.okBtn.TabIndex = 2;
	    this.okBtn.Text = "&OK";
	    this.okBtn.UseVisualStyleBackColor = true;
	    // 
	    // cancelBtn
	    // 
	    this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
	    this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
	    this.cancelBtn.Location = new System.Drawing.Point(524, 478);
	    this.cancelBtn.Name = "cancelBtn";
	    this.cancelBtn.Size = new System.Drawing.Size(75, 23);
	    this.cancelBtn.TabIndex = 3;
	    this.cancelBtn.Text = "&Cancel";
	    this.cancelBtn.UseVisualStyleBackColor = true;
	    // 
	    // searchBtn
	    // 
	    this.searchBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
	    this.searchBtn.Image = ((System.Drawing.Image)(resources.GetObject("searchBtn.Image")));
	    this.searchBtn.Location = new System.Drawing.Point(605, 431);
	    this.searchBtn.Name = "searchBtn";
	    this.searchBtn.Size = new System.Drawing.Size(75, 23);
	    this.searchBtn.TabIndex = 1;
	    this.searchBtn.Text = "&Search...";
	    this.searchBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
	    this.searchBtn.UseVisualStyleBackColor = true;
	    this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
	    // 
	    // operationGrp
	    // 
	    this.operationGrp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
	    this.operationGrp.Controls.Add(this.repRadio);
	    this.operationGrp.Controls.Add(this.appRadio);
	    this.operationGrp.Location = new System.Drawing.Point(12, 431);
	    this.operationGrp.Name = "operationGrp";
	    this.operationGrp.Size = new System.Drawing.Size(80, 70);
	    this.operationGrp.TabIndex = 5;
	    this.operationGrp.TabStop = false;
	    this.operationGrp.Text = "Operation";
	    // 
	    // repRadio
	    // 
	    this.repRadio.AutoSize = true;
	    this.repRadio.Location = new System.Drawing.Point(6, 42);
	    this.repRadio.Name = "repRadio";
	    this.repRadio.Size = new System.Drawing.Size(65, 17);
	    this.repRadio.TabIndex = 1;
	    this.repRadio.TabStop = true;
	    this.repRadio.Text = "&Replace";
	    this.repRadio.UseVisualStyleBackColor = true;
	    // 
	    // appRadio
	    // 
	    this.appRadio.AutoSize = true;
	    this.appRadio.Checked = true;
	    this.appRadio.Location = new System.Drawing.Point(6, 19);
	    this.appRadio.Name = "appRadio";
	    this.appRadio.Size = new System.Drawing.Size(62, 17);
	    this.appRadio.TabIndex = 0;
	    this.appRadio.TabStop = true;
	    this.appRadio.Text = "&Append";
	    this.appRadio.UseVisualStyleBackColor = true;
	    // 
	    // clearBtn
	    // 
	    this.clearBtn.Location = new System.Drawing.Point(524, 431);
	    this.clearBtn.Name = "clearBtn";
	    this.clearBtn.Size = new System.Drawing.Size(75, 23);
	    this.clearBtn.TabIndex = 4;
	    this.clearBtn.Text = "Clea&r";
	    this.clearBtn.UseVisualStyleBackColor = true;
	    this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
	    // 
	    // GenericSearchDlg
	    // 
	    this.AcceptButton = this.searchBtn;
	    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	    this.CancelButton = this.cancelBtn;
	    this.ClientSize = new System.Drawing.Size(692, 513);
	    this.Controls.Add(this.clearBtn);
	    this.Controls.Add(this.operationGrp);
	    this.Controls.Add(this.searchBtn);
	    this.Controls.Add(this.cancelBtn);
	    this.Controls.Add(this.okBtn);
	    this.Controls.Add(this.searchControl);
	    this.MaximizeBox = false;
	    this.MinimizeBox = false;
	    this.Name = "GenericSearchDlg";
	    this.ShowIcon = false;
	    this.ShowInTaskbar = false;
	    this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
	    this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
	    this.Text = "GenericSearchDlg";
	    this.operationGrp.ResumeLayout(false);
	    this.operationGrp.PerformLayout();
	    this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button searchBtn;
        protected SearchControl2 searchControl;
        private System.Windows.Forms.GroupBox operationGrp;
        private System.Windows.Forms.RadioButton repRadio;
        private System.Windows.Forms.RadioButton appRadio;
	private System.Windows.Forms.Button clearBtn;
    }
}
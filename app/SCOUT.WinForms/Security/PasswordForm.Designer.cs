using SCOUT.WinForms.Controls;

namespace SCOUT.WinForms
{
    partial class PasswordForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.oldTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.newTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.confirmTxt = new System.Windows.Forms.TextBox();
            this.hLine1 = new HLine();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.msgPanel = new System.Windows.Forms.Panel();
            this.msgLabel = new System.Windows.Forms.Label();
            this.hLine2 = new HLine();
            this.msgPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Old:";
            // 
            // oldTxt
            // 
            this.oldTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.oldTxt.Location = new System.Drawing.Point(63, 8);
            this.oldTxt.Name = "oldTxt";
            this.oldTxt.PasswordChar = '*';
            this.oldTxt.Size = new System.Drawing.Size(218, 20);
            this.oldTxt.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "New:";
            // 
            // newTxt
            // 
            this.newTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.newTxt.Location = new System.Drawing.Point(63, 50);
            this.newTxt.Name = "newTxt";
            this.newTxt.PasswordChar = '*';
            this.newTxt.Size = new System.Drawing.Size(218, 20);
            this.newTxt.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Confirm:";
            // 
            // confirmTxt
            // 
            this.confirmTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.confirmTxt.Location = new System.Drawing.Point(63, 76);
            this.confirmTxt.Name = "confirmTxt";
            this.confirmTxt.PasswordChar = '*';
            this.confirmTxt.Size = new System.Drawing.Size(218, 20);
            this.confirmTxt.TabIndex = 6;
            // 
            // hLine1
            // 
            this.hLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hLine1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.hLine1.LineDrawStyle = LineDrawStyle.System;
            this.hLine1.Location = new System.Drawing.Point(15, 34);
            this.hLine1.Name = "hLine1";
            this.hLine1.Size = new System.Drawing.Size(266, 10);
            this.hLine1.TabIndex = 2;
            this.hLine1.TabStop = false;
            this.hLine1.Text = "hLine1";
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Location = new System.Drawing.Point(295, 12);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 8;
            this.okBtn.Text = "&OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(295, 41);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 9;
            this.cancelBtn.Text = "&Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // msgPanel
            // 
            this.msgPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.msgPanel.Controls.Add(this.msgLabel);
            this.msgPanel.Controls.Add(this.hLine2);
            this.msgPanel.Location = new System.Drawing.Point(15, 102);
            this.msgPanel.Name = "msgPanel";
            this.msgPanel.Size = new System.Drawing.Size(355, 33);
            this.msgPanel.TabIndex = 7;
            this.msgPanel.Visible = false;
            // 
            // msgLabel
            // 
            this.msgLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.msgLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msgLabel.ForeColor = System.Drawing.Color.Red;
            this.msgLabel.Location = new System.Drawing.Point(0, 10);
            this.msgLabel.Name = "msgLabel";
            this.msgLabel.Size = new System.Drawing.Size(355, 23);
            this.msgLabel.TabIndex = 1;
            this.msgLabel.Text = "You must change your password.";
            this.msgLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hLine2
            // 
            this.hLine2.Dock = System.Windows.Forms.DockStyle.Top;
            this.hLine2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.hLine2.LineDrawStyle = LineDrawStyle.System;
            this.hLine2.Location = new System.Drawing.Point(0, 0);
            this.hLine2.Name = "hLine2";
            this.hLine2.Size = new System.Drawing.Size(355, 10);
            this.hLine2.TabIndex = 0;
            this.hLine2.TabStop = false;
            this.hLine2.Text = "hLine2";
            // 
            // PasswordForm
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(382, 139);
            this.ControlBox = false;
            this.Controls.Add(this.msgPanel);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.hLine1);
            this.Controls.Add(this.confirmTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.newTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.oldTxt);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PasswordForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Password";
            this.Load += new System.EventHandler(this.PasswordForm_Load);
            this.msgPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox oldTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox newTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox confirmTxt;
        private HLine hLine1;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Panel msgPanel;
        private HLine hLine2;
        private System.Windows.Forms.Label msgLabel;
    }
}
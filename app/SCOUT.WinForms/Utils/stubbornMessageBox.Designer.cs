namespace Inventory.UI
{
    partial class StubbornMessageBox
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.okButton = new DevExpress.XtraEditors.SimpleButton();
            this.yesButton = new DevExpress.XtraEditors.SimpleButton();
            this.noButton = new DevExpress.XtraEditors.SimpleButton();
            this.messageText = new DevExpress.XtraEditors.MemoEdit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.messageText.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.okButton);
            this.panel1.Controls.Add(this.yesButton);
            this.panel1.Controls.Add(this.noButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 242);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(428, 33);
            this.panel1.TabIndex = 4;
            // 
            // okButton
            // 
            this.okButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.okButton.Location = new System.Drawing.Point(198, 5);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.TabStop = false;
            this.okButton.Text = "Ok";
            // 
            // yesButton
            // 
            this.yesButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.yesButton.Location = new System.Drawing.Point(273, 5);
            this.yesButton.Name = "yesButton";
            this.yesButton.Size = new System.Drawing.Size(75, 23);
            this.yesButton.TabIndex = 5;
            this.yesButton.TabStop = false;
            this.yesButton.Text = "Yes";
            // 
            // noButton
            // 
            this.noButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.noButton.Location = new System.Drawing.Point(348, 5);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(75, 23);
            this.noButton.TabIndex = 4;
            this.noButton.TabStop = false;
            this.noButton.Text = "No";
            // 
            // messageText
            // 
            this.messageText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageText.Location = new System.Drawing.Point(0, 0);
            this.messageText.Name = "messageText";
            this.messageText.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.messageText.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageText.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.messageText.Properties.Appearance.Options.UseBackColor = true;
            this.messageText.Properties.Appearance.Options.UseFont = true;
            this.messageText.Properties.Appearance.Options.UseForeColor = true;
            this.messageText.Properties.ReadOnly = true;
            this.messageText.Size = new System.Drawing.Size(428, 242);
            this.messageText.TabIndex = 6;
            this.messageText.TabStop = false;
            // 
            // StubbornMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 275);
            this.ControlBox = false;
            this.Controls.Add(this.messageText);
            this.Controls.Add(this.panel1);
            this.Name = "StubbornMessageBox";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stubborn Message";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.messageText.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton okButton;
        private DevExpress.XtraEditors.SimpleButton yesButton;
        private DevExpress.XtraEditors.SimpleButton noButton;
        private DevExpress.XtraEditors.MemoEdit messageText;
    }
}
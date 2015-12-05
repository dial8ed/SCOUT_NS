namespace SCOUT.WinForms.Reports
{
    partial class ToteTravelerReport
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator1 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator2 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator3 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator4 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator5 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator6 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator7 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToteTravelerReport));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrBarCode1 = new DevExpress.XtraReports.UI.XRBarCode();
            this.manageBarCode = new DevExpress.XtraReports.UI.XRBarCode();
            this.transferContentsBarCode = new DevExpress.XtraReports.UI.XRBarCode();
            this.removeItemsBarCode = new DevExpress.XtraReports.UI.XRBarCode();
            this.transferToteBarCode = new DevExpress.XtraReports.UI.XRBarCode();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrBarCode2 = new DevExpress.XtraReports.UI.XRBarCode();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.toteLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.toteTravelerDetails1 = new SCOUT.WinForms.Reports.toteTravelerDetails();
            this.vw_tote_traveler_detailsTableAdapter = new SCOUT.WinForms.Reports.toteTravelerDetailsTableAdapters.vw_tote_traveler_detailsTableAdapter();
            this.toteId = new DevExpress.XtraReports.Parameters.Parameter();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrBarCode3 = new DevExpress.XtraReports.UI.XRBarCode();
            ((System.ComponentModel.ISupportInitialize)(this.toteTravelerDetails1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel5,
            this.xrBarCode1,
            this.manageBarCode,
            this.transferContentsBarCode,
            this.removeItemsBarCode,
            this.transferToteBarCode,
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1,
            this.xrLabel6,
            this.xrBarCode2,
            this.xrLabel7,
            this.xrBarCode3});
            this.Detail.Height = 361;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Location = new System.Drawing.Point(8, 8);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.Size = new System.Drawing.Size(140, 23);
            this.xrLabel5.Text = "Tote Id:";
            // 
            // xrBarCode1
            // 
            this.xrBarCode1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "vw_tote_traveler_details.id", "")});
            this.xrBarCode1.Location = new System.Drawing.Point(158, 8);
            this.xrBarCode1.Module = 1F;
            this.xrBarCode1.Name = "xrBarCode1";
            this.xrBarCode1.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 100F);
            this.xrBarCode1.ShowText = false;
            this.xrBarCode1.Size = new System.Drawing.Size(279, 23);
            this.xrBarCode1.StylePriority.UseTextAlignment = false;
            code128Generator1.CharacterSet = DevExpress.XtraPrinting.BarCode.Code128Charset.CharsetAuto;
            this.xrBarCode1.Symbology = code128Generator1;
            this.xrBarCode1.Text = "xrBarCode1";
            this.xrBarCode1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // manageBarCode
            // 
            this.manageBarCode.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "vw_tote_traveler_details.command_4", "")});
            this.manageBarCode.Location = new System.Drawing.Point(158, 179);
            this.manageBarCode.Module = 1F;
            this.manageBarCode.Name = "manageBarCode";
            this.manageBarCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 100F);
            this.manageBarCode.ShowText = false;
            this.manageBarCode.Size = new System.Drawing.Size(925, 23);
            code128Generator2.CharacterSet = DevExpress.XtraPrinting.BarCode.Code128Charset.CharsetAuto;
            this.manageBarCode.Symbology = code128Generator2;
            this.manageBarCode.Text = "manageBarCode";
            // 
            // transferContentsBarCode
            // 
            this.transferContentsBarCode.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "vw_tote_traveler_details.command_3", "")});
            this.transferContentsBarCode.Location = new System.Drawing.Point(158, 140);
            this.transferContentsBarCode.Module = 1F;
            this.transferContentsBarCode.Name = "transferContentsBarCode";
            this.transferContentsBarCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 100F);
            this.transferContentsBarCode.ShowText = false;
            this.transferContentsBarCode.Size = new System.Drawing.Size(925, 23);
            code128Generator3.CharacterSet = DevExpress.XtraPrinting.BarCode.Code128Charset.CharsetAuto;
            this.transferContentsBarCode.Symbology = code128Generator3;
            this.transferContentsBarCode.Text = "transferContentsBarCode";
            // 
            // removeItemsBarCode
            // 
            this.removeItemsBarCode.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "vw_tote_traveler_details.command_2", "")});
            this.removeItemsBarCode.Location = new System.Drawing.Point(158, 96);
            this.removeItemsBarCode.Module = 1F;
            this.removeItemsBarCode.Name = "removeItemsBarCode";
            this.removeItemsBarCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 100F);
            this.removeItemsBarCode.ShowText = false;
            this.removeItemsBarCode.Size = new System.Drawing.Size(925, 23);
            code128Generator4.CharacterSet = DevExpress.XtraPrinting.BarCode.Code128Charset.CharsetAuto;
            this.removeItemsBarCode.Symbology = code128Generator4;
            this.removeItemsBarCode.Text = "removeItemsBarCode";
            // 
            // transferToteBarCode
            // 
            this.transferToteBarCode.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "vw_tote_traveler_details.command_1", "")});
            this.transferToteBarCode.Location = new System.Drawing.Point(158, 52);
            this.transferToteBarCode.Module = 1F;
            this.transferToteBarCode.Name = "transferToteBarCode";
            this.transferToteBarCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 100F);
            this.transferToteBarCode.ShowText = false;
            this.transferToteBarCode.Size = new System.Drawing.Size(925, 23);
            code128Generator5.CharacterSet = DevExpress.XtraPrinting.BarCode.Code128Charset.CharsetAuto;
            this.transferToteBarCode.Symbology = code128Generator5;
            this.transferToteBarCode.Text = "transferToteBarCode";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Location = new System.Drawing.Point(6, 179);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.Size = new System.Drawing.Size(140, 23);
            this.xrLabel4.Text = "Manage:";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Location = new System.Drawing.Point(6, 140);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.Size = new System.Drawing.Size(140, 23);
            this.xrLabel3.Text = "Transfer Contents:";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Location = new System.Drawing.Point(6, 96);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.Size = new System.Drawing.Size(140, 23);
            this.xrLabel2.Text = "Remove Items:";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Location = new System.Drawing.Point(6, 52);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.Size = new System.Drawing.Size(140, 23);
            this.xrLabel1.Text = "Transfer Tote:";
            // 
            // xrLabel6
            // 
            this.xrLabel6.Location = new System.Drawing.Point(4, 221);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.Size = new System.Drawing.Size(140, 23);
            this.xrLabel6.Text = "Add Items:";
            // 
            // xrBarCode2
            // 
            this.xrBarCode2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "vw_tote_traveler_details.command_5", "")});
            this.xrBarCode2.Location = new System.Drawing.Point(158, 219);
            this.xrBarCode2.Module = 1F;
            this.xrBarCode2.Name = "xrBarCode2";
            this.xrBarCode2.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 100F);
            this.xrBarCode2.ShowText = false;
            this.xrBarCode2.Size = new System.Drawing.Size(925, 23);
            code128Generator6.CharacterSet = DevExpress.XtraPrinting.BarCode.Code128Charset.CharsetAuto;
            this.xrBarCode2.Symbology = code128Generator6;
            this.xrBarCode2.Text = "xrBarCode2";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine1,
            this.toteLabel});
            this.PageHeader.Height = 85;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLine1
            // 
            this.xrLine1.Location = new System.Drawing.Point(12, 77);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.Size = new System.Drawing.Size(1069, 2);
            // 
            // toteLabel
            // 
            this.toteLabel.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "vw_tote_traveler_details.label", "")});
            this.toteLabel.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toteLabel.Location = new System.Drawing.Point(4, 6);
            this.toteLabel.Name = "toteLabel";
            this.toteLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.toteLabel.Size = new System.Drawing.Size(1079, 60);
            this.toteLabel.StylePriority.UseFont = false;
            this.toteLabel.StylePriority.UseTextAlignment = false;
            this.toteLabel.Text = "toteLabel";
            this.toteLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 30;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.PageFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // toteTravelerDetails1
            // 
            this.toteTravelerDetails1.DataSetName = "toteTravelerDetails";
            this.toteTravelerDetails1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vw_tote_traveler_detailsTableAdapter
            // 
            this.vw_tote_traveler_detailsTableAdapter.ClearBeforeFill = true;
            // 
            // toteId
            // 
            this.toteId.Description = "Tote Id";
            this.toteId.Name = "toteId";
            this.toteId.ParameterType = DevExpress.XtraReports.Parameters.ParameterType.Int32;
            this.toteId.Value = 0;
            this.toteId.Visible = false;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Location = new System.Drawing.Point(4, 262);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.Size = new System.Drawing.Size(140, 23);
            this.xrLabel7.Text = "Put away items:";
            // 
            // xrBarCode3
            // 
            this.xrBarCode3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "vw_tote_traveler_details.command_6", "")});
            this.xrBarCode3.Location = new System.Drawing.Point(160, 262);
            this.xrBarCode3.Module = 1F;
            this.xrBarCode3.Name = "xrBarCode3";
            this.xrBarCode3.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 100F);
            this.xrBarCode3.ShowText = false;
            this.xrBarCode3.Size = new System.Drawing.Size(925, 23);
            code128Generator7.CharacterSet = DevExpress.XtraPrinting.BarCode.Code128Charset.CharsetAuto;
            this.xrBarCode3.Symbology = code128Generator7;
            this.xrBarCode3.Text = "xrBarCode3";
            // 
            // ToteTravelerReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.PageFooter});
            this.DataAdapter = this.vw_tote_traveler_detailsTableAdapter;
            this.DataMember = "vw_tote_traveler_details";
            this.DataSource = this.toteTravelerDetails1;
            this.DataSourceSchema = resources.GetString("$this.DataSourceSchema");
            this.FilterString = "[id] = ?toteId";
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GridSize = new System.Drawing.Size(2, 2);
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(10, 0, 10, 10);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.toteId});
            this.Version = "8.2";
            ((System.ComponentModel.ISupportInitialize)(this.toteTravelerDetails1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRLabel toteLabel;
        private DevExpress.XtraReports.UI.XRBarCode xrBarCode1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRBarCode manageBarCode;
        private DevExpress.XtraReports.UI.XRBarCode transferContentsBarCode;
        private DevExpress.XtraReports.UI.XRBarCode removeItemsBarCode;
        private DevExpress.XtraReports.UI.XRBarCode transferToteBarCode;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private toteTravelerDetails toteTravelerDetails1;
        private SCOUT.WinForms.Reports.toteTravelerDetailsTableAdapters.vw_tote_traveler_detailsTableAdapter vw_tote_traveler_detailsTableAdapter;
        private DevExpress.XtraReports.Parameters.Parameter toteId;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRBarCode xrBarCode2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRBarCode xrBarCode3;
    }
}

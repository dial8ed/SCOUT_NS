using System;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.Xpo;
using DevExpress.XtraBars;
using SCOUT.Core.Data;
using SCOUT.Core.Services;
using SCOUT.WinForms.Areas;
using SCOUT.WinForms.Core;
using SCOUT.WinForms.Inventory;
using SCOUT.WinForms.Orders;
using SCOUT.WinForms.Parts;
using SCOUT.WinForms.Reports;
using SCOUT.WinForms.Search;
using SCOUT.WinForms.Security;
using SCOUT.WinForms.Service;
using SCOUT.WinForms.Views;
using SCOUT.WinForms.Views.Warehouse.Shipping;

namespace SCOUT.WinForms
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private FrontController m_frontController;
        private XPCollection<RawReportQuery> m_queries;
        private static MainForm m_instance;

        public static MainForm GetInstance()
        {
            if(m_instance == null)    
                m_instance = new MainForm();

            return m_instance;
        }

        public MainForm()
        {
            InitializeComponent();

            // Get the front controller
            m_frontController = FrontController.GetInstance();

            // Tell the view loader that this form is the MDI Parent
            ViewLoader.Instance().SetMdiParent(this);

            WireCommandRequests();
            InitSkinsMenu();
            LoadQueries();
            LoadUserReports();
            LoadSharedQueries();
            LoadMyQueries();
            DirtyOrderHack();
            WireEvents();
        }

        private void barItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            m_frontController.RunCommand(e.Item.Tag.ToString());
        }

        private void LoadMyQueries()
        {
            myQueriesLookup.DataSource = UserQuery.MyQueries();
        }

        private void LoadSharedQueries()
        {
            sharedQueriesLookup.DataSource = UserQuery.SharedQueries();
        }

        private void LoadUserReports()
        {
            
            //userReportList.Strings.Clear();
            //foreach (ReportInfo info in ReportDirectory.ReportList)
            //{
                //userReportList.Strings.Add(info.Name);
            //}
        }

        private void
            WireEvents()
        {
            queriesList.ListItemClick += queriesList_ListItemClick;
            userReportList.ListItemClick += userReportList_ListItemClick;

            //reportDirectoryWatcher.Path = ReportDirectory.ReportPath;
            //reportDirectoryWatcher.Changed += reportDirectoryWatcher_Changed;

            myQueriesOwner.EditValueChanged += userQueriesLookup_EditValueChanged;
            sharedQueriesOwner.EditValueChanged += userQueriesLookup_EditValueChanged;

            ordersPOButton.ItemClick += barItem_ItemClick;
            ordersRNRButton.ItemClick += barItem_ItemClick;
            ordersADEXButton.ItemClick += barItem_ItemClick;
            ordersSOButton.ItemClick += barItem_ItemClick;
            ordersCreateFromTemplateButton.ItemClick += barItem_ItemClick;
            invShippingButton.ItemClick += barItem_ItemClick;
            invReceivingButton.ItemClick += barItem_ItemClick;

            Closing += mainForm_Closing;
        }

        private void WireCommandRequests()
        {
            ordersPOButton.Tag = OrdersCommands.New_PO;
            ordersSOButton.Tag = OrdersCommands.New_SO;
            ordersRNRButton.Tag = OrdersCommands.New_RNR;
            ordersADEXButton.Tag = OrdersCommands.New_ADEX;
            ordersCreateFromTemplateButton.Tag = OrdersCommands.New_FromTemplate;
            invShippingButton.Tag = InventoryCommands.ShipItems;
            invReceivingButton.Tag = InventoryCommands.ReceiveItems;
        }

        private void mainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ApplicationEntry.updateController1 != null)
                ApplicationEntry.updateController1.Dispose();
        }

        private void userQueriesLookup_EditValueChanged(object sender, EventArgs e)
        {
            UserQuery query = ((BarEditItem) sender).EditValue as UserQuery;
            if (query != null)
            {
                Type t = Type.GetType(query.SearchObjectType);
                SearchForm searchForm = new SearchForm();
                if (t == typeof (RawReportQuery))
                {
                    searchForm.LoadUserQuery(query);
                }
                else
                {
                    LoadSearchFor(t);
                }
            }

            ((BarEditItem) sender).EditValue = null;
        }

        private void reportDirectoryWatcher_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            LoadUserReports();
        }

        private void userReportList_ListItemClick(object sender, ListItemClickEventArgs e)
        {
            ReportDirectory.CreateReportFromFile(
                ReportDirectory.ReportList[e.Index].Path).ShowPreview();
        }

        private void LoadQueries()
        {
            queriesList.Strings.Clear();
            m_queries = new XPCollection<RawReportQuery>(Scout.Core.Data.GetUnitOfWork());
            foreach (RawReportQuery query in m_queries)
            {
                queriesList.Strings.Add(query.DisplayName);
            }
        }

        private void queriesList_ListItemClick(object sender, ListItemClickEventArgs e)
        {
            RawReportQuery query = m_queries[e.Index];
            LoadUserQuery(query.RoutineName, query.DisplayName);
        }


        public T CreateFormWithArgs<T>(params object[] args) where T : Form
        {
            return ViewLoader.Instance().CreateFormWithArgs<T>(true, args);
        }


        private void InitSkinsMenu()
        {
            foreach (SkinContainer skin in SkinManager.Default.Skins)
            {
                BarButtonItem barButtonItem = new BarButtonItem();
                barButtonItem.Caption = skin.SkinName;
                barButtonItem.Name = skin.SkinName;
                barButtonItem.ItemClick += barButtonItem_ItemClick;
                skinsMenu.AddItem(barButtonItem);
            }

            string lastSkin = SCOUT.Core.Data.Helpers.Config["LastSkinName"];
            if (lastSkin != null)
            {
                defaultLookAndFeel1.LookAndFeel.SetSkinStyle(lastSkin);
            }
            else
            {
                defaultLookAndFeel1.LookAndFeel.SetDefaultStyle();
            }
        }

        private void barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            defaultLookAndFeel1.LookAndFeel.SetSkinStyle(e.Item.Name);
            SCOUT.Core.Data.Helpers.Config["LastSkinName"] = e.Item.Name;
        }

        private void ordersSearchButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadSearchFor<Order>();
        }

        private void setupSitesButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            CreateFormWithArgs<areaManagementForm>(null);
        }

        private void setupOrganizationsButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            CreateFormWithArgs<OrganizationForm>(null);
        }

        private void invBatchTransferButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            CreateFormWithArgs<InventoryTransactionForm>(null);
        }

        private void invLotSplitButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            ViewLoader.Instance()
                .CreateFormWithArgs<LotSplitForm>(false, null);
        }

        private void lotChangePnButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            ViewLoader.Instance()
                .CreateFormWithArgs<ChangeForm>(false, "");
        }

        private void adminUserMgrButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (new DirtyPasswordDialog().ShowDialog() == DialogResult.Yes)
                CreateFormWithArgs<UserManagerForm>(null);
        }

        private void changePasswordButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            CreateFormWithArgs<PasswordForm>(null);
        }

        private void genericLabelButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            ViewLoader.Instance().CreateFormWithArgs<GenericLabelForm>(false, null);
        }

        private void reportDesignerButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            CreateFormWithArgs<ReportDesignerForm>(null);
        }

        private void invSearchButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadSearchFor<InventoryItem>();
        }

        private void setupPrinterLink_ItemClick(object sender, ItemClickEventArgs e)
        {
            ViewLoader.Instance()
                .CreateFormWithArgs<PrinterSetupForm>(false, null);
        }

        private void exitButton2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void transactionSearchButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadSearchFor<Transaction>();
        }

        private void partsSearchButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadSearchFor<Part>();
        }

        private void LoadSearchFor<T>()
        {
            SearchController<T> controller = new SearchController<T>();
            controller.SearchByType();
        }

        private void LoadUserQuery(string routineName, string displayText)
        {
            var detail = new SearchDetail<RawReportQuery>()
                             {
                                 StoredProcedure = routineName,
                                 SearchText = displayText
                             };

            var searchController = new SearchController<RawReportQuery>();

            searchController.SearchByDetail(detail);
        }

        private void newPartButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            CreateFormWithArgs<PartEditForm>(
                PartFactory.CreatePartAsArg());
        }

        private void updatesButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            UpdateInteractive();
        }

        private void UpdateInteractive()
        {
            updateController1.UpdateInteractive(this);
        }

        private void manualButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            CreateFormWithArgs<WebBrowserForm>(
                new object[] {@"http://www.sts.net/intranet/SCOUT_Manual/index.HTML"});
        }

        private void refreshQueriesButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadQueries();
        }

        private void travelerLabelButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            ViewLoader.Instance()
                .CreateFormWithArgs<TravelerLabelForm>(false, null);
        }

        private void reportVideosButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            CreateFormWithArgs<WebBrowserForm>(
                new object[] {@"http://tv.devexpress.com/Training,XtraReports.tags"});
        }

        private void LoadSearchFor(Type type)
        {
            if (type == typeof (InventoryItem))
                LoadSearchFor<InventoryItem>();

            if (type == typeof (Part))
                LoadSearchFor<Part>();

            if (type == typeof (Transaction))
                LoadSearchFor<Transaction>();

            if (type == typeof (SalesOrder))
                LoadSearchFor<SalesOrder>();

            if (type == typeof (PurchaseOrder))
                LoadSearchFor<PurchaseOrder>();

            if (type == typeof (Order))
                LoadSearchFor<Order>();

            if (type == typeof (ServiceRoute))
                LoadSearchFor<ServiceRoute>();

            if (type == typeof (InventoryCapture))
                LoadSearchFor<InventoryCapture>();

            if (type == typeof (PartFamily))
                LoadSearchFor<PartFamily>();
        }

        private void refreshUserQueriesLink_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadSharedQueries();
            LoadMyQueries();
        }

        private void toteSearchButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadSearchFor<Tote>();
        }

        private void stationFormButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            CreateFormWithArgs<ServiceStationForm>(null);
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            CreateFormWithArgs<ServiceSetupForm>(null);
        }

        private void routeBuilderButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            CreateFormWithArgs<RouteBuilderForm>(
                Scout.Core.Data.CreateEntity<ServiceRoute>(Scout.Core.Data.GetUnitOfWork()));
        }

        private void routeSearchButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadSearchFor<ServiceRoute>();
        }

        private void stationProcessItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            ViewLoader.Instance()
                .CreateFormWithArgs<StationInputForm>(false);
        }

        // * HACK * //
        // Have to new up a order for each order type 
        // before it will load a order from the search
        private void DirtyOrderHack()
        {
            Order o;
            o = OrderService.CreateOrder(OrderType.ADEX);
            o = null;

            o = OrderService.CreateOrder(OrderType.PurchaseOrder);
            o = null;

            o = OrderService.CreateOrder(OrderType.ReturnNReplace);
            o = null;

            o = OrderService.CreateOrder(OrderType.SalesOrder);
            o = null;
        }

        private void manualRoutingButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (new DirtyPasswordDialog().ShowDialog() == DialogResult.Yes)
                CreateFormWithArgs<RouteStationMaintForm>(null);
        }

        private void newCaptureButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            m_frontController
                .RunCommand(InventoryCommands.NewCapture,
                            Scout.Core.Data.GetUnitOfWork());
        }

        private void findCaptureButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadSearchFor<InventoryCapture>();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
        }

        private void customFieldsButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            ViewLoader.Instance()
                .CreateFormWithArgs<ShopfloorlineCustomFieldsForm>(false, null);
        }

        private void commandItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrontController.GetInstance()
                .RunCommand("input.commandinput");
        }

        private void newFamilyLink_ItemClick(object sender, ItemClickEventArgs e)
        {
            ViewLoader.Instance()
                .CreateFormWithArgs<PartFamilyForm>(false, PartService.CreateFamilyAsArg());
        }

        private void partFamilySearchButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadSearchFor<PartFamily>();
        }

        private void toteCommandLink_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrontController.GetInstance()
                .RunCommand("input.commandinput");
        }

        private void createToteLink_ItemClick(object sender, ItemClickEventArgs e)
        {
            ToteCreateCommandArguments args;
            IUnitOfWork uow = Scout.Core.Data.GetUnitOfWork();

            args = new ToteCreateCommandArguments(uow, ToteType.Tray);

            FrontController.GetInstance()
                .RunCommand(ToteCommands.ToteCreate, args);
        }

        private void barButtonItem9_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            ViewLoader.Instance().CreateFormWithArgs<PreAlertImportForm>(true, null);
        }

        private void materialCreatePOLink_ItemClick(object sender, ItemClickEventArgs e)
        {
            m_frontController.RunCommand(MaterialCommands.CreatePO, null);
        }

        private void materialPurchaseOrderSearchLink_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadSearchFor<MaterialPurchaseOrder>();
        }

        private void materialPOReceivingButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            m_frontController.RunCommand(MaterialCommands.ReceivePO, null);
        }

        private void materialWarehouseSearchLink_ItemClick(object sender, ItemClickEventArgs e)
        {
            m_frontController.RunCommand(MaterialCommands.SearchWarehouseItems, null);
        }

        private void materialTransactionsSearchLink_ItemClick(object sender, ItemClickEventArgs e)
        {
            m_frontController.RunCommand(MaterialCommands.SearchTransactions, null);
        }

        private void materialsPutAwayLink_ItemClick(object sender, ItemClickEventArgs e)
        {
            m_frontController.RunCommand(MaterialCommands.PutAway, null);
        }

        private void materialIssueOutLink_ItemClick(object sender, ItemClickEventArgs e)
        {
            m_frontController.RunCommand(MaterialCommands.IssueOut, null);
        }

        private void materialConsumableSearchLink_ItemClick(object sender, ItemClickEventArgs e)
        {
            m_frontController.RunCommand(MaterialCommands.SearchConsumableItems, null);
        }

        private void materialWarehouseReturnLink_ItemClick(object sender, ItemClickEventArgs e)
        {
            m_frontController.RunCommand(MaterialCommands.WarehouseReturn, null);
        }

        private void materialsLocationTransferLink_ItemClick(object sender, ItemClickEventArgs e)
        {
            m_frontController.RunCommand(MaterialCommands.LocationTransfer, null);
        }

        private void materialsQtyAdjustmentLink_ItemClick(object sender, ItemClickEventArgs e)
        {
            m_frontController.RunCommand(MaterialCommands.QtyAdjustment, null);
        }

        private void materialsAllInventorySearchLink_ItemClick(object sender, ItemClickEventArgs e)
        {
            m_frontController.RunCommand(MaterialCommands.SearchAllInventory,
                                         null);
        }

        private void serviceBomMasterLink_ItemClick(object sender, ItemClickEventArgs e)
        {
            ViewLoader.Instance().CreateFormWithArgs<Bom.BomMasterView>(true,
                                                                        null);
        }

        private void barButtonItem11_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            ViewLoader.Instance()
                .CreateFormWithArgs<ManageInventoryHoldsView>(true, null);
        }

        private void resolveOpenDfileItemsLink_ItemClick(object sender, ItemClickEventArgs e)
        {
            ViewLoader.Instance().CreateFormWithArgs<DfileResolutionSearchView>(false, null);
        }

        private void processResolvedDfileItemsLink_ItemClick(object sender, ItemClickEventArgs e)
        {
            ViewLoader.Instance().CreateFormWithArgs<DfileActionSearchView>(false, null);
        }

        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            ViewLoader.Instance().CreateFormWithArgs<ShippingSessionView>(false, null);
        }

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            ViewLoader.Instance().CreateFormWithArgs<ShippingConfigurationsView>(false, null);
        }

        private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
        {
            m_frontController.RunCommand(OrdersCommands.Search_Packlists, null);
        }

        private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
        {
            ViewLoader.Instance().CreateFormWithArgs<InventoryAdjustmentView>(false, null);
        }

        private void ordersNewTemplateItem_ListItemClick(object sender, ListItemClickEventArgs e)
        {
            var barList = e.Item as BarListItem;
            var orderType = barList.Strings[e.Index];
            m_frontController.RunCommand(OrdersCommands.New_Template, orderType);
        }
    }
}
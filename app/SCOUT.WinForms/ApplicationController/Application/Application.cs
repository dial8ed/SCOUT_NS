using System;
using System.Threading;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using gma.System.Windows;
using SCOUT.Core;
using STS.WinApi;
using Kjs.AppLife.Update.Controller;  

namespace SCOUT.CS.UI
{
    public class ApplicationEntry
    {
        private static IDataStore s_dataStore;
        private static Form s_mainForm;
        private static NamedEvent s_runSignal;
        private static SplashForm s_splashForm;
        public static UpdateController updateController1;
                
        [STAThread]
        public static void Main()
        {
            if (CheckRunning())
                return;
         
            CheckForUpdates();

            InitDatabase();

            SCOUT.Security.Security.Initialize();

            DevExpress.Skins.SkinManager.Default.RegisterAssembly(typeof(DevExpress.UserSkins.OfficeSkins).Assembly);
            DevExpress.Skins.SkinManager.Default.RegisterAssembly(typeof (DevExpress.UserSkins.BonusSkins).Assembly);

            LoginForm loginForm = new LoginForm();
            s_mainForm = loginForm;

            if (loginForm.ShowDialog() != DialogResult.OK)
                return;

            loginForm.Close();
            loginForm.Dispose();

            CheckResolution();

            s_splashForm = new SplashForm();
            s_splashForm.StartPosition = FormStartPosition.CenterScreen;
            s_splashForm.Show();
            Application.DoEvents();
            
            SetStatus("SCOUT is starting...");

            Thread.CurrentThread.CurrentCulture =
                System.Globalization.CultureInfo.InstalledUICulture;
           
            Application.Idle += Application_Idle;
            Application.ThreadExit += Application_ThreadExit;

                s_mainForm = new mainForm();
                Application.Run(s_mainForm);    
            
            //}
            //catch (Exception e)
            //{
            //    throw;
            //    //MessageBox.Show(e.Message + Environmen, Application.ProductName, 
            //      //  MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}            
        }

        static void Application_ThreadExit(object sender, EventArgs e)
        {
            if(updateController1 != null)
                updateController1.Dispose();
        }

        private static void CheckForUpdates()
        {
            updateController1 = new UpdateController();

            updateController1.ApplicationId = new System.Guid("2fc25b66-6324-4837-bb8e-0eba63d23060");
            updateController1.BypassProxyOnLocal = true;
            updateController1.PublicKeyToken =
                "<RSAKeyValue><Modulus>9CnV1FgcBdkIZTyPGzUc1K1dXFoT3zUmDdYszbo/HkR++JnHg2ScKL0+U12qqkjHegcSfE1yz0z/nXi3iNyQX0ANdjCurZsDAzZbmtnFOeVtESSHEZ51OcU2FiE+9Ggn/9j2TghvIBB0O+1VHpQf6m6ihqZk/rZGpVgVBHQ6E80=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
            updateController1.UpdateLocation = "\\\\sts-srv\\SCOUT_AU";
            updateController1.UseHostAssemblyVersion = true;
            //updateController1.Version = ((System.Version)(resources.GetObject("updateController1.Version")));

            updateController1.UpdateInteractive();
        }

        static void Application_Idle(object sender, System.EventArgs e)
        {
            Application.Idle -= null;
            if(s_splashForm != null)
            {
                s_splashForm.Close();
                s_splashForm = null;
            }
        }

        private static void InitDatabase()
        {
            string baseStr = "data source=STS-SQLSRV;";
            string xpoStr;

            baseStr += "initial catalog={0};";
            baseStr += "user id=datacat;";
            baseStr += "password=catdaddy;";
            baseStr += "application name={0};";
            baseStr += "connect timeout=120;";
            baseStr += "max pool size=200";

#if DEBUG

            Helpers.Config["DB:SCOUT"] = string.Format(baseStr, "DEV_SCOUT");
            Helpers.Config["DB:Settings"] = string.Format(baseStr, "DEV_SCOUT_SETTINGS");
            Helpers.Config["DB:Security"] = string.Format(baseStr, "DEV_SCOUT_SECURITY");

            xpoStr = DevExpress.Xpo.DB.MSSqlConnectionProvider.GetConnectionString(
                "STS-SQLSRV", "datacat", "catdaddy", "DEV_SCOUT");

            // Init XPO Session and data layer
            s_dataStore = XpoDefault.GetConnectionProvider(
                xpoStr, AutoCreateOption.SchemaOnly);

#else
            Helpers.Config["DB:SCOUT"] = string.Format(baseStr, "STS_SCOUT");
            Helpers.Config["DB:Settings"] = string.Format(baseStr, "STS_SCOUT_SETTINGS");
            Helpers.Config["DB:Security"] = string.Format(baseStr, "STS_SCOUT_SECURITY");

            xpoStr = DevExpress.Xpo.DB.MSSqlConnectionProvider.GetConnectionString(
                "STS-SQLSRV", "datacat", "catdaddy", "STS_SCOUT");

                        // Init XPO Session and data layer
            s_dataStore = XpoDefault.GetConnectionProvider(
                xpoStr, AutoCreateOption.SchemaAlreadyExists); //    AutoCreateOption.SchemaOnly);
#endif

            SimpleDataLayer simpleDataLayer = new SimpleDataLayer(s_dataStore);            
            XpoDefault.DataLayer = simpleDataLayer;
            XpoDefault.Session = new Session();

        }

        protected static void CheckResolution()
        {
            if((SystemInformation.VirtualScreen.Width <1024) || (SystemInformation.VirtualScreen.Height < 768))
            {
                string msg = Application.ProductName;
                msg += " was designed for a minimum screen";
                msg += " resolution of 1024 x 768. Your screen";
                msg += " resolution is set lower than this. Some";
                msg += " visual components may not appear";
                msg += " correcty as a result.";

                MessageBox.Show(msg, Application.ProductName, 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        protected static void MaxEvent(object state, bool timedOut)
        {
        }

        protected static void SetStatus(string status)
        {
            s_splashForm.Status = status;
            Application.DoEvents();
        }

        protected static bool CheckRunning()
        {

            //return false;

            string name;
            name = "SCOUT NS";

            s_runSignal = new NamedEvent(name, false);

            if (s_runSignal.WaitOne(0, false))
            {
                MessageBox.Show("A copy of SCOUT is already running.",
                                System.Windows.Forms.Application.ProductName,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return true;
            }

            s_runSignal.Set();
            return false;
        }

        protected static void CheckWinVer()
        {
            STS.WinApi.OSVERSIONINFO info = new OSVERSIONINFO();
            if (STS.WinApi.Call.GetVersionEx(info))
            {
            }
        }
    }
}
using System.Data;
using System.Data.SqlClient;
using SCOUT.Core.Data;
using SCOUT.Core.Security;

namespace SCOUT.Core.Security
{
    public partial class UserSecurity
    {
        private UserSecurity()
        {
            // Singleton
        }

        /// <summary>
        /// Initializes security for SCOUT.
        /// </summary>
        static public void Initialize()
        {
#pragma warning disable 168
            // Preload the roles.
            RobotList<Role> r = Roles;
#pragma warning restore 168
        }

        static public void Save()
        {
            SqlConnection cn = new SqlConnection(Helpers.Config["DB:Security"]);
            SqlTransaction tr;

            cn.Open();
            tr = cn.BeginTransaction(IsolationLevel.Serializable);

            try
            {
                Roles.Save(cn, tr);
                //Users.Save(cn, tr);
                CurrentUser.Save(tr);

                tr.Commit();
            }
            catch
            {
                tr.Rollback();
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
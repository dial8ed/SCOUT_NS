using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SCOUT.Core.Data
{
    /// <summary>
    /// Base class for common actions such as part number changes, LOT
    /// splits, etc.
    /// </summary>
    public abstract class RobotAction : RobotBase
    {
        protected virtual void PostExecute(SafeDataReader dr)
        {
        }

        protected abstract void FillExecuteCmd(SqlCommand cmd);

        public void Execute()
        {
            List<BrokenRule> rulesBroken = GetBrokenRules();
            if (rulesBroken.Count > 0)
                throw new BrokenRuleException(this, rulesBroken);

            SqlConnection cn = new SqlConnection(Helpers.CnnStr());
            SafeDataReader dr = null;
            SqlTransaction tr;

            cn.Open();
            tr = cn.BeginTransaction(IsolationLevel.Serializable);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.Transaction = tr;

                FillExecuteCmd(cmd);

                dr = new SafeDataReader(cmd.ExecuteReader());
                PostExecute(dr);

                if (!dr.IsClosed)
                    dr.Close();

                tr.Commit();
            }
            catch
            {
                if ((dr != null) && !dr.IsClosed)
                    dr.Close();

                tr.Rollback();
                throw;
            }
            finally
            {
                if ((dr != null) && !dr.IsClosed)
                    dr.Close();

                cn.Close();
            }
        }
    }
}

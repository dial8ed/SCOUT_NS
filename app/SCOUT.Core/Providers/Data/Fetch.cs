using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SCOUT.Core.Data
{
    [Obsolete("Use a Query object instead.")]
    public class Fetch
    {
        public delegate void CommandFill(SqlCommand cmd, object[] args);

        private Fetch()
        {
            // Singleton
        }

        #region Work Horse

        private delegate ItemTy PerformRead<ItemTy>(SafeDataReader dr);

        static private ItemTy PerformOperation<ItemTy>(
            string CnnStr,
            PerformRead<ItemTy> ReadData, 
            CommandFill FillCmd,
            object[] args)
        {
            SqlConnection cn = new SqlConnection(CnnStr);
            ItemTy rval = default(ItemTy);
            SafeDataReader dr = null;
            SqlTransaction tr;
            
            cn.Open();
            tr = cn.BeginTransaction(IsolationLevel.ReadCommitted);

            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.Transaction = tr;

                FillCmd(cmd, args);

                dr  =new SafeDataReader(cmd.ExecuteReader());

                rval = ReadData(dr);

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

            return rval;
        }

        #endregion

        #region Delegates

        static private ItemTy ReadSingleObject<ItemTy>(SafeDataReader dr)
            where ItemTy : Robot, new()
        {
            ItemTy rval = null;

            if (dr.Read())
            {
                rval = new ItemTy();
                rval.DoLoad(dr);
            }

            return rval;
        }

        static private List<ItemTy> ReadObjectList<ItemTy>(SafeDataReader dr)
            where ItemTy : Robot, new()
        {
            List<ItemTy> rval = new List<ItemTy>();

            while (dr.Read())
            {
                ItemTy item = new ItemTy();
                item.DoLoad(dr);

                rval.Add(item);
            }

            return rval;
        }

        #endregion

        #region Fetch Single Scalar

        static private ItemTy ReadSingleScalar<ItemTy>(SafeDataReader dr)
        {
            ItemTy rval = default(ItemTy);

            if (!typeof(ItemTy).IsPrimitive)
            {
                throw new Exception(
                    "Attempted to use scalar reader for non-scalar type!");
            }

            if (dr.Read())
                rval = (ItemTy)dr.GetValue(0);

            return rval;
        }

        static public ItemTy Scalar<ItemTy>(string CnnStr,
            CommandFill FillCmd, params object[] args)
        {
            return PerformOperation<ItemTy>(
                CnnStr, ReadSingleScalar<ItemTy>, FillCmd, args);
        }

        static public ItemTy Scalar<ItemTy>(
            CommandFill FillCmd, params object[] args)
        {
            return PerformOperation<ItemTy>(
                Helpers.CnnStr(), ReadSingleScalar<ItemTy>, FillCmd, args);
        }

        #endregion

        #region Fetch Scalar List

        static private List<ItemTy> ReadScalarList<ItemTy>(SafeDataReader dr)
        {
            List<ItemTy> rval = new List<ItemTy>();

            //if (!typeof(ItemTy).IsPrimitive)
            //{
            //    throw new Exception(
            //        "Attempted to use scalar reader for non-scalar type!");
            //}

            while (dr.Read())
                rval.Add((ItemTy)dr.GetValue(0));

            return rval;
        }

        static public List<ItemTy> ScalarList<ItemTy>(string CnnStr,
            CommandFill FillCmd, params object[] args)
        {
            return PerformOperation<List<ItemTy>>(
                CnnStr, ReadScalarList<ItemTy>, FillCmd, args);
        }

        static public List<ItemTy> ScalarList<ItemTy>(
            CommandFill FillCmd, params object[] args)
        {
            return PerformOperation<List<ItemTy>>(
                Helpers.CnnStr(), ReadScalarList<ItemTy>, FillCmd, args);
        }

        #endregion

        #region Fetch Single Object

        static public ItemTy SingleObject<ItemTy>(string CnnStr, 
            CommandFill FillCmd, params object[] args)
            where ItemTy : Robot, new()
        {
            return PerformOperation<ItemTy>(
                CnnStr, ReadSingleObject<ItemTy>, FillCmd, args);
        }

        static public ItemTy SingleObject<ItemTy>(CommandFill FillCmd, 
            params object[] args)
            where ItemTy : Robot, new()
        {
            return PerformOperation<ItemTy>(
                Helpers.CnnStr(), ReadSingleObject<ItemTy>, FillCmd, args);
        }

        #endregion

        #region Fetch List of Objects

        static public List<ItemTy> ObjectList<ItemTy>(string CnnStr, 
            CommandFill FillCmd, params object[] args)
            where ItemTy : Robot, new()
        {
            return PerformOperation<List<ItemTy>>(
                CnnStr, ReadObjectList<ItemTy>, FillCmd, args);
        }

        static public List<ItemTy> ObjectList<ItemTy>(
            CommandFill FillCmd, params object[] args)
            where ItemTy : Robot, new()
        {
            return PerformOperation<List<ItemTy>>(
                Helpers.CnnStr(), ReadObjectList<ItemTy>, FillCmd, args);
        }

        #endregion
    }
}

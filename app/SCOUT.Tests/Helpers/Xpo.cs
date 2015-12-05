using System;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using SCOUT.Core.Data;

namespace SCOUT.Tests.Domain
{
    public class Xpo
    {
        private static XpoUnitOfWork m_unitOfWork;

        public static T CreateXPObject<T>() where T: XPLiteObject
        {
            //CreateInMemoryDataLayer();

            XPLiteObject xpLiteObject =
                (T) Activator.CreateInstance(typeof (T), UnitOfWork());

            return (T)xpLiteObject;            
        }

        public static XpoUnitOfWork UnitOfWork()
        {
            if(m_unitOfWork == null)
            {
                CreateInMemoryDataLayer();
                m_unitOfWork = new XpoUnitOfWork(XpoDefault.DataLayer);
            }

            return m_unitOfWork;            
        }

        private static void CreateInMemoryDataLayer()
        {
            XpoDefault.DataLayer =
                new SimpleDataLayer(
                    new InMemoryDataStore(AutoCreateOption.DatabaseAndSchema));
        }

        private static void DestroyInMemoryDataLayer()
        {
            if(m_unitOfWork != null)
                m_unitOfWork.Dispose();

            m_unitOfWork = null;

            if(XpoDefault.DataLayer != null)
                XpoDefault.DataLayer.Dispose();
        }


        public static void Destroy()
        {
            DestroyInMemoryDataLayer();
        }

    }
}
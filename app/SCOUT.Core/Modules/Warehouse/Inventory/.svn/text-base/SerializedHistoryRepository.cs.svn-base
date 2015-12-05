using System;
using System.Collections;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;

namespace SCOUT.Core.Data
{
    internal class SerializedHistoryRepository
    {        
        internal static SerializedUnit GetLastReturn(Session session,SerializedUnit unit)
        {
            ICollection serializedReturns;
            XPClassInfo serializedClass;
            BinaryOperator criteria;
            SortingCollection sortProps;
            SerializedUnit m_lastReturn = null;

            serializedClass = session.GetClassInfo<SerializedUnit>();           
            criteria = new BinaryOperator("EndIdent", unit.InitIdent);
            sortProps = new SortingCollection(null);
            sortProps.Add(new SortProperty("ReturnDate", SortingDirection.Descending));            

            serializedReturns = session.GetObjects(serializedClass, criteria, sortProps, 1,false, true);

            foreach (SerializedUnit serializedReturn in serializedReturns)
            {
                m_lastReturn = serializedReturn;               
            }    
                       
            return m_lastReturn;           
        }

        internal static SerializedUnit GetLastReturnForType(Session session, SerializedUnit unit)
        {
            ICollection serializedReturns;
            XPClassInfo serializedClass;
            GroupOperator criteria;
            BinaryOperator op1;
            BinaryOperator op2;
            BinaryOperator op3;
            SortingCollection sortProps;
            SerializedUnit m_lastReturn = null;

            serializedClass = session.GetClassInfo<SerializedUnit>();
            op1 = new BinaryOperator("EndIdent", unit.InitIdent);
            op2 = new BinaryOperator("ReturnType", unit.ReturnType);
            op3 = new BinaryOperator("Item.Shopfloorline", unit.Item.Shopfloorline);
           
            criteria = new GroupOperator(op1,op2, op3);

            sortProps = new SortingCollection(null);
            sortProps.Add(new SortProperty("ReturnDate", SortingDirection.Descending));

            serializedReturns = session.GetObjects(serializedClass, criteria, sortProps, 1, false, true);

            foreach (SerializedUnit serializedReturn in serializedReturns)
            {
                m_lastReturn = serializedReturn;
            }
            
            return m_lastReturn;                                      
        }

        internal static int GetTimeInFieldFor(SerializedUnit unit)
        {
            Session session = new Session(XpoDefault.DataLayer);

            SerializedUnit lastReturn = 
                GetLastReturn(session, unit);
            session.Dispose();

            if(lastReturn == null) return -1;
            TimeSpan ts = unit.ReturnDate - lastReturn.ReturnEndDate;
            return ts.Days;
            
        }

        internal static int GetReturnSeedFor(SerializedUnit unit)
        {
            using(Session session = new Session(XpoDefault.DataLayer))
                try
                {
                    SerializedUnit lastReturn =
                        GetLastReturn(session, unit);

                    if (lastReturn == null)
                        return 1;

                    return lastReturn.ReturnSeed + 1;
                }
                catch (Exception)
                {
                    throw;                
                }
        }

        public static int GetReturnTypeCount(SerializedUnit serializedUnit)
        {
            SerializedUnit lastReturn = GetLastReturnForType(
                serializedUnit.Session as Session, serializedUnit);

            if (lastReturn == null)
                return 1;
            else
            {
                return lastReturn.ReturnTypeCount + 1;
            }
            
        }
    }
}
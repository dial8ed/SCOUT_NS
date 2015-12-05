using System;
using System.Windows.Forms;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    public abstract class PartFactory
    {
        public static Part CreatePart(Session session)
        {
            try
            {
                return new Part(session);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating part. " + ex.Message);
            }

            return null;
        }
        public static Part CreatePart()
        {
            return Scout.Core.Data.CreateEntity<Part>(Scout.Core.Data.GetUnitOfWork());                
        }

        public static PartFamily CreatePartFamily()
        {
            return Scout.Core.Data.CreateEntity<PartFamily>(Scout.Core.Data.GetUnitOfWork());            
        }

        public static object[] CreatePartAsArg()
        {
            return new object[] { CreatePart() };
        }

        public static object[] CreatePartFamilyAsArg()
        {
            return new object[] { CreatePartFamily() };
        }
    }
}
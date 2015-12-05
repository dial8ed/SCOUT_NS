using System;
using SCOUT.Core.Data;
using SCOUT.Core.Services;

namespace SCOUT.Core.Modules.Warehouse.Inventory
{
    public class InventoryData
    {
        private InventoryItem m_item;
        private SerializedUnit m_serialItem;
        private ItemCustomFields m_customFields;
        private InventoryWarehouseData m_warehouse;
        private InventoryShopfloorData m_shopfloor;
        private InventoryIdentificationData m_identification;
        private IUnitOfWork m_unitOfWork;

        public InventoryData(InventoryItem item)
        {
            m_item = item;
            m_unitOfWork = item.Session;

            m_serialItem =
                Scout.Core.Service<IInventoryService>()
                    .GetSerializedUnitById(m_unitOfWork, m_item.LotId);

            m_customFields = m_item.CustomFields;
        }

        public string SerialNumber
        {
            get
            { return m_item.SerialNumber;}
            set
            {
                
            }
        }

        public int Qty
        {
            get { return m_item.Qty; }
        }

        public Part Part
        {
            get { return m_item.Part;  }
        }

        public InventoryWarehouseData Warehouse
        {
            get
            {                
                if(m_warehouse == null)
                    m_warehouse = new InventoryWarehouseData(m_item);

                return m_warehouse;
            }
        }

        public InventoryShopfloorData Shopfloor
        {
            get
            {                           
                if(m_shopfloor == null)
                    m_shopfloor = new InventoryShopfloorData(m_item);

                return m_shopfloor;

                }
        }

        public InventoryIdentificationData Identification
        {
            get { 
                if(m_identification == null)
                    m_identification = new InventoryIdentificationData(m_item, m_serialItem);

                return m_identification;
            }
        }        
    }

    public class InventoryWarehouseData
    {
        private InventoryItem m_item;

        public InventoryWarehouseData(InventoryItem item)
        {
            m_item = item;
        }

        public Site Site
        {
            get { return m_item.Site; }
        }

        public Shopfloorline Shopfloorline
        {
            get { return m_item.Shopfloorline; }
        }

        public Domain Domain
        {
            get { return m_item.Domain; }
        }

        public string Location
        {
            get { return m_item.LocatorLabel; }
        } 

    }

    public class InventoryShopfloorData
    {
        private InventoryItem m_inventoryItem;

        public InventoryShopfloorData(InventoryItem item)
        {
            m_inventoryItem = item;
        }

        public RouteStationProcess CurrentShopfloorProcess
        {
            get
            {
                return m_inventoryItem.CurrentProcess;
            }
        }

        
    }

    public class InventoryIdentificationData
    {
        private InventoryItem m_inventoryItem;
        private SerializedUnit m_serializedItem;

        public InventoryIdentificationData(InventoryItem inventoryItem, SerializedUnit serializedItem)
        {
            m_inventoryItem = inventoryItem;
            m_serializedItem = serializedItem;
        }

        public string IncomingSerialNumber
        {
            get { return m_serializedItem.InitIdent; }
            set { m_serializedItem.InitIdent = value; }
        }

        public string OutgoingSerialNumber
        {
            get { return m_serializedItem.EndIdent; }
            set { m_serializedItem.EndIdent = value; }
        }

        public string TokenTraveler
        {
            get { return m_serializedItem.TokenTraveler; }
            set { m_serializedItem.TokenTraveler = value; }
        }

        public DateTime ReceiveDate
        {
            get { return m_serializedItem.ReturnDate; }
            set { m_serializedItem.ReturnDate = value; }
        }

        public DateTime ShipDate
        {
            get { return m_serializedItem.ReturnEndDate; }
            set { m_serializedItem.ReturnEndDate = value; }
        }

        public string Program
        {
            get { return m_inventoryItem.ShopfloorProgram; }
            set { m_inventoryItem.ShopfloorProgram = value; }
        }

    }
}
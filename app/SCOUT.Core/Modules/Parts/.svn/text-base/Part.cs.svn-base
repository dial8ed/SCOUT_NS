using System;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.Core.Data
{
    [Persistent("parts")]
    public class Part : VPObject, IPart
    {              
        private string m_description;        
        private int m_id =-1;
        private PartIdentType m_identType;
        private bool m_isShippable = true;
        private bool m_isReceivable = true;
        private DateTime m_lastUsed;
        private string m_partNumber;
        private PartServiceCommodity m_serviceCommodity;
        private PartType m_type;
        private PartManufacturer m_manufacturer;
        private PartAttributeValues m_attributes;
        private string m_validSerialFormats;
        private DateTime m_topLevelStartDate = DateTime.MinValue;
        private DateTime m_topLevelEndDate = DateTime.MinValue;
        private bool m_isTopLevel;
        private PartFamily m_partFamily;
        private PartModel m_model;
        private MaterialsPart m_materialsPart;
        private bool m_disableMaterialsTracking;

        public Part(Session session) : base(session)
        {
            UserTracking.SetUserInfoGetter(new SecurityUserGetter());
            m_lastUsed = DateTime.Now;
        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("part_no")]
        public string PartNumber
        {
            get { return m_partNumber; }
            set { SetPropertyValue("PartNumber", ref m_partNumber, value); }
        }

        [Persistent("description")]
        public string Description
        {
            get { return m_description; }
            set { SetPropertyValue("Description", ref m_description, value); }
        }

        [Persistent("is_shippable")]
        public bool IsShippable
        {
            get { return m_isShippable; }
            set { SetPropertyValue("IsShippable", ref m_isShippable, value); }
        }

        [Persistent("is_receivable")]
        public bool IsReceivable
        {
            get { return m_isReceivable; }
            set { SetPropertyValue("IsReceivable", ref m_isReceivable, value); }
        }

        [Persistent("last_used")]
        public DateTime LastUsed
        {
            get { return m_lastUsed; }
            set { SetPropertyValue("LastUsed", ref m_lastUsed, value); }
        }

        [Persistent("ident_type_id")]
        public PartIdentType IdentType
        {
            get { return m_identType; }
            set { SetPropertyValue("IdentType", ref m_identType, value); }
        }

        [Persistent("type_id")]
        public PartType Type
        {
            get { return m_type; }
            set { SetPropertyValue("Type", ref m_type, value); }
        }

        [Persistent("model_id")]
        public PartModel Model
        {
            get { return m_model; }
            set { SetPropertyValue("Model", ref m_model, value); }
        }

        [Persistent("service_commodity_id")]
        public PartServiceCommodity ServiceCommodity
        {
            get { return m_serviceCommodity; }
            set
            {                
                // Validate that the service commodity can change in its current state
                if(new ServiceCommodityChangeValidator(this, value).Validated())
                {
                    // Change the model to null if the service commodity changes
                    if(!IsLoading && m_serviceCommodity != value)
                        m_model = null;

                    SetPropertyValue("ServiceCommodity", ref m_serviceCommodity, value);
                    
                }            
            }
        }

        [Persistent("manufacturer_id")]        
        public PartManufacturer Manufacturer
        {
            get { return m_manufacturer; }
            set { SetPropertyValue("Manufacturer",ref m_manufacturer, value); }
        }

        [Persistent("attr_values_id")]        
        public PartAttributeValues Attributes
        {
            get { return m_attributes; }
            set { SetPropertyValue("Attributes", ref m_attributes, value); }
        }

        [Persistent("valid_serial_formats")]
        public string ValidSerialFormats
        {
            get { return m_validSerialFormats; }
            set { SetPropertyValue("ValidSerialFormats", ref m_validSerialFormats, value); }
        }

        [Persistent("top_level_start_date")]
        public DateTime TopLevelStartDate
        {
            get { return m_topLevelStartDate; }
            set { SetPropertyValue("TopLevelStartDate", ref m_topLevelStartDate, value); }
        }

        [Persistent("top_level_end_date")]
        public DateTime TopLevelEndDate
        {
            get { return m_topLevelEndDate; }
            set { SetPropertyValue("TopLevelEndDate", ref m_topLevelEndDate, value); }
        }

        [Persistent("family_id")]
        [Association("PartFamily-Members")]
        public PartFamily PartFamily
        {
            get { return m_partFamily;}
            set { SetPropertyValue("PartFamily", ref m_partFamily, value); }
        }

        [Persistent("disable_materials_tracking")]
        public bool DisableMaterialsTracking
        {
            get { return m_disableMaterialsTracking; }
            set { SetPropertyValue("DisableMaterialsTracking", ref m_disableMaterialsTracking, value); }
        }

        [NonPersistent]
        private MaterialsPart MaterialsPart
        {
            get
            {
                // Loading guard
                if (IsLoading)
                    return null;

                // Load the materials part if it hasnt been loaded yet.
                if (m_materialsPart == null)
                    m_materialsPart =
                        Session.FindObject<MaterialsPart>(
                            new BinaryOperator("ParentPart", this));

                return m_materialsPart;
            }
        }

        // Gets the orderable part number from a materials part config if it exists.
        [NonPersistent]
        public string OrderablePartNumber
        {
            get
            {
                if (MaterialsPart == null)
                {
                    return "";
                }                    
                    
                return MaterialsPart.OrderablePn;                
            }
        }

        public XPCollection<Part> FamilyMembers
        {
            get
            {
                if(IsLoading) return null;
                
                return m_partFamily != null ? m_partFamily.Members : null;
            }
        }

        [Persistent("is_top_level")]
        public bool IsTopLevel
        {
            get { return m_isTopLevel; }
            set
            {
                if(new TopLevelChangeValidator(this, value).Validated())
                    SetPropertyValue("IsTopLevel", ref m_isTopLevel, value);
            }
        }

        [Association("Part-Documents")]
        public XPCollection<PartDocument> Documents
        {
            get { return GetCollection<PartDocument>("Documents"); }
        }

        [Association("Part-DefaultRoutes")]
        public XPCollection<PartDefaultRoute> DefaultRoutes
        {
            get { return GetCollection<PartDefaultRoute>("DefaultRoutes"); }
        }

        [Association("Part-Revisions")]
        public XPCollection<PartRevision> Revisions
        {
            get { return GetCollection<PartRevision>("Revisions"); }
        }

        public string[] ValidSerialFormatList
        {
            get
            {
                if (m_validSerialFormats == null)
                    return null;

                return m_validSerialFormats.Split(char.Parse(","));
            }
        }
           
        protected override void ValidateRules(BrokenRules Verify)
        {
            Verify.IsNotNull(
                PartNumber,
                "BADPARTNO",
                "Invalid or no part number specified.",
                "PartNumber");

            Verify.IsNotNull(
                Type,
                "BADPARTTYPE",
                "Invalid or no type selected.",
                "Type");

            Verify.IsNotNull(
                IdentType,
                "BADPARTIDENT",
                "Invalid or no part identifier type selected.",
                "IdentType");
        }

        public static Part GetPart(IUnitOfWork uow,int id)
        {
            return PartRepository.GetPartById(uow,id);
        }

        public static Part GetPart(int id)
        {
            return PartRepository.GetPartById(Scout.Core.Data.GetUnitOfWork(), id);
        }

        public static Part GetPartByPartNumber(IUnitOfWork uow, string partNo)
        {
            return PartRepository.GetPartByPartNumber(uow, partNo);
        }

        public override bool Equals(object obj)
        {
            Part part = obj as Part;
            if(part == null)
                return false;

            return (m_id == part.Id);

        }

        public ServiceRoute DefaultRouteFor(Shopfloorline shopfloorline)
        {
            foreach (PartDefaultRoute partRoute in DefaultRoutes)
            {
                if (partRoute.Shopfloorline.Equals(shopfloorline))
                    return partRoute.Route;
            }

            return null;
        }

        public bool IsSerialized()
        {
            if(m_identType == null) return false;

            return m_identType.Name == "Serialized";
        }

        public void RemoveDocument(PartDocument document)
        {
            Documents.Remove(document);
        }
    }
}
using System;
using System.Collections.Generic;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using SCOUT.Core.Services;

namespace SCOUT.Core.Data
{
    /// <summary>
    /// Represents a Shopfloorline within a Site.
    /// </summary>
    [Persistent("areas")]
    [MapInheritance(MapInheritanceType.ParentTable)]
    public class Shopfloorline : Area
    {
        private Site m_site;
        private bool m_routingRequired;
        private string m_programs = "";
        private bool m_isProgramRequired = false;
        private bool m_dfileIsEnabled = false;
        private bool m_useMaterialsInventory;

        public Shopfloorline(Session session) : base(session)
        {
            
        }

        [Association("Site-ShopfloorLines")]
        [Persistent("parent_id")]
        public Site Parent
        {
            get { return m_site;}
            set
            {
                SetPropertyValue("Site", ref m_site, value);
                m_parent = value;
            }
        }

        [Persistent("sfl_routing_required")]
        public bool RoutingRequired
        {
            get { return m_routingRequired; }
            set { SetPropertyValue("RoutingRequired", ref m_routingRequired, value); }
        }

        [Persistent("dfile_condition_types")]
        public string DfileConditionTypes{ get; set;}

        [Persistent("programs")]
        private string Programs
        {
            get { return m_programs; }
            set { SetPropertyValue("Programs", ref m_programs, value); }
        }

        [Persistent("is_program_required")]
        public bool IsProgramRequired
        {
            get { return m_isProgramRequired; }
            set { SetPropertyValue("IsProgramRequired", ref m_isProgramRequired, value); }
        }

        [Persistent("use_materials_inventory")]
        public bool UseMaterialsInventory
        {
            get { return m_useMaterialsInventory; }
            set { SetPropertyValue("UseMaterialsInventory", ref m_useMaterialsInventory, value); }
        }

        [NonPersistent]
        public string[] ProgramList
        {
            get
            {
                if (string.IsNullOrEmpty(m_programs))
                    return null;

                return m_programs.Split
                    (new string[] {","}, StringSplitOptions.None);
            }
        }

        [Persistent("dfile_is_enabled")]
        public bool DfileIsEnabled
        {
            get { return m_dfileIsEnabled; }
            set { SetPropertyValue("DfileIsEnabled", ref m_dfileIsEnabled, value); }
        }

        [Association("ShopfloorLine-Domains"),Aggregated]
        public XPCollection<Domain> Domains
        {
            get { return GetCollection<Domain>("Domains"); }
        }

        [Association("Shopfloorline-CustomFields")]
        public XPCollection<CustomField> CustomFields
        {
            get { return GetCollection<CustomField>("CustomFields"); }
        }
   
        public XPCollection<Domain> ActiveDomains
        {
            get { return new XPCollection<Domain>(Domains,new BinaryOperator("Active", true));}
        }

        [NonPersistent]
        public XPCollection<Domain> PreProcessDomains
        {
           get
           {
               CriteriaOperator filterCriteria =
                 GroupOperator.And(new BinaryOperator("IsPreProcessArea", true),
                                 new BinaryOperator("Parent", this));

               XPCollection<Domain> domains = 
                   new XPCollection<Domain>(Domains,filterCriteria, false);
               
               return domains;
           }            
        }

        [NonPersistent]
        public XPCollection<Domain> LocatorControlledDomains
        {
            get
            {
                CriteriaOperator filterCriteria =
                  GroupOperator.And(new BinaryOperator("LocatorControlled", true),
                                  new BinaryOperator("Parent", this));

                XPCollection<Domain> domains = 
                    new XPCollection<Domain>(this.Domains, filterCriteria, false);        

                return domains;
            }
        }

        [NonPersistent]
        public XPCollection<Domain> ShippableDomains
        {
            get
            {
                CriteriaOperator filterCriteria =
                  GroupOperator.And(new BinaryOperator("IsShippable", true),
                                  new BinaryOperator("Parent", this));

                XPCollection<Domain> domains =
                    new XPCollection<Domain>(this.Domains, filterCriteria, false);

                return domains;
            }
        }

        [NonPersistent]
        public XPCollection<ServiceStation> ActiveServiceStations
        {
            get
            {
                GroupOperator criteria = new GroupOperator(
                    new CriteriaOperator[]
                        {
                            new BinaryOperator("Active", true), 
                            new BinaryOperator("Shopfloorline", this)
                        });

                XPCollection<ServiceStation> stations   ;
                stations = new XPCollection<ServiceStation>(Session as XpoUnitOfWork, criteria);
                stations.DisplayableProperties = "Name;Type;Domain!;Active;This";

                return stations;
            }
        }

        [NonPersistent]
        public ICollection<ServiceRoute> ActiveServiceRoutes
        {
            get
            {
                GroupOperator criteria = new GroupOperator(
                    new CriteriaOperator[]
                        {
                            new BinaryOperator("Active", true), 
                            new BinaryOperator("Shopfloorline", this)
                        });

                return Scout.Core.Data
                        .GetList<ServiceRoute>(Session)
                        .ByCriteria(criteria);
            }
        }
        
        public ICollection<ServiceRoute> GetServiceRoutesByReturnType(ReturnType returnType)
        {
            string criteriaString = "[Active] = 1 AND [Shopfloorline] = ? AND ([ReturnType] = 0 OR [ReturnType] = ?)";

            CriteriaOperator op1 = CriteriaOperator.Parse(criteriaString, this, returnType);

            return Scout.Core.Data
                    .GetList<ServiceRoute>(Session)
                    .ByCriteria(op1);

        }

        public override string ToString()
        {
            return Label;
        }

        public void RemoveCustomField(string value)
        {
            CustomField field;
            CustomFields.Filter = new BinaryOperator("FieldName", value);

            if (CustomFields.Count == 1)
            {
                field = CustomFields[0];
                field.Delete();   
            }

            CustomFields.Filter = null;
        }
       
        public void AddCustomField(string value)
        {
            CustomField field = Scout.Core.Data.CreateEntity<CustomField>(Session);
            field.FieldName = value;
            CustomFields.Add(field);
        }

    }
}
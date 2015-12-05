using System;
using SCOUT.Core.Messaging;
using SCOUT.Core.Services;

namespace SCOUT.Core.Data
{
    public class PartReplacementService : MessageService
    {        
        public static bool Save(RouteStationRepair repair, ReplacementComponentFacts facts)
        {                                   
            var component = Scout.Core.Mapping.Map<ReplacementComponentFacts, RepairComponent>(facts);
   
            repair.Components.Add(component);
                                                         
            Scout.Core.UserInteraction.Dialog.ShowMessage
               ("Component Added.", UserMessageType.Information);

            return true;                        
        }

        public static bool CreateNoRepairRecord(RouteStationFailure failure)
        {
            RouteStationRepair repair = Scout.Core.Data.CreateEntity<RouteStationRepair>(failure.Session);
            repair.Comments = "No Repair";
            repair.Component = null;
            repair.Failure = failure;
            repair.ArePartsRequired = false;
            repair.Repair = RepairAction.None;

            ReplacementComponentFacts facts = CreateNoPartComponent(repair);
            
            return Save(repair, facts);
          
        }

        public  static ReplacementComponentFacts CreateNoPartComponent(RouteStationRepair repair)
        {
            ReplacementComponentFacts facts = new ReplacementComponentFacts(repair);
            Part noPart = PartService.GetPartByPartNumber(repair.Session,
                                                          "NoPart");
            facts.PartIn = noPart;
            facts.PartOut = noPart;
            facts.Component = null;
            facts.Repair = repair;
            facts.SerialNumberIn = "";
            facts.SerialNumberOut = "";

            return facts;
        }

        /// <summary>
        /// Creates a component tracking entry using the part "NoPart".
        /// This is currently used to fill in blank component tracking
        /// for failure/repair reporting data.
        /// </summary>
        /// <param name="repair"></param>
        /// <returns></returns>
        public  static bool CreateNoPartRecord(RouteStationRepair repair)
        {            
            ReplacementComponentFacts facts = CreateNoPartComponent(repair);
            
            repair.ArePartsRequired = false;

            return Save(repair, facts);           
        }
    }
}
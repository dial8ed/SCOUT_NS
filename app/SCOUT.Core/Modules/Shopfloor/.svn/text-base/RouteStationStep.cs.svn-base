using System;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("route_station_steps")]
    public class RouteStationStep : VPObject
    {
        private int m_id;
        private string m_displayPrompt = "";
        private ResultList m_resultList;
        private bool m_limitToList = false;
        private int m_seqNo = 0;
        private bool m_required = false;
        private ServiceTaskType m_taskType;        
        private RouteStationConfiguration m_configuration;
        private bool m_active = true;
        private StepResultValidationType m_validationType = StepResultValidationType.OpenText;
        private string m_programSpecifications;
        private string m_conditionSpecifications;
        

        public RouteStationStep(Session session) : base(session)
        {
            UserTracking.SetUserInfoGetter(new SecurityUserGetter());
        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("display_prompt")]
        public string DisplayPrompt
        {
            get { return m_displayPrompt; }
            set { SetPropertyValue("DisplayPrompt", ref m_displayPrompt, value); }
        }

        [Persistent("limit_to_list")]
        public bool LimitToList
        {
            get { return m_limitToList; }
            set { SetPropertyValue("LimitToList", ref m_limitToList, value); }
        }

        [Persistent("seq_no")]
        public int SeqNo
        {
            get { return m_seqNo; }
            set { SetPropertyValue("SeqNo", ref m_seqNo, value); }
        }

        [Persistent("required")]
        public bool Required
        {
            get { return m_required; }
            set { SetPropertyValue("Required", ref m_required, value); }
        }

        [Persistent("type_id")]
        public ServiceTaskType TaskType
        {
            get { return m_taskType; }
            set { SetPropertyValue("TaskType", ref m_taskType, value); }
        }

        [Persistent("list_id")]
        public ResultList ResultList
        {
            get { return m_resultList; }
            set { SetPropertyValue("ResultList", ref m_resultList, value); }
        }

 
        [Persistent("station_config_id")]
        [Association("RouteStationConfig-Steps")]
        public RouteStationConfiguration Configuration
        {
            get { return m_configuration; }
            set { SetPropertyValue("Configuration", ref m_configuration, value); }
        }

        [Persistent("active")]
        public bool Active
        {
            get { return m_active; }
            set { SetPropertyValue("Active", ref m_active, value); }
        }

        [Persistent("validation_type")]
        public StepResultValidationType ValidationType
        {
            get { return m_validationType; }
            set { SetPropertyValue("ValidationType", ref m_validationType, value); }
        }

        [Persistent("program_specifications")]
        public string ProgramSpecifications
        {
            get { return m_programSpecifications; }
            set { SetPropertyValue("ProgramSpecifications", ref m_programSpecifications, value); }
        }

        [Persistent("condition_specifications")]
        public string ConditionSpecifications
        {
            get { return m_conditionSpecifications; }
            set { SetPropertyValue("ConditionSpecifications", ref m_conditionSpecifications, value); }
        }
        
        public bool ContainsProgramSpecification(string program)
        {
            if (string.IsNullOrEmpty(m_programSpecifications))
                return true;

            //TODO : Use this helper method, test.
            //return Strings.DelimitedListContains(m_programSpecifications, program);

            string[] programs =
                m_programSpecifications.Split(new string[] {","}, StringSplitOptions.None);

            for(int i = 0; i< programs.Length; i++)
            {
                if (programs[i] == program)
                    return true;
            }

            return false;                      
        }



        public override bool Equals(object obj)
        {
            RouteStationStep step = obj as RouteStationStep;
            
            if(step == null) return false;

            return step.DisplayPrompt.Equals(m_displayPrompt);
        }


        public override string ToString()
        {
            return m_displayPrompt;
        }


        protected override void ValidateRules(BrokenRules Verify)
        {
            if(!IsDeleted)
            {
                if(Verify.Count > 0 )
                    Verify.Clear();
                return;
            }
                                
            Verify.IsNotNull(m_taskType, "TaskTypeReq", "Task type is required", "TaskType");
            Verify.IsNotEmpty(m_displayPrompt, "DisplayPromptReq", "Display prompt is required", "DisplayPrompt");
        }

        public bool HasRequiredConditions(string itemConditions)
        {
            if (string.IsNullOrEmpty(m_conditionSpecifications))
                return true;

            ShopfloorConditionController itemConditionController =
                new ShopfloorConditionController(itemConditions);

            ShopfloorConditionController stepConditionController =
                new ShopfloorConditionController(m_conditionSpecifications);

            foreach (string condition in stepConditionController.List)
            {
                if (itemConditionController.ContainsCondition(condition))
                    return true;
            }

            return false;            
        }
    }
}
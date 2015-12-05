using System;
using System.Collections.Generic;
using System.Linq;
using SCOUT.Core.Data.Rules;
using SCOUT.Core.Messaging;

namespace SCOUT.Core.Data
{
    public class ShippingRules
    {        
        private IUserMessageBuilder m_messageBuilder;
        private List<IShippingRule> m_rules = new List<IShippingRule>();

        public ShippingRules(IUserMessageBuilder messageBuilder)
        {            
            m_messageBuilder = messageBuilder;
            AddRules();
        }

        private void AddRules()
        {
            m_rules.Add(new DomainIsShippable());
            m_rules.Add(new ExceedsExpectedQty());
            m_rules.Add(new ExceedsLotQty());
            m_rules.Add(new LineItemIsShippable());
            m_rules.Add(new PartIsExpected());
            m_rules.Add(new UnitCompletedRequiredServiceRoute());
            m_rules.Add(new UnitHasFinishedProcessing());
            m_rules.Add(new UnitIsInTheCorrectShippingDomain());
            m_rules.Add(new UnitIsOnHold());        
            m_rules.Add(new UnitIsOnTheCorrectShopfloorline());
            m_rules.Add(new UnitHasCorrectShopfloorProgram());

        }

        public string GetErrors(ShipmentFacts facts)
        {
            m_rules.Where(r => r.IsBroken(facts,m_messageBuilder));
            return m_messageBuilder.FlatContents;
        }
    }
}
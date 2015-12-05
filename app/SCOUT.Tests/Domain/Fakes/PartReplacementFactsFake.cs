using System;
using SCOUT.Core.Data;

namespace SCOUT.Tests.Domain.Fakes
{
    public class PartReplacementFactsFake : ReplacementComponentFacts
    {
        public override Part PartIn
        {
            get { return base.PartIn; }
            set { base.PartIn = value; }            
        }
        
    }
}
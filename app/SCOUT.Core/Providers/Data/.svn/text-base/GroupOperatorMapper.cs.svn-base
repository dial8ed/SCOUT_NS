using System.Collections.Generic;
using DevExpress.Data.Filtering;

namespace SCOUT.Core.Data
{
    public class GroupOperatorMapper : Core.IMapper<List<Fact>, GroupOperator>
    {
        public GroupOperator MapFrom(List<Fact> input)
        {
            List<CriteriaOperator> criteriaOperators = new List<CriteriaOperator>();

            foreach (Fact fact in input)
            {
                BinaryOperator binaryOperator = new BinaryOperator(fact.PropertyName,fact.Value);   
                criteriaOperators.Add(binaryOperator);                
            }

            return  new GroupOperator(criteriaOperators.ToArray());
            
        }
    }
}
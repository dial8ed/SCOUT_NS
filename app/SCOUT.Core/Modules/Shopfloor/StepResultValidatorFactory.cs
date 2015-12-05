using System;
using SCOUT.Core.Messaging;
using SCOUT.Core.Modules.Shopfloor;
using SCOUT.Core.Utils;

namespace SCOUT.Core.Data
{

    /// <summary>
    /// A factory for creating step result validators
    /// </summary>
    public class StepResultValidatorFactory
    {
        /// <summary>
        /// Creates a step result validator
        /// </summary>
        /// <param name="validationType">Type of validator to create</param>
        /// <param name="facts">Facts about the <cref>RouteStationResult</cref></param>
        /// <param name="values"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static IValidator CreateValidator(StepResultValidationType validationType,PartAttributeValues values, string result)
        {
            IUserMessageOutputHost messageOutputHost = new BlackHoleOutputHost();
            MessageListener listener = new MessageListener(messageOutputHost);

            string invalidMessage = "";
            Func<bool> isValid = () => false;
                       
            switch (validationType)
            {                                        
                case StepResultValidationType.MinimumShippableRevision:
                    invalidMessage = "The MSR entered was not found in the Acceptable Shipment Revisions list.";
                    isValid =
                        () => values.GetValueForAttribute("ASR").DelimitedListContains(result);
                    break;

                case StepResultValidationType.OpenText:

                    invalidMessage = "";
                    isValid = () => true;
                    break;

                default:
                    invalidMessage = "The " + validationType + " entered is not valid";
                    isValid = () => values.GetValueForAttribute(validationType.ToString()).Equals(result);
                    break;
            }

            return new AttributeValidator(() => isValid(), invalidMessage);            
        } 
    }
}
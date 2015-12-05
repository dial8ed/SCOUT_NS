using System.Collections.Generic;

namespace SCOUT.Core.Data
{
    /// <summary>
    /// Defines a "compound" identifier
    /// IE: PPID (US082HER123451234567)    
    /// </summary>
    public interface IMultiFieldIdentifier
    {
        /// <summary>
        /// Determines if the value matches the pattern of the defined Identifier
        /// </summary>
        /// <returns></returns>
        bool Validate();

        /// <summary>
        /// Parses out the pertinent identifiers from the compound identifier
        /// </summary>
        void BuildFieldList();

        /// <summary>
        /// Returns the complete compound identifier
        /// </summary>
        string CompleteIdentifier{ get; set;}

        /// <summary>
        /// Returns a Dictionary of the parsed identifiers
        /// within the compound indentifier
        /// </summary>
        Dictionary<string,string> MultiFieldList { get;}
    }


    public interface ILineItemIdentifier
    {
        string LineItemIdentifier { get; }
    }

    public interface ICustomFieldsIdentifier
    {
        Dictionary<string, string> CustomFieldsDictionary { get; }
    }

}
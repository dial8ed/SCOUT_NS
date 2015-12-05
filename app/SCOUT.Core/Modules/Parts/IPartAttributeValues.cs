namespace SCOUT.Core.Data
{
    public interface IPartAttributeValues
    {        
        IPart Part { get; set; }
            
        IPartAttributesHeader Header { get; set; }
        
        string Attr1 { get; set; }
        
        string Attr2 { get; set; }
        
        string Attr3 { get; set; }

        string Attr4 { get; set; }

        string Attr5 { get; set; }

        string Attr6 { get; set; }

        string Attr7 { get; set; }

        string Attr8 { get; set; }

        string Attr9 { get; set; }

        string Attr10 { get; set; }

        string Attr1Label { get; }

        string Attr2Label { get; }

        string Attr3Label { get; }

        string Attr4Label { get; }

        string Attr5Label { get; }

        string Attr6Label { get; }

        string Attr7Label { get; }

        string Attr8Label { get; }

        string Attr9Label { get; }

        string Attr10Label { get; }

        string GetValueForAttribute(string attribute);
    }
}
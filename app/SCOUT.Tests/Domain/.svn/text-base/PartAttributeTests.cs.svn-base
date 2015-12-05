using NUnit.Framework;
using SCOUT.Core.Data;

namespace SCOUT.Tests.Domain
{
    [TestFixture]
    public class PartAttributeTests
    {  
        [Test]
        public void part_attributes_return_value_by_label()
        {
            PartAttributesHeader header =
                Xpo.CreateXPObject<PartAttributesHeader>();

            PartAttributeValues values =
                Xpo.CreateXPObject<PartAttributeValues>();
            
            header.Attr1 = "Firmware";
            values.Header = header;
            values.Attr1 = "E64X";

            Assert.AreEqual(values.GetValueForAttribute("Firmware"), "E64X");
        }                
    }
}
using NUnit.Framework;
using SCOUT.Core.Data;
using SCOUT.Tests.Domain;

namespace SCOUT.Tests.Core
{
    [TestFixture]
    public class ReflectionTests
    {
        [Test]
        public void can_get_the_value_of_a_property_by_name()
        {
            PartAttributesHeader header =
                Xpo.CreateXPObject<PartAttributesHeader>();
            
            header.Attr1 = "Firmware";
            header.Attr2 = "MSR";

            Assert.AreEqual(Reflection.GetPropertyValue(header, "Attr1"),
                            "Firmware");

            Assert.AreEqual(Reflection.GetPropertyValue(header, "Attr2"), 
                            "MSR");
        }

        [Test]
        public void can_copy_property_values_between_objects_by_property_name()
        {
            Person justin = new Person();
            justin.FirstName = "Justin";
            justin.LastName = "Dial";

            Person justinCopy = new Person();

            PropertyMapper<Person, Person> mapper = 
                new PropertyMapper<Person, Person>();

            mapper.MapFrom(justin, justinCopy);

            Assert.AreEqual("Justin", justinCopy.FirstName);
            Assert.AreEqual("Dial", justinCopy.LastName);
                    
        }

        private class Person
        {
            private string m_firstName;
            private string m_lastName;

            public string FirstName
            {
                get { return m_firstName; }
                set { m_firstName = value; }
            }

            public string LastName
            {
                get { return m_lastName; }
                set { m_lastName = value; }
            }
        }

        [TearDown]
        public void teardown()
        {
            Xpo.Destroy();
        }

    }     
}
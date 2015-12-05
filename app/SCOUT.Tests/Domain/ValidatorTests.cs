using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevExpress.Xpo;
using NUnit.Framework;
using SCOUT.Core.Data;


namespace SCOUT.Tests.Domain
{
    [TestFixture]
    public class ValidatorTests
    {

        [Test]
        public void duplication_collection_validator_returns_error_on_duplicate()
        {
            DuplicateCollectionValueValidator<Person> validator;
            ICollection<Person> m_people = new Collection<Person>();
            m_people.Add(new Person(Xpo.UnitOfWork(), "Justin"));            
            m_people.Add(new Person(Xpo.UnitOfWork(), "Wil"));
            m_people.Add(new Person(Xpo.UnitOfWork(), "Justin"));
            m_people.Add(new Person(Xpo.UnitOfWork(), "Mark"));

            validator = new DuplicateCollectionValueValidator<Person>(m_people,"FirstName");

            validator.Validated();

            Assert.IsTrue(validator.HasError());
        }
        
        private class Person : VPLiteObject
        {
            private string m_firstName;

            public Person(Session session, string firstName) : base(session)
            {
                m_firstName = firstName;
            }

            public string FirstName
            {
                get { return m_firstName; }
                set { m_firstName = value; }
            }
        }

    }
}
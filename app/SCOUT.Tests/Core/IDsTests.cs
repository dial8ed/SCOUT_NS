using NUnit.Framework;
using SCOUT.Core.Utils;

namespace SCOUT.Tests.Core
{
    [TestFixture]
    public class IDsTests
    {
        
        [Test]
        public void can_generate_a_unique_id_with_a_prefix()
        {
            string rval = IDs.Generate(char.Parse("P"));
            Assert.That(rval.Length > 0);
        }
    }
}
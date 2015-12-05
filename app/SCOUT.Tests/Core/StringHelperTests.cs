using NUnit.Framework;
using SCOUT.Core.Data;

namespace SCOUT.Tests.Core
{
    [TestFixture]
    public class StringHelperTests
    {        
        [Test]
        public void comma_delimited_contains_returns_true_if_it_finds_a_match()
        {
            string searchList = "A00,A01,A02";
            string searchWord = "A00";
            
            Assert.IsTrue(Strings.DelimitedListContains(searchList,searchWord));            
        }


        [Test]
        public void wrap_in_double_quotes_returns_statement_wrapped_in_double_quotes()
        {
            string statementToWrap = "Wrap this statement";
           
            Assert.AreEqual(Strings.WrapInDoubleQuotes(statementToWrap),
                          "\"Wrap this statement\"");

        }
    }
}
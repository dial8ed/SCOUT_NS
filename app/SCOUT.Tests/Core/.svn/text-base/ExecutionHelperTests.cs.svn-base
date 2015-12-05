using System;
using System.Data;
using NUnit.Framework;
using SCOUT.Core.Utils;

namespace SCOUT.Tests.Core
{
    [TestFixture]
    public class ExecutionHelperTests
    {

        [Test]
        public void when_attempt_to_execute_a_method_x_number_of_times()
        {
            ExecutionLoop loop = new ExecutionLoop();
            int executionAttempts = 5;

            try
            {
               loop.TryLoopOn<NoNullAllowedException>
                    (() =>
                         {
                             throw new NoNullAllowedException();
                         }
                     ,executionAttempts);
            }
            catch (Exception ex)
            {
                Assert.That(loop.ExecutionCount == 5);
            }
             
        }
        
    }
}
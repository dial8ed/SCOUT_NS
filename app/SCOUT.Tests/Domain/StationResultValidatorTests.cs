using NUnit.Framework;
using SCOUT.Core.Data;

namespace SCOUT.Tests.Domain
{
    [TestFixture]
    public class StationResultValidatorTests
    {
        [SetUp]
        public void Setup()
        {
            Helpers.Core.Initialize();
        }

        [Test]
        public void firmware_validator_returns_false_when_the_firmware_doesnt_match()
        {
            PartAttributesHeader header =
                Xpo.CreateXPObject<PartAttributesHeader>();

            PartAttributeValues values =
                Xpo.CreateXPObject<PartAttributeValues>();
            
            header.Attr1 = "Firmware";
            values.Header = header;
            values.Attr1 = "E36X";

            IValidator validator = 
                StepResultValidatorFactory.CreateValidator(StepResultValidationType.Firmware, values,"wr0ng");
            Assert.IsFalse(validator.Validated());
        }

        [Test]
        public void msr_validator_returns_false_when_msr_doesnt_match()
        {
            PartAttributesHeader header =
                Xpo.CreateXPObject<PartAttributesHeader>();

            PartAttributeValues values =
                Xpo.CreateXPObject<PartAttributeValues>();
            
            header.Attr1 = "ASR";
            values.Header = header;
            values.Attr1 = "A00,A01,A02";
          
            IValidator validator =
                StepResultValidatorFactory.CreateValidator(StepResultValidationType.MinimumShippableRevision, values, "wr0ng");

            Assert.IsFalse(validator.Validated());
        }


        [Test]
        public void process_validator_fails_when_there_are_invalid_steps()
        {
            PartAttributesHeader header =
                Xpo.CreateXPObject<PartAttributesHeader>();

            PartAttributeValues values =
                Xpo.CreateXPObject<PartAttributeValues>();
            
            header.Attr1 = "Firmware";
            header.Attr2 = "ASR";

            values.Header = header;
            values.Attr1 = "E36X";
            values.Attr2 = "A03";

            // Create step1 with Firmware validation
            RouteStationStep step1 = Xpo.CreateXPObject<RouteStationStep>();

            step1.DisplayPrompt = "Firmware";            
            step1.ValidationType = StepResultValidationType.Firmware;

            // Create step2 with MSR validation
            RouteStationStep step2 = Xpo.CreateXPObject<RouteStationStep>();
            step2.DisplayPrompt = "Current Revision";
            step2.ValidationType = StepResultValidationType.MinimumShippableRevision;

            // Create step3 with OpenText validation
            RouteStationStep step3 = Xpo.CreateXPObject<RouteStationStep>();
            step3.DisplayPrompt = "Step3";
            step3.ValidationType = StepResultValidationType.OpenText;

            // Create a test part with dummy attributes
            Part part = Xpo.CreateXPObject<Part>();

            // Set the parts attributes to the fake attributes we created.
            part.Attributes = values;

            // Create Firmware step result
            RouteStationResult result1 =
                Xpo.CreateXPObject<RouteStationResult>();
            result1.Step = step1;
            result1.Result = "E36X";

            // Create the MSR step result
            RouteStationResult result2 = Xpo.CreateXPObject<RouteStationResult>();
            result2.Step = step2;
            result2.Result = "A04";

            // Create the OpenText step result
            RouteStationResult result3 = Xpo.CreateXPObject<RouteStationResult>();
            result3.Step = step3;
            result3.Result = "i can type whatever i want to";

            // Create a station process SCENARIO             
            RouteStationProcess process =
                Xpo.CreateXPObject<RouteStationProcess>();

            // Create a fake inventory item
            InventoryItem item = Xpo.CreateXPObject<InventoryItem>();

            // Set the inventory part to the attribute part we've created.
            item.Part = part;

            // Set the process inventory item to the fake inventory item we've created.
            process.Item = item;
            
            // Add the results to the process
            process.Results.Add(result1);
            process.Results.Add(result2);
            process.Results.Add(result3);
            
            // Generate a fake process outcome
            StationOutcome outcome = Xpo.CreateXPObject<StationOutcome>();
            outcome.Label = "PASS";

            // Assign the outcome to our fake process
            process.StationOutcome = outcome;
                      
            // Validate the process
            RouteStationProcessValidator validator =
                new RouteStationProcessValidator(process);

            Assert.IsFalse(validator.Validated());

        }     
   

        [TearDown]
        public void teardown()
        {
            Xpo.Destroy();
        }
    }
}
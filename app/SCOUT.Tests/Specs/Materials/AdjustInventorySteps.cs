using Moq;
using SCOUT.Core.Data;
using SCOUT.Core.Modules.Materials;
using TechTalk.SpecFlow;
using IRepository = SCOUT.Core.Providers.Data.IRepository;

namespace SCOUT.Specs.Materials
{
    [Binding]
    public class AdjustMaterialInOrOutWherePartNumberIsInvalid
    {
        private MaterialsWarehouseInventory warehouseInventory;
        private Mock<IRepository> repository = new Mock<IRepository>();

        [Given(@"I have input a invalid Part Number")]
        public void GivenIHaveInputAInvalidPartNumber()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I Click Adjust")]
        public void WhenIClickAdjust()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I Should see an error stating the Part Number is invalid")]
        public void ThenIShouldSeeAnErrorStatingThePartNumberIsInvalid()
        {
            ScenarioContext.Current.Pending();
        }
    }


    [Binding]
    public class AdjustMaterialIntoInventoryWhereItemDoesExist
    {
        [Given(@"I have input a valid Part Number")]
        public void GivenIHaveInputAValidPartNumber()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Input Source Type, Locations, and Comments")]
        public void GivenInputSourceTypeLocationsAndComments()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I click Adjust")]
        public void WhenIClickAdjust()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The Inventory Qty should by the adjustment qty plus the starting qty")]
        public void ThenTheInventoryQtyShouldByTheAdjustmentQtyPlusTheStartingQty()
        {
            ScenarioContext.Current.Pending();
        }            
    }


    [Binding]
    public class AdjustMaterialIntoInventoryWhereItemDoesNotExist
    {
        
    }


    [Binding]
    public class AdjustMaterialOutOfInventoryWhereItemDoesExist
    {
        
    }

    [Binding]
    public class AdjustMaterialOutOfInventoryWhereItemDoesNotExist
    {
        
    }


}
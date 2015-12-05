using SCOUT.Core.Data;
using SCOUT.Core.Messaging;

namespace SCOUT.Core.Mvc
{
    public class NewBomMasterValidator : ModelValidator<BomMasterModel>
    {
        public NewBomMasterValidator(BomMasterModel model, MessageListener messageListener)
            : base(model, messageListener)
        {

        }

        public override void GetError()
        {          
            if (Model.PartModel == null)
            {
                m_error = "Part Model is required.";
                return;
            }

            if(Model.BomMaster != null)
            {
                m_error = "BomMaster already exists";
                return;
            }
                
        }
    }

    public class SaveBomMasterValidator : ModelValidator<BomMasterModel>
    {
        public SaveBomMasterValidator(BomMasterModel bomMasterModel, MessageListener listener) : base(bomMasterModel, listener)
        {
        }

        public override void GetError()
        {
            if(HasInvalidComponents())
                return;

            if(HasDuplicateComponentCategories())
                return;

            if(HasDuplicateMasterComponents())
                return;
                                  
        }


        private bool HasInvalidComponents()
        {
            foreach (BomMasterComponent component in Model.BomMasterComponents)
            {
                if (!string.IsNullOrEmpty(component.Error))
                {
                    m_error = component.Error;
                    return true;
                }                   
            }

            return false;
        }

        private bool HasDuplicateMasterComponents()
        {
            DuplicateCollectionValueValidator<BomMasterComponent>
                componentValidator;

            componentValidator = new DuplicateCollectionValueValidator<BomMasterComponent>(
                null,Model.BomMasterComponents,
                "PartNumber");

            if (!componentValidator.Validated())
            {
                m_error = componentValidator.Error;
                return true;
            }

            return false;
        }


        private bool HasDuplicateComponentCategories()
        {
            DuplicateCollectionValueValidator<BomComponentCategory> categoryValidator;

            categoryValidator =
                new DuplicateCollectionValueValidator<BomComponentCategory>(
                    null,
                    Model.BomComponentCategories,
                    "Category");

            if (!categoryValidator.Validated())
            {
                m_error = categoryValidator.Error;
                return true;
            }

            return false;
        }
    }
}
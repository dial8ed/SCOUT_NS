using System;
using System.Collections.Generic;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.Core.Data
{
    internal class PartRepository
    {
        /**********************************************************************
        /** Part **/
        internal static Part GetPartById(IUnitOfWork uow, int id)
        {
            return Repository
                .Get<Part>(uow)
                .ById(id);
        }

        internal static Part GetPartByPartNumber(IUnitOfWork uow, string partNo)
        {
            BinaryOperator op1 = new BinaryOperator("PartNumber", partNo);
            return Repository
                .Get<Part>(uow)
                .ByCriteria(op1);
        }

        /**********************************************************************
        /** PartIdentType **/
        internal static PartIdentType GetIdentType(IUnitOfWork uow, int value)
        {
            return Repository
                .Get<PartIdentType>(uow)
                .ById(value);
        }

        internal static ICollection<PartIdentType> GetPartIdentTypes(IUnitOfWork uow)
        {
            return Repository
                .GetList<PartIdentType>(uow)
                .All();
        }

        /**********************************************************************
        /** PartType **/
        internal static PartType GetType(IUnitOfWork uow, int value)
        {
            return Repository
                .Get<PartType>(uow)
                .ById(value);
        }


        internal static ICollection<PartType> GetPartTypes(IUnitOfWork uow)
        {
            return Repository
                .GetList<PartType>(uow)
                .All();
        }

        /**********************************************************************
        /** PartServiceCommodity **/
        internal static ICollection<PartServiceCommodity> GetPartServiceCommodities(IUnitOfWork uow)
        {
            return Repository
                .GetList<PartServiceCommodity>(uow)
                .All();            
        }


        internal static ICollection<PartManufacturer> GetPartManufacturers(IUnitOfWork uow)
        {
            return Repository
                .GetList<PartManufacturer>(uow)
                .All();
        }


        public static ICollection<ServiceCode> GetFailCodesByModel(PartServiceCommodity commodity, PartModel model)
        {            
            string criteria =
                string.Format("(Active=True AND ServiceCommodity={0} AND Model IS NULL) OR (Model='{1}') OR (IsGlobal=True)",
                              commodity.Id, model.Id);
                
            CriteriaOperator op = CriteriaOperator.Parse(criteria);

            return Repository
                .GetList<ServiceCode>(commodity.Session)
                .ByCriteria(op);            
        }


        internal static MaterialsPart GetMaterialsPart(Part part)
        {
            BinaryOperator op1 = new BinaryOperator("ParentPart", part);
            return Repository
                    .Get<MaterialsPart>(part.Session)
                    .ByCriteria(op1);
        }


        internal static Part GetPartFromMaterialsXref(IUnitOfWork uow, string partNumber)
        {
            // Build cross reference part query criteria.  
            BinaryOperator op1 = new BinaryOperator("MaterialsPart.ParentPart.PartNumber", partNumber );
            BinaryOperator op2 = new BinaryOperator("XrefPartNumber", partNumber);
            BinaryOperator op3 = new BinaryOperator("XrefPartNumberAlt", partNumber);
            GroupOperator criteria = new GroupOperator(GroupOperatorType.Or, op1,op2,op3);

            MaterialsPartXref materialsPartXref = 
                Repository
                .Get<MaterialsPartXref>(uow)
                .ByCriteria(criteria);

            // If no cross reference is found then return null
            if (materialsPartXref == null)
                return null;

            // Return the parent part (toplevel/static) of the material part xref.
            return materialsPartXref.MaterialsPart.ParentPart;

        }

        internal static ICollection<PartModel> GetAllPartModels(IUnitOfWork uow)
        {
            return Repository
                .GetList<PartModel>(uow)
                .All();
        }


        internal static PartModel GetPartModelById(IUnitOfWork uow, int id)
        {
            BinaryOperator op1 = new BinaryOperator("Id", id);

            return Repository
                .Get<PartModel>(uow)
                .ByCriteria(op1);
        }


        internal static BomConfiguration GetBomConfigurationById(IUnitOfWork uow, int id)
        {
            BinaryOperator op1 = new BinaryOperator("Id", id);

            return
                Repository
                .Get<BomConfiguration>(uow)
                .ByCriteria(op1);
        }

        internal static ICollection<BomConfiguration> GetBomConfigurationsByModel(IUnitOfWork uow, PartModel model)
        {
            BinaryOperator op1 = new BinaryOperator("PartModel", model);

            return Repository
                .GetList<BomConfiguration>(uow)
                .ByCriteria(op1);
        }


        public static BomConfiguration GetBomConfigurationByStation(IUnitOfWork uow, RouteStationProcess process)
        {
            BinaryOperator op1 = new BinaryOperator("RouteStation", process.Station);
            BinaryOperator op2 = new BinaryOperator("PartModel", process.Item.Part.Model);

            GroupOperator critieria = new GroupOperator(op1,op2);

            return
                Repository
                .Get<BomConfiguration>(uow)
                .ByCriteria(critieria);
        }
    }
}
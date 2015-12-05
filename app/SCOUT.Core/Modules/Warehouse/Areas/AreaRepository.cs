using System;
using System.Collections.Generic;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.Core.Data
{
    internal class AreaRepository
    {
        internal static ICollection<Shopfloorline> GetAllShopfloorlines(IUnitOfWork uow)
        {
            return Repository
                .GetList<Shopfloorline>(uow)
                .All();
        }

        internal static Site GetSiteById(IUnitOfWork uow, int id)
        {
            return Repository
                .Get<Site>(uow)
                .ById(id);
        }

        internal static ICollection<Tote> GetAllTotes(IUnitOfWork uow)
        {
            return Repository
                .GetList<Tote>(uow)
                .All();
        }


        internal static ICollection<Tote> GetAllCarts(IUnitOfWork uow)
        {
            BinaryOperator criteria = new BinaryOperator("ToteType", "Cart");
            return Repository
                .GetList<Tote>(uow)
                .ByCriteria(criteria);
        }

        internal static ICollection<Tote> GetAllEmptyCarts(IUnitOfWork uow)
        {
            NotOperator criteria = new NotOperator(new ContainsOperator("Contents", null));
            return Repository
                .GetList<Tote>(uow)
                .ByCriteria(criteria);
        }

        internal static ICollection<Domain> GetAllDomains(IUnitOfWork uow)
        {
            return Repository
                .GetList<Domain>(uow)
                .All();
        }

        internal static ICollection<Domain> GetAllLocatorControlledDomains(IUnitOfWork uow)
        {
            BinaryOperator op1 = new BinaryOperator("LocatorControlled", true);

            return Repository
                .GetList<Domain>(uow)
                .ByCriteria(op1);
          
        }

        internal static ICollection<AreaStatus> GetAllAreaStatuses(IUnitOfWork uow)
        {
            return Repository
                .GetList<AreaStatus>(uow)
                .All();
        }

        public static ICollection<Tote> GetAllTotesByType(IUnitOfWork uow, ToteType type)
        {
            BinaryOperator criteria = new BinaryOperator("ToteType", type);
            return Repository
                .GetList<Tote>(uow)
                .ByCriteria(criteria);
        }

        internal static Section GetSectionByLabel(IUnitOfWork uow, string section)
        {
            BinaryOperator op1 = new BinaryOperator("Label", section);
            return Repository
                .Get<Section>(uow)
                .ByCriteria(op1);           
        }
    }
}
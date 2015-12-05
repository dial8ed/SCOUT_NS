using System.Collections.Generic;
using SCOUT.Core.Data;

namespace SCOUT.Core.Services
{
    public interface IAreaService
    {
        ICollection<Shopfloorline> GetAllShopfloorlines(IUnitOfWork uow);
        Site GetSiteById(IUnitOfWork uow, int id);
        ICollection<Tote> GetAllTotes(IUnitOfWork uow);
        ICollection<Tote> GetAllCarts(IUnitOfWork uow);
        ICollection<Tote> GetAllEmptyCarts(IUnitOfWork uow);
        ICollection<Domain> GetAllDomains(IUnitOfWork uow);
        ICollection<Domain> GetAllLocatorControlledDomains(IUnitOfWork uow);
        ICollection<AreaStatus> GetAllAreaStatuses(IUnitOfWork uow);
        Section GetSectionByLabel(IUnitOfWork uow, string section);
        bool GenerateRackLocations(Domain domain, string sectionLabel, int numberOfBays, int numberOfShelves);
        bool GenerateRackLocations(Domain domain, string sectionLabel, int startingBay, int numberOfBays, int numberOfShelves);
    }
}
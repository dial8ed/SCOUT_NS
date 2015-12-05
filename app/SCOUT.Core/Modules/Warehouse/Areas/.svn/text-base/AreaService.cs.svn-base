using System.Collections.Generic;
using DevExpress.Xpo;
using SCOUT.Core.Data;
using SCOUT.Core.Modules;

namespace SCOUT.Core.Services
{
    public class AreaService : ModuleService, IAreaService
    {
        public AreaService(IModule module) : base(module)
        {

        }

        public ICollection<Shopfloorline> GetAllShopfloorlines(IUnitOfWork uow)
        {
            return AreaRepository.GetAllShopfloorlines(uow);
        }

        public Site GetSiteById(IUnitOfWork uow, int id)
        {
            return AreaRepository.GetSiteById(uow, id);
        }

        public ICollection<Tote> GetAllTotes(IUnitOfWork uow)
        {
            return AreaRepository.GetAllTotes(uow);
        }

        public ICollection<Tote> GetAllCarts(IUnitOfWork uow)
        {
            return AreaRepository.GetAllCarts(uow);
        }

        public ICollection<Tote> GetAllEmptyCarts(IUnitOfWork uow)
        {
            return AreaRepository.GetAllEmptyCarts(uow);
        }

        public ICollection<Domain> GetAllDomains(IUnitOfWork session)
        {
            return AreaRepository.GetAllDomains(session);
        }

        public ICollection<Domain> GetAllLocatorControlledDomains(IUnitOfWork uow)
        {
            return AreaRepository.GetAllLocatorControlledDomains(uow);
        }

        public ICollection<AreaStatus> GetAllAreaStatuses(IUnitOfWork uow)
        {
            return AreaRepository.GetAllAreaStatuses(uow);
        }

        public Section GetSectionByLabel(IUnitOfWork uow, string section)
        {
            return AreaRepository.GetSectionByLabel(uow, section);          
        }

        public  bool GenerateRackLocations(Domain domain, string sectionLabel, int numberOfBays, int numberOfShelves)
        {
            return GenerateRackLocations(domain, sectionLabel, 1, numberOfBays,
                                  numberOfShelves);
        }

        public  bool GenerateRackLocations(Domain domain, string sectionLabel, int startingBay, int numberOfBays, int numberOfShelves)
        {
            // Append to an existing section if it exists.
            Section section = AreaRepository.GetSectionByLabel(domain.Session,
                                                              sectionLabel);      
            // If section doesnt exist then create it
            if (section == null)
                section = domain.CreateSection(sectionLabel);

            if (!new RackLocationGenerationValidator(domain, section, numberOfBays, numberOfShelves, startingBay).Validated())
                return false;

            for (int i = startingBay; i < startingBay + numberOfBays; i++)
            {
                Bay bay = section.CreateBay(i);

                for (int j = 1; j <= numberOfShelves; j++)
                {
                    bay.CreateShelf(j);
                }
            }

            return true;  
        }
    }
}
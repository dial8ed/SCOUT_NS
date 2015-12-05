using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using DevExpress.Xpo;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;

namespace SCOUT.Core.Services
{
    public class PartService : MessageService
    {
        /// <summary>
        /// Creates a new blank part
        /// </summary>
        /// <returns></returns>
        public static Part CreatePart()
        {
            return PartFactory.CreatePart();
        }
            
        /// <summary>
        /// Creates a new materials configuration
        /// </summary>
        /// <param name="part"></param>
        /// <returns></returns>
        public static MaterialsPart CreateMaterialsPart(Part part)
        {            
            // Add validation.
            MaterialsPart materialsPart =Scout.Core.Data.CreateEntity<MaterialsPart>(part.Session);
            materialsPart.ParentPart = part;
            return materialsPart;
        }

        /// <summary>
        /// Validates a part then saves it to the database.
        /// </summary>
        /// <param name="part"></param>
        /// <returns></returns>
        public bool SavePart(Part part)
        {
            if(new PartValidator(part).Validated())
            {
                try
                {
                    Scout.Core.Data.Save(part.Session);
                    RaiseUserMessage("Part " + part.PartNumber + " saved successfully.", UserMessageType.Information);
                    return true;
                }
                catch (Exception ex)
                {
                    RaiseUserMessage("Error saving part. \r" + ex.Message, UserMessageType.Error);                      
                }
            }

            return false;
        }

        /// <summary>
        /// Gets a part instance by id
        /// </summary>
        /// <param name="session"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Part GetPartById(IUnitOfWork uow,int id)
        {
            return PartRepository.GetPartById(uow, id);
        }


        /// <summary>
        /// Gets a part by part number
        /// </summary>
        /// <param name="session"></param>
        /// <param name="partNumber"></param>
        /// <returns></returns>
        public static Part GetPartByPartNumber(IUnitOfWork uow, string partNumber)
        {
            return PartRepository.GetPartByPartNumber(uow, partNumber);
        }

        public static ICollection<PartIdentType> GetPartIdentTypes(IUnitOfWork uow)
        {
            return PartRepository.GetPartIdentTypes(uow);            
        }

        public static ICollection<PartType> GetPartTypes(IUnitOfWork uow)
        {
            return PartRepository.GetPartTypes(uow);
        }

        public static ICollection<PartServiceCommodity> GetPartServiceCommodities(IUnitOfWork uow)
        {
            return PartRepository.GetPartServiceCommodities(uow);
        }

        public static ICollection<PartManufacturer> GetPartManufacturers(IUnitOfWork uow)
        {
            return PartRepository.GetPartManufacturers(uow);
        }

        /// <summary>
        /// Parses a comma delimited string of Serial Identity types 
        /// into a list of ISerialIndentifier objects
        /// </summary>
        /// <param name="identNameList"></param>
        /// <returns></returns>
        public static List<ISerialIdentifier> GetSerialIdentifiersFor(string[] identNameList)
        {
            if (identNameList == null)
                return null;

            List<ISerialIdentifier> identifiers = new List<ISerialIdentifier>();

            foreach (string s in identNameList)
            {
                ObjectHandle handle =
                    Activator.CreateInstance(null, "SCOUT.Core.Inventory." + s + "Identifier"); 

                if (handle != null)
                {
                    ISerialIdentifier identifier = handle.Unwrap() as ISerialIdentifier;
                    if (identifier != null)
                        identifiers.Add(identifier);
                }
            }

            return identifiers;
        }
        

        /// <summary>
        /// Returns true if the sn matches any of the parts valid sn formats.
        /// </summary>
        /// <param name="part"></param>
        /// <param name="sn"></param>
        /// <returns></returns>
        public static bool SnMatchesFormat(Part part, string sn)
        {
            List<ISerialIdentifier> identifiers =
                GetSerialIdentifiersFor(part.ValidSerialFormatList);

            if (identifiers != null)
            {
                bool validSerial = false;
                foreach (ISerialIdentifier identifier in identifiers)
                {
                    identifier.SetSerial(sn);
                    if (identifier.SilentValidate())
                    {
                        validSerial = true;
                        break;
                    }
                }

                if (validSerial == false)
                {                    
                    return false;
                }
            }

            return true;            
        }

        public static object[] CreateFamilyAsArg()
        {
            return PartFactory.CreatePartFamilyAsArg();
        }

        public static MaterialsPart GetMaterialsPart(Part part)
        {
            return PartRepository.GetMaterialsPart(part);
        }

        public static Part GetPartFromMaterialsXref(IUnitOfWork uow,string partNumber)
        {
            return PartRepository.GetPartFromMaterialsXref(uow,partNumber);   
        }
    }
}
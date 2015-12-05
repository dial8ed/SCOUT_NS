using System;
using System.Collections.Generic;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    public class ToteNumbers
    {
        public static string Next(ToteType type)
        {
            ICollection<Tote> totes = 
                AreaRepository.GetAllTotesByType(Scout.Core.Data.GetUnitOfWork(), type);                       
            int largestId = -1;

            foreach (Tote tote in totes)
            {
                int nextNumber = -1;
                string toteNumber = "";
                string toteLabel = tote.Label.Trim();

                int spaceIndex = toteLabel.IndexOf(" ");
                int numberLength = toteLabel.Length - (spaceIndex + 1);

                toteNumber = toteLabel.Substring
                    (
                        spaceIndex + 1,
                        numberLength
                    );

                Int32.TryParse(toteNumber, out nextNumber);

                if (largestId == -1 || nextNumber > largestId)
                    largestId = nextNumber;
            }
  
            if (largestId > -1)
                {
                    largestId += 1;
                    return largestId.ToString();
                }

                return "1";
            }
        }
    }

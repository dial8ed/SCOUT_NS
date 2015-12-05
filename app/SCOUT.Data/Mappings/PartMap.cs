using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using SCOUT.Core.Data;

namespace SCOUT.Data.Mappings
{
    public class PartMap : ClassMap<Part>
    {
        public PartMap()
        {
            Id(x => x.Id);
            Map(x => x.PartNumber);
            Map(x => x.Description);
            Map(x => x.IsReceivable);                        
            HasOne(x => x.Model);                     
        }
    }
}

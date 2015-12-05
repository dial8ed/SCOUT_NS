using System.Collections.Generic;

namespace SCOUT.Core.Data
{
    public interface IPartHierarchyItem
    {
        void Save();

        int Id { get; }
        int ParentId { get; set; }

	string PathId { get; }

        string Name { get; set; }
	    string FullPath { get; }
        int Level { get; }

        IList<IPartHierarchyItem> GetChildren();
        IPartHierarchyItem CreateSubItem();
    }
}

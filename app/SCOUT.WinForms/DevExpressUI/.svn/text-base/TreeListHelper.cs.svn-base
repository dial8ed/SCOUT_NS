using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace SCOUT.WinForms.DevExpressUI
{
    public static class TreeListHelper
    {
        internal static TreeListNode GetNodeByTag(TreeList treeList, object[] values)
        {
            foreach (TreeListNode node in treeList.Nodes)
            {
                object nodeValue = node.GetValue(0);

                if (nodeValue != null && (nodeValue.ToString() == values[0].ToString()))
                    return node;
            }

            return null;
        }

    }
}
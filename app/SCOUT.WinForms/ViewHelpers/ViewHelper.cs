using System.Collections.Generic;
using DevExpress.XtraLayout;

namespace SCOUT.WinForms.ViewHelpers
{
    public class ViewHelper
    {
        /// <summary>
        /// Sets a LayoutControlItem.ContentVisible to false
        /// </summary>
        /// <param name="item"></param>
        public static void HideLayoutItem(LayoutControlItem item)
        {
            item.ContentVisible = false;
        }

        /// <summary>
        /// Sets a LayoutControlItem.ContentVisible to true
        /// </summary>
        /// <param name="item">LayoutControlItem</param>
        public static void ShowLayoutItem(LayoutControlItem item)
        {
            item.ContentVisible = true;
        }

        /// <summary>
        /// Sets LayoutControlItem and LayoutItemControl text to a blank string.
        /// </summary>
        /// <param name="item"></param>
        public static void ClearLayoutItemText(LayoutControlItem item)
        {
            item.Text = "";
            item.Control.Text = "";
        }

        /// <summary>
        /// Process <cref>LayoutControlItem</cref> delegate signature
        /// </summary>
        /// <param name="layoutControlItem"></param>
        public delegate void ProcessLayoutItem(
            LayoutControlItem layoutControlItem);


        /// <summary>
        /// Calls the delegate on each of the layout control items in the list
        /// </summary>
        /// <param name="process">The method to be called for each list item</param>
        /// <param name="items">List of layout control items to process</param>
        public static void ProcessLayoutItems(ProcessLayoutItem process, 
            IEnumerable<LayoutControlItem> items)
        {
            foreach (LayoutControlItem item in items)
            {
                process(item);
            }
        }        
    }
}
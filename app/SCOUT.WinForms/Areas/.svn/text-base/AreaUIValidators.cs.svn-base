using System;
using System.Collections;
using SCOUT.Core.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;

namespace SCOUT.WinForms
{
    public static class AreaUIValidators
    {

        public static void ValidateRow(object sender, ValidateRowEventArgs e, GridControl grid)
        {
            ColumnView currentView = (ColumnView)sender;

            e.Valid = (
                IsNotDuplicateAreaLabel(currentView, e) && 
                IsNotPreProcessAreaAndLocatorControlled(currentView, e) &&
                SectionHasBays(currentView,e) &&
                BayHasShelves(currentView,e)
                );            
        } 
       
        private static bool IsNotDuplicateAreaLabel(ColumnView currentView, ValidateRowEventArgs e)
        {            
            IEnumerable dataSource = currentView.DataSource as IEnumerable;

            if (dataSource != null)
            {
                Area area = e.Row as Area;

                if (area != null)
                {
                    GridColumn colLabel = currentView.Columns["Labels"];

                    // Check section does not exist at a site level
                    if(area.GetType() == typeof(Section))
                    {
                        return IsNotDuplicateSectionWithinSite(currentView, (Section)area, colLabel);
                    }

                    // Otherwise area does not exist based on FullLocation
                    foreach (Area a in dataSource)
                    {
                        if (string.Equals(a.FullLocation,
                                        area.FullLocation,
                                        StringComparison.CurrentCultureIgnoreCase) &&
                            a.Id != area.Id)
                        {                            
                            currentView.SetColumnError(colLabel, "Area " + area.Label + " already exists");
                            return false;
                        }
                    } //foreach
                } // if(area!=null)
            } //if(datasource!=null)

            return true;            
        }

        private static bool IsNotDuplicateSectionWithinSite(ColumnView currentView, Section section, GridColumn column)
        {
            Site site = Site.Current;

            foreach(Shopfloorline sfl in site.ShopfloorLines)
            {
                foreach (Domain domain in sfl.Domains)
                {
                    foreach (Section currentSection in domain.Sections)
                    {
                        if(currentSection.Label.Equals(section.Label))
                        {
                            currentView.SetColumnError(column,"Section " + section.Label + " already exists for site: " + site.Label);
                            return false;
                        }                        
                    }                    
                }
            }

            return true;            
        }

        private static bool IsNotPreProcessAreaAndLocatorControlled(ColumnView currentView, ValidateRowEventArgs e)
        {
            //Domain domain = e.Row as Domain;

            //if(domain != null)
            //{
            //    if(domain.LocatorControlled && domain.IsPreProcessArea)
            //    {
            //        GridColumn col = currentView.Columns["IsPreProcessArea"];
            //        currentView.SetColumnError(col,"A domain cannot be locator controlled and a pre process area");
            //        return false;
            //    }
            //}

            return true;                       
        }

        private static bool SectionHasBays(ColumnView currentView, ValidateRowEventArgs e)
        {
            Section section = e.Row as Section;

            if(section !=null)
            {
                if(section.Bays.Count == 0)
                {
                    GridColumn col = currentView.Columns["Label!"];
                    currentView.SetColumnError(col, "Sections must have bays defined");
                    return false;
                }                
            }

            return true;
        }

        private static bool BayHasShelves(ColumnView currentView, ValidateRowEventArgs e)
        {
            Bay bay = e.Row as Bay;

            if(bay != null)
            {
                if(bay.Shelves.Count == 0)
                {
                    GridColumn col = currentView.Columns["Label!"];
                    currentView.SetColumnError(col, "Bays must have shelves defined");
                    return false;
                }
            }

            return true;
        }
    }
}
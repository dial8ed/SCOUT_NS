using System.Collections.Generic;
using DevExpress.Data.Filtering;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Service
{
    public class RouteBuilderController
    {
        private ServiceRoute m_route;

        public RouteBuilderController(ServiceRoute route)
        {
            m_route = route;
        }

        public void GenerateStations(Shopfloorline shopfloorline)
        {   
             //Create a new route if the user is switching shopfloorlines
            //if(m_route.Stations.Count > 0)
            //        m_route= new ServiceRoute(shopfloorline.Session);            

            // Add the stations to the route via a mapper
            m_route.AddStations(ServiceStationsForShopfloorline(shopfloorline));            
        }

        public ICollection<ServiceStation> ServiceStationsForShopfloorline(Shopfloorline shopfloorline)
        {
            GroupOperator criteria = new GroupOperator(
                    new CriteriaOperator[]
                        {
                              new BinaryOperator("Shopfloorline", shopfloorline),
                              new BinaryOperator("Active", true)
                        });

            return Scout.Core.Data
                    .GetList<ServiceStation>(m_route.Session)
                    .ByCriteria(criteria);
                      
        }
    }
}
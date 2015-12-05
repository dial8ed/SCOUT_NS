using System.Drawing;
using System.Drawing.Imaging;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("station_inspection_task_results"), MapInheritance(MapInheritanceType.OwnTable)]
    public class StationInspectionTaskResult : StationTaskResult
    {                
        private RouteStationStep m_step;
        private string m_damageType;
        private string m_damageMethod;        
        private byte[] m_imageData;        
               
        public StationInspectionTaskResult(Session session) : base(session)
        {
        }


        [Persistent("station_step_id")]
        public RouteStationStep Step
        {
            get { return m_step; }
            set { SetPropertyValue("Step", ref m_step, value); }
        }

        [Persistent("damage_type")]
        public string DamageType
        {
            get { return m_damageType; }
            set { SetPropertyValue("DamageType", ref m_damageType, value); }  
        }

        [Persistent("damage_method")]
        public string DamageMethod
        {
            get { return m_damageMethod; }
            set { SetPropertyValue("DamageMethod",ref m_damageMethod, value); }
        }

        [Persistent("image_data")]
        public byte[] ImageData
        {
            get { return m_imageData; }
            set
            {
                SetPropertyValue("ImageData", ref m_imageData, value);
            }
        }


        [NonPersistent]
        public Image Image
        {
            get
            {
                if (m_imageData != null)
                    return ImageService.ConvertByteArrayToImage(m_imageData,
                                                                ImageFormat.Jpeg);
                return null;
            }

            set
            {
                if (value != null)
                    ImageData = ImageService.CovertImageToByteArray(value);
            }
        }

        protected override void ValidateRules(BrokenRules Verify)
        {
            
        }
    }
}
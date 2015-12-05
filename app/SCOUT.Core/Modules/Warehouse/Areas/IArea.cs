namespace SCOUT.Core.Data
{
    public interface IArea
    {
        //[Persistent("area_label")]
        string Label { get; set; }

        //[Persistent("status_id")]
        AreaStatus Status { get; set; }

        string AreaType { get; }

        //[Persistent("area_full_location")]
        string FullLocation { get; set; // do nothing 
        }
        
        bool Equals(Area other);

        string ToString();

        int Id { get; set;}
    }
}
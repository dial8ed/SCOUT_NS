using System;

namespace SCOUT.Core.Data
{
    public interface IStationTask
    {
        Guid Id {get;}
        string Description { get; }
        string Category { get; }
        StationTaskOutcome Outcome { get;}
        bool IsRequired { get; }
    }
}